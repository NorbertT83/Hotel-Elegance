import { createContext, useContext, useState, useEffect, ReactNode } from 'react';
import { RoomType, CateringType, FormData, Room, BookingState } from '../types/booking';
import { useLocation, useNavigate } from 'react-router-dom';

interface BookingContextProps {
    step: number;
    arrivalDate: string;
    departureDate: string;
    guests: { adult: number; child: number };
    freeRooms: Room[];
    roomType: RoomType;
    catering: CateringType;
    extras: Record<string, boolean>;
    formData: FormData;
    isFormValid: boolean;
    setRoomType: (type: RoomType) => void;
    setCatering: (type: CateringType) => void;
    handleCheckboxChange: (e: React.ChangeEvent<HTMLInputElement>) => void;
    handleInputChange: (e: React.ChangeEvent<HTMLInputElement | HTMLSelectElement>) => void;
    nextStep: () => void;
    prevStep: () => void;
    finishBooking: () => void;
}

const BookingContext = createContext<BookingContextProps | undefined>(undefined);

export function BookingProvider({ children }: { children: ReactNode }) {
    const location = useLocation();
    const navigate = useNavigate();

    // Ha nincs state, visszadobjuk a főoldalra
    useEffect(() => {
        if (!location.state) navigate("/");
    }, [location, navigate]);

    const state = (location.state as BookingState) || { freeRooms: [], guests: { adult: 2, child: 0 }, arrivalDate: "", departureDate: "" };

    const [step, setStep] = useState(1);
    const [roomType, setRoomType] = useState<RoomType>("standard");
    const [catering, setCatering] = useState<CateringType>("breakfast");
    const [extras, setExtras] = useState<Record<string, boolean>>({});
    const [formData, setFormData] = useState<FormData>({
        lname: "", fname: "", email: "", country: "HU", zip: "", city: "", street: ""
    });
    const [isFormValid, setIsFormValid] = useState(false);

    // Ide jön a korábbi validate objektum és az useEffect a form validálásra...
    
    const nextStep = () => setStep(p => p + 1);
    const prevStep = () => setStep(p => p - 1);
    
    const finishBooking = () => {
        console.log("Küldés API-nak...", { formData, roomType, catering, extras });
        setStep(5);
    };

    return (
        <BookingContext.Provider value={{
            step, roomType, catering, extras, formData, isFormValid,
            freeRooms: state.freeRooms, arrivalDate: state.arrivalDate, departureDate: state.departureDate, guests: state.guests,
            setRoomType, setCatering, nextStep, prevStep, finishBooking,
            handleCheckboxChange: (e) => setExtras(p => ({ ...p, [e.target.id]: e.target.checked })),
            handleInputChange: (e) => setFormData(p => ({ ...p, [e.target.name]: e.target.value }))
        }}>
            {children}
        </BookingContext.Provider>
    );
}

export const useBooking = () => {
    const context = useContext(BookingContext);
    if (!context) throw new Error("useBooking must be used within a BookingProvider");
    return context;
};