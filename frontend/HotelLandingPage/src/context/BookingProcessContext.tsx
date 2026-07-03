import { customAlphabet } from 'nanoid';
import { createContext, useContext, useState, useEffect, ReactNode, useMemo } from 'react';
import { Room, BookingState, ExtraOption } from '../types/booking';
import { useLocation, useNavigate } from 'react-router-dom';
import { createData } from '../services/apiService';
import { useGuest } from './GuestContext';
import countries from '../utils/countries';
import { PriceCatalog } from '../utils/utils';

interface BookingContextProps {
    step: number;
    bookingState: BookingState;
    filteredRooms: Room[];
    roomsForSelectedType: Room[];
    extraOptions: ExtraOption[];
    setBookingState: React.Dispatch<React.SetStateAction<BookingState>>;
    setFilteredRooms: React.Dispatch<React.SetStateAction<Room[]>>;
    updateBooking: (patch: Partial<BookingState>) => void;
    handleCheckboxChange: (e: React.ChangeEvent<HTMLInputElement>) => void;
    handleInputChange: (e: React.ChangeEvent<HTMLInputElement | HTMLSelectElement>) => void;
    nextStep: () => void;
    prevStep: () => void;
    finishBooking: () => void;
    pricing: PriceCatalog;
    setPricing: React.Dispatch<React.SetStateAction<PriceCatalog>>;
    isFormValid: {
        lname: boolean;
        fname: boolean;
        email: boolean;
        zip: boolean;
        city: boolean;
        street: boolean;
    };
}

const BookingProcessContext = createContext<BookingContextProps | undefined>(undefined);

const nanoid = customAlphabet('0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ', 4);

type BookingApiResponse = {
    success: boolean;
    booking_id?: string;
};

const validate = {
    name: (val: string) => val.length > 1 && val.length < 30 && /^[\p{L}\s-]+$/u.test(val),
    email: (val: string) => /^[^\s@]+@[^\s@]+\.[^\s@]+$/.test(val),
    zip: (val: string) => /^[a-zA-Z0-9\s-]{4,10}$/.test(val),
    city: (val: string) => val.length > 1 && /^[\p{L}\s-]+$/u.test(val),
    street: (val: string) => val.length > 4 && /^(?=.*\d).+$/.test(val)
};

function getDefaultBookingState(): BookingState {
    return {
        bookingId: "",
        freeRooms: [],
        guests: { adult: 2, child: 0 },
        arrivalDate: "",
        departureDate: "",
        roomTypeChosen: "standard",
        cateringChosen: "breakfast",
        extrasChosen: [],
        formData: {
            lname: { value: "", isTouched: false },
            fname: { value: "", isTouched: false },
            email: { value: "", isTouched: false },
            country: { value: "HU", isTouched: false },
            zip: { value: "", isTouched: false },
            city: { value: "", isTouched: false },
            street: { value: "", isTouched: false }
        }
    };
}

function buildBookingPayload(state: BookingState, roomNumber: number | null, bookingId: string) {
    return {
        fname: state.formData.fname.value,
        lname: state.formData.lname.value,
        email: state.formData.email.value,
        country: state.formData.country.value,
        zip_code: state.formData.zip.value,
        city: state.formData.city.value,
        street: state.formData.street.value,
        booking_id: bookingId,
        room_number: roomNumber,
        room_type: state.roomTypeChosen,
        beginning_of_stay: state.arrivalDate,
        end_of_stay: state.departureDate,
        catering_level: state.cateringChosen,
        services: state.extrasChosen || []
    };
}

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
        const defaultState = getDefaultBookingState();

        if (!location.state) return defaultState;

        const incomingState = location.state as Partial<BookingState>;
        return {
            ...defaultState,
            ...incomingState,
            formData: {
                ...defaultState.formData,
                ...(incomingState.formData || {})
            },
            guests: {
                ...defaultState.guests,
                ...(incomingState.guests || {})
            }
        } as BookingState;
    });


    const { guest } = useGuest();
    const [filteredRooms, setFilteredRooms] = useState<Room[]>(bookingState.freeRooms);
    const [step, setStep] = useState(1);
    const [pricing, setPricing] = useState<PriceCatalog>({
        flatFeeExtras: {},
        cateringServicePrices: { breakfast: 0 },
    });

    useEffect(() => {
        setFilteredRooms(bookingState.freeRooms);
    }, [bookingState.freeRooms]);

    useEffect(() => {
        if (!guest) return;

        setBookingState(prev => {
            const current = prev.formData;
            const guestCountryCode = countries.find(country => country.name.toLowerCase() === guest.country.toLowerCase())?.code ?? current.country.value;

            const updatedFormData = {
                lname: !current.lname.isTouched ? { ...current.lname, value: guest.lname } : current.lname,
                fname: !current.fname.isTouched ? { ...current.fname, value: guest.fname } : current.fname,
                email: !current.email.isTouched ? { ...current.email, value: guest.email } : current.email,
                country: !current.country.isTouched ? { ...current.country, value: guestCountryCode } : current.country,
                zip: !current.zip.isTouched ? { ...current.zip, value: guest.zip_code } : current.zip,
                city: !current.city.isTouched ? { ...current.city, value: guest.city } : current.city,
                street: !current.street.isTouched ? { ...current.street, value: guest.street } : current.street,
            };

            const hasChanges = Object.entries(updatedFormData).some(([key, field]) => field.value !== current[key as keyof typeof current].value);
            return hasChanges ? { ...prev, formData: updatedFormData } : prev;
        });
    }, [guest]);

    const updateBooking = (patch: Partial<BookingState>) => {
        setBookingState(prev => ({ ...prev, ...patch }));
    };

    const isFormValid = useMemo(() => {
        const { lname, fname, email, zip, city, street } = bookingState.formData;
        return ({
            lname: validate.name(lname.value),
            fname: validate.name(fname.value),
            email: validate.email(email.value),
            zip: validate.zip(zip.value),
            city: validate.city(city.value),
            street: validate.street(street.value)
        });
    }, [bookingState.formData.lname.value, bookingState.formData.fname.value, bookingState.formData.email.value, bookingState.formData.zip.value, bookingState.formData.city.value, bookingState.formData.street.value]);
    
    const roomsForSelectedType = useMemo(() => {
        return bookingState.freeRooms.filter(
            room => room.room_type === bookingState.roomTypeChosen
        );
    }, [bookingState.roomTypeChosen, bookingState.freeRooms]);

    const availableExtras = useMemo(() => {
        const keys: ExtraOption[] = ['balcony', 'garden', 'panorama', 'jacuzzi', 'kitchen'];
        const result: Record<ExtraOption, boolean> = {
            balcony: false,
            panorama: false,
            garden: false,
            jacuzzi: false,
            kitchen: false,
            latecheckout: false,
            transfer: false,
            champagne: false,
        };

        keys.forEach(key => {
            result[key] = roomsForSelectedType.some(r => roomSupportsExtra(r, key));
        });

        return result;
    }, [roomsForSelectedType]);

    const extraOptions = useMemo(() => {
        const baseOptions: ExtraOption[] = ['latecheckout', 'transfer', 'champagne'];
        const activeExtras = (Object.keys(availableExtras) as ExtraOption[]).filter(
            key => availableExtras[key]
        );

        return [...baseOptions, ...activeExtras];
    }, [availableExtras]);


    const nextStep = () => setStep(p => p + 1);
    const prevStep = () => setStep(p => p - 1);
    
    const finishBooking = async () => {
        const year = new Date(bookingState.arrivalDate).getFullYear();
        const generatedBookingId = `HE-${year}-${nanoid()}`;
        const payload = buildBookingPayload(bookingState, filteredRooms[0]?.room_number ?? null, generatedBookingId);

        try {
            const response = await createData<typeof payload, BookingApiResponse>('auth/public-booking', payload);

            if (response.success) {
                setBookingState(prev => ({ ...prev, bookingId: generatedBookingId }));
                setStep(5);
            } else {
                console.error("Sikertelen foglalás: Nem érkezett sikeres válasz a szervertől.");
            }
        } catch (err) {
            console.error("Hiba történt a foglalási folyamat során:", err);
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
        const value = e.target.value;
        const name = e.target.name as keyof typeof bookingState.formData;

        setBookingState(prev => ({
            ...prev,
            formData: {
                ...prev.formData,
                [name]: { ...prev.formData[name], value, isTouched: true }
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
            updateBooking,
            nextStep, 
            prevStep, 
            finishBooking,
            pricing,
            setPricing,
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