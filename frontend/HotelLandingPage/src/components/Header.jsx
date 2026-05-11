import Logo from '../assets/HE-logo.png'
import LanguageSelector from './LanguageSelector.jsx';

export default function Header() {
    return (
            <header className="header">
            <div className="header-container">
                <div className='logo-img'><img src={Logo} alt="Logo" /></div>

                <div className="logo">Hotel Elegance</div>
                <nav className="nav-links">
                    <a href="#">Szobák</a>
                    <a href="#">Szolgáltatások</a>
                    <a href="#">Galéria</a>
                    <a href="#">Rólunk</a>
                </nav>
                <button className="btn btn-primary">Foglalás most</button>
                <LanguageSelector></LanguageSelector>
                
            </div>
        </header>
    )
}

