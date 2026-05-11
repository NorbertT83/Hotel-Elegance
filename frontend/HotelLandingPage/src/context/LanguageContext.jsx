import {useState, useEffect, createContext, useContext} from 'react';

const LanguageContext = createContext();

export const LanguageProvider = ({children}) => {
    const [language, setLanguage] = useState(localStorage.getItem('language') || 'hu');

    useEffect(() => {
        localStorage.setItem('language', language);
    }, [language]);

        return (
        <LanguageContext.Provider value={{ language, setLanguage }}>
            {children}
        </LanguageContext.Provider>
    );
}

export const useLanguage = () => useContext(LanguageContext);