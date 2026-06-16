import { useGuest } from "../../context/GuestContext";
import { useLanguage } from "../../context/LanguageContext";
import { guestPageText } from "../../utils/translations";
import s from '../../styles/GuestSubPages.module.css';

const statusIcons = {
    created: 'order_approve',
    pending: 'schedule',
    completed: 'check_circle',
    deleted: 'contract_delete'
}

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
                    <div className={s.serviceTableHead}>
                        <span> {labels.serviceCard.description} </span>
                        <span> {labels.serviceCard.latestUpdate} </span>
                        <span> {labels.serviceCard.status} </span>
                    </div>
                    {currentBookedServices.map((sb) => (
                        <div key={sb.id} className={s.serviceItem}>
                            <span>{sb[`name_${language}`]}</span>
                            <span>{sb.updated_at}</span>
                            <span style={{color: sb.status=='completed' ? "green" : "gray"}} title={labels.serviceCard[sb.status]} className="material-symbols-outlined">{statusIcons[sb.status]}</span>
                        </div>
                    ))}
                </div>
            </div>

        </div>
    )
}
