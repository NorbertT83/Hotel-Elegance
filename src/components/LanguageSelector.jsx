import { useGlobal } from '../context/GlobalContext';

export default function LanguageSelector() {
    const { language, setLanguage } = useGlobal();

    return (
        <div id="language-selector">
            <button 
                className={`btn-subtle ${language === 'hu' ? 'active' : ''}`} 
                id="lang-hu" 
                onClick={() => setLanguage('hu')}
            >
                HU
            </button>
            
            <span style={{ color: 'lightgray' }}>|</span>
            
            <button 
                className={`btn-subtle ${language === 'en' ? 'active' : ''}`} 
                id="lang-en" 
                onClick={() => setLanguage('en')}
            >
                EN
            </button>
        </div>
    )
}