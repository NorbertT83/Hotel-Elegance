import labels from '../const/Labels';
import TopBar from "../components/TopBar";
import { useGlobal } from '../context/GlobalContext';


export default function RoomService() {
    const { language } = useGlobal();

    return ( <main>
        <TopBar page={"roomservice"}></TopBar>

        <div className="contentHeader">
            <div>
                <button className="btn-primary"><i className="fa-solid fa-plus"></i> {labels[language]["roomservice"].button1}</button>
                <button className="btn-secondary"><i className="fa-solid fa-plus"></i> {labels[language]["roomservice"].button2}</button>
            </div>
        </div>

        <div className="hkContent">
            <div>Room Service</div>
        </div>

        <div className="contentFooter"></div>
    </main>
    )
}