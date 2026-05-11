import HeroImg from '../assets/hero_photo.png';

export default function Hero() {
    return (
        <section className="hero">
            <div className="hero-bg">
                <img src={HeroImg} alt="Luxus hotel szoba belső tere" />
                <div className="hero-overlay"></div>
            </div>
            <div className="hero-content">
                <h1 className="hero-title">Elegancia minden részletben</h1>
                <p className="hero-subtitle">Tapasztalja meg a nyugalom és a visszafogott luxus szentélyét, ahol a kifogástalan kiszolgálás időtlen dizájnnal párosul.</p>
            </div>
        </section>
    )
}