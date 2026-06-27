import React, {createContext, useContext, useState, useEffect} from 'react';

const GlobalContext = createContext();

export const GlobalProvider = ({ children }) => {
    const [language, setLanguage] = useState(localStorage.getItem('language') || 'hu');
    const [theme, setTheme]  = useState(localStorage.getItem('theme') || 'light');

    useEffect(() => {
        localStorage.setItem('language', language);
    }, [language]);

    useEffect(() => {
        localStorage.setItem('theme', theme);
    }, [theme]);

    return (
        <GlobalContext.Provider value={{ language, setLanguage, theme, setTheme }}>
            {children}
        </GlobalContext.Provider>
    );
};

export const useGlobal = () => useContext(GlobalContext);