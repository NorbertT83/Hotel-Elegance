import s from '../../styles/BookingPage.module.css';
import { CateringType, ExtraOption } from '../../types/booking';
import { bookingPageText } from '../../utils/translations';
import { useLanguage } from '../../context/LanguageContext';
import { roomSupportsExtra, useBooking } from '../../context/BookingProcessContext';

export default function Step3ExtraOptions() {
    const { language } = useLanguage();
    const labels = bookingPageText[language].step3;
    const { bookingState, roomsForSelectedType, setFilteredRooms, extraOptions, setBookingState, prevStep, nextStep } = useBooking();
    
    type Step3Keys = keyof typeof labels;
    const cateringOptions = ['breakfast', 'halfboard', 'fullboard'] as CateringType[];


    const handleSmartCheckboxChange = (e: React.ChangeEvent<HTMLInputElement>) => {
        const clickedOption = e.target.id as ExtraOption;
        
            let newExtrasChosen = bookingState.extrasChosen.includes(clickedOption)
            ? bookingState.extrasChosen.filter(id => id !== clickedOption)
            : [...bookingState.extrasChosen, clickedOption];

        const turnsOn = newExtrasChosen.includes(clickedOption);

        if (turnsOn && ['jacuzzi', 'kitchen'].includes(clickedOption)) {
            const hasOnlyJacuzziRoom = roomsForSelectedType.some(r => roomSupportsExtra(r, 'jacuzzi') && !roomSupportsExtra(r, 'kitchen'));
            const hasOnlyKitchenRoom = roomsForSelectedType.some(r => !roomSupportsExtra(r, 'jacuzzi') && roomSupportsExtra(r, 'kitchen'));

            // Ha a jacuzzit nyomta meg, de nincs CSAK jacuzzis szoba (de van kombinált)
            if (clickedOption === 'jacuzzi' && !hasOnlyJacuzziRoom) {
                if (!newExtrasChosen.includes('kitchen')) {
                    newExtrasChosen.push('kitchen');
                }
            }
            
            // Ha a konyhát nyomta meg, de nincs CSAK konyhás szoba (de van kombinált)
            if (clickedOption === 'kitchen' && !hasOnlyKitchenRoom) {
                if (!newExtrasChosen.includes('jacuzzi')) {
                    newExtrasChosen.push('jacuzzi');
                }
            }
        }

        setBookingState(prev => ({
            ...prev,
            extrasChosen: newExtrasChosen
        }));
    };

    return (
        <div className={s.cardContainer}>
            <div className={s.card}>
                <h2>{labels.header}</h2>
                <h3>{labels.description}</h3>
                <div className={s.chooseExtras}>
                    <div className={s.radioGroup}>
                        <p>{labels.catering}</p>
                        {cateringOptions.map((option) => (
                            <label key={option} htmlFor={option}>
                                <input
                                    type="radio"
                                    id={option}
                                    name="catering"
                                    value={option}
                                    checked={bookingState.cateringChosen === option}
                                    onChange={(e) => setBookingState(p => ({ ...p, cateringChosen: e.target.value as CateringType }))}
                                />
                                {labels[option as Step3Keys]} <span>{labels[`${option}Note` as Step3Keys]}</span>
                            </label>
                        ))}
                    </div>
                    <div className={s.checkboxGroup}>
                        <p>{labels.extras}</p>
                        {extraOptions.map((option) => {
                            const isChecked = bookingState.extrasChosen.includes(option as ExtraOption);

                            const hasMatchingRoom = roomsForSelectedType.some((room) => {
                                const matchesCurrentSelected = bookingState.extrasChosen.every((chosen) =>
                                    roomSupportsExtra(room, chosen)
                                );
                                const matchesThisOption = roomSupportsExtra(room, option);
                                return matchesCurrentSelected && matchesThisOption;
                            });

                            const isDisabled = !isChecked && !hasMatchingRoom;

                            return (
                                <label key={option} htmlFor={option}>
                                    <input 
                                        type="checkbox" 
                                        id={option} 
                                        name="extras"
                                        checked={isChecked}
                                        disabled={isDisabled}
                                        onChange={handleSmartCheckboxChange}
                                    />
                                    {labels[option as Step3Keys]}
                                </label>
                            );
                        })}
                    </div>
                </div>
                <div className={s.extraInfo}>{labels.extraInfo}</div>
                <div className={s.buttonContainer}>
                    <button className="btn btn-secondary" onClick={prevStep}>
                        {labels.prevButton}
                    </button>

                    <button 
                        className="btn btn-primary" 
                        onClick={() => {
                            const roomsForSelectedType = bookingState.freeRooms.filter(
                                room => room.room_type === bookingState.roomTypeChosen
                            );

                            let finalExtrasChosen = [...bookingState.extrasChosen];

                            const hasJacuzziChosen = finalExtrasChosen.includes('jacuzzi');
                            const hasKitchenChosen = finalExtrasChosen.includes('kitchen');

                            const hasOnlyJacuzziRoom = roomsForSelectedType.some(r => roomSupportsExtra(r, 'jacuzzi') && !roomSupportsExtra(r, 'kitchen'));
                            const hasOnlyKitchenRoom = roomsForSelectedType.some(r => !roomSupportsExtra(r, 'jacuzzi') && roomSupportsExtra(r, 'kitchen'));

                            if (hasJacuzziChosen && !hasKitchenChosen && !hasOnlyJacuzziRoom) {
                                finalExtrasChosen.push('kitchen');
                            }
                            
                            if (hasKitchenChosen && !hasJacuzziChosen && !hasOnlyKitchenRoom) {
                                finalExtrasChosen.push('jacuzzi');
                            }

                            if (finalExtrasChosen.length !== bookingState.extrasChosen.length) {
                                setBookingState(p => ({ ...p, extrasChosen: finalExtrasChosen }));
                            }

                            let matchingRooms = roomsForSelectedType.filter((room) => {
                                const matchesSelected = finalExtrasChosen.every((chosenExtra) =>
                                    roomSupportsExtra(room, chosenExtra)
                                );
                                if (!matchesSelected) return false;

                                const roomLevelOptions: ExtraOption[] = ['jacuzzi', 'kitchen'];
                                for (const option of roomLevelOptions) {
                                    const isRequested = finalExtrasChosen.includes(option);
                                    const hasIt = roomSupportsExtra(room, option);

                                    if (!isRequested && hasIt) {
                                        return false; 
                                    }
                                }
                                return true;
                            });

                            if (matchingRooms.length === 0) {
                                matchingRooms = roomsForSelectedType.filter((room) =>
                                    finalExtrasChosen.every((chosenExtra) =>
                                        roomSupportsExtra(room, chosenExtra)
                                    )
                                );
                            }

                            if (matchingRooms.length > 0) {
                                const sortedRooms = [...matchingRooms].sort((a, b) => b.room_number - a.room_number);
                                setFilteredRooms([sortedRooms[0]]);
                            } else {
                                setFilteredRooms([]);
                            }

                            nextStep();
                        }}
                    >
                        <span>{labels.nextButton}</span>
                        <span className="material-symbols-outlined">arrow_forward</span>
                    </button>
                </div>
            </div>
        </div>
    );
}