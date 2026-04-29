import { useGlobal } from '../context/GlobalContext';
import TopBar from "../components/TopBar";

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
    const { language } = useGlobal();

    return ( <main>
        <TopBar></TopBar>
        <div id="content-header">
            <div>
                <h2>{labels[language].header}</h2>
                <p>{labels[language].subtitle}</p>
            </div>
            <div>
                <button className="btn-primary"><i className="fa-solid fa-plus"></i> {labels[language].buttonPrimary}</button>
                <button className="btn-secondary"><i className="fa-solid fa-plus"></i> {labels[language].buttonSecondary}</button>
            </div>
        </div>
        <div id="hk-content">
            <div>Dashboard</div>
        </div>
        <div id="content-footer"></div>
    </main>
    )
}