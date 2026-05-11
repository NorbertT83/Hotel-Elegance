import s from '../styles/LanguageSelector.module.css'
import { useLanguage } from '../context/LanguageContext';

export default function LanguageSelector() {
    const { language, setLanguage } = useLanguage();

    return (
        <div className={s.languageSelector}>
            <button 
                className={`btn-subtle ${language === 'hu' ? s.active : ''}`} 
                id="lang-hu" 
                onClick={() => setLanguage('hu')}
            >
                HU
            </button>
            
            <span style={{ color: 'lightgray', pointerEvents: 'none' }}>|</span>
            
            <button 
                className={`btn-subtle ${language === 'en' ? s.active : ''}`} 
                id="lang-en" 
                onClick={() => setLanguage('en')}
            >
                EN
            </button>
        </div>
    )
}