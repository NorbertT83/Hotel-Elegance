import s from '../styles/LoginPage.module.css'

import { useState } from 'react';
import { useNavigate } from 'react-router-dom'
import { useLanguage } from '../context/LanguageContext'
import { useGuest } from '../context/GuestContext';
import { guestPageText } from '../utils/translations';
import LanguageSelector from '../components/LanguageSelector';

export default function GuestLoginPage() {
    const { language } = useLanguage();
    const [email, setEmail] = useState('');
    const [bookingId1stHalf, setBookingId1stHalf] = useState('');
    const [bookingId2ndHalf, setBookingId2ndHalf] = useState('');
    const [error, setError] = useState<ErrorKey | null>(null);
    const { login } = useGuest();
    const navigate = useNavigate();

    type ErrorKey = 'allFieldsRequired' | 'onlyNumbers' | 'noMatchingEmailOrBooking' | 'bookingExpired' | 'network';

    const labels = guestPageText[language].loginPage;

    async function handleLogin(e: React.SubmitEvent<HTMLFormElement>) {
        e.preventDefault();
        if (email.trim() && bookingId1stHalf.trim() && bookingId2ndHalf.trim()) {
            const result = await login(email.trim(), `HE-${bookingId1stHalf}-${bookingId2ndHalf}`);

            if (!result.success) {
                setError(result.errorType as ErrorKey);
                return;
            }
        } else {
            setError('allFieldsRequired');
            return;
        }
        
        navigate('/guest');
    };


    function handleYearInput(value: string) {
        if (value === '' || /^\d+$/.test(value)) {
            setBookingId1stHalf(value);
            setError(null);
        } else {
            setError('onlyNumbers');
        }
    }

    return (
        <div className={s.loginSection}>
            <LanguageSelector />
            <h1 className={s.h1Text}>{labels.h1Text}</h1>
            <form className={s.loginForm} onSubmit={handleLogin}>
                <input 
                    className={s.inputField}
                    type="text" 
                    required
                    autoFocus
                    value={email} 
                    onChange={(e) => setEmail(e.target.value)}
                    onFocus={() => setError(null)}
                    placeholder={labels.emailPlaceholder}
                    />
                <div>
                    <strong>HE -</strong>

                    <input 
                        className={s.inputField}
                        type="text"
                        minLength={4}
                        maxLength={4}
                        required
                        value={bookingId1stHalf}
                        onChange={(e) => handleYearInput(e.target.value)}
                        onFocus={() => setError(null)}
                        placeholder='20xx'
                        />-
                    <input 
                        className={s.inputField}
                        type="password"
                        minLength={4}
                        maxLength={4}
                        required
                        value={bookingId2ndHalf}
                        onChange={(e) => setBookingId2ndHalf(e.target.value)}
                        onFocus={() => setError(null)}
                        placeholder={labels.passPlaceholder}
                        />
                </div>
                <button className='btn btn-primary' type="submit">{labels.buttonText}</button>
            </form>
            {error && <div className={s.errorMessage}><span className="material-symbols-outlined">error</span>{labels.errorMessages[error]}</div>}
        </div>
    );
};