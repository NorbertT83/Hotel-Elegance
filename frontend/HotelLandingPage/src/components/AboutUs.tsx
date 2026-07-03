import Logo from '../assets/HE-Logo.png'
import { useLanguage } from '../context/LanguageContext'
import { landingPageText } from '../translations'

export default function AboutUs() {
    const { language } = useLanguage();
    const text = landingPageText[language].aboutus;

    return (
        <section className="aboutus-section" id="aboutus">
            <h2>{text.title}</h2>
            <div className='aboutus-wrapper'>
                <img src={Logo} alt="logo" />
                <p>{text.description1}</p>
                <p></p>
                <p>{text.description2}</p>
            </div>
        </section>
    )
}
