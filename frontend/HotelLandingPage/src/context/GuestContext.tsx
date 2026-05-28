import { createContext, useState, useContext, useEffect } from 'react';
import { BookingState, CateringType, Guest, Room, RoomType } from '../types/booking';
import { getData } from '../api/apiService';

type Props = {
    children: React.ReactNode;
};


type GuestContextType = {
    guest: Guest | null;
    currentBooking: BookingContextType | null;
    currentRoom: Room | null;
    isLoading: boolean;
    login: (email: string, password: string) => Promise<void>;
    logout: () => void;
};

type BookingResponseDTO = {
    id: number;
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
    id: number,
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
    
    async function fetchGuestById(id: string) {
        const guest: Guest = await getData(`guest/${id}`);
        guest.role = "guest";
        return guest
    };

    async function fetchGuestByEmail(email: string) {
        const data: Guest[] = await getData('guest', {email});
        const guest = data[0];
        guest.role = "guest";
        return guest
    }

    useEffect(() => {
        const initGuest = async () => {
            const savedId = localStorage.getItem("guest_id");
            
            if (savedId) {
                try {
                    const user = await fetchGuestById(savedId);
                    setGuest(user);
                } catch (error) {
                    console.error("Nem sikerült a vendég betöltése:", error);
                    localStorage.removeItem("guest_id");
                }
            }

            setIsLoading(false);
        };

        initGuest();
    }, []);


    useEffect(() => {
        const fetchBookingAndRoom = async () => {
            if (!guest) {
                setCurrentBooking(null);
                setCurrentRoom(null);
                return;
            }

            setIsLoading(true);
            try {
                const bookingData: BookingResponseDTO[] = await getData('booking', {"guest1_id": String(guest.id) });
                
                if (bookingData && bookingData.length > 0) {
                    const activeBooking: BookingContextType = mapBookingDTOToState(bookingData[0]);
                    setCurrentBooking(activeBooking);
                    console.log(activeBooking);

                    if (activeBooking.roomNumber) {
                        const roomData: Room = await getData(`room/${activeBooking.roomNumber}`);
                        setCurrentRoom(roomData);
                        console.log(roomData);
                    }
                }
            } catch (error) {
                console.error("Hiba a foglalási adatok lekérése közben:", error);
            } finally {
                setIsLoading(false);
            }
        };

        fetchBookingAndRoom();
    }, [guest]);


    
    async function login(email: string, password: string) {
        setIsLoading(true);
        const newUser = await fetchGuestByEmail(email);
        setGuest(newUser); 
        localStorage.setItem("guest_id", String(newUser.id));
        setIsLoading(false);
    };

    const logout = () => {
        setGuest(null);
        localStorage.removeItem("guest_id");
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