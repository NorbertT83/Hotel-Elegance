import { useLanguage } from '../../context/LanguageContext';
import { useBooking } from '../../context/BookingContext';
import { bookingPageText } from '../../utils/translations';
import { useMemo } from 'react';
import s from '../../styles/BookingPage.module.css';
import { RoomType } from '../../types/booking';


export default function Step2RoomSelection()  {
    const { freeRooms, roomTypeChosen, setFreeRooms, setRoomTypeChosen, nextStep, prevStep } = useBooking();
    const { language } = useLanguage();
    const availableRoomTypes = [...new Set(freeRooms.map(room => room.room_type))];
    const filteredRooms = freeRooms.filter(r => r.room_type === roomTypeChosen);

    const roomOptions = [
        { value: 'standard', label: "Standard Elegance" },
        { value: 'deluxe', label: "Grand Ivory" },
        { value: 'suite', label: "Panorama Penthouse" }
    ];

    
    const availableExtras = useMemo(() => {
        if (!roomTypeChosen) return {};
        
        return {
            has_balcony: filteredRooms.some(r => r.has_balcony === 1),
            garden: filteredRooms.some(r => r.has_view === 'garden'),
            panorama: filteredRooms.some(r => r.has_view === 'panorama'),
            jacuzzi: filteredRooms.some(r => r.extras?.includes("jacuzzi")),
            kitchen: filteredRooms.some(r => r.extras?.includes("kitchen")),
        };
    }, [roomTypeChosen, freeRooms]);

    console.log(availableExtras);

    return (
        <div className={s.cardContainer}>
            <div className={s.card}>
                <h2>{bookingPageText[language].step2.header}</h2>
                <h3>{bookingPageText[language].step2.description}</h3>
                
                <div className={s.chooseRoom}>
                    {availableRoomTypes.map((availRoom) => (
                        <div 
                            key={availRoom}
                            className={`${s.roomOption} ${roomTypeChosen === availRoom ? s.active : ''}`}
                            onClick={() => {
                                setRoomTypeChosen(roomOptions.find(r => r.value === availRoom)?.value as RoomType);
                            }}
                        >
                            {roomOptions.find(r => r.value === availRoom)?.label}
                        </div>
                    ))}
                </div>

                <div className={s.buttonContainer}>
                    <button className="btn btn-secondary" onClick={prevStep}>
                        {bookingPageText[language].step2.prevButton}
                    </button>
                    <button className="btn btn-primary" onClick={() => {
                        setFreeRooms(filteredRooms);
                        nextStep()}
                    }>
                        <span>{bookingPageText[language].step2.nextButton}</span><span className="material-symbols-outlined">arrow_forward</span>
                    </button>
                </div>
            </div>
        </div>
    );
}