import { useGuest } from '../context/GuestContext'
import { Navigate } from 'react-router-dom'
import s from '../styles/GuestPage.module.css'

export default function GuestPage() {
    const { guest, isLoading, logout } = useGuest();

    if (isLoading) {
        return <div>Betöltés...</div>;
    }

    if (!guest) {
        return <Navigate to="/guest/login" />;
    }
    
    return (
        <div className={s.guestSection}>
            <div className={s.sidebar}>Sidebar</div>
            <div className={s.content}>Content</div>
        </div>
    );
}