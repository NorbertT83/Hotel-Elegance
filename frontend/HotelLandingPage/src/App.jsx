import './App.css'
import { BrowserRouter } from 'react-router-dom';
import { LanguageProvider } from './context/LanguageContext.jsx';
import Header from './components/Header.jsx';
import Hero from './components/Hero.jsx';
import Booking from './components/Booking.jsx';
import Rooms from './components/Rooms.jsx';
import Services from './components/Services.jsx';
import Footer from './components/Footer.jsx';

function App() {
    return (
    <>
        <LanguageProvider>
            <BrowserRouter>
                <Header />
                <Hero />
                <Booking />
                <Rooms />
                <Services />
                <Footer />
            </BrowserRouter>
        </LanguageProvider>
    </>
    )
}

export default App