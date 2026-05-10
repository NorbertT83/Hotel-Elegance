import React, {createContext, useContext, useState, useEffect, useCallback} from 'react'
import { getData } from '../api/apiService'

const RoomContext = createContext();

export const RoomProvider = ({ children }) => {
    const [ rooms, setRooms ] = useState([]);
    const [ loading, setLoading ] = useState(false);
    const [ error, setError ] = useState(null);

    const fetchRooms = useCallback(async (roomNumber = "") => {
        setLoading(true);
        try {
            const data = await getData(`room/${roomNumber ? roomNumber : "all"}`);
            setRooms(data);
            console.log(data);
        } catch (err) {
            setError(err.message);
            throw err;
        } finally {
            setLoading(false);
        }
    }, []);

    useEffect(() => {
        fetchRooms()
    }, [fetchRooms]);

    return (
        <RoomContext.Provider value={{ rooms, setRooms, loading, error, refreshRooms: fetchRooms }}>
            {children}
        </RoomContext.Provider>
    );
}

export const useRooms = () => useContext(RoomContext);