import { useLocation, useNavigate } from "react-router-dom";
import { useEffect } from 'react';
import { useLanguage } from '../context/LanguageContext';
import s from '../styles/BookingPage.module.css';

export default function BookingPage() {
    const { language } = useLanguage();
    const location = useLocation();
    const navigate = useNavigate();
    
    useEffect(() => {
        if (!location.state) {
            navigate("/");
        }
    }, [location, navigate]);
    
    if (!location.state) return null;
    
    const { guests, arrivalDate, departureDate } = location.state;
    
    function getNameOfDay(date) {
        const dayName = new Date(date).toLocaleDateString(language === 'hu' ? "hu-HU" : "en-US", {weekday: "long"});
        return dayName
    }

    return (
        <section className={s.bookingSection}>
            <h2>Foglalási adatok:</h2>

            <p>Érkezés: {arrivalDate} {getNameOfDay(arrivalDate)}</p>
            <p>Távozás: {departureDate} {getNameOfDay(departureDate)}</p>
            <p>Felnőttek: {guests.adult} fő</p>
            <p>Gyerekek: {guests.child} fő</p>
        </section>
    );
}