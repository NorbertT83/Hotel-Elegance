import { useEffect, useState, CSSProperties } from 'react';

export default function WelcomeModal() {
    const [isAtHotel, setIsAtHotel] = useState(false);

    useEffect(() => {
        //fetch('http://192.168.2.162/api/check_ip.php')
        fetch('https://nrbrt-codes.hu/hotelmanager/api/check_ip.php')
        .then(response => response.json())
        .then(data => {
            console.log(data);
            if (data.isAtHotel) {
            setIsAtHotel(true);
            }
        })
        .catch(err => console.error("Hiba az IP ellenőrzésekor:", err));
    }, []);

    if (!isAtHotel) return null;

    return (
        <div style={popupStyle}>
            <h2>Üdvözöljük a hotelben!</h2>
            <p>Észleltük, hogy a hotel hálózatát használja.</p>
            <p>Szeretne bejelentkezni?</p>
            <button className='btn btn-primary' style={{margin: '1rem 0rem', alignSelf: 'right'}} onClick={() => window.location.href = '/login'}>Bejelentkezés</button>
        </div>
    );
};

const popupStyle: CSSProperties = {
    position: 'fixed',
    bottom: '3.75rem',
    right: '1rem',
    padding: '.75rem 1.5rem',
    color: 'var(--primary)',
    backgroundColor: 'var(--surface-container)',
    boxShadow: '0 0 10px rgba(0,0,0,0.2)',
    zIndex: 1000,
    borderRadius: '.5rem'
};