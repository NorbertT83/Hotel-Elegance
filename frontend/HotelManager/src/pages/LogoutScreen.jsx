import s from '../styles/LoginScreen.module.css'
import { useUser } from '../context/UserContext'

import LanguageSelector from '../components/LanguageSelector';

const LogoutScreen = () => {
    const {logout} = useUser();
    logout();
    
    return (
        <div className={s.container}>
            <LanguageSelector />
            <div>Logged out</div>
        </div>
    );
};

export default LogoutScreen;