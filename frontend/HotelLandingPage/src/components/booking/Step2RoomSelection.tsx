import { useLanguage } from '../../context/LanguageContext';
import { useBooking } from '../../context/BookingContext';
import { bookingPageText } from '../../utils/translations';
import s from '../../styles/BookingPage.module.css';
import { RoomType } from '../../types/booking';


export default function Step2RoomSelection()  {
    const { language } = useLanguage();
    const labels = bookingPageText[language].step2;
    const { bookingState, setBookingState, setFilteredRooms, nextStep, prevStep  } = useBooking();
    const availableRoomTypes = [...new Set(bookingState.freeRooms.map(room => room.room_type))];

    const roomOptions: { value: RoomType; label: string }[] = [
        { value: 'standard', label: "Standard Elegance" },
        { value: 'deluxe', label: "Grand Ivory" },
        { value: 'suite', label: "Panorama Penthouse" }
    ];

    return (
        <div className={s.cardContainer}>
            <div className={s.card}>
                <h2>{labels.header}</h2>
                <h3>{labels.description}</h3>
                
                <div className={s.chooseRoom}>
                    {availableRoomTypes.map((availRoom) => (
                        <div 
                            key={availRoom}
                            className={`${s.roomOption} ${bookingState.roomTypeChosen === availRoom ? s.active : ''}`}
                            onClick={() => {
                                setBookingState(p => ({ 
                                    ...p, 
                                    roomTypeChosen: roomOptions.find(r => r.value === availRoom)?.value as RoomType,
                                    extrasChosen: [] 
                                }));

                            }}
                        >
                            {roomOptions.find(r => r.value === availRoom)?.label}
                        </div>
                    ))}
                </div>

                <div className={s.buttonContainer}>
                    <button className="btn btn-secondary" onClick={prevStep}>
                        {labels.prevButton}
                    </button>
                    <button className="btn btn-primary" onClick={() => {
                        setFilteredRooms( bookingState.freeRooms.filter(r => r.room_type === bookingState.roomTypeChosen));
                        nextStep()}
                    }>
                        <span>{labels.nextButton}</span><span className="material-symbols-outlined">arrow_forward</span>
                    </button>
                </div>
            </div>
        </div>
    );
}