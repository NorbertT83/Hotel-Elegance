import EliteImg from '../assets/elite_room.png';
import SuiteImg from '../assets/suite_room.png';
import { useLanguage } from '../context/LanguageContext';
import { landingPageText } from '../translations.js';

export default function Rooms() {
    const { language } = useLanguage();
    const text = landingPageText[language].rooms;

    return (
        <section className="rooms-section">
            <div className="section-header">
                <h2>{text.sectionTitle}</h2>
                <p>{text.sectionDescription}</p>
            </div>
            <div className="rooms-grid">
                <div className="room-card">
                    <div className="room-img-container">
                        <img src={EliteImg} alt={text.cards[0].imageAlt} />
                    </div>
                    <div className="room-content">
                        <div className="room-header">
                            <h3>{text.cards[0].title}</h3>
                            <span className="price">{text.cards[0].price}<span>{text.cards[0].priceSuffix}</span></span>
                        </div>
                        <p className="room-desc">{text.cards[0].description}</p>
                        <a className="link-with-icon" href="#">
                            {text.cards[0].linkText} <span className="material-symbols-outlined">arrow_forward</span>
                        </a>
                    </div>
                </div>
                <div className="room-card">
                    <div className="room-img-container">
                        <img src={SuiteImg} alt={text.cards[1].imageAlt} />
                    </div>
                    <div className="room-content">
                        <div className="room-header">
                            <h3>{text.cards[1].title}</h3>
                            <span className="price">{text.cards[1].price}<span>{text.cards[1].priceSuffix}</span></span>
                        </div>
                        <p className="room-desc">{text.cards[1].description}</p>
                        <a className="link-with-icon" href="#">
                            {text.cards[1].linkText} <span className="material-symbols-outlined">arrow_forward</span>
                        </a>
                    </div>
                </div>
            </div>
        </section>
    )
}