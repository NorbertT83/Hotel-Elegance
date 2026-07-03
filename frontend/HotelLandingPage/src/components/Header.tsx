import { HashLink } from 'react-router-hash-link';
import { useNavigate, useLocation } from 'react-router-dom';
import { useLanguage } from '../context/LanguageContext';
import { useGuest } from '../context/GuestContext';
import { landingPageText } from '../translations';
import Logo from '../assets/HE-logo.png'

export default function Header() {
    const { language } = useLanguage();
    const { guest, logout } = useGuest();
    const navigate = useNavigate();
    const location = useLocation();
    const isGuestPage = location.pathname === '/guest';
    const labels = landingPageText[language].header;


    return (
        <header className="header">
            <div className="header-container">
                <HashLink smooth to="/#" className="logo">
                    <img src={Logo} alt="Logo" />
                    Hotel Elegance
                </HashLink>
                <nav className="nav-links">
                    <HashLink smooth to="/#rooms"> {labels.navLinks[0]} </HashLink>
                    <HashLink smooth to="/#services"> {labels.navLinks[1]} </HashLink>
                    <HashLink smooth to="/#gallery"> {labels.navLinks[2]} </HashLink>
                    <HashLink smooth to="/#aboutus"> {labels.navLinks[3]} </HashLink>
                </nav>
                {guest ? <div className="btn-container">
                        {!isGuestPage && (
                            <>
                                <button className="btn btn-light" onClick={() => navigate('/guest')}><span className='material-symbols-outlined'>person</span></button>
                                <div className='separator'></div>
                            </>
                        )}
                        <button className="btn btn-light" onClick={logout} title={language === 'hu' ? 'Kijelentkezés' : 'Logout'}>
                            <span className='material-symbols-outlined'>logout</span>
                        </button>
                    </div>
                :
                    <HashLink smooth to="/#booking" className="btn btn-primary"> {labels.bookNow} </HashLink>
                }
            </div>
        </header>
    )
}
