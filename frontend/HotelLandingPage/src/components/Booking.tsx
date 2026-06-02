import { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import { useLanguage } from '../context/LanguageContext';
import { landingPageText } from '../utils/translations';
import { addDays } from '../utils/utils';
import { Room } from '../types/booking';
import { getData } from '../services/apiService';

export default function Booking() {
    const navigate = useNavigate();
    const today = new Date().toISOString().split('T')[0];
    const [selectedGuestIndex, setSelectedGuestIndex] = useState<number>(0);
    const { language } = useLanguage();
    const [ arrivalDate, setArrivalDate ] = useState(today);
    const [ departureDate, setDepartureDate ] = useState(addDays(today, 2));
    const text = landingPageText[language].booking;

    const guestOptionsValue = [
        {adult: 2, child: 0},
        {adult: 1, child: 0},
        {adult: 2, child: 1}
    ]

    async function handleBookingStart() {

        const result = await getData('freerooms', {
            beginning_of_stay: arrivalDate,
            end_of_stay: departureDate
        });

        if (!result) {
            alert("Hiba történt a szabad szobák lekérésekor. Kérem próbálja újra később.");
            return;
        }

        const freeRooms: Room[]  = result as Room[];

        console.log(freeRooms);

        if (!freeRooms || freeRooms.length === 0) {
            alert("Sajnos erre a dátumra nincs üres szobánk. Kérem válasszon másik időpontot.");
            return;
        }

        navigate("/booking", {
            state: {
                arrivalDate,
                departureDate,
                guests: guestOptionsValue[selectedGuestIndex],
                freeRooms
            }
        })
    }

    function handleArrivalChange(e: React.ChangeEvent<HTMLInputElement>) {
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

    function handleArrivalBlur(e: React.ChangeEvent<HTMLInputElement>) {
        const newArrival = e.target.value;
        if (newArrival < today) {
            setArrivalDate(today);
        }
    }

    function handleDepartureBlur(e: React.ChangeEvent<HTMLInputElement>) {
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
                    <select 
                        value={selectedGuestIndex} 
                        onChange={(e) => setSelectedGuestIndex(Number(e.target.value))}
                    >
                        <option value={0}>{text.guestOptions[0]}</option>
                        <option value={1}>{text.guestOptions[1]}</option>
                        <option value={2}>{text.guestOptions[2]}</option>
                    </select>
                </div>
                <div className="submit-group">
                    <button className="btn btn-primary btn-large"
                        onClick={handleBookingStart}
                    >
                        {text.submit}
                    </button>
                </div>
            </div>
        </section>
    )
}