import './App.css'
import { LanguageProvider } from './context/LanguageContext.jsx';
import Header from './components/Header.jsx';
import Footer from './components/Footer.jsx';
import Hero from './components/Hero.jsx';
import Booking from './components/Booking.jsx';
import Rooms from './components/Rooms.jsx';

function App() {
    return (
    <>
    <LanguageProvider>
        <Header>
        </Header>
        <main>
            <Hero></Hero>
            <Booking></Booking>
            <Rooms></Rooms>
        </main>
        <Footer></Footer>
    </LanguageProvider>
    </>
    )
}

export default App