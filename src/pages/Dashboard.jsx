import React from 'react';
import TopBar from "../components/TopBar";
import { useUser } from '../context/UserContext';

const labels = { 
    en: {
        header: "Dashboard",
        subtitle: "Global statistics",
        buttonPrimary: "Add",
        buttonSecondary: "Add"
    },
    hu: {
        header: "Irányítópult",
        subtitle: "Globális statisztikák",
        buttonPrimary: "Hozzáad",
        buttonSecondary: "Hozzáad"
    }
}

export default function Dashboard() {
    const { loggedInUser } = useUser();
    const userLang = loggedInUser?.lang || 'hu';

    return ( <main>
        <TopBar></TopBar>
        <div id="content-header">
            <div>
                <h2>{labels[userLang].header}</h2>
                <p>{labels[userLang].subtitle}</p>
            </div>
            <div>
                <button className="btn-primary"><i className="fa-solid fa-plus"></i> {labels[userLang].buttonPrimary}</button>
                <button className="btn-secondary"><i className="fa-solid fa-plus"></i> {labels[userLang].buttonSecondary}</button>
            </div>
        </div>
        <div id="hk-content">
            <div>Dashboard</div>
        </div>
        <div id="content-footer"></div>
    </main>
    )
}