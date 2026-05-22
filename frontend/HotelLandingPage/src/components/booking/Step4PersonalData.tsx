import { useBooking } from '../../context/BookingContext';
import { useLanguage } from '../../context/LanguageContext';
import { bookingPageText } from '../../utils/translations';
import countries from '../../utils/countries';
import s from '../../styles/BookingPage.module.css';


export default function Step4PersonalData() {
    const { language } = useLanguage();
    const { bookingState, handleInputChange, isFormValid, prevStep, finishBooking } = useBooking();
    const labels = bookingPageText[language].step4;

    return (
        <div className={s.cardContainer}>
            <div className={s.card}>
                <h2>{labels.header}</h2>
                <h3>{labels.description}</h3>
                <div className={s.personalData}>
                    <div className={s.inputGroup}>
                        <span>{labels.lname}:</span>
                        <input className={s.colSpan2} type="text" name="lname" value={bookingState.formData.lname} maxLength={30} onChange={handleInputChange}/>
                        
                        <span>{labels.fname}:</span>
                        <input className={s.colSpan2} type="text" name="fname" value={bookingState.formData.fname} maxLength={30} onChange={handleInputChange}/>
                        
                        <span>{labels.email}:</span>
                        <input className={s.colSpan2} type="email" name="email" value={bookingState.formData.email} onChange={handleInputChange}/>
                    </div>
                    <div className={s.addressGroup}>
                        <span>{labels.address}:</span>
                        <select name="country" id="countrySelect" value={bookingState.formData.country} onChange={handleInputChange}>
                            <option value="" disabled>{labels.countryPlaceholder}</option>
                            {countries.map(country => (
                                <option key={country.code} value={country.code}>{country.name}</option>
                            ))}
                        </select>
                        <input type="text" name="zip" value={bookingState.formData.zip} maxLength={10} onChange={handleInputChange} placeholder={labels.zipPlaceholder} />

                        <span></span>
                        <input className={s.colSpan2} type="text" name="city" value={bookingState.formData.city} placeholder={labels.cityPlaceholder} onChange={handleInputChange}/>
                        
                        <span></span>
                        <input className={s.colSpan2} type="text" name="street" value={bookingState.formData.street} placeholder={labels.streetPlaceholder} onChange={handleInputChange}/>

                    </div>
                </div>
                <div className={s.buttonContainer}>
                    <button className="btn btn-secondary" onClick={prevStep}>
                        {labels.prevButton}
                    </button>
                    <button className={`btn btn-primary ${isFormValid ? "" : "btn-inactive"}`} onClick={finishBooking}>
                        <span>{labels.finishButton}</span><span className="material-symbols-outlined">arrow_forward</span>
                    </button>
                </div>
            </div>
        </div>
    );
}