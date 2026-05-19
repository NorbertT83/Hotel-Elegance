import s from '../../styles/BookingPage.module.css';
import { FormData } from '../../types/booking';
import { bookingPageText } from '../../translations';
import { Language } from '../../context/LanguageContext';

interface Step4Props {
    formData: FormData;
    isFormValid: boolean;
    language: Language;
    countries: Array<{ code: string; name: string }>;
    handleInputChange: (e: React.ChangeEvent<HTMLInputElement | HTMLSelectElement>) => void;
    onBack: () => void;
    onFinish: () => void;
}

export default function Step4PersonalData({ formData, isFormValid, language, countries, handleInputChange, onBack, onFinish }: Step4Props) {
    const step4Text = bookingPageText[language].step4;

    type step4TextType = typeof step4Text;

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
                            <option value="" disabled>Válasszon országot...</option>
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
                    <button className="btn btn-secondary" onClick={onBack}>Vissza</button>
                    <button className={`btn btn-primary ${isFormValid ? "" : "btn-inactive"}`} onClick={onFinish}>
                        <span>{step4Text.finishButton}</span><span className="material-symbols-outlined">arrow_forward</span>
                    </button>
                </div>
            </div>
        </div>
    );
}