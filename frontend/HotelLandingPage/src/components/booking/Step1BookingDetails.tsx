import { HashLink } from "react-router-hash-link";
import { getNameOfDay } from '../../utils/utils';
import { bookingPageText } from '../../utils/translations';
import { useLanguage } from "../../context/LanguageContext";
import { useBooking } from "../../context/BookingContext";
import s from '../../styles/BookingPage.module.css';


export default function Step1BookingDetails() {
    const { bookingState, nextStep } = useBooking();
    const { language } = useLanguage();
    const labels = bookingPageText[language].step1;

    return (
        <div className={s.cardContainer}>
            <div className={s.card}>
                <h2>{labels.header}</h2>
                <h3>{labels.description}</h3>
                <div className={s.bookingDetails}>
                    <p><span>{labels.arrival}:</span><span>{bookingState.arrivalDate}. - {getNameOfDay(bookingState.arrivalDate, language)}</span></p>
                    <p><span>{labels.departure}:</span><span>{bookingState.departureDate}. - {getNameOfDay(bookingState.departureDate, language)}</span></p>
                    <p><span>{labels.adults}:</span><span>{bookingState.guests.adult} {labels.person}</span></p>
                    <p><span>{labels.children}:</span><span>{bookingState.guests.child} {labels.person}</span></p>
                </div>
                <div className={s.buttonContainer}>
                    <HashLink smooth to="/#booking" className="btn btn-secondary">{labels.modifyButton}</HashLink>
                    <button className="btn btn-primary" onClick={nextStep}>
                        <span>{labels.nextButton}</span><span className="material-symbols-outlined">arrow_forward</span>
                    </button>
                </div>
            </div>
        </div>
    );
}