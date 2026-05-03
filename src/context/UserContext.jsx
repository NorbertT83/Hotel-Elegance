import React, { createContext, useState, useContext } from 'react';

const UserContext = createContext();

export const UserProvider = ({ children }) => {
    const [loggedInUser, setLoggedInUser] = useState(null);
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
        setLoggedInUser(mockUser);
        setIsLoading(false);
        }, 1000);
    };

    const logout = () => {
        setLoggedInUser(null);
    };

    return (
        <UserContext.Provider value={{ loggedInUser, setLoggedInUser, login, logout, isLoading }}>
            {children}
        </UserContext.Provider>
    );
};

export const useUser = () => useContext(UserContext);