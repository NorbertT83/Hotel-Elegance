import { useEffect, useState, CSSProperties } from 'react';
import { Link } from 'react-router-dom';
import { useLocalStorageExpiry } from "../hooks/useLocalStorageExpiry";
import { useGuest } from '../context/GuestContext';
import { landingPageText } from '../utils/translations';
import { useLanguage } from '../context/LanguageContext';

export default function WelcomeModal(): React.JSX.Element | null {
    const [isAtHotel, setIsAtHotel] = useState(false);
    const {language} = useLanguage();
    const [showWelcomeModal, setShowWelcomeModal] = useLocalStorageExpiry<boolean>(
        "showWelcomeModal",
        true,
        120_000 // 2 hours
    );
    const { guest } = useGuest();
    const labels = landingPageText[language].welcomModal;

    useEffect(() => {
        fetch('http://localhost/api/check_ip.php')
        //fetch('https://nrbrt-codes.hu/hotelmanager/api/check_ip.php')
        .then(response => response.json())
        .then(data => {
            console.log(data);
            if (data.isAtHotel) {
            setIsAtHotel(true);
            }
        })
        .catch(err => console.error("Hiba az IP ellenőrzésekor:", err));
    }, []);


    if (!isAtHotel || !showWelcomeModal) return null;

    return (!guest ? (
        <div style={modalStyle}>
            <button style={closeButtonStyle} onClick={() => setShowWelcomeModal(false)} aria-label="Close">
                <span className="material-symbols-outlined">close</span>
            </button>
            <h2 style={{color: 'var(--text-on-background)', marginBottom: '.75rem'}}> {labels.welcome} </h2>
            <p style={{color: 'var(--on-surface-variant)'}}> {labels.line1} </p>
            <p style={{color: 'var(--on-surface-variant)'}}> {labels.line2} </p>
            <p style={{color: 'var(--on-surface-variant)'}}> {labels.line3} </p>

            <div style={{display: 'flex', margin: '1rem 0', width: '100%', justifyContent: 'center'}}>
                <Link to="/guest" className='btn btn-primary' onClick={() => setShowWelcomeModal(false)}> {labels.login} </Link>
            </div>
        </div>
    ) : null);
};

const modalStyle: CSSProperties = {
    position: 'fixed',
    bottom: '3.75rem',
    right: '1rem',
    padding: '.75rem 1.5rem',
    color: 'var(--primary)',
    backgroundColor: 'var(--surface-container)',
    boxShadow: '0 0 10px rgba(0,0,0,0.2)',
    border: '1px solid var(--outline-variant)',
    zIndex: 1000,
    borderRadius: '.5rem'
};

const closeButtonStyle: CSSProperties= {
    position: 'absolute',
    backgroundColor: 'transparent',
    color: 'var(--primary)',
    border: 'none',
    top: '1rem',
    right: '1rem',
    fontSize: '1rem',
    cursor: 'pointer'
};