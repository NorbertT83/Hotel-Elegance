import { HashLink } from 'react-router-hash-link';
import { useLanguage } from '../context/LanguageContext';
import { landingPageText } from '../utils/translations';
import LanguageSelector from './LanguageSelector';

export default function Footer() {
    const { language } = useLanguage();
    const text = landingPageText[language].footer;

    return (
        <footer className="footer">
            <div className="footer-container">
                <div className="footer-brand">
                    <div className="footer-logo">
                        <HashLink smooth to="/#">Hotel Elegance
                        <span>
                            <span className="material-symbols-outlined stars">star</span>
                            <span className="material-symbols-outlined stars">star</span>
                            <span className="material-symbols-outlined stars">star</span>
                            <span className="material-symbols-outlined stars">star</span>
                        </span>
                        </HashLink>
                    </div>
                    <p>{text.brandDescription}</p>
                </div>
                <div className="footer-links-grid">
                    <div className="footer-col">
                        <h4>{text.legalTitle}</h4>
                        <a href="#">{text.privacyPolicy}</a>
                        <a href="#">{text.terms}</a>
                    </div>
                    <div className="footer-col">
                        <h4>{text.contactTitle}</h4>
                        <a href="#">{text.contact}</a>
                        <a href="#">{text.press}</a>
                    </div>
                    <div className="footer-col footer-address">
                        <h4>{text.locationTitle}</h4>
                        <address>
                            <span>{text.addressLine1}</span><br/>
                            <span>{text.addressLine2}</span><br/>
                            <a href="mailto:info@hotelelegance.hu" className="email-link">{text.email}</a>
                        </address>
                    </div>
                </div>
                <div className="footer-bottom">
                    <span>{text.copyright}</span>
                </div>
            </div>
            <LanguageSelector />
        </footer>
    )
}