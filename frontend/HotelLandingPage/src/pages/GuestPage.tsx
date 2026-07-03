import s from '../styles/GuestPage.module.css'

import { useState } from 'react';
import { useGuest } from '../context/GuestContext'
import { Navigate } from 'react-router-dom'
import { guestPageText } from '../translations';
import { useLanguage } from '../context/LanguageContext';

import Overview from './guest/Overview'
import RoomService from './guest/RoomService';
import Wellness from './guest/Wellness';
import Extras from './guest/Extras';
import Logistics from './guest/Logistics';

const PAGES = [Overview, RoomService, Wellness, Extras, Logistics];

export default function GuestPage() {
    const { guest, currentBooking, isLoading } = useGuest();
    const { language } = useLanguage();
    const sidebarMenuItems = guestPageText[language].guestPage.sidebarMenuItems;
    const [menuIndexSelected, setMenuIndexSelected] = useState<number>(0);

    if (isLoading) {
        return <div>Betöltés...</div>;
    }

    if (!guest || !currentBooking) {
        return <Navigate to="/guest/login" />;
    }

    const ActivePage = PAGES[menuIndexSelected] || Overview;
    
    return (
        <div className={s.guestSection}>
            <aside className={s.sidebar}>
                <nav>
                    {sidebarMenuItems.map((item, index) => (
                        <li key={item} className={ menuIndexSelected===index ? s.selected : '' }
                            onClick={() => setMenuIndexSelected(index)}>{item.toLocaleUpperCase()}
                        </li>
                    ))}
                </nav>
            </aside>

            <ActivePage />

        </div>
    );
}
