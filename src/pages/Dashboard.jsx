import labels from '../const/Labels';
import TopBar from "../components/TopBar";
import { useGlobal } from '../context/GlobalContext';


export default function Dashboard() {
    const { language } = useGlobal();

    return ( <main>
        <TopBar page={"dashboard"}></TopBar>

        <div className="contentHeader">
            <div>
                <button className="btn-primary"><i className="fa-solid fa-plus"></i> {labels[language].buttonPrimary}</button>
                <button className="btn-secondary"><i className="fa-solid fa-plus"></i> {labels[language].buttonSecondary}</button>
            </div>
        </div>

        <div className="hkContent">
            <div>Dashboard</div>
        </div>

        <div className="contentFooter"></div>
    </main>
    )
}