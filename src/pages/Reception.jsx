import labels from '../const/Labels';
import TopBar from "../components/TopBar";
import { useGlobal } from '../context/GlobalContext';


export default function Reception() {
    const { language } = useGlobal();

    return ( <main>
        <TopBar page={"reception"}></TopBar>

        <div className="contentHeader">
            <div>
                <button className="btn-primary"><i className="fa-solid fa-plus"></i> {labels[language]["reception"].button1}</button>
                <button className="btn-secondary"><i className="fa-solid fa-plus"></i> {labels[language]["reception"].button2}</button>
            </div>
        </div>

        <div className="hkContent">
            <div>Reception</div>
        </div>

        <div className="contentFooter"></div>
    </main>
    )
}