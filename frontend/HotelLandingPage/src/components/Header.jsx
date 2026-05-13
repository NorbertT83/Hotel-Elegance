import { HashLink } from 'react-router-hash-link';
import { useLanguage } from '../context/LanguageContext';
import { landingPageText } from '../translations.js';

export default function Header() {
    const { language } = useLanguage();
    const text = landingPageText[language].header;

    return (
        <header className="header">
            <div className="header-container">
                <div className="logo">Hotel Elegance</div>
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