import React, { createContext, useState, useContext } from 'react';

const UserContext = createContext();

export const UserProvider = ({ children }) => {
    const [user, setUser] = useState(null);
    const [isLoading, setIsLoading] = useState(false);

    // Szimulált bejelentkezési folyamat
    const login = async (username, password) => {
        setIsLoading(true);
        
        setTimeout(() => {
        const mockUser = {
            id: "u123",
            name: username,
            email: `${username.toLowerCase()}@example.hu`,
            role: "admin",
            lang: "hu"
        };
        setUser(mockUser);
        setIsLoading(false);
        }, 1000);
    };

    const logout = () => {
        setUser(null);
    };

    return (
        <UserContext.Provider value={{ user, setUser, login, logout, isLoading }}>
            {children}
        </UserContext.Provider>
    );
};

export const useUser = () => useContext(UserContext);