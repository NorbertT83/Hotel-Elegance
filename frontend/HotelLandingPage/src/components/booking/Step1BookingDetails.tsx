import { HashLink } from "react-router-hash-link";
import { getNameOfDay } from '../../utils/utils';
import s from '../../styles/BookingPage.module.css';

interface Step1Props {
    arrivalDate: string;
    departureDate: string;
    language: string;
    guests: { adult: number; child: number };
    onNext: () => void;
}

export default function Step1BookingDetails({ arrivalDate, departureDate, language, guests, onNext }: Step1Props) {
    return (
        <div className={s.cardContainer}>
            <div className={s.card}>
                <h2>Foglalási adatok</h2>
                <h3>Az Ön által eddig rögzített adatok</h3>
                <div className={s.bookingDetails}>
                    <p><span>Érkezés:</span><span>{arrivalDate}. - {getNameOfDay(arrivalDate, language)}</span></p>
                    <p><span>Távozás:</span><span>{departureDate}. - {getNameOfDay(departureDate, language)}</span></p>
                    <p><span>Felnőttek:</span><span>{guests.adult} fő</span></p>
                    <p><span>Gyerekek:</span><span>{guests.child} fő</span></p>
                </div>
                <div className={s.buttonContainer}>
                    <HashLink smooth to="/#booking" className="btn btn-secondary">Módosít</HashLink>
                    <button className="btn btn-primary" onClick={onNext}>
                        <span>Tovább</span><span className="material-symbols-outlined">arrow_forward</span>
                    </button>
                </div>
            </div>
        </div>
    );
}