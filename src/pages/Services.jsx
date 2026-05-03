import labels from '../const/Labels';
import TopBar from "../components/TopBar";
import { useGlobal } from '../context/GlobalContext';


export default function Services() {
    const { language } = useGlobal();

    return ( <main>
        <TopBar page={"services"}></TopBar>

        <div className="contentHeader">
            <div>
                <button className="btn-primary"><i className="fa-solid fa-plus"></i> {labels[language]["services"].button1}</button>
                <button className="btn-secondary"><i className="fa-solid fa-plus"></i> {labels[language]["services"].button2}</button>
            </div>
        </div>

        <div className="hkContent">
            <div>Services</div>
        </div>

        <div className="contentFooter"></div>
    </main>
    )
}