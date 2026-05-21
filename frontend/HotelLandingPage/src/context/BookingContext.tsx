import { createContext, useContext, useState, useEffect, ReactNode } from 'react';
import { RoomType, CateringType, FormData, Room, BookingState } from '../types/booking';
import { useLocation, useNavigate } from 'react-router-dom';

interface BookingContextProps {
    step: number;
    arrivalDate: string;
    departureDate: string;
    guests: { adult: number; child: number };
    freeRooms: Room[];
    roomTypeChosen: RoomType;
    cateringChosen: CateringType;
    extrasChosen: Record<string, boolean>;
    formData: FormData;
    isFormValid: boolean;
    setFreeRooms: (rooms: Room[]) => void;
    setRoomTypeChosen: (type: RoomType) => void;
    setCateringChosen: (type: CateringType) => void;
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

    useEffect(() => {
        if (!location.state) navigate("/");
    }, [location, navigate]);

    const state = (location.state as BookingState) || { freeRooms: [], guests: { adult: 2, child: 0 }, arrivalDate: "", departureDate: "" };

    const [step, setStep] = useState(1);
    const [roomTypeChosen, setRoomTypeChosen] = useState<RoomType>("standard");
    const [freeRooms, setFreeRooms] = useState<Room[]>(state.freeRooms);
    const [cateringChosen, setCateringChosen] = useState<CateringType>("breakfast");
    const [extrasChosen, setExtrasChosen] = useState<Record<string, boolean>>({});
    const [formData, setFormData] = useState<FormData>({
        lname: "", fname: "", email: "", country: "HU", zip: "", city: "", street: ""
    });
    const [isFormValid, setIsFormValid] = useState(false);

    const validate = {
        name: (val: string) => val.length > 2 && val.length <= 30 && /^[\p{L}\s-]+$/u.test(val),
        email: (val: string) => /^[^\s@]+@[^\s@]+\.[^\s@]+$/.test(val),
        zip: (val: string) => /^[a-zA-Z0-9\s-]{4,10}$/.test(val),
        city: (val: string) => val.length > 1 && /^[\p{L}\s-]+$/u.test(val),
        street: (val: string) => val.length > 4 && /^(?=.*\d).+$/.test(val)
    };

    useEffect(() => {
        const { lname, fname, email, zip, city, street } = formData;
        const isValid = validate.name(lname) && validate.name(fname) && validate.email(email) && validate.zip(zip) && validate.city(city) && validate.street(street);
        setIsFormValid(isValid);
    }, [formData]);
    
    const nextStep = () => setStep(p => p + 1);
    const prevStep = () => setStep(p => p - 1);
    
    const finishBooking = () => {
        console.log("Küldés API-nak...", { formData, roomType: roomTypeChosen, catering: cateringChosen, extrasChosen });
        setStep(5);
    };

    
    return (
        <BookingContext.Provider value={{
            step, roomTypeChosen, cateringChosen , extrasChosen, formData, isFormValid,
            freeRooms: state.freeRooms, arrivalDate: state.arrivalDate, departureDate: state.departureDate, guests: state.guests,
            setFreeRooms,setRoomTypeChosen,  setCateringChosen, nextStep, prevStep, finishBooking,
            handleCheckboxChange: (e) => setExtrasChosen(p => ({ ...p, [e.target.id]: e.target.checked })),
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