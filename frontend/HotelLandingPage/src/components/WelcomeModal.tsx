import { useEffect, useState, CSSProperties } from 'react';
import { Link } from 'react-router-dom';
import { useLocalStorageExpiry } from "../hooks/useLocalStorageExpiry";
import { useGuest } from '../context/GuestContext';

export default function WelcomeModal(): React.JSX.Element | null {
    const [isAtHotel, setIsAtHotel] = useState(false);
    const [showWelcomeModal, setShowWelcomeModal] = useLocalStorageExpiry<boolean>(
        "showWelcomeModal",
        true,
        120_000 // 2 hours
    );
    const { guest } = useGuest();

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
            <button style={closeButtonStyle} onClick={() => setShowWelcomeModal(false)} aria-label="Bezárás">
                <span className="material-symbols-outlined">close</span>
            </button>
            <h2 style={{color: 'var(--text-on-background)', marginBottom: '.75rem'}}>Üdvözöljük a hotelben!</h2>
            <p style={{color: 'var(--on-surface-variant)'}}>Észleltük, hogy a hotel hálózatát használja.</p>
            <p style={{color: 'var(--on-surface-variant)'}}>Extra funkciókat és felhasználói élményt kínálunk.</p>
            <p style={{color: 'var(--on-surface-variant)'}}>Szeretne bejelentkezni?</p>

            <div style={{margin: '1rem auto', width: '50%'}}>
                <Link to="/guest" className='btn btn-primary' onClick={() => setShowWelcomeModal(false)}>Bejelentkezés</Link>
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