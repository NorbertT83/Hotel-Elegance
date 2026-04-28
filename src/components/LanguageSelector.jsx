import React from 'react'
import { useUser } from '../context/UserContext'

export default function LanguageSelector() {
    const { loggedInUser, setLoggedInUser } = useUser();

    function handleLangChange(newLang) {
        setLoggedInUser({ ...loggedInUser, lang: newLang });
    };

    return (
        <div id="language-selector">
            <button 
                className={`btn-subtle ${loggedInUser.lang === 'hu' ? 'active' : ''}`} 
                id="lang-hu" 
                onClick={() => handleLangChange('hu')}
            >
                HU
            </button>
            
            <span style={{ color: 'lightgray' }}>|</span>
            
            <button 
                className={`btn-subtle ${loggedInUser.lang === 'en' ? 'active' : ''}`} 
                id="lang-en" 
                onClick={() => handleLangChange('en')}
            >
                EN
            </button>
        </div>
    )
}