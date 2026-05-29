import { useGuest } from "../../context/GuestContext";
import { useLanguage } from "../../context/LanguageContext";
import { guestPageText } from "../../utils/translations";
import s from '../../styles/GuestOverview.module.css';

export default function Overview() {
    const { language }= useLanguage();
    const { guest, currentBooking, currentRoom } = useGuest();
    const menuOverviewLabels = guestPageText[language].guestPage.menuOverview;

    if (!guest) return;

    return (
        <div className={s.cardWrapper}>
            <div className={`${s.card} ${s.guestCard}`}>

                <div className={s.cardHeader}>
                    {menuOverviewLabels.guestCard.headerText}
                </div>

                <div className={s.content}>
                    <div>{menuOverviewLabels.guestCard.nameText}</div>
                    <div>{guest.lname} {guest.fname}</div>
                    <div>{menuOverviewLabels.guestCard.emailText}</div>
                    <div className={s.truncate}>{guest.email}</div>
                    <div className={s.span3}>{menuOverviewLabels.guestCard.addressText}</div>
                    <div>{guest.country} {guest.zip_code}</div>
                    <div>{guest.city}</div>
                    <div>{guest.street}</div>
                    {guest.car_plate_number ? <>
                        <div>Gépjárműve:</div>
                        <div>{guest.car_plate_number}</div>
                        </> : ''}
                    
                    <div>Összes éjszaka:</div>
                    <div>{guest.total_nights}</div>
                    <div>Lojalitási szint:</div>
                    <div>{guest.loyalty_level}</div>
                    <div>Aktuális foglalása:</div>
                    <div>{currentBooking?.id}</div>
                </div>
            </div>

            <div className={`${s.card} ${s.roomCard}`}>
                <div className={s.cardHeader}>
                    {menuOverviewLabels.roomCard.headerText}
                </div>

                <div className={s.content}>
                    <p>Szobaszám: {currentRoom?.room_number}</p>
                    <p>Terület: {currentRoom?.floorspace} m2</p>
                    <p>Ágy: {currentRoom?.bed_type}</p>
                    <p>Állapot: {currentRoom?.status}</p>
                </div>
            </div>

            <div className={`${s.card} ${s.bookingCard}`}>
                <div className={s.cardHeader}>
                    Igénybevett szolgáltatások
                </div>

                <div className={s.content}>
                    <p>Masszázs: {currentRoom?.room_number}</p>
                    <p>Transzfer: {currentRoom?.floorspace} m2</p>
                    <p>Szobaszerviz: {currentRoom?.bed_type}</p>
                </div>
            </div>

        </div>
    )
}
