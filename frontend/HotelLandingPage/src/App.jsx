import './App.css'
import { Routes, Route, BrowserRouter } from 'react-router-dom';
import { LanguageProvider } from './context/LanguageContext.jsx';
import Header from './components/Header.jsx';
import HomePage from './pages/HomePage.jsx';
import BookingPage from './pages/BookingPage.jsx';
import Footer from './components/Footer.jsx';
import Teszt from './components/Teszt.jsx';


function App() {
    return (
    <>
        <LanguageProvider>
            <BrowserRouter>
                <Header />
                <Routes>
                    <Route path="/" element={<HomePage />} />
                    <Route path="/booking" element={<BookingPage />} />
                    <Route path="/teszt" element={<Teszt />} />
                    <Route path="*" element={<HomePage />} />
                </Routes>
                <Footer />
            </BrowserRouter>
        </LanguageProvider>
    </>
    )
}

export default App