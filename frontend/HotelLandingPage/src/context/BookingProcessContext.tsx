import { customAlphabet } from 'nanoid';
import { createContext, useContext, useState, useEffect, ReactNode, useMemo } from 'react';
import { Room, BookingState, ExtraOption } from '../types/booking';
import { useLocation, useNavigate } from 'react-router-dom';
import { createData, getData } from '../api/apiService';

interface BookingContextProps {
    step: number;
    bookingState: BookingState;
    filteredRooms: Room[];
    roomsForSelectedType: Room[];
    extraOptions: ExtraOption[];
    setBookingState: React.Dispatch<React.SetStateAction<BookingState>>;
    setFilteredRooms: React.Dispatch<React.SetStateAction<Room[]>>;
    handleCheckboxChange: (e: React.ChangeEvent<HTMLInputElement>) => void;
    handleInputChange: (e: React.ChangeEvent<HTMLInputElement | HTMLSelectElement>) => void;
    nextStep: () => void;
    prevStep: () => void;
    finishBooking: () => void;
    isFormValid: boolean;
}

const BookingProcessContext = createContext<BookingContextProps | undefined>(undefined);

const nanoid = customAlphabet('0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ', 4);

const validate = {
    name: (val: string) => val.length > 2 && val.length <= 30 && /^[\p{L}\s-]+$/u.test(val),
    email: (val: string) => /^[^\s@]+@[^\s@]+\.[^\s@]+$/.test(val),
    zip: (val: string) => /^[a-zA-Z0-9\s-]{4,10}$/.test(val),
    city: (val: string) => val.length > 1 && /^[\p{L}\s-]+$/u.test(val),
    street: (val: string) => val.length > 4 && /^(?=.*\d).+$/.test(val)
};

export function roomSupportsExtra(room: Room, option: ExtraOption): boolean {
    if (['latecheckout', 'transfer', 'champagne'].includes(option)) return true;
    if (option === 'balcony') return room.has_balcony === 1;
    if (option === 'garden') return room.has_view === 'garden';
    if (option === 'panorama') return room.has_view === 'panorama';
    return room.extras?.includes(option) ?? false;
};

export function BookingProcessProvider({ children }: { children: ReactNode }) {
    const location = useLocation();
    const navigate = useNavigate();

    useEffect(() => {
        if (!location.state) {
            navigate("/");
        }
    }, [location.state, navigate]);

    const [bookingState, setBookingState] = useState<BookingState>(() => {
        const defaultDefaults = {
            bookingId: "",
            freeRooms: [],
            guests: { adult: 2, child: 0 },
            arrivalDate: "",
            departureDate: "",
            roomTypeChosen: "standard",
            cateringChosen: "breakfast",
            extrasChosen: [],
            roomAssigned: {} as Room,
            formData: { lname: "", fname: "", email: "", country: "HU", zip: "", city: "", street: "" }
        };

        if (!location.state) return defaultDefaults as BookingState;

        const incomingState = location.state as Partial<BookingState>;

        return {
            ...defaultDefaults,
            ...incomingState,
            formData: {
                ...defaultDefaults.formData,
                ...(incomingState.formData || {})
            },
            guests: {
                ...defaultDefaults.guests,
                ...(incomingState.guests || {})
            }
        } as BookingState;
    });


    const [filteredRooms, setFilteredRooms] = useState<Room[]>(bookingState.freeRooms);
    const [step, setStep] = useState(1);

    const isFormValid = useMemo(() => {
        const { lname, fname, email, zip, city, street } = bookingState.formData;
        return (
            validate.name(lname) &&
            validate.name(fname) &&
            validate.email(email) &&
            validate.zip(zip) &&
            validate.city(city) &&
            validate.street(street)
        );
    }, [bookingState.formData.lname, bookingState.formData.fname, bookingState.formData.email, bookingState.formData.zip, bookingState.formData.city, bookingState.formData.street]);
    
    const roomsForSelectedType = useMemo(() => {
        return bookingState.freeRooms.filter(
            room => room.room_type === bookingState.roomTypeChosen
        );
    }, [bookingState.roomTypeChosen, bookingState.freeRooms]);

    const availableExtras = useMemo(() => {
        const keys: ExtraOption[] = ['balcony', 'garden', 'panorama', 'jacuzzi', 'kitchen'];
        const result: Record<string, boolean> = {};
        
        keys.forEach(key => {
            result[key] = roomsForSelectedType.some(r => roomSupportsExtra(r, key));
        });
        
        return result;
    }, [roomsForSelectedType]);

    const extraOptions = useMemo(() => {
        const baseOptions = ['latecheckout', 'transfer', 'champagne'] as ExtraOption[];
        
        const activeExtras = Object.keys(availableExtras).filter(
            (key) => availableExtras[key as keyof typeof availableExtras]
        );

        return [...baseOptions, ...activeExtras] as ExtraOption[];
    }, [availableExtras]);


    const nextStep = () => setStep(p => p + 1);
    const prevStep = () => setStep(p => p - 1);
    
    const finishBooking = async () => {
        console.log("Küldés API-nak...", { ...bookingState });
        
        // guest keresése, ha nincs, új guest létrehozása, majd booking létrehozása a guest ID-val
        let guestid;

        try {
            const existingGuestResponse: any[] = await getData('guest', { email: bookingState.formData.email });
            if (existingGuestResponse && existingGuestResponse.length > 0) {
                console.log("Létező vendég megtalálva:", existingGuestResponse[0]);
                guestid = existingGuestResponse[0].id;
            }
        } catch {
            try {
                const guestResponse = await createData('guest', {
                    fname: bookingState.formData.fname,
                    lname: bookingState.formData.lname,
                    email: bookingState.formData.email,
                    country: bookingState.formData.country,
                    zip_code: bookingState.formData.zip,
                    city: bookingState.formData.city,
                    street: bookingState.formData.street
                });
                if (!guestResponse || !guestResponse.id) {
                    console.error("Sikertelen foglalás: vendég létrehozása sikertelen");
                    return;
                }
                guestid = guestResponse.id;
            } catch (err: any){
                console.error(err.message);
                return;
            }
        }
        try {
            if (guestid && guestid != 0) {
                // Foglalási szám generálása (pl: HE-2026-A1B2)
                const year = new Date(bookingState.arrivalDate).getFullYear();
                setBookingState(prev => ({...prev, bookingId: `HE-${year}-${nanoid()}`}));

                const createBookingResponse = await createData('booking', {
                    id: bookingState.bookingId,
                    room_number: filteredRooms[0]?.room_number || null,
                    room_type: bookingState.roomTypeChosen,
                    guest1_id: guestid || null,
                    beginning_of_stay: bookingState.arrivalDate,
                    end_of_stay: bookingState.departureDate,
                    catering_level: bookingState.cateringChosen
                });
                if (!createBookingResponse || !createBookingResponse.id) {
                    console.error("Sikertelen foglalás: foglalás létrehozása sikertelen");
                    return;
                }
                console.log("Sikeres foglalás: ", createBookingResponse.id);
                setStep(5);
            }
        } catch (err: any){
            console.log(err.message);
        }
    };

    const handleCheckboxChange = (e: React.ChangeEvent<HTMLInputElement>) => {
        setBookingState(prev => ({
            ...prev,
            extrasChosen: prev.extrasChosen.includes(e.target.id as ExtraOption)
                ? prev.extrasChosen.filter(id => id !== e.target.id)
                : [...prev.extrasChosen, e.target.id as ExtraOption]
        }));
    };

    const handleInputChange = (e: React.ChangeEvent<HTMLInputElement | HTMLSelectElement>) => {
        const { name, value } = e.target;
        setBookingState(prev => ({
            ...prev,
            formData: {
                ...prev.formData,
                [name]: value
            }
        }));
    };

    return (
        <BookingProcessContext.Provider value={{
            step, 
            bookingState, 
            filteredRooms,
            roomsForSelectedType,
            extraOptions,
            setBookingState, 
            setFilteredRooms,
            nextStep, 
            prevStep, 
            finishBooking,
            isFormValid,
            handleCheckboxChange,
            handleInputChange
        }}>
            {children}
        </BookingProcessContext.Provider>
    );
}

export const useBooking = () => {
    const context = useContext(BookingProcessContext);
    if (!context) throw new Error("useBooking must be used within a BookingProvider");
    return context;
};