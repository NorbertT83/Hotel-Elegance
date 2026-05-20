import { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import s from '../../styles/BookingPage.module.css';
import { bookingPageText } from "../../utils/translations";
import { Language } from "../../context/LanguageContext";

interface Step5Props {
    email: string;
    language: Language;
}

export default function Step5SuccessCard({ email, language }: Step5Props) {
    const navigate = useNavigate();
    const [bookingId, setBookingId] = useState("");
    const step5Text = bookingPageText[language].step5;

    // Foglalási szám generálása a komponens betöltődésekor (pl: HE-2026-A1B2)
    useEffect(() => {
        const year = new Date().getFullYear();
        const randomHex = Math.random().toString(36).substring(2, 6).toUpperCase();
        setBookingId(`HE-${year}-${randomHex}`);
    }, []);

    return (
        <div className={s.cardContainer}>
            <div className={`${s.card} ${s.successCard}`}>
                <div className={s.successIconContainer}>
                    <span className="material-symbols-outlined" style={{ fontSize: "64px", color: "#2e7d32" }}>
                        check_circle
                    </span>
                </div>

                <h2>{step5Text.header}</h2>
                <h3>{step5Text.description}</h3>

                <div className={s.successDetails}>
                    <p>
                        <span>{step5Text.bookingId}</span>
                        <span className={s.bookingId}>
                            {bookingId}
                            <button className="material-symbols-outlined">content_copy</button>
                        </span>
                        
                    </p>
                    <p className={s.infoText}>
                        {step5Text.emailInfo}
                        <span className={s.highlighted}>{` ${email} `}</span>
                        {step5Text.emailInfo2}
                    </p>
                    <p className={s.spamNotice}>
                        {step5Text.spamNotice}
                    </p>
                </div>


                <div className={s.buttonContainer}>
                    <button className="btn btn-primary" onClick={() => navigate("/")}>
                        <span>{step5Text.backButton}</span>
                        <span className="material-symbols-outlined">home</span>
                    </button>
                </div>
            </div>
        </div>
    );
}