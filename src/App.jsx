import { GlobalProvider } from './context/GlobalContext.jsx';
import { UserProvider, useUser } from './context/UserContext.jsx';
import { RoomProvider } from './context/RoomContext.jsx';
import { BrowserRouter, Routes, Route, Navigate } from 'react-router-dom';

import './styles/App.css'
import Header from './components/Header.jsx'
import NavBar from './components/NavBar.jsx'
import Footer from './components/Footer.jsx'
import Dashboard from './pages/Dashboard.jsx'
import HouseKeeping from './pages/HouseKeeping.jsx'
import Reception from './pages/Reception.jsx'
import FoodBev from './pages/FoodBev.jsx'
import RoomService from './pages/RoomService.jsx'
import Services from './pages/Services.jsx'
import LoginScreen from './pages/LoginScreen.jsx'
import LogoutScreen from './pages/LogoutScreen.jsx'


function AppRouter() {
    const { user } = useUser();

    if (!user) {
        return (
            <Routes>
                <Route path="/login" element={<LoginScreen />} />
                <Route path="*" element={<Navigate to="/login" />} />
            </Routes>
        );
    }

    return (<div className='content'>
        <Header />
        <NavBar />
            <RoomProvider>
                <Routes>
                    <Route path="/" element={<Dashboard />} />
                    <Route path="/dashboard" element={<Dashboard />} />
                    <Route path="/reception" element={<Reception />} />
                    <Route path="/housekeeping" element={<HouseKeeping />} />
                    <Route path="/foodbev" element={<FoodBev />} />
                    <Route path="/roomservice" element={<RoomService />} />
                    <Route path="/services" element={<Services />} />
                    <Route path="/logout" element={<LogoutScreen />} />
                    <Route path="*" element={<Navigate to="/dashboard" replace />} />
                </Routes>
            </RoomProvider>
        <Footer />
    </div>
    );
}

function App() {
    return (
        <GlobalProvider>
            <UserProvider>
                <BrowserRouter>
                    <AppRouter />
                </BrowserRouter>
            </UserProvider>
        </GlobalProvider>
    );
}

export default App;