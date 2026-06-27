import { useGlobal } from '../context/GlobalContext.jsx'
import { useRooms } from '../context/RoomContext.jsx'
import labels from '../const/Labels.js'
import TopBar from '../components/TopBar.jsx'
import SearchInput from '../components/SearchInput.jsx'
import CustomSelect from '../components/CustomSelect.jsx'
import RoomCard from '../components/RoomCard.jsx'

export default function HouseKeeping() {
    const { language } = useGlobal();
    const { rooms, refreshRooms } = useRooms();

    return ( <main>
        <TopBar page={"housekeeping"}></TopBar>
        <div className="contentHeader">
            <SearchInput placeholder={language == "en" ? "Search..." : "Keresés..."}></SearchInput>                
            <CustomSelect 
                options={
                    language == "en" ? [
                        { label: "Name", value: "lname" },
                        { label: "Price", value: "price_per_night" },
                        { label: "Room number", value: "room_number" }
                    ] : [
                        { label: "Név szerint", value: "lname" },
                        { label: "Ár szerint", value: "price_per_night" },
                        { label: "Szobaszám", value: "room_number" }
                    ]
                } 
                label={language == "en" ? "Sort by..." : "Rendezés..."}
                onChange={(val) => console.log("Új sorrend:", val)}
            />
            <div>
                <button className="btn-primary"><i className="fa-solid fa-plus"></i> {labels[language]["housekeeping"].button1}</button>
                <button className="btn-secondary"><i className="fa-solid fa-plus"></i> {labels[language]["housekeeping"].button2}</button>
            </div>
        </div>
        <div className="hkContent">
            {rooms.map((room) => (
                <RoomCard key={room.room_number} room={room}></RoomCard>
            ))}
        </div>
        <div className="contentFooter"></div>
    </main>
    )
}
