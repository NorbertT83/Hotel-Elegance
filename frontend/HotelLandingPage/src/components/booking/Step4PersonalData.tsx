import s from '../../styles/BookingPage.module.css';
import { FormData } from '../../types/booking';

interface Step4Props {
    formData: FormData;
    isFormValid: boolean;
    countries: Array<{ code: string; name: string }>;
    handleInputChange: (e: React.ChangeEvent<HTMLInputElement | HTMLSelectElement>) => void;
    onBack: () => void;
    onFinish: () => void;
}

export default function Step4PersonalData({ formData, isFormValid, countries, handleInputChange, onBack, onFinish }: Step4Props) {
    return (
        <div className={s.cardContainer}>
            <div className={s.card}>
                <h2>Személyes adatok</h2>
                <h3>A foglalás rögzítéséhez szükséges személyes adatok</h3>
                <div className={s.personalData}>
                    <div className={s.inputGroup}>
                        <span>Vezetéknév:</span>
                        <input type="text" name="lname" value={formData.lname} maxLength={30} onChange={handleInputChange}/>
                        
                        <span>Keresztnév:</span>
                        <input type="text" name="fname" value={formData.fname} maxLength={30} onChange={handleInputChange}/>
                        
                        <span>E-mail cím:</span>
                        <input type="email" name="email" value={formData.email} onChange={handleInputChange}/>
                        
                        <span>Ország:</span>
                        <select name="country" id="countrySelect" value={formData.country} onChange={handleInputChange}>
                            <option value="" disabled>Válasszon országot...</option>
                            {countries.map(country => (
                                <option key={country.code} value={country.code}>{country.name}</option>
                            ))}
                        </select>
                        
                        <span>Irányítószám:</span>
                        <input type="text" name="zip" value={formData.zip} maxLength={10} onChange={handleInputChange} placeholder="Pl. 1051" />

                        <span>Város:</span>
                        <input type="text" name="city" value={formData.city} placeholder="Város" onChange={handleInputChange}/>
                        
                        <span>Utca / házszám:</span>
                        <input type="text" name="street" value={formData.street} placeholder="Utca / házszám" onChange={handleInputChange}/>
                    </div>
                </div>
                <div className={s.buttonContainer}>
                    <button className="btn btn-secondary" onClick={onBack}>Vissza</button>
                    <button className={`btn btn-primary ${isFormValid ? "" : "btn-inactive"}`} onClick={onFinish}>
                        <span>Befejezés</span><span className="material-symbols-outlined">arrow_forward</span>
                    </button>
                </div>
            </div>
        </div>
    );
}