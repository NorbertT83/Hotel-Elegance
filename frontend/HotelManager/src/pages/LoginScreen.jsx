import s from '../styles/LoginScreen.module.css'

import { useState } from 'react';
import { useGlobal } from '../context/GlobalContext';
import { useUser } from '../context/UserContext';
import LanguangeSelector from '../components/LanguageSelector';

const LoginScreen = () => {
    const { language } = useGlobal();
    const [name, setName] = useState('');
    const [password, setPassword] = useState('');
    const { login } = useUser();

    const labels = {
        hu: {
            h1Text: "Bejelentkezés",
            userPlaceholder: "Felhasználónév...",
            passPlaceholder: "Jelszó...",
            buttonText: "Belépés"
        },
        en: {
            h1Text: "Authentication",
            userPlaceholder: "Username...",
            passPlaceholder: "Password...",
            buttonText: "Login"
        }
    }

    const handleLogin = (e) => {
        e.preventDefault();
        if (name.trim()) {
            login(name, password);
        }
    };

    return (
        <div className={s.container}>
            <LanguangeSelector />
            <h1 className={s.h1Text}>{labels[language].h1Text}</h1>
            <form className={s.loginForm} onSubmit={handleLogin}>
                <input 
                    className={s.inputField}
                    type="text" 
                    autoFocus
                    value={name} 
                    onChange={(e) => setName(e.target.value)}
                    placeholder={labels[language].userPlaceholder}
                />
                <input 
                    className={s.inputField}
                    type="password"
                    value={password}
                    onChange={(e) => setPassword(e.target.value)}
                    placeholder={labels[language].passPlaceholder}
                />
                <button className='btn-primary' type="submit">{labels[language].buttonText}</button>
            </form>
        </div>
    );
};

export default LoginScreen;