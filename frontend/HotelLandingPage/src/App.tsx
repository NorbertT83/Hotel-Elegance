import { Routes, Route, BrowserRouter } from 'react-router-dom'
import { LanguageProvider } from './context/LanguageContext'
import Header from './components/Header'
import HomePage from './pages/HomePage'
import BookingPage from './pages/BookingPage'
import LoginPage from './pages/LoginPage'
import GuestPage from './pages/GuestPage'
import Footer from './components/Footer'
import WelcomeModal from './components/WelcomeModal'
import { GuestProvider } from './context/GuestContext'


function App() {
    return (
    <>
        <LanguageProvider>
            <GuestProvider>
                <BrowserRouter basename="/hotelelegance">
                    <WelcomeModal />
                    <Header />
                    <Routes>
                        <Route path="/" element={<HomePage />} />
                        <Route path="/booking" element={<BookingPage />} />
                        <Route path="/guest/login" element={<LoginPage />} />
                        <Route path="/guest" element={<GuestPage />} />

                        <Route path="*" element={<HomePage />} />
                    </Routes>
                    <Footer />
                </BrowserRouter>
            </GuestProvider>
        </LanguageProvider>
    </>
    )
}

export default App