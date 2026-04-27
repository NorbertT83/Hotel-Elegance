import './TopBar.css'
import CustomSelect from  './CustomSelect.jsx'
import SearchInput from './SearchInput.jsx'
import UserGroup from './UserGroup.jsx'

export default function TopBar({loggedInUser}) {
    return (
        <div id="top-bar">
            <SearchInput placeholder="Keresés..."></SearchInput>                
            <CustomSelect 
                options={[
                    { label: "Név szerint", value: "lname" },
                    { label: "Ár szerint", value: "price_per_night" },
                    { label: "Szobaszám", value: "room_number" }
                ]} 
                label="Rendezés..." 
                onChange={(val) => console.log("Új sorrend:", val)}
            />
            <UserGroup user={loggedInUser}></UserGroup>
        </div>
    )
}