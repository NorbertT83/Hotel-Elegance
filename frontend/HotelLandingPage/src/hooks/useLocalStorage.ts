import { useEffect, useState, type Dispatch, type SetStateAction } from 'react';

export function useLocalStorageState<T = undefined>(
    key: string,
    defaultValue?: T,
): [T | undefined, Dispatch<SetStateAction<T | undefined>>] {
    const [storedValue, setStoredValue] = useState<T | undefined>(() => {
        if (typeof window === 'undefined') return defaultValue;

        try {
            const item = localStorage.getItem(key);
            if (item === null) return defaultValue;
            return JSON.parse(item) as T;
        } catch {
            return defaultValue;
        }
    });

    useEffect(() => {
        try {
            if (storedValue === undefined) {
                // if undefined, remove the key so absence can be detected
                localStorage.removeItem(key);
            } else {
                localStorage.setItem(key, JSON.stringify(storedValue));
            }
        } catch {
            // ignore write errors
        }
    }, [key, storedValue]);

    return [storedValue, setStoredValue];
}
