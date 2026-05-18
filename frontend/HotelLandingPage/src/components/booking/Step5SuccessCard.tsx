import { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import s from '../../styles/BookingPage.module.css';

interface Step5Props {
    email: string; // Átadjuk a megadott emailt, hogy személyesebb legyen
}

export default function Step5SuccessCard({ email }: Step5Props) {
    const navigate = useNavigate();
    const [bookingId, setBookingId] = useState("");

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

                <h2>Sikeres foglalás!</h2>
                <h3>Köszönjük, hogy a <strong>Hotel Elegance</strong>-t választotta.</h3>

                <div className={s.successDetails}>
                    <p>
                        Foglalási száma: <span className={s.bookingId}> {bookingId}</span>
                    </p>
                    <p className={s.infoText}>
                        A visszaigazoló dokumentumokat és a részletes tájékoztatót elküldtük a megadott 
                        <span className={s.highlighted}>{email}</span> e-mail címre.
                    </p>
                    <p className={s.spamNotice}>
                        *Amennyiben pár percen belül nem érkezik meg a levél, kérjük, ellenőrizze a Spam/Promóciók mappát is.
                    </p>
                </div>


                <div className={s.buttonContainer}>
                    <button className="btn btn-primary" onClick={() => navigate("/")}>
                        <span>Vissza a főoldalra</span>
                        <span className="material-symbols-outlined">home</span>
                    </button>
                </div>
            </div>
        </div>
    );
}