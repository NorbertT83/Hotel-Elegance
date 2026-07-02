import { useBooking } from '../../context/BookingProcessContext';
import { useLanguage } from '../../context/LanguageContext';
import { bookingPageText } from '../../utils/translations';
import countries from '../../utils/countries';
import s from '../../styles/BookingPage.module.css';


export default function Step5PersonalData() {
    const { language } = useLanguage();
    const { bookingState, handleInputChange, isFormValid, prevStep, finishBooking } = useBooking();
    const labels = bookingPageText[language].step5;

    return (
        <div className={s.cardContainer}>
            <div className={s.card}>
                <h2>{labels.header}</h2>
                <h3>{labels.description}</h3>
                <div className={s.personalData}>
                    <div className={s.inputGroup}>
                        <span>{labels.lname}:</span>
                        <div className={s.colSpan2}>
                            <span className={`${!bookingState.formData.lname.isTouched || isFormValid.lname  ? s.valid : s.invalid} material-symbols-outlined`}>error</span>
                            <input
                                type="text"
                                name="lname"
                                maxLength={30}
                                value={bookingState.formData.lname.value}
                                onChange={handleInputChange}
                            />
                        </div>

                        <span>{labels.fname}:</span>
                        <div className={s.colSpan2}>
                            <span className={`${!bookingState.formData.fname.isTouched || isFormValid.fname  ? s.valid : s.invalid} material-symbols-outlined`}>error</span>
                            <input
                                type="text"
                                name="fname"
                                value={bookingState.formData.fname.value}
                                maxLength={30}
                                onChange={handleInputChange}
                            />
                        </div>

                        <span>{labels.email}:</span>
                        <div className={s.colSpan2}>
                            <span className={`${!bookingState.formData.email.isTouched || isFormValid.email  ? s.valid : s.invalid} material-symbols-outlined`}>error</span>
                            <input
                                type="email"
                                name="email"
                                value={bookingState.formData.email.value}
                                onChange={handleInputChange}
                            />
                        </div>
                    </div>

                    <div className={s.addressGroup}>
                        <span>{labels.address}:</span>
                        <select name="country" id="countrySelect" value={bookingState.formData.country.value} onChange={handleInputChange}>
                            <option value="" disabled>{labels.countryPlaceholder}</option>
                            {countries.map(country => (
                                <option key={country.code} value={country.code}>{country.name}</option>
                            ))}
                        </select>
                        <div>
                            <span className={`${!bookingState.formData.zip.isTouched || isFormValid.zip  ? s.valid : s.invalid} material-symbols-outlined`}>error</span>
                            <input
                                type="text"
                                name="zip"
                                maxLength={10}
                                placeholder={labels.zipPlaceholder}
                                value={bookingState.formData.zip.value}
                                onChange={handleInputChange}
                            />
                        </div>

                        <span></span>
                        <div className={s.colSpan2}>
                            <span className={`${!bookingState.formData.city.isTouched || isFormValid.city  ? s.valid : s.invalid} material-symbols-outlined`}>error</span>
                            <input
                                type="text"
                                name="city"
                                placeholder={labels.cityPlaceholder}
                                value={bookingState.formData.city.value}
                                onChange={handleInputChange}
                            />
                        </div>
                        
                        <span></span>
                        <div className={s.colSpan2}>
                            <span className={`${!bookingState.formData.street.isTouched || isFormValid.street  ? s.valid : s.invalid} material-symbols-outlined`}>error</span>
                            <input
                                type="text"
                                name="street"
                                value={bookingState.formData.street.value}
                                placeholder={labels.streetPlaceholder}
                                onChange={handleInputChange}
                            />
                        </div>

                    </div>
                </div>
                <div className={s.buttonContainer}>
                    <button className="btn btn-secondary" onClick={prevStep}>
                        {labels.prevButton}
                    </button>
                    <button className={`btn btn-primary ${Object.values(isFormValid).every(v => v) ? "" : "btn-inactive"}`} onClick={finishBooking}>
                        <span>{labels.finishButton}</span><span className="material-symbols-outlined">arrow_forward</span>
                    </button>
                </div>
            </div>
        </div>
    );
}