import {useState, useEffect, createContext, useContext} from 'react';

type Props = {
    children: React.ReactNode;
};

export type Language = 'hu' | 'en';

type LanguageContextType = {
    language: Language;
    setLanguage: React.Dispatch<React.SetStateAction<Language>>;
};

const LanguageContext = createContext<LanguageContextType | null>(null);



export const LanguageProvider = ({children}: Props) => {
    const [language, setLanguage] = useState<Language>(() => {
        const stored = localStorage.getItem('language');
        return stored === 'en' ? 'en' : 'hu';
    });

    useEffect(() => {
        localStorage.setItem('language', language);
    }, [language]);

        return (
        <LanguageContext.Provider value={{ language, setLanguage }}>
            {children}
        </LanguageContext.Provider>
    );
}

export const useLanguage = () => {
    const context = useContext(LanguageContext);

    if (!context) {
        throw new Error('useLanguage must be used within LanguageProvider');
    }
    
    return context;
};