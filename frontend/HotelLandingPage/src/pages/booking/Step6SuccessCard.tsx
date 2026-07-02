import { useState } from "react";
import { useNavigate } from "react-router-dom";
import { bookingPageText } from "../../utils/translations";
import { useLanguage } from "../../context/LanguageContext";
import { useBooking } from "../../context/BookingProcessContext";
import s from '../../styles/BookingPage.module.css';

export default function Step6SuccessCard() {
    const navigate = useNavigate();
    const { language } = useLanguage()
    const { bookingState } = useBooking();
    const [copied, setCopied] = useState(false);
    const step6Text = bookingPageText[language].step6;

    async function copyToClipboard() {
        try {
            await navigator.clipboard.writeText(bookingState.bookingId);
            setCopied(true);
            setTimeout(() => setCopied(false), 2000);
        } catch (err) {
            console.error("Sikertelen másolás: ", err);
        }
    };

    return (
        <div className={s.cardContainer}>
            <div className={`${s.card} ${s.successCard}`}>
                <div className={s.successIconContainer}>
                    <span className="material-symbols-outlined" style={{ fontSize: "64px", color: "#2e7d32" }}>
                        check_circle
                    </span>
                </div>

                <h2>{step6Text.header}</h2>
                <h3>{step6Text.description}</h3>

                <div className={s.successDetails}>
                    <p>
                        <span>{step6Text.bookingId}</span>
                        <span className={s.bookingId}>
                            {bookingState.bookingId}
                            <button className="material-symbols-outlined" style={{ color: copied ? "green" : "" }} onClick={copyToClipboard}>
                                {copied ? 'check' : 'content_copy'}
                            </button>
                        </span>
                        
                    </p>
                    <p className={s.infoText}>
                        {step6Text.emailInfo}
                        <span className={s.highlighted}>{` ${bookingState.formData.email.value} `}</span>
                        {step6Text.emailInfo2}
                    </p>
                    <p className={s.spamNotice}>
                        {step6Text.spamNotice}
                    </p>
                </div>

                <div className={s.buttonContainer}>
                    <button className="btn btn-primary" onClick={() => navigate("/")}>
                        <span>{step6Text.backButton}</span>
                        <span className="material-symbols-outlined">home</span>
                    </button>
                </div>
            </div>
        </div>
    );
}