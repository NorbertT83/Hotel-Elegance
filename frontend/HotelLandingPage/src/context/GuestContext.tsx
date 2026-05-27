import { createContext, useState, useContext, useEffect } from 'react';
import { Guest } from '../types/booking';
import { getData } from '../api/apiService';

type Props = {
    children: React.ReactNode;
};

type GuestContextType = {
    guest: Guest | null;
    isLoading: boolean;
    login: (username: string, password: string) => Promise<void>;
    logout: () => void;
};

const GuestContext = createContext<GuestContextType | null>(null);

export const GuestProvider = ({ children }: Props) => {
    const [guest, setGuest] = useState<Guest | null>(null);
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
        <GuestContext.Provider value={{ guest, isLoading, login, logout }}>
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