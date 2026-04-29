import { useGlobal } from '../context/GlobalContext.jsx'
import { useRooms } from '../context/RoomContext.jsx'
import TopBar from '../components/TopBar.jsx'
import RoomCard from '../components/RoomCard.jsx'

import './HouseKeeping.css'


export default function HouseKeeping() {
    const { language } = useGlobal();
    const { rooms, refreshRooms } = useRooms();

    const labels = { 
    en: {
        header: "Room Management",
        subtitle: `Tracking all the ${rooms.length} rooms`,
        buttonPrimary: "Add",
        buttonSecondary: "Add"
    },
    hu: {
        header: "Szobák menedzselése",
        subtitle: `${rooms.length} szoba követése`,
        buttonPrimary: "Hozzáad",
        buttonSecondary: "Hozzáad"
    }
}

    return ( <main>
        <TopBar></TopBar>
        <div id="content-header">
            <div>
                <h2 onClick={() => refreshRooms()}>{labels[language].header}</h2>
                <p>{labels[language].subtitle}</p>
            </div>
            <div>
                <button className="btn-primary"><i className="fa-solid fa-plus"></i> {labels[language].buttonPrimary}</button>
                <button className="btn-secondary"><i className="fa-solid fa-plus"></i> {labels[language].buttonSecondary}</button>
            </div>
        </div>
        <div id="hk-content">
            {rooms.map((room) => (
                <RoomCard key={room.room_number} room={room}></RoomCard>
            ))}
        </div>
        <div id="content-footer"></div>
    </main>
    )
}
