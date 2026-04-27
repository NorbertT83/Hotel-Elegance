import { BrowserRouter, Routes, Route } from 'react-router-dom';

import './App.css'
import Header from './components/Header.jsx'
import NavBar from './components/NavBar.jsx'
import TopBar from './components/TopBar.jsx'
import Footer from './components/Footer.jsx'
import Dashboard from './pages/Dashboard.jsx'
import HouseKeeping from './pages/HouseKeeping.jsx';


const loggedInUser = {
    name: "Kovács Áron",
    title: "General Manager"
}

const rooms = [
    {
        number: 113,
        type: "DELUXE",
        status: "READY"
    },
    {
        number: 211,
        type: "SUITE",
        status: "READY"
    },
    {
        number: 305,
        type: "STANDARD",
        status: "READY"
    }
]


function App() {

    return (
    <>
        <Header></Header>
        <BrowserRouter>
            <NavBar />
            <main>
                <div id="content-wrapper">
                    <TopBar loggedInUser={loggedInUser}></TopBar>
                    <Routes>
                        <Route path="/" element={<Dashboard />} />
                        <Route path="/dashboard" element={<Dashboard />} />
                        <Route path="/housekeeping" element={<HouseKeeping rooms={rooms}/>} />
                    </Routes>
                </div>
            </main>
        </BrowserRouter>
        <Footer></Footer>
    </>
    )
}

export default App
