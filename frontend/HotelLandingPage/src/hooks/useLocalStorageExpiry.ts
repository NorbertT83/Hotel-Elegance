import { useState } from "react";

interface StoredItem<T> {
    value: T;
    expiry: number;
}

export function useLocalStorageExpiry<T>(key: string, defaultValue: T, ttlInMs: number): [T, (value: T) => void] {
    const [storedValue, setStoredValue] = useState<T>(() => {
        try {
            const itemStr = localStorage.getItem(key);
            
            if (!itemStr) return defaultValue;

            const item: StoredItem<T> = JSON.parse(itemStr);
            const now = new Date().getTime();

            if (now > item.expiry) {
                localStorage.removeItem(key);
                return defaultValue;
            }

            return item.value;
        } catch (error) {
            console.error("LocalStorage beolvasási hiba:", error);
            return defaultValue;
        }
    });

    const setValue = (value: T) => {
        try {
            const now = new Date();
            const item: StoredItem<T> = {
                value: value,
                expiry: now.getTime() + ttlInMs,
            };
            
            setStoredValue(value);
            localStorage.setItem(key, JSON.stringify(item));
        } catch (error) {
            console.error("LocalStorage mentési hiba:", error);
        }
    };

    return [storedValue, setValue];
}