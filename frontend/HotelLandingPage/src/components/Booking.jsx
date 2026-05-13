import { useState, useRef } from 'react';
import { useNavigate } from 'react-router-dom';
import { useLanguage } from '../context/LanguageContext';
import { landingPageText } from '../translations.js';

export default function Booking() {
    const navigate = useNavigate();
    const today = new Date().toISOString().split('T')[0];
    const guestRef = useRef();
    const { language } = useLanguage();
    const [ arrivalDate, setArrivalDate ] = useState(today);
    const [ departureDate, setDepartureDate ] = useState(addDays(today, 2));
    const text = landingPageText[language].booking;

    const guestOptionsValue = [
        {adult: 2, child: 0},
        {adult: 1, child: 0},
        {adult: 2, child: 1}
    ]

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

        const minDeparture = addDays(newArrival, 1);
        const maxDeparture = addDays(newArrival, 21);

        setArrivalDate(newArrival);

        if (!departureDate || departureDate < minDeparture) {
            setDepartureDate(minDeparture);
        }

        if (departureDate > maxDeparture) {
            setDepartureDate(maxDeparture);
        }
    }

    function handleArrivalBlur(e) {
        const newArrival = e.target.value;
        if (newArrival < today) {
            setArrivalDate(today);
        }
    }

    function handleDepartureBlur(e) {
        const newDeparture = e.target.value;
        if (newDeparture < arrivalDate) {
            setDepartureDate(addDays(arrivalDate, 1));
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
                        onBlur={handleArrivalBlur}
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
                        onBlur={handleDepartureBlur}
                    />
                </div>
                <div className="input-group">
                    <label>{text.guests}</label>
                    <select ref={guestRef}>
                        <option value={0}>{text.guestOptions[0]}</option>
                        <option value={1}>{text.guestOptions[1]}</option>
                        <option value={2}>{text.guestOptions[2]}</option>
                    </select>
                </div>
                <div className="submit-group">
                    <button className="btn btn-primary btn-large"
                        onClick={() => ( 
                            navigate("/booking", {
                                state: {
                                    arrivalDate,
                                    departureDate,
                                    guests: guestOptionsValue[guestRef.current.value]
                                }
                            })
                        )}
                    >
                        {text.submit}
                    </button>
                </div>
            </div>
        </section>
    )
}