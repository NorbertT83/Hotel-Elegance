import { useLanguage } from '../context/LanguageContext';
import { landingPageText } from '../translations';
import { RoomType } from '../types/booking';

export default function Rooms({ openRoomModal }: { openRoomModal: (roomType: RoomType) => void }) {
    const { language } = useLanguage();
    const text = landingPageText[language].rooms;

    return (
        <section className="rooms-section" id="rooms">
            <div className="section-header">
                <h2>{text.sectionTitle}</h2>
                <p>{text.sectionDescription}</p>
            </div>
                <div className="rooms-grid">
                    {Object.entries(text.types).map(([roomType, card]) => (
                        <div className="room-card" key={roomType}> 
                            <div className="room-img-container">
                                <img src={card.imageURL} alt={card.imageAlt} />
                            </div>
                            <div className="room-content">
                                <div className="room-header">
                                    <h3>{card.title}</h3>
                                    <span className="price">{card.price}<span>{card.priceSuffix}</span></span>
                                </div>
                                <p className="room-desc">{card.description}</p>
                                
                                <div className="link-with-icon" onClick={() => openRoomModal(roomType as RoomType)}>
                                    {card.linkText} <span className="material-symbols-outlined">arrow_forward</span>
                                </div>
                            </div>
                        </div>
                    ))}
                </div>
        </section>
    )
}