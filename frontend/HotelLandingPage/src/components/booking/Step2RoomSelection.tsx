import { Language } from '../../context/LanguageContext';
import s from '../../styles/BookingPage.module.css';
import { bookingPageText } from '../../utils/translations';
import { Room, RoomType } from '../../types/booking';
import { useMemo, useState } from 'react';

interface Step2Props {
    roomType: RoomType;
    setRoomType: (type: RoomType) => void;
    language: Language;
    onBack: () => void;
    onNext: () => void;
    freeRooms: Room[];
}

const ROOM_OPTIONS: { id: RoomType; label: string }[] = [
    { id: "standard", label: "Standard Elegance" },
    { id: "deluxe", label: "Grand Ivory" },
    { id: "suite", label: "Terrace Penthouse" },
];


export default function Step2RoomSelection({ roomType, setRoomType, language, onBack, onNext, freeRooms }: Step2Props) {
    const availableRoomTypes = [...new Set(freeRooms.map(room => room.room_type))];
    const filteredRooms = freeRooms.filter(r => r.room_type === roomType);
    const availableExtras = useMemo(() => {
        if (!roomType) return {};
        
        return {
            has_balcony: filteredRooms.some(r => r.has_balcony === 1),
            garden: filteredRooms.some(r => r.has_view === 'garden'),
            panorama: filteredRooms.some(r => r.has_view === 'panorama'),
            jacuzzi: filteredRooms.some(r => r.extras?.includes("jacuzzi")),
            kitchen: filteredRooms.some(r => r.extras?.includes("kitchen")),
        };
    }, [roomType, freeRooms]);

    console.log(availableExtras);

    return (
        <div className={s.cardContainer}>
            <div className={s.card}>
                <h2>{bookingPageText[language].step2.header}</h2>
                <h3>{bookingPageText[language].step2.description}</h3>
                
                <div className={s.chooseRoom}>
                    {ROOM_OPTIONS.filter(room => availableRoomTypes.includes(room.id)).map((room) => (
                        <div 
                            key={room.id}
                            className={`${s.roomOption} ${roomType === room.id ? s.active : ''}`}
                            onClick={() => {
                                setRoomType(room.id);
                            }}
                        >
                            {room.label}
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