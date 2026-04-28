
export default function RoomCard({room}) {
    return (
        <div className="room-card">
            <div className=" card-row row1">
                <h3 className="room-number">{room.room_number}</h3>
                <div className="room-type">{room.room_type}</div>
                <i className="fa-solid fa-circle"></i>
            </div>
            <div className=" card-row row2">
                <div className="infopiece">{room.status}</div>
            </div>
            <div className=" card-row row3">
                <div className="room-status"><button className="btn-primary">Gyors foglalás</button></div>
            </div>
        </div>
    )
}