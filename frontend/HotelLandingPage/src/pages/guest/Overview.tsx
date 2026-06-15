import { useGuest } from "../../context/GuestContext";
import { useLanguage } from "../../context/LanguageContext";
import { guestPageText } from "../../utils/translations";
import s from '../../styles/GuestSubPages.module.css';

export default function Overview() {
    const { language }= useLanguage();
    const { guest, currentBooking, currentRoom, currentBookedServices } = useGuest();
    const labels = guestPageText[language].guestPage.menuOverview;

    if (!guest) return;

    return (
        <div className={s.cardWrapper}>
            <div className={`${s.card} ${s.guestCard}`}>
                <div className={s.cardHeader}>
                    <div className={s.headerText}>{labels.guestCard.headerText}</div>
                </div>

                <div className={s.content}>
                    <div>{labels.guestCard.nameText}</div>
                    <div>{guest.lname} {guest.fname}</div>
                    <div>{labels.guestCard.emailText}</div>
                    <div className={s.truncate}>{guest.email}</div>
                    <div className={s.span3}>{labels.guestCard.addressText}</div>
                    <div>{guest.country} {guest.zip_code}</div>
                    <div>{guest.city}</div>
                    <div>{guest.street}</div>
                    {guest.car_plate_number ? <>
                        <div>{labels.guestCard.car}</div>
                        <div>{guest.car_plate_number}</div>
                        </> : ''}
                    
                    <div>{labels.guestCard.nightsSlept}</div>
                    <div>{guest.total_nights}</div>
                    <div>{labels.guestCard.vipLevel}</div>
                    <div>{guest.loyalty_level}</div>
                    <div>{labels.guestCard.currentBooking}</div>
                    <div>{currentBooking?.id}</div>
                </div>
            </div>

            <div className={`${s.card} ${s.roomCard}`}>
                <div className={s.cardHeader}>
                    <div className={s.headerText}>{labels.roomCard.headerText}</div>
                </div>

                <div className={s.content}>
                    <div>{labels.roomCard.roomNumber}</div>
                    <div>{currentRoom?.room_number}</div>

                    <div>{labels.roomCard.roomSize}</div>
                    <div>{currentRoom?.floorspace} m2</div>

                    <div>{labels.roomCard.bedtype}</div>
                    <div>{currentRoom?.bed_type}</div>

                    <div>{labels.roomCard.status}</div>
                    <div>{currentRoom?.status}</div>
                </div>
            </div>

            <div className={`${s.card} ${s.serviceCard}`}>
                <div className={s.cardHeader}>
                    <div className={s.headerText}>{labels.serviceCard.headerText}</div>
                </div>

                <div className={s.content}>
                    {currentBookedServices.map((sb) => (
                        <div key={sb.id} className={s.serviceItem}>
                            <span>{sb.name_hu}</span>

                            {sb.status != 'completed' ?
                                <span style={{color: "gray"}} title={sb.updated_at} className="material-symbols-outlined">hourglass_check</span>
                            :
                                <span style={{color: "green"}} title={sb.updated_at} className="material-symbols-outlined">done_all</span>
                            }
                        </div>
                    ))}
                </div>
            </div>

        </div>
    )
}
