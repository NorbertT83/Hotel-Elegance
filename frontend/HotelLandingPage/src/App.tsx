import { Routes, Route, BrowserRouter, Outlet } from 'react-router-dom'
import { LanguageProvider } from './context/LanguageContext'
import Header from './components/Header'
import HomePage from './pages/HomePage'
import BookingProcessPage from './pages/BookingProcessPage'
import GuestLoginPage from './pages/GuestLoginPage'
import GuestPage from './pages/GuestPage'
import Footer from './components/Footer'
import WelcomeModal from './components/WelcomeModal'
import { GuestProvider } from './context/GuestContext'
import LanguageSelector from './components/LanguageSelector'

const MainLayout = () => (
    <>
        <Header />
        <Outlet />
        <Footer />
    </>
);

const NoFooterLayout = () => (
    <>
        <Header />
        <Outlet />
    </>
);

function App() {
    return (
    <>
        <LanguageProvider>
            <GuestProvider>
                <BrowserRouter basename="/hotelelegance">
                    <WelcomeModal />
                    <Header />
                    <Routes>
                        <Route element={<MainLayout />}>
                            <Route path="/" element={<HomePage />} />
                            <Route path="/booking" element={<BookingProcessPage />} />
                            <Route path="*" element={<HomePage />} />
                        </Route>

                        <Route element={<NoFooterLayout />}>
                            <Route path="/guest/login" element={<GuestLoginPage />} />
                            <Route path="/guest" element={<GuestPage />} />
                        </Route>
                    </Routes>
                    <LanguageSelector />
                </BrowserRouter>
            </GuestProvider>
        </LanguageProvider>
    </>
    )
}

export default App