import './HouseKeeping.css'
import RoomCard from '../components/RoomCard.jsx'

export default function HouseKeeping({rooms}) {
    return ( <>
        <div id="content-header">
            <div>
                <h2>Szobák menedzselése</h2>
                <h2>Szobák menedzselése</h2>
                <p>48 kiadott szoba követése</p>
            </div>
            <div>
                <button className="btn-primary"><i className="fa-solid fa-plus"></i> Hozzáad</button>
                <button className="btn-secondary"><i className="fa-solid fa-plus"></i> Hozzáad</button>
            </div>
        </div>
        <div id="hk-content">
            {rooms.map((room) => (
                <RoomCard key={room.number} room={room}></RoomCard>
                <RoomCard key={room.number} room={room}></RoomCard>
            ))}
        </div>
        <div id="content-footer"></div>
        </>
    )
}