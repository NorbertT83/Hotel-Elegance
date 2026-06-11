import { useGuest } from "../../context/GuestContext";
import { useLanguage } from "../../context/LanguageContext";
import { guestPageText } from "../../utils/translations";
import s from '../../styles/GuestSubPages.module.css';

export default function Overview() {
    const { language }= useLanguage();
    const { guest, currentBooking, currentRoom, currentBookedServices } = useGuest();
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
                        <div>{menuOverviewLabels.guestCard.car}</div>
                        <div>{guest.car_plate_number}</div>
                        </> : ''}
                    
                    <div>{menuOverviewLabels.guestCard.nightsSlept}</div>
                    <div>{guest.total_nights}</div>
                    <div>{menuOverviewLabels.guestCard.vipLevel}</div>
                    <div>{guest.loyalty_level}</div>
                    <div>{menuOverviewLabels.guestCard.currentBooking}</div>
                    <div>{currentBooking?.id}</div>
                </div>
            </div>

            <div className={`${s.card} ${s.roomCard}`}>
                <div className={s.cardHeader}>
                    {menuOverviewLabels.roomCard.headerText}
                </div>

                <div className={s.content}>
                    <div>{menuOverviewLabels.roomCard.roomNumber}</div>
                    <div>{currentRoom?.room_number}</div>

                    <div>{menuOverviewLabels.roomCard.roomSize}</div>
                    <div>{currentRoom?.floorspace} m2</div>

                    <div>{menuOverviewLabels.roomCard.bedtype}</div>
                    <div>{currentRoom?.bed_type}</div>

                    <div>{menuOverviewLabels.roomCard.status}</div>
                    <div>{currentRoom?.status}</div>
                </div>
            </div>

            <div className={`${s.card} ${s.serviceCard}`}>
                <div className={s.cardHeader}>
                    {menuOverviewLabels.serviceCard.headerText}
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
