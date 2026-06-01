import { createContext, useState, useContext, useEffect } from 'react';
import { CateringType, Guest, Room, RoomType } from '../types/booking';
import { getData } from '../api/apiService';

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
    
    useEffect(() => {
        const initGuest = async () => {
            const savedGuestId = localStorage.getItem("guest_id");
            const savedBookingId = localStorage.getItem("booking_id");
            
            if (savedGuestId && savedBookingId) {
                try {
                    const guestResponse: Guest = await getData(`guest/${savedGuestId}`);
                    if (!guestResponse) return;

                    const result = await login(guestResponse.email, savedBookingId);
                    if (!result.success) {
                        logout();
                    }
                } catch (error) {
                    console.error("Nem sikerült a mentett vendég betöltése:", error);
                    logout();
                }
            }

            setIsLoading(false);
        };

        initGuest();
    }, []);

        async function fetchBookingAndRoom(bookingId: string) {
        setIsLoading(true);
        try {
            const bookingResponse: BookingResponseDTO = await getData(`booking/${bookingId}`);

            if (bookingResponse) {
                const activeBooking: BookingContextType = mapBookingDTOToState(bookingResponse);

                if (activeBooking.roomNumber) {
                    const roomData: Room = await getData(`room/${activeBooking.roomNumber}`);
                    return { fetchedBooking: activeBooking, fetchedRoom: roomData };
                }
                return null;
            }
        } catch (error) {
            console.error("Hiba a foglalási adatok lekérése közben:", error);
            return null;
        } finally {
            setIsLoading(false);
        }
    };

    async function login(email: string, bookingIdAsPassword: string): Promise<LoginResult> {
        setIsLoading(true);
        try {
            const guestResponse: Guest[] = await getData('guest', {email});

            if (!guestResponse) {
                return {success: false, errorType: 'noMatchingEmailOrBooking'};
            }
            const guestData = guestResponse[0];
            guestData.role = "guest";

            const result = await fetchBookingAndRoom(bookingIdAsPassword);

            if (!result) return { success: false, errorType: 'noMatchingEmailOrBooking' };

            const {fetchedBooking, fetchedRoom} = result;

            if (fetchedBooking.id !== bookingIdAsPassword || fetchedBooking.guestId !== guestData.id) {
                return { success: false, errorType: 'noMatchingEmailOrBooking' };
            }

            if (fetchedBooking.checkout || fetchedBooking.departureDate < new Date())
                return { success: false, errorType: 'bookingExpired' };

            setGuest(guestData);
            setCurrentBooking(fetchedBooking);
            setCurrentRoom(fetchedRoom);
            localStorage.setItem("guest_id", String(guestData.id));
            localStorage.setItem('booking_id', fetchedBooking.id);
            return { success: true };
        } catch (error) {
            console.error("Hiba a bejelentkezés során:", error);
            return { success: false, errorType: "network" };
        } finally {
            setIsLoading(false);
        }
    };

    const logout = () => {
        setGuest(null);
        setCurrentBooking(null);
        setCurrentRoom(null);
        localStorage.removeItem("guest_id");
        localStorage.removeItem("booking_id");
    };

    return (
        <GuestContext.Provider value={{ guest, currentBooking, currentRoom, isLoading, login, logout }}>
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