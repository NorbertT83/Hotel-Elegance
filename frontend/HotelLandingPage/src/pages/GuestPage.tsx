import { useState } from 'react';
import { useGuest } from '../context/GuestContext'
import { Navigate } from 'react-router-dom'
import s from '../styles/GuestPage.module.css'
import { guestPageText } from '../utils/translations';
import { useLanguage } from '../context/LanguageContext';


export default function GuestPage() {
    const { guest, currentBooking, currentRoom, isLoading, logout } = useGuest();
    const { language } = useLanguage();
    const sidebarMenuItems = guestPageText[language].guestPage.sidebarMenuItems;
    const menuOverviewLabels = guestPageText[language].guestPage.menuOverview
    const [menuIndexSelected, setMenuIndexSelected] = useState<number>(0);

    if (isLoading) {
        return <div>Betöltés...</div>;
    }

    if (!guest) {
        return <Navigate to="/guest/login" />;
    }
    
    return (
        <div className={s.guestSection}>
            <div className={s.sidebar}>
                <ul>
                    {sidebarMenuItems.map((item, index) => (
                        <li key={item} className={ menuIndexSelected===index ? s.selected : '' } onClick={() => setMenuIndexSelected(index)}>{item.toLocaleUpperCase()}</li>
                    ))}
                </ul>
            </div>
            <div className={s.cardWrapper}>

                <div className={`${s.card} ${s.guestCard}`}>
                    <div className={s.cardHeader}>
                        {menuOverviewLabels.guestCard.headerText}
                    </div>
                    <div className={s.content}>
                        <table>
                        <tbody>
                            <tr>
                                <td>{menuOverviewLabels.guestCard.nameText}</td>
                                <td>{guest.lname} {guest.fname}</td>
                            </tr>
                            <tr>
                                <td>{menuOverviewLabels.guestCard.emailText}</td>
                                <td>{guest.email}</td>
                            </tr>
                            <tr>
                                <td rowSpan={3}>{menuOverviewLabels.guestCard.addressText}</td>
                                <td>{guest.country} {guest.zip_code}</td>
                            </tr>
                            <tr><td> {guest.city}</td></tr>
                            <tr><td> {guest.street}</td></tr>

                        </tbody>
                        </table>
                    </div>
                </div>

                <div className={`${s.card} ${s.roomCard}`}>
                    <div className={s.cardHeader}>
                        {menuOverviewLabels.roomCard.headerText}
                    </div>
                    <div className={s.content}>
                        <p>{currentRoom?.room_number}</p>
                        <p>{currentRoom?.floorspace} m2</p>
                        <p>{currentRoom?.bedtype}</p>
                        <p>{currentRoom?.status}</p>
                    </div>
                </div>

            </div>
        </div>
    );
}