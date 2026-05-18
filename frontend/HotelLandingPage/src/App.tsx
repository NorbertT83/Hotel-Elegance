import { Routes, Route, BrowserRouter } from 'react-router-dom';
import { LanguageProvider } from './context/LanguageContext.js';
import Header from './components/Header.js';
import HomePage from './pages/HomePage.jsx';
import BookingPage from './pages/BookingPage.jsx';
import Footer from './components/Footer.js';
import HotelWelcome from './components/HotelWelcome.js';


function App() {
    return (
    <>
        <LanguageProvider>
            <BrowserRouter>
                <Header />
                <Routes>
                    <Route path="/" element={<HomePage />} />
                    <Route path="/booking" element={<BookingPage />} />
                    <Route path="/welcome" element={<HotelWelcome />} />
                    <Route path="*" element={<HomePage />} />
                </Routes>
                <Footer />
            </BrowserRouter>
        </LanguageProvider>
    </>
    )
}

export default App