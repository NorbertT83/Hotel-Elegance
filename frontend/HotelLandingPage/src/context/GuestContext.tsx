import { createContext, useState, useContext, useEffect, useCallback } from 'react';
import { CateringType, Guest, Room, RoomType } from '../types/booking';
import { getData, createData, apiServiceConfig, tryToRefreshToken } from '../services/apiService';
import { parseJwt } from '../utils/utils';

type Props = {
    children: React.ReactNode;
};

export type LoginResult = 
    | { success: true } 
    | { success: false; errorType: 'noMatchingEmailOrBooking' | 'bookingExpired' | 'network' | string };

type GuestContextType = {
    guest: Guest | null;
    currentBooking: BookingContextType | null;
    currentRoom: Room | null;
    isLoading: boolean;
    accessToken: string | null;
    setAccessToken: (token: string | null) => void;
    login: (email: string, bookingIdAsPassword: string) => Promise<LoginResult>;
    logout: () => void;
};

type BookingResponseDTO = {
    id: string;
    room_number: number;
    room_type: RoomType;
    guest1_id: number;
    beginning_of_stay: string;
    end_of_stay: string;
    checkin: string | null;
    checkout: string | null;
    catering_level: CateringType;
}

type BookingContextType = {
    id: string,
    roomNumber: Room['room_number'],
    roomType: RoomType,
    guestId: Guest['id'],
    arrivalDate: Date,
    departureDate: Date,
    checkin: Date | null,
    checkout: Date | null,
    cateringChosen: CateringType,
}

export const mapBookingDTOToState = (dto: BookingResponseDTO): BookingContextType => {
    return {
        id: dto.id,
        roomNumber: dto.room_number,
        roomType: dto.room_type,
        guestId: dto.guest1_id,
        arrivalDate: new Date(dto.beginning_of_stay),
        departureDate: new Date(dto.end_of_stay),
        checkin: dto.checkin ? new Date(dto.checkin) : null,
        checkout: dto.checkout ? new Date(dto.checkout) : null,
        cateringChosen: dto.catering_level
    };
};

const GuestContext = createContext<GuestContextType | null>(null);

export const GuestProvider = ({ children }: Props) => {
    const [guest, setGuest] = useState<Guest | null>(null);
    const [currentBooking, setCurrentBooking] = useState<BookingContextType | null>(null);
    const [currentRoom, setCurrentRoom] = useState<Room | null>(null);
    const [isLoading, setIsLoading] = useState(true);
    const [accessToken, setAccessToken] = useState<string | null>(null);

    const logout = useCallback(() => {
        setGuest(null);
        setAccessToken(null);
        setCurrentBooking(null);
        setCurrentRoom(null);
    }, []);

    useEffect(() => {
        apiServiceConfig.setLogoutCallback(logout);
        apiServiceConfig.setTokenRefreshCallback((newToken) => {
            setAccessToken(newToken);
        });
    }, [logout]);

    useEffect(() => {
        apiServiceConfig.setToken(accessToken);
    }, [accessToken]);

    const hydrateAppState = useCallback(async (token: string) => {
        const payload = parseJwt(token);
        if (!payload) {
            logout();
            return false;
        }

        try {
            const guestResponse: Guest = await getData(`guest/${payload.guest_id}`);
            if (!guestResponse) {
                logout();
                return false;
            }

            const bookingResponse: BookingResponseDTO = await getData(`booking/${payload.booking_id}`);
            if (!bookingResponse) {
                logout();
                return false;
            }

            const activeBooking: BookingContextType = mapBookingDTOToState(bookingResponse);
            let roomData: Room | null = null;

            if (activeBooking.roomNumber) {
                roomData = await getData(`room/${activeBooking.roomNumber}`);
            }

            setGuest({ ...guestResponse, role: "guest" });
            setCurrentBooking(activeBooking);
            setCurrentRoom(roomData);
            return true;

        } catch (error) {
            console.error("Hiba az adatok hidratálása során:", error);
            logout();
            return false;
        }
    }, [logout]);

    useEffect(() => {
        const initGuest = async () => {
            setIsLoading(true);
            try {
                const token = await tryToRefreshToken();
                
                if (token) {
                    setAccessToken(token);
                    await hydrateAppState(token);
                } else {
                    logout();
                }
            } catch (error) {
                logout();
            } finally {
                setIsLoading(false);
            }
        };

        initGuest();
    }, [hydrateAppState, logout]);

    async function login(email: string, bookingIdAsPassword: string): Promise<LoginResult> {
        setIsLoading(true);
        try {
            const res = await createData<{ email: string; booking_id: string }, { success: boolean; accessToken?: string; errorType?: string }>(
                'auth/login', 
                { email, booking_id: bookingIdAsPassword }
            );

            if (res.success && res.accessToken) {
                setAccessToken(res.accessToken);
                
                const success = await hydrateAppState(res.accessToken);
                if (success) {
                    return { success: true };
                }
            }
            
            return { success: false, errorType: res.errorType || 'noMatchingEmailOrBooking' };

        } catch (error) {
            console.error("Hiba a bejelentkezés során:", error);
            return { success: false, errorType: "network" };
        } finally {
            setIsLoading(false);
        }
    }

    return (
        <GuestContext.Provider value={{ guest, accessToken, setAccessToken, currentBooking, currentRoom, isLoading, login, logout }}>
            {children}
        </GuestContext.Provider>
    );
};

export const useGuest = () => {
    const context = useContext(GuestContext);
    if (!context) {
        throw new Error("useGuest must be used within a GuestProvider");
    }
    return context;
};