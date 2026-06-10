import { HashLink } from 'react-router-hash-link';
import { useLanguage } from '../context/LanguageContext';
import { useGuest } from '../context/GuestContext';
import { landingPageText } from '../utils/translations';
import Logo from '../assets/HE-logo.png'

export default function Header() {
    const { language } = useLanguage();
    const { guest, logout } = useGuest();
    const labels = landingPageText[language].header;


    return (
        <header className="header">
            <div className="header-container">
                <div className="logo"><img src={Logo} alt="Logo" />
                    <HashLink smooth to="/#">Hotel Elegance</HashLink>
                </div>
                <nav className="nav-links">
                    <HashLink smooth to="/#rooms"> {labels.navLinks[0]} </HashLink>
                    <HashLink smooth to="/#services"> {labels.navLinks[1]} </HashLink>
                    <HashLink smooth to="/#gallery"> {labels.navLinks[2]} </HashLink>
                    <HashLink smooth to="/#aboutus"> {labels.navLinks[3]} </HashLink>
                </nav>
                {guest ? 
                    <button  className="btn btn-primary" onClick={logout}> {labels.logout} </button>
                :
                    <HashLink smooth to="/#booking" className="btn btn-primary"> {labels.bookNow} </HashLink>
                }
            </div>
        </header>
    )
}

const fillStyle = { fontVariationSettings: "'FILL' 1" }