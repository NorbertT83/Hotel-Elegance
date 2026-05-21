import { useBooking } from '../../context/BookingContext';
import { useLanguage } from '../../context/LanguageContext';
import { bookingPageText } from '../../utils/translations';
import countries from '../../utils/countries';
import s from '../../styles/BookingPage.module.css';


export default function Step4PersonalData() {
    const { language } = useLanguage();
    const { formData, handleInputChange, isFormValid, prevStep, finishBooking } = useBooking();
    const step4Text = bookingPageText[language].step4;

    return (
        <div className={s.cardContainer}>
            <div className={s.card}>
                <h2>{step4Text.header}</h2>
                <h3>{step4Text.description}</h3>
                <div className={s.personalData}>
                    <div className={s.inputGroup}>
                        <span>{step4Text.lname}:</span>
                        <input className={s.colSpan2} type="text" name="lname" value={formData.lname} maxLength={30} onChange={handleInputChange}/>
                        
                        <span>{step4Text.fname}:</span>
                        <input className={s.colSpan2} type="text" name="fname" value={formData.fname} maxLength={30} onChange={handleInputChange}/>
                        
                        <span>{step4Text.email}:</span>
                        <input className={s.colSpan2} type="email" name="email" value={formData.email} onChange={handleInputChange}/>
                    </div>
                    <div className={s.addressGroup}>
                        <span>{step4Text.address}:</span>
                        <select name="country" id="countrySelect" value={formData.country} onChange={handleInputChange}>
                            <option value="" disabled>{step4Text.countryPlaceholder}</option>
                            {countries.map(country => (
                                <option key={country.code} value={country.code}>{country.name}</option>
                            ))}
                        </select>
                        <input type="text" name="zip" value={formData.zip} maxLength={10} onChange={handleInputChange} placeholder={step4Text.zipPlaceholder} />

                        <span></span>
                        <input className={s.colSpan2} type="text" name="city" value={formData.city} placeholder={step4Text.cityPlaceholder} onChange={handleInputChange}/>
                        
                        <span></span>
                        <input className={s.colSpan2} type="text" name="street" value={formData.street} placeholder={step4Text.streetPlaceholder} onChange={handleInputChange}/>

                    </div>
                </div>
                <div className={s.buttonContainer}>
                    <button className="btn btn-secondary" onClick={prevStep}>
                        {step4Text.prevButton}
                    </button>
                    <button className={`btn btn-primary ${isFormValid ? "" : "btn-inactive"}`} onClick={finishBooking}>
                        <span>{step4Text.finishButton}</span><span className="material-symbols-outlined">arrow_forward</span>
                    </button>
                </div>
            </div>
        </div>
    );
}