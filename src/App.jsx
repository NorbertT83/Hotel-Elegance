import './App.css'
import CustomSelect from  './components/CustomSelect.jsx'
import logo from './assets/Logo-horizontal.png'

function App() {

    return (
    <>
    <header>
    </header>
    <nav>
        <div className="nav-header">
            <img src={logo} alt="logo"></img>
        </div>
        <ul id="menu">
            <div id="menu-indicator"></div>
            <li data-menu="dashboard" className="menuitem selected"><i className="fa-solid fa-house"></i>Irányítópult</li>
            <li data-menu="reception" className="menuitem"><i className="fa-solid fa-bell"></i>Recepció</li>
            <li data-menu="housekeeping" className="menuitem"><i className="fa-solid fa-bed"></i>Housekeeping</li>
            <li data-menu="foodbev" className="menuitem"><i className="fa-solid fa-utensils"></i>F&B</li>
            <li data-menu="roomservice" className="menuitem"><i className="fa-solid fa-bell-concierge"></i>Szobaszerviz</li>
            <li data-menu="services" className="menuitem"><i className="fa-solid fa-spa"></i>Szolgáltatások</li>
            <li data-menu="settings" className="menuitem"><i className="fa-solid fa-user"></i>Beállítások</li>
            <li data-menu="logout" className="menuitem"><i className="fa-solid fa-right-from-bracket"></i>Kijelentkezés</li>
        </ul>
    </nav>
    <main>
        <div id="content-wrapper">
            <div id="top-bar">
                <div className="search-input">
                    <i className="fa-solid fa-magnifying-glass"></i>
                    <input type="text" placeholder="Keresés..."></input>
                </div>
                
                    <CustomSelect 
                        options={[
                            { label: "Név szerint", value: "lname" },
                            { label: "Ár szerint", value: "price_per_night" },
                            { label: "Szobaszám", value: "room_number" }
                        ]} 
                        label="Rendezés..." 
                        onChange={(val) => console.log("Új sorrend:", val)}
                    />
                <div id="user-wrapper">
                    <div>
                        <p className="user-name">Tóth-Kocsis Petra</p>
                        <p className="user-title">Housekeeping manager</p>
                    </div>
                    <div className="profile-pic">
                        <i className="fa-regular fa-user"></i>
                        {/* <img src="./assets/profile.png" alt="profile"></img> */}
                    </div>
                </div>
            </div>
            <div id="content-header">
                <div>
                    <h2>Room Management</h2>
                    <p>48 kiadott szoba követése</p>
                </div>
                <div>
                    <button className="btn-primary"><i className="fa-solid fa-plus"></i> Hozzáad</button>
                    <button className="btn-secondary"><i className="fa-solid fa-plus"></i> Hozzáad</button>
                </div>
            </div>
            <div id="hk-content">
                <div className="card">
                    <div className=" card-row row1">
                        <h3 className="room-number">113</h3>
                        <div className="room-type">DELUXE</div>
                        <i className="fa-solid fa-circle"></i>
                    </div>
                    <div className=" card-row row2">
                        <div className="infopiece">Ready for Guest</div>
                    </div>
                    <div className=" card-row row3">
                        <div className="room-status"><button className="btn-primary">Quick book</button></div>
                    </div>
                </div>
                <div className="card">
                    <div className=" card-row row1">
                        <h3 className="room-number">211</h3>
                        <div className="room-type">SUITE</div>
                        <i className="fa-solid fa-circle"></i>
                    </div>
                    <div className=" card-row row2">
                        <div className="infopiece">Ready for Guest</div>
                    </div>
                    <div className=" card-row row3">
                        <div className="room-status"><button className="btn-primary">Quick book</button></div>
                    </div>
                </div>
                <div className="card">
                    <div className=" card-row row1">
                        <h3 className="room-number">211</h3>
                        <div className="room-type">STANDARD</div>
                        <i className="fa-solid fa-circle"></i>
                    </div>
                    <div className=" card-row row2">
                        <div className="infopiece">Ready for Guest</div>
                    </div>
                    <div className=" card-row row3">
                        <div className="room-status"><button className="btn-primary">Quick book</button></div>
                    </div>
                </div>

            </div>
            <div id="content-footer">
            </div>
        </div>
    </main>
    <footer><div>NrBrT - Copyright 2026</div></footer>    
    </>
    )
}

export default App
