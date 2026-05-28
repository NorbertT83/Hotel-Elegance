import s from '../styles/LoginPage.module.css'

import { useState } from 'react';
import { useNavigate } from 'react-router-dom'
import { useLanguage } from '../context/LanguageContext'
import { useGuest } from '../context/GuestContext';
import { guestPageText } from '../utils/translations';
import LanguageSelector from '../components/LanguageSelector';

export default function LoginPage() {
    const { language } = useLanguage();
    const [email, setEmail] = useState('');
    const [bookingId2ndHalf, setBookingId2ndHalf] = useState('');
    const { login } = useGuest();
    const navigate = useNavigate();

    const labels = guestPageText[language].loginPage

    const bookingId1stHalf = `HE-${new Date().getFullYear()}-`;

    const handleLogin = (e: React.SubmitEvent<HTMLFormElement>) => {
        e.preventDefault();
        if (email.trim()) {
            login(email, `${bookingId1stHalf}${bookingId2ndHalf}`);
        }
        navigate('/guest');
    };

    return (
        <div className={s.loginSection}>
            <LanguageSelector />
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
                <div>
                    <strong>{bookingId1stHalf}</strong>
                    <input 
                        className={s.inputField}
                        type="password"
                        maxLength={4}
                        value={bookingId2ndHalf}
                        onChange={(e) => setBookingId2ndHalf(e.target.value)}
                        placeholder={labels.passPlaceholder}
                    />
                </div>
                <button className='btn btn-primary' type="submit">{labels.buttonText}</button>
            </form>
        </div>
    );
};