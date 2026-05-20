import { HashLink } from "react-router-hash-link";
import { getNameOfDay } from '../../utils/utils';
import s from '../../styles/BookingPage.module.css';
import { bookingPageText } from '../../utils/translations';
import { Language } from "../../context/LanguageContext";

interface Step1Props {
    arrivalDate: string;
    departureDate: string;
    language: Language;
    guests: { adult: number; child: number };
    onNext: () => void;
}

export default function Step1BookingDetails({ arrivalDate, departureDate, language, guests, onNext }: Step1Props) {
    return (
        <div className={s.cardContainer}>
            <div className={s.card}>
                <h2>{bookingPageText[language].step1.header}</h2>
                <h3>{bookingPageText[language].step1.description}</h3>
                <div className={s.bookingDetails}>
                    <p><span>{bookingPageText[language].step1.arrival}:</span><span>{arrivalDate}. - {getNameOfDay(arrivalDate, language)}</span></p>
                    <p><span>{bookingPageText[language].step1.departure}:</span><span>{departureDate}. - {getNameOfDay(departureDate, language)}</span></p>
                    <p><span>{bookingPageText[language].step1.adults}:</span><span>{guests.adult} {bookingPageText[language].step1.person}</span></p>
                    <p><span>{bookingPageText[language].step1.children}:</span><span>{guests.child} {bookingPageText[language].step1.person}</span></p>
                </div>
                <div className={s.buttonContainer}>
                    <HashLink smooth to="/#booking" className="btn btn-secondary">{bookingPageText[language].step1.modifyButton}</HashLink>
                    <button className="btn btn-primary" onClick={onNext}>
                        <span>{bookingPageText[language].step1.nextButton}</span><span className="material-symbols-outlined">arrow_forward</span>
                    </button>
                </div>
            </div>
        </div>
    );
}