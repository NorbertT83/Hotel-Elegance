import { useLocation, useNavigate } from "react-router-dom";
import { useEffect, useState } from 'react';
import { HashLink } from "react-router-hash-link";
import { useLanguage } from '../context/LanguageContext';
import { getNameOfDay } from '../utils/utils';
import s from '../styles/BookingPage.module.css';

export default function BookingPage() {
    const { language } = useLanguage();
    const location = useLocation();
    const navigate = useNavigate();
    const [step, setStep] = useState(1);
    
    useEffect(() => {
        if (!location.state) {
            navigate("/");
        }
    }, [location, navigate]);
    
    if (!location.state) return null;

    const { guests, arrivalDate, departureDate } = location.state;

    const sliderStyle = {transform: `translateX(-${(step - 1) * 100}%)`};

    return (
        <section className={s.bookingSection}>
            <div className={s.slider} style={sliderStyle}>

                <div className={s.cardContainer}>
                    <div className={`${s.card} ${s.bookingDetails}`}>
                        <h2>Foglalási adatok</h2>

                        <p><span>Érkezés:</span><span>{arrivalDate} {getNameOfDay(arrivalDate, language)}</span></p>
                        <p><span>Távozás:</span><span>{departureDate} {getNameOfDay(departureDate, language)}</span></p>
                        <p><span>Felnőttek:</span><span>{guests.adult} fő</span></p>
                        <p><span>Gyerekek:</span><span>{guests.child} fő</span></p>

                        <div className={s.buttonContainer}>
                            <HashLink smooth to="/#booking" className={`btn btn-secondary`}>Módosít</HashLink>
                            <button className="btn btn-primary" onClick={() => setStep(2)}><span>Tovább</span><span className="material-symbols-outlined">arrow_forward</span></button>
                        </div>
                    </div>
                </div>

                <div className={s.cardContainer}>
                    <div className={`${s.card} ${s.chooseRoom}`}>
                        <h2>Szobatípus kiválasztása</h2>

                        <p>Standard</p>
                        <p>Elite</p>
                        <p>Suite</p>

                        <div className={s.buttonContainer}>
                            <button className="btn btn-secondary" onClick={() => setStep(1)}>Vissza</button>
                            <button className="btn btn-primary" onClick={() => setStep(3)}>
                                <span>Tovább</span><span className="material-symbols-outlined">arrow_forward</span>
                            </button>
                        </div>
                    </div>
                </div>

                <div className={s.cardContainer}>
                    <div className={`${s.card} ${s.chooseExtras}`}>
                        <h2>Extra igények</h2>
                        <div className="radioGroup">
                            <p>Étkezés</p>
                            <input type="radio" id="catering" name="catering" defaultChecked />
                            <label htmlFor="catering" value="breakfast">Reggeli</label><br />
                            <input type="radio" id="catering" name="catering"/>
                            <label htmlFor="catering" value="halfboard">Félpanzió</label><br />
                            <input type="radio" id="catering" name="catering"/>
                            <label htmlFor="catering" value="fullboard">Teljes ellátás</label><br />
                        </div>

                        <div>
                            <p>Egyebek</p>
                            <input type="checkbox" id="transfer" name="exras"/>
                            <label htmlFor="transfer">Reptéri transzfer</label>
                            <input type="checkbox" id="view" name="extras"/>
                            <label htmlFor="view">Udvarra néző szoba</label>
                            <input type="checkbox" id="jacuzzi" name="extras"/>
                            <label htmlFor="jacuzzi">Jacuzzi a teraszon</label>
                        </div>

                        <div className={s.buttonContainer}>
                            <button className="btn btn-secondary" onClick={() => setStep(2)}>Vissza</button>
                            <button className="btn btn-primary" onClick={() => setStep(4)}>
                                <span>Tovább</span><span className="material-symbols-outlined">arrow_forward</span>
                            </button>
                        </div>
                    </div>
                </div>

            </div>
        </section>
    );
}