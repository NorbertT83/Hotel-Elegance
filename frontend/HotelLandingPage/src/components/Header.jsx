import LanguageSelector from './LanguageSelector.jsx';
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
                    <a href="#">{text.navLinks[0]}</a>
                    <a href="#">{text.navLinks[1]}</a>
                    <a href="#">{text.navLinks[2]}</a>
                    <a href="#">{text.navLinks[3]}</a>
                </nav>
                <button className="btn btn-primary">{text.bookNow}</button>
                <LanguageSelector></LanguageSelector>                
            </div>
        </header>
    )
}

