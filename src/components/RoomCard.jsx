import s from '../styles/RoomCard.module.css'

export default function RoomCard({room}) {
    return (
        <div className={s.roomCard}>
            <div className={s.cardRow1}>
                <h3 className={s.roomNumber}>{room.room_number}</h3>
                <div className={s.roomType}>{room.room_type}</div>
                <i className="fa-solid fa-circle"></i>
            </div>
            <div className={s.cardRow2}>
                <div className="infopiece">{room.status}</div>
            </div>
            <div className={s.cardRow3}>
                <div className={s.roomStatus}><button className="btn-primary">Gyors foglalás</button></div>
            </div>
        </div>
    )
}