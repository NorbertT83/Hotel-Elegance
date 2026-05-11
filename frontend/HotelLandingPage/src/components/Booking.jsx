import { useLanguage } from '../context/LanguageContext';
import { landingPageText } from '../translations.js';

export default function Booking() {
    const { language } = useLanguage();
    const text = landingPageText[language].booking;

    return (
        <section className="booking-section">
            <div className="booking-bar">
                <div className="input-group">
                    <label>{text.arrival}</label>
                    <input type="date"/>
                </div>
                <div className="input-group">
                    <label>{text.departure}</label>
                    <input type="date"/>
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