import EliteImg from '../assets/elite_room.png';
import SuiteImg from '../assets/suite_room.png';


export default function Rooms() {
    return (
        <section className="rooms-section">
            <div className="section-header">
                <h2>Lakosztályaink</h2>
                <p>Gondosan kialakított terek a tökéletes kikapcsolódásért és a kifinomult kényelemért.</p>
            </div>
            <div className="rooms-grid">
                <div className="room-card">
                    <div className="room-img-container">
                        <img src={EliteImg} alt="A Grand Ivory lakosztály" />
                    </div>
                    <div className="room-content">
                        <div className="room-header">
                            <h3>The Grand Ivory</h3>
                            <span className="price">$850<span>/éjszaka</span></span>
                        </div>
                        <p className="room-desc">Tágas saroklakosztály panorámás kilátással, privát terasszal és egyedi készítésű bútorokkal, lágy pezsgő színekben.</p>
                        <a className="link-with-icon" href="#">
                            Lakosztály megtekintése <span className="material-symbols-outlined">arrow_forward</span>
                        </a>
                    </div>
                </div>
                <div className="room-card">
                    <div className="room-img-container">
                        <img src={SuiteImg} alt="A Teraszos Penthouse" />
                    </div>
                    <div className="room-content">
                        <div className="room-header">
                            <h3>The Terrace Penthouse</h3>
                            <span className="price">$1,200<span>/éjszaka</span></span>
                        </div>
                        <p className="room-desc">Magas szintű kényelem körbefutó erkéllyel, külön étkezővel és a visszafogott luxus iránti kivételes figyelemmel.</p>
                        <a className="link-with-icon" href="#">
                            Lakosztály megtekintése <span className="material-symbols-outlined">arrow_forward</span>
                        </a>
                    </div>
                </div>
            </div>
        </section>
    )
}