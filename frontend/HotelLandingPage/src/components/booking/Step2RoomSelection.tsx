import { Language } from '../../context/LanguageContext';
import s from '../../styles/BookingPage.module.css';
import { bookingPageText } from '../../utils/translations';
import { RoomType } from '../../types/booking';

interface Step2Props {
    roomType: RoomType;
    setRoomType: (type: RoomType) => void;
    language: Language;
    onBack: () => void;
    onNext: () => void;
}

const ROOM_OPTIONS: { id: RoomType; label: string }[] = [
    { id: "standard", label: "The Standard Elegance" },
    { id: "deluxe", label: "The Grand Ivory" },
    { id: "suite", label: "The Terrace Penthouse" },
];


export default function Step2RoomSelection({ roomType, setRoomType, language, onBack, onNext }: Step2Props) {
    return (
        <div className={s.cardContainer}>
            <div className={s.card}>
                <h2>{bookingPageText[language].step2.header}</h2>
                <h3>{bookingPageText[language].step2.description}</h3>
                
                {/* A szobaválasztó most már interaktív és kap egy s.active osztályt a kijelölttől */}
                <div className={s.chooseRoom}>
                    {ROOM_OPTIONS.map((room) => (
                        <div 
                            key={room.id}
                            className={`${s.roomOption} ${roomType === room.id ? s.active : ''}`}
                            onClick={() => setRoomType(room.id)}
                        >
                            <p>{room.label}</p>
                        </div>
                    ))}
                </div>

                <div className={s.buttonContainer}>
                    <button className="btn btn-secondary" onClick={onBack}>
                        {bookingPageText[language].step2.prevButton}
                    </button>
                    <button className="btn btn-primary" onClick={onNext}>
                        <span>{bookingPageText[language].step2.nextButton}</span><span className="material-symbols-outlined">arrow_forward</span>
                    </button>
                </div>
            </div>
        </div>
    );
}