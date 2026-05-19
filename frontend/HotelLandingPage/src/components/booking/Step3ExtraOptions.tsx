import s from '../../styles/BookingPage.module.css';
import { CateringType, ExtraOption } from '../../types/booking';
import { bookingPageText } from '../../translations';
import { Language } from '../../context/LanguageContext';

interface Step3Props {
    catering: CateringType;
    setCatering: (type: CateringType) => void;
    extras: Record<string, boolean>;
    handleCheckboxChange: (e: React.ChangeEvent<HTMLInputElement>) => void;
    cateringOptions: Array<{ id: string }>;
    extraOptions: ExtraOption[];
    language: Language;
    onBack: () => void;
    onNext: () => void;
}

export default function Step3ExtraOptions({
    catering, setCatering, extras, handleCheckboxChange, cateringOptions, extraOptions, language, onBack, onNext
}: Step3Props) {

    const step3Text = bookingPageText[language].step3;
    type Step3Keys = keyof typeof step3Text;
    return (
        <div className={s.cardContainer}>
            <div className={s.card}>
                <h2>{step3Text.header}</h2>
                <h3>{step3Text.description}</h3>
                <div className={s.chooseExtras}>
                    <div className={s.radioGroup}>
                        <p>{step3Text.catering}</p>
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
                                {step3Text[option.id as Step3Keys]} <span>{step3Text[`${option.id}Note` as Step3Keys]}</span>
                            </label>
                        ))}
                    </div>
                    <div className={s.checkboxGroup}>
                        <p>{step3Text.extras}</p>
                        {extraOptions.map((option) => (
                            <label key={option.id} htmlFor={option.id}>
                                <input 
                                    type="checkbox" 
                                    id={option.id} 
                                    name="extras"
                                    checked={!!extras[option.id]}
                                    onChange={handleCheckboxChange}
                                />
                                {step3Text[option.id as Step3Keys]}
                            </label>
                        ))}
                    </div>
                </div>
                <div className={s.buttonContainer}>
                    <button className="btn btn-secondary" onClick={onBack}>
                        {step3Text.prevButton}
                    </button>
                    <button className="btn btn-primary" onClick={onNext}>
                        <span>{step3Text.nextButton}</span><span className="material-symbols-outlined">arrow_forward</span>
                    </button>
                </div>
            </div>
        </div>
    );
}