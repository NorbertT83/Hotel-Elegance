import { useEffect, useState } from 'react';

const HotelWelcome = () => {
    const [isAtHotel, setIsAtHotel] = useState(false);

    useEffect(() => {
        // fetch('http://localhost/api/check_ip.php')
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
            <button className='btn btn-primary' style={{margin: '1rem 0rem'}} onClick={() => window.location.href = '/login'}>Bejelentkezés</button>
        </div>
    );
};

const popupStyle = {
    position: 'fixed',
    bottom: '3.5rem',
    right: '1.5rem',
    padding: '12px 24px',
    color: 'var(--primary)',
    backgroundColor: 'var(--surface-container)',
    boxShadow: '0 0 10px rgba(0,0,0,0.2)',
    zIndex: 1000,
    borderRadius: '8px'
};

export default HotelWelcome;