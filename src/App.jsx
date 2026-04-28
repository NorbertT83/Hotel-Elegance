import { UserProvider, useUser } from './context/UserContext.jsx';
import { RoomProvider } from './context/RoomContext.jsx';
import { BrowserRouter, Routes, Route, Navigate } from 'react-router-dom';

import './App.css'
import Header from './components/Header.jsx'
import NavBar from './components/NavBar.jsx'
import TopBar from './components/TopBar.jsx'
import Footer from './components/Footer.jsx'
import Dashboard from './pages/Dashboard.jsx'
import HouseKeeping from './pages/HouseKeeping.jsx';
import LoginScreen from './pages/LoginScreen.jsx';


function AppRouter() {
    const { loggedInUser } = useUser();

    if (!loggedInUser) {
        return <LoginScreen />;
    }

    return (
        <Routes>
            <Route path="/" element={<Dashboard />} />
            <Route path="/dashboard" element={<Dashboard />} />
            <Route path="/housekeeping" element={<HouseKeeping />} />
            <Route path="*" element={<Navigate to="/" />} />
        </Routes>
    );
};

function App() {
    return (
        <UserProvider>
            <RoomProvider>
                <Header />
                <BrowserRouter>
                    <NavBar />
                    <AppRouter />
                </BrowserRouter>
                <Footer />
            </RoomProvider>
        </UserProvider>
    );
}

export default App;