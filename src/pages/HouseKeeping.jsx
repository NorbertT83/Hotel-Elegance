import './HouseKeeping.css'
import TopBar from '../components/TopBar.jsx'
import RoomCard from '../components/RoomCard.jsx'

const text = { 
    en: {
        header: "Room Management",
        subtitle: "Tracking 48 issued rooms",
        buttonPrimary: "Add",
        buttonSecondary: "Add"
    },
    hu: {
        header: "Szobák menedzselése",
        subtitle: "48 kiadott szoba követése",
        buttonPrimary: "Hozzáad",
        buttonSecondary: "Hozzáad"
    }
}

export default function HouseKeeping({loggedInUser, rooms}) {
    return ( <>
        <TopBar loggedInUser={loggedInUser}></TopBar>
        <div id="content-header">
            <div>
                <h2>{text[loggedInUser.lang].header}</h2>
                <p>{text[loggedInUser.lang].subtitle}</p>
            </div>
            <div>
                <button className="btn-primary"><i className="fa-solid fa-plus"></i> {text[loggedInUser.lang].buttonPrimary}</button>
                <button className="btn-secondary"><i className="fa-solid fa-plus"></i> {text[loggedInUser.lang].buttonSecondary}</button>
            </div>
        </div>
        <div id="hk-content">
            {rooms.map((room) => (
                <RoomCard key={room.number} room={room}></RoomCard>
            ))}
        </div>
        <div id="content-footer"></div>
        </>
    )
}
