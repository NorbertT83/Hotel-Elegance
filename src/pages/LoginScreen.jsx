import React, { useState } from 'react';
import { useUser } from '../context/UserContext';

const LoginScreen = () => {
    const [name, setName] = useState('');
    const { login } = useUser();

    const handleLogin = (e) => {
        e.preventDefault();
        if (name.trim()) {
            login(name, "password123");
        }
    };

    return (
        <div style={{ textAlign: 'center', marginTop: '50px' }}>
            <h1>Bejelentkezés</h1>
            <form onSubmit={handleLogin}>
                <input 
                    type="text" 
                    value={name} 
                    onChange={(e) => setName(e.target.value)} 
                    placeholder="Felhasználónév"
                />
                <button type="submit">Belépés</button>
            </form>
        </div>
    );
};

export default LoginScreen;