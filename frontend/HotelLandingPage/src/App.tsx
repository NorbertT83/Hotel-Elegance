import { Routes, Route, BrowserRouter } from 'react-router-dom'
import { LanguageProvider } from './context/LanguageContext'
import Header from './components/Header'
import HomePage from './pages/HomePage'
import BookingPage from './pages/BookingPage'
import Footer from './components/Footer'
import HotelWelcome from './components/HotelWelcome'


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