import s from '../styles/LoginPage.module.css'

import { useState } from 'react';
import { useNavigate } from 'react-router-dom'
import { useLanguage } from '../context/LanguageContext'
import { useGuest } from '../context/GuestContext';
import { guestPageText } from '../utils/translations';
import LanguangeSelector from '../components/LanguageSelector';

export default function LoginPage() {
    const { language } = useLanguage();
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');
    const { login } = useGuest();
    const navigate = useNavigate();

    const labels = guestPageText[language].loginPage


    const handleLogin = (e: React.SubmitEvent<HTMLFormElement>) => {
        e.preventDefault();
        if (email.trim()) {
            login(email, password);
        }
        navigate('/guest');
    };

    return (
        <div className={s.loginSection}>
            <LanguangeSelector />
            <h1 className={s.h1Text}>{labels.h1Text}</h1>
            <form className={s.loginForm} onSubmit={handleLogin}>
                <input 
                    className={s.inputField}
                    type="text" 
                    autoFocus
                    value={email} 
                    onChange={(e) => setEmail(e.target.value)}
                    placeholder={labels.emailPlaceholder}
                />
                <input 
                    className={s.inputField}
                    type="password"
                    value={password}
                    onChange={(e) => setPassword(e.target.value)}
                    placeholder={labels.passPlaceholder}
                />
                <button className='btn btn-primary' type="submit">{labels.buttonText}</button>
            </form>
        </div>
    );
};