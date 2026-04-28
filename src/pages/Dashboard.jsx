import TopBar from "../components/TopBar";
const text = { 
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

export default function Dashboard({loggedInUser}) {
    return ( <>
        <TopBar loggedInUser={loggedInUser}></TopBar>
        <div id="content-header">
            <div>
                <h2>{text[loggedInUser.lang].header}</h2>
                <p>{text[loggedInUser.lang].subtitle}</p>
            </div>
            <div>
                <button className="btn-primary"><i className="fa-solid fa-plus"></i> {text[loggedInUser.lang].buttonPrimary}</button>
                <button className="btn-secondary"><i className="fa-solid fa-plus"></i> {text[loggedInUser.lang].buttonSecondary}</button>
            </div>
        </div>
        <div id="hk-content">
            <div>Dashboard</div>
        </div>
        <div id="content-footer"></div>
        </>
    )
}