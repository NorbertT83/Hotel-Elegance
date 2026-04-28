import './TopBar.css'
import React from 'react'
import { useUser } from '../context/UserContext.jsx'
import CustomSelect from  './CustomSelect.jsx'
import SearchInput from './SearchInput.jsx'
import LanguageSelector from './LanguageSelector.jsx'
import UserGroup from './UserGroup.jsx'

export default function TopBar() {
    const { loggedInUser } = useUser();
    return (
        <div id="top-bar">
            <SearchInput placeholder={loggedInUser.lang == "en" ? "Search..." : "Keresés..."}></SearchInput>                
            <CustomSelect 
                options={
                    loggedInUser.lang == "en" ? [
                        { label: "Name", value: "lname" },
                        { label: "Price", value: "price_per_night" },
                        { label: "Room number", value: "room_number" }
                    ] : [
                        { label: "Név szerint", value: "lname" },
                        { label: "Ár szerint", value: "price_per_night" },
                        { label: "Szobaszám", value: "room_number" }
                    ]
                } 
                label={loggedInUser.lang == "en" ? "Sort by..." : "Rendezés..."}
                onChange={(val) => console.log("Új sorrend:", val)}
            />
            <LanguageSelector />
            <UserGroup user={loggedInUser}></UserGroup>
        </div>
    )
}