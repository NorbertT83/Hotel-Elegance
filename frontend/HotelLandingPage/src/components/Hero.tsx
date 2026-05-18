import HeroImg from '../assets/hero_photo.png'
import { useLanguage } from '../context/LanguageContext'
import { landingPageText } from '../translations'


export default function Hero() {
    const { language } = useLanguage();
    const text = landingPageText[language].hero;
    return (
        <section className="hero">
            <div className="hero-bg">
                <img src={HeroImg} alt={text.imageAlt} />
                <div className="hero-overlay"></div>
            </div>
            <div className="hero-content">
                <h1 className="hero-title">{text.title}</h1>
                <p className="hero-subtitle">{text.subtitle}</p>
            </div>
        </section>
    )
}