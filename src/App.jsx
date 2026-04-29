import { GlobalProvider } from './context/GlobalContext.jsx';
import { UserProvider, useUser } from './context/UserContext.jsx';
import { RoomProvider } from './context/RoomContext.jsx';
import { BrowserRouter, Routes, Route, Navigate } from 'react-router-dom';

import './App.css'
import Header from './components/Header.jsx'
import NavBar from './components/NavBar.jsx'
import Footer from './components/Footer.jsx'
import Dashboard from './pages/Dashboard.jsx'
import HouseKeeping from './pages/HouseKeeping.jsx';
import LoginScreen from './pages/LoginScreen.jsx';


function AppRouter() {
    const { loggedInUser } = useUser();

    if (!loggedInUser) {
        return (
            <Routes>
                <Route path="/login" element={<LoginScreen />} />
                <Route path="*" element={<Navigate to="/login" />} />
            </Routes>
        );
    }

    return (<div id='content'>
        <Header />
        <NavBar />
            <RoomProvider>
                <Routes>
                    <Route path="/" element={<Dashboard />} />
                    <Route path="/dashboard" element={<Dashboard />} />
                    <Route path="/housekeeping" element={<HouseKeeping />} />
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