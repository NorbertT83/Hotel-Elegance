import s from '../../styles/BookingPage.module.css';
import { CateringType, ExtraOption, Room } from '../../types/booking';
import { bookingPageText } from '../../utils/translations';
import { useLanguage } from '../../context/LanguageContext';
import { useBooking } from '../../context/BookingContext';


export default function Step3ExtraOptions() {
    const { language } = useLanguage();
    const step3Text = bookingPageText[language].step3;
    const { cateringChosen , setCateringChosen, extrasChosen, handleCheckboxChange, freeRooms, prevStep, nextStep } = useBooking();
    
    type Step3Keys = keyof typeof step3Text;

    const cateringOptions = ['breakfast', 'halfboard', 'fullboard'] as CateringType[];
    const extraOptions: ExtraOption[] = ['jacuzzi', 'kitchen'];
    const availableExtras = {
            has_balcony: freeRooms.some(r => r.has_balcony === 1),
            garden: freeRooms.some(r => r.has_view === 'garden'),
            panorama: freeRooms.some(r => r.has_view === 'panorama'),
            jacuzzi: freeRooms.some(r => r.extras?.includes("jacuzzi")),
            kitchen: freeRooms.some(r => r.extras?.includes("kitchen")),
        };

    return (
        <div className={s.cardContainer}>
            <div className={s.card}>
                <h2>{step3Text.header}</h2>
                <h3>{step3Text.description}</h3>
                <div className={s.chooseExtras}>
                    <div className={s.radioGroup}>
                        <p>{step3Text.catering}</p>
                        {cateringOptions.map((option) => (
                            <label key={option} htmlFor={option}>
                                <input
                                    type="radio"
                                    id={option}
                                    name="catering"
                                    value={option}
                                    checked={cateringChosen === option}
                                    onChange={(e) => setCateringChosen(e.target.value as CateringType)}
                                />
                                {step3Text[option as Step3Keys]} <span>{step3Text[`${option}Note` as Step3Keys]}</span>
                            </label>
                        ))}
                    </div>
                    <div className={s.checkboxGroup}>
                        <p>{step3Text.extras}</p>
                        {extraOptions.map((option) => (
                            <label key={option} htmlFor={option}>
                                <input 
                                    type="checkbox" 
                                    id={option} 
                                    name="extras"
                                    checked={!!extrasChosen[option]}
                                    onChange={handleCheckboxChange}
                                />
                                {step3Text[option as Step3Keys]}
                            </label>
                        ))}
                    </div>
                </div>
                <div className={s.extraInfo}>{step3Text.extraInfo}</div>
                <div className={s.buttonContainer}>
                    <button className="btn btn-secondary" onClick={prevStep}>
                        {step3Text.prevButton}
                    </button>
                    <button className="btn btn-primary" onClick={nextStep}>
                        <span>{step3Text.nextButton}</span><span className="material-symbols-outlined">arrow_forward</span>
                    </button>
                </div>
            </div>
        </div>
    );
}