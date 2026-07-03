import { useMemo } from "react";
import { calculateBookingPrice, fmt } from "../../utils/utils";
import s from "../../styles/BookingPage.module.css";
import { useLanguage } from "../../context/LanguageContext";
import { bookingPageText } from "../../translations";
import { roomSupportsExtra, useBooking } from "../../context/BookingProcessContext";

export default function Step4Summary() {
    const { language } = useLanguage();
    const { bookingState, roomsForSelectedType, filteredRooms, prevStep, nextStep, pricing } = useBooking();
    const labels = bookingPageText[language].step4;
    type Step4Keys = keyof typeof labels;

    const referenceRoom = useMemo(() => {
            const selectedRoom = filteredRooms[0] ?? null;
            const matchingRooms = roomsForSelectedType.filter((room) =>
                bookingState.extrasChosen.every((chosenExtra) => roomSupportsExtra(room, chosenExtra))
            );
    
            if (selectedRoom && matchingRooms.some((room) => room.room_number === selectedRoom.room_number)) {
                return selectedRoom;
            }
    
            return [...matchingRooms].sort((a, b) => a.price_per_night - b.price_per_night)[0] ?? selectedRoom ?? roomsForSelectedType[0] ?? null;
        }, [bookingState.extrasChosen, filteredRooms, roomsForSelectedType]);

    const price = useMemo(
        () => calculateBookingPrice(bookingState, referenceRoom, pricing),
        [bookingState, referenceRoom, pricing]
    );

    const priceLabels = labels.priceBox;

    return (
            <div className={s.cardContainer}>
            <div className={s.card}>
                <h2>{labels.header}</h2>
                <h3>{labels.description}</h3>

                    <div className={s.priceSummary}>
                        <div className={s.priceSummaryHeader}>
                            <span className="material-symbols-outlined">receipt_long</span>
                            {priceLabels.title}
                        </div>
                        <div className={s.priceSummaryRows}>
                            {/* Room base */}
                            <div className={s.priceRow}>
                                <span className={s.priceLabel}>
                                    <span className="material-symbols-outlined">hotel</span>
                                    {priceLabels.roomBase}
                                    <span style={{ opacity: .65, fontSize: '.8rem' }}>
                                        ({fmt(price.pricePerNight)}{priceLabels.perNight} × {price.nights} {priceLabels.nights})
                                    </span>
                                </span>
                                <span className={s.priceAmount}>{fmt(price.roomBaseTotal)}</span>
                            </div>

                            {/* Catering surcharge (only when > 0) */}
                            {price.cateringExtra > 0 && (
                                <div className={s.priceRow}>
                                    <span className={s.priceLabel}>
                                        <span className="material-symbols-outlined">restaurant</span>
                                        {priceLabels.catering}
                                        <span style={{ opacity: .65, fontSize: '.8rem' }}>
                                            ({fmt(price.cateringMultiplier)}{labels.priceBox.perPersonPerNight})
                                        </span>
                                    </span>
                                    <span className={s.priceAmount}>+{fmt(price.cateringExtra)}</span>
                                </div>
                            )}

                            {/* Flat-fee extras */}
                            {price.flatFeeExtras.map(({ key, amount }) => (
                                <div key={key} className={s.priceRow}>
                                    <span className={s.priceLabel}>
                                        <span className="material-symbols-outlined">add_circle</span>
                                        {labels[key as Step4Keys] as string}
                                    </span>
                                    <span className={s.priceAmount}>+{fmt(amount)}</span>
                                </div>
                            ))}

                            <div className={s.priceRowDivider} />

                            {/* Total */}
                            <div className={s.priceRowTotal}>
                                <span>{priceLabels.total}</span>
                                <span className={s.priceAmount}>{fmt(price.total)}</span>
                            </div>
                        </div>
                    </div>
                    <div className={s.buttonContainer}>
                        <button className="btn btn-secondary" onClick={prevStep}>
                            {labels.prevButton}
                        </button>
                        <button className={`btn btn-primary`} onClick={nextStep}>
                            <span>{labels.nextButton}</span><span className="material-symbols-outlined">arrow_forward</span>
                        </button>
                </div>
            </div>
        </div>
    )

}
