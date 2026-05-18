import s from '../../styles/BookingPage.module.css';
import { CateringType, ExtraOption } from '../../types/booking';

interface Step3Props {
    catering: CateringType;
    setCatering: (type: CateringType) => void;
    extras: Record<string, boolean>;
    handleCheckboxChange: (e: React.ChangeEvent<HTMLInputElement>) => void;
    cateringOptions: Array<{ id: string; label: string; info: string }>;
    extraOptions: ExtraOption[];
    onBack: () => void;
    onNext: () => void;
}

export default function Step3ExtraOptions({
    catering, setCatering, extras, handleCheckboxChange, cateringOptions, extraOptions, onBack, onNext
}: Step3Props) {
    return (
        <div className={s.cardContainer}>
            <div className={s.card}>
                <h2>Extra igények</h2>
                <h3>Válasszon igényei szerint extra szolgáltatásainkból</h3>
                <div className={s.chooseExtras}>
                    <div className={s.radioGroup}>
                        <p>Étkezés</p>
                        {cateringOptions.map((option) => (
                            <label key={option.id} htmlFor={option.id}>
                                <input
                                    type="radio"
                                    id={option.id}
                                    name="catering"
                                    value={option.id}
                                    checked={catering === option.id}
                                    onChange={(e) => setCatering(e.target.value as CateringType)}
                                />
                                {option.label} <span>{option.info}</span>
                            </label>
                        ))}
                    </div>
                    <div className={s.checkboxGroup}>
                        <p>Egyebek</p>
                        {extraOptions.map((option) => (
                            <label key={option.id} htmlFor={option.id}>
                                <input 
                                    type="checkbox" 
                                    id={option.id} 
                                    name="extras"
                                    checked={!!extras[option.id]}
                                    onChange={handleCheckboxChange}
                                />
                                {option.label}
                            </label>
                        ))}
                    </div>
                </div>
                <div className={s.buttonContainer}>
                    <button className="btn btn-secondary" onClick={onBack}>Vissza</button>
                    <button className="btn btn-primary" onClick={onNext}>
                        <span>Tovább</span><span className="material-symbols-outlined">arrow_forward</span>
                    </button>
                </div>
            </div>
        </div>
    );
}