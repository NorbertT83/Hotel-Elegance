import { useEffect, useState, type Dispatch, type SetStateAction } from 'react';

function safeParse<T>(value: string | null, defaultValue: T): T {
    if (value === null) return defaultValue;
    try {
        return JSON.parse(value) as T;
    } catch {
        return defaultValue;
    }
}

export function useLocalStorageState<T>(key: string, defaultValue: T): [T, Dispatch<SetStateAction<T>>] {
    const [storedValue, setStoredValue] = useState<T>(() => {
        if (typeof window === 'undefined') return defaultValue;

        try {
            const item = localStorage.getItem(key);
            return safeParse(item, defaultValue);
        } catch {
            return defaultValue;
        }
    });

    useEffect(() => {
        try {
            localStorage.setItem(key, JSON.stringify(storedValue));
        } catch {
            // ignore write errors
        }
    }, [key, storedValue]);

    return [storedValue, setStoredValue];
}
