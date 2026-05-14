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
    const [isFormValid, setIsFormValid] = useState(false);
    const [formData, setFormData] = useState({
        lname: "",
        fname: "",
        email: "",
        city: "",
        street: ""
    });
    
    useEffect(() => {
        if (!location.state) {
            navigate("/");
        }
    }, [location, navigate]);
    
    if (!location.state) return null;

    const { guests, arrivalDate, departureDate } = location.state;

    const sliderStyle = {transform: `translateX(-${(step - 1) * 100}%)`};

    function validateInput(e) {
        const { name, value } = e.target;
        
        const updatedFormData = { ...formData, [name]: value.trim() };
        setFormData(updatedFormData);
        
        const isLnameValid = updatedFormData.lname.length > 2 && updatedFormData.lname.length <= 30 && /^\p{L}+$/u.test(updatedFormData.lname);
        const isFnameValid = updatedFormData.fname.length > 2 && updatedFormData.fname.length <= 30 && /^\p{L}+$/u.test(updatedFormData.fname);
        const isEmailValid = /^[^\s@]+@[^\s@]+\.[^\s@]+$/.test(updatedFormData.email);
        const isCityValid = updatedFormData.city.length > 0;
        const isStreetValid = updatedFormData.street.length > 0;
        
        const isValid = isLnameValid && isFnameValid && isEmailValid && isCityValid && isStreetValid;
        setIsFormValid(isValid);
    }


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
                    <div className={s.card}>
                        <h2>Extra igények</h2>
                        <h3>Válasszon igényei szerint extra szolgáltatásainkból</h3>

                        <div  className={s.chooseExtras}>
                            <div className={s.radioGroup}>
                                <p>Étkezés</p>
                                
                                <label htmlFor="breakfast" value="breakfast">
                                    <input type="radio" id="breakfast" name="catering" defaultChecked />Reggeli <span>(+0%)</span>
                                </label>

                                <label htmlFor="halfboard" value="halfboard">
                                    <input type="radio" id="halfboard" name="catering"/>Félpanzió <span>(+10%)</span>
                                </label>

                                <label htmlFor="fullboard" value="fullboard">
                                    <input type="radio" id="fullboard" name="catering"/>
                                    Teljes ellátás <span>(+20%)</span>
                                </label>
                            </div>

                            <div className={s.selectGroup}>
                                <p>Egyebek</p>

                                <label htmlFor="view">
                                    <input type="checkbox" id="view" name="extras"/>Udvarra néző szoba
                                </label>

                                <label htmlFor="jacuzzi">
                                    <input type="checkbox" id="jacuzzi" name="extras"/>Jacuzzi a teraszon
                                </label>

                                <label htmlFor="kitchen">
                                    <input type="checkbox" id="latecheckout" name="extras"/>Késői kijelentkezés
                                </label>

                                <label htmlFor="transfer">
                                    <input type="checkbox" id="transfer" name="extras"/>Reptéri transzfer
                                </label>
                            </div>
                        </div>

                        <div className={s.buttonContainer}>
                            <button className="btn btn-secondary" onClick={() => setStep(2)}>Vissza</button>
                            <button className="btn btn-primary" onClick={() => setStep(4)}>
                                <span>Tovább</span><span className="material-symbols-outlined">arrow_forward</span>
                            </button>
                        </div>
                    </div>
                </div>

                <div className={s.cardContainer}>
                    <div className={`${s.card} ${s.personalData}`}>
                        <h2>Személyes adatok</h2>
                        <div className={s.inputGroup}>
                            <span>Vezetéknév:</span>
                            <input type="text" name="lname" value={formData.lname} maxLength={30} onChange={validateInput}/>
                            <span>Keresztnév:</span>
                            <input type="text" name="fname" value={formData.fname} maxLength={30} onChange={validateInput}/>
                            <span>E-mail cím:</span>
                            <input type="email" name="email" value={formData.email} onChange={validateInput}/>
                            <span>Lakcím:</span>
                            <input type="text" name="city" value={formData.city} placeholder="Város" onChange={validateInput}/>
                            <span></span>
                            <input type="text" name="street" value={formData.street} placeholder="Utca / házszám" onChange={validateInput}/>
                        </div>

                        <div className={s.buttonContainer}>
                            <button className="btn btn-secondary" onClick={() => setStep(3)}>Vissza</button>
                            <button className={`btn btn-primary ${isFormValid ? "" : "btn-inactive"}`} onClick={() => setStep(5)}>
                                <span>Befejezés</span><span className="material-symbols-outlined">arrow_forward</span>
                            </button>
                        </div>
                    </div>
                </div>

            </div>
        </section>
    );
}