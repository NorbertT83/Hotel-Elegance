import { Routes, Route, BrowserRouter } from 'react-router-dom'
import { LanguageProvider } from './context/LanguageContext'
import Header from './components/Header'
import HomePage from './pages/HomePage'
import BookingProcessPage from './pages/BookingProcessPage'
import GuestLoginPage from './pages/GuestLoginPage'
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
                        <Route path="/booking" element={<BookingProcessPage />} />
                        <Route path="/guest/login" element={<GuestLoginPage />} />
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