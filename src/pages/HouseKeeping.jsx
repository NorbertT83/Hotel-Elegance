import './HouseKeeping.css'

export default function HouseKeeping({rooms}) {
    return ( <>
        <div id="content-header">
            <div>
                <h2>Room Management</h2>
                <p>48 kiadott szoba követése</p>
            </div>
            <div>
                <button className="btn-primary"><i className="fa-solid fa-plus"></i> Hozzáad</button>
                <button className="btn-secondary"><i className="fa-solid fa-plus"></i> Hozzáad</button>
            </div>
        </div>
        <div id="hk-content">
            {rooms.map((room) => (
                <div className="room-card" key={room.number}>
                    <div className=" card-row row1">
                        <h3 className="room-number">{room.number}</h3>
                        <div className="room-type">{room.type}</div>
                        <i className="fa-solid fa-circle"></i>
                    </div>
                    <div className=" card-row row2">
                        <div className="infopiece">Ready for Guest</div>
                    </div>
                    <div className=" card-row row3">
                        <div className="room-status"><button className="btn-primary">Quick book</button></div>
                    </div>
                </div>
            ))}
        </div>
        <div id="content-footer"></div>
        </>
    )
}