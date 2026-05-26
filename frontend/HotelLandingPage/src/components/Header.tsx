import { HashLink } from 'react-router-hash-link';
import { useLanguage } from '../context/LanguageContext';
import { landingPageText } from '../utils/translations';
import Logo from '../assets/HE-logo.png'

export default function Header() {
    const { language } = useLanguage();
    const text = landingPageText[language].header;

    return (
        <header className="header">
            <div className="header-container">
                <div className="logo"><img src={Logo} alt="Logo" />
                    <HashLink smooth to="/#">Hotel Elegance
                        <span className='stars'>
                            <span className="material-symbols-outlined stars">star</span>
                            <span className="material-symbols-outlined stars">star</span>
                            <span className="material-symbols-outlined stars">star</span>
                            <span className="material-symbols-outlined stars">star</span>
                        </span>
                    </HashLink>
                </div>
                <nav className="nav-links">
                    <HashLink smooth to="/#rooms"> {text.navLinks[0]} </HashLink>
                    <HashLink smooth to="/#services"> {text.navLinks[1]} </HashLink>
                    <HashLink smooth to="/#gallery"> {text.navLinks[2]} </HashLink>
                    <HashLink smooth to="/#aboutus"> {text.navLinks[3]} </HashLink>
                </nav>
                <HashLink smooth to="/#booking" className="btn btn-primary"> {text.bookNow} </HashLink>
            </div>
        </header>
    )
}

const fillStyle = { fontVariationSettings: "'FILL' 1" }