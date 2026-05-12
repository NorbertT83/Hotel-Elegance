import { useState } from 'react';
import { useLanguage } from '../context/LanguageContext';
import { landingPageText } from '../translations.js';

export default function Booking() {
    const today = new Date().toISOString().split('T')[0];
    
    const { language } = useLanguage();
    const [ arrivalDate, setArrivalDate ] = useState(today);
    const [ departureDate, setDepartureDate ] = useState(addDays(today, 2));
    const text = landingPageText[language].booking;
    function addDays(dateString, days) {
        if (!dateString) return "";

        const [year, month, day] = dateString.split("-").map(Number);
        const date = new Date(year, month - 1, day);

        date.setDate(date.getDate() + days);

        const yyyy = date.getFullYear();
        const mm = String(date.getMonth() + 1).padStart(2, "0");
        const dd = String(date.getDate()).padStart(2, "0");

        return `${yyyy}-${mm}-${dd}`;
    }

    function handleArrivalChange(e) {
        const newArrival = e.target.value;
        setArrivalDate(newArrival);
        const minDeparture = addDays(newArrival, 1);
        const maxDeparture = addDays(newArrival, 21);

        if (!departureDate || departureDate < minDeparture) {
            setDepartureDate(minDeparture);
        }

        if (departureDate > maxDeparture) {
            setDepartureDate(maxDeparture);
        }
    }


    return (
        <section className="booking-section" id="booking">
            <div className="booking-bar">
                <div className="input-group">
                    <label>{text.arrival}</label>
                    <input
                        type="date"
                        min={today}
                        value={arrivalDate}
                        onChange={handleArrivalChange}
                    />
                </div>
                <div className="input-group">
                    <label>{text.departure}</label>
                    <input
                        type="date"
                        min={addDays(arrivalDate, 1)}
                        max={addDays(arrivalDate, 21)}
                        value={departureDate}
                        onChange={(e) => setDepartureDate(e.target.value)}
                    />
                </div>
                <div className="input-group">
                    <label>{text.guests}</label>
                    <select>
                        <option>{text.guestOptions[0]}</option>
                        <option>{text.guestOptions[1]}</option>
                        <option>{text.guestOptions[2]}</option>
                    </select>
                </div>
                <div className="submit-group">
                    <button className="btn btn-primary btn-large">{text.submit}</button>
                </div>
            </div>
        </section>
    )
}