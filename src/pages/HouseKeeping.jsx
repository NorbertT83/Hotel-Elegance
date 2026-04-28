import React from 'react';
import { useUser } from '../context/UserContext.jsx'
import { useRooms } from '../context/RoomContext.jsx'
import TopBar from '../components/TopBar.jsx'
import RoomCard from '../components/RoomCard.jsx'

import './HouseKeeping.css'


export default function HouseKeeping() {
    const { loggedInUser } = useUser();
    const { rooms, refreshRooms } = useRooms();

    const text = { 
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
                <h2 onClick={() => refreshRooms()}>{text[loggedInUser.lang].header}</h2>
                <p>{text[loggedInUser.lang].subtitle}</p>
            </div>
            <div>
                <button className="btn-primary"><i className="fa-solid fa-plus"></i> {text[loggedInUser.lang].buttonPrimary}</button>
                <button className="btn-secondary"><i className="fa-solid fa-plus"></i> {text[loggedInUser.lang].buttonSecondary}</button>
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
