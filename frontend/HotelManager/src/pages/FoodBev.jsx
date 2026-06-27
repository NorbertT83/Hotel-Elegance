import labels from '../const/Labels';
import TopBar from "../components/TopBar";
import { useGlobal } from '../context/GlobalContext';


export default function FoodBev() {
    const { language } = useGlobal();

    return ( <main>
        <TopBar page={"foodbev"}></TopBar>

        <div className="contentHeader">
            <div>
                <button className="btn-primary"><i className="fa-solid fa-plus"></i> {labels[language]["foodbev"].button1}</button>
                <button className="btn-secondary"><i className="fa-solid fa-plus"></i> {labels[language]["foodbev"].button2}</button>
            </div>
        </div>

        <div className="hkContent">
            <div>Food & Beverages</div>
        </div>

        <div className="contentFooter"></div>
    </main>
    )
}