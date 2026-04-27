export default function Dashboard() {
    return ( <>
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
            <div>Dashboard</div>
        </div>
        <div id="content-footer"></div>
        </>
    )
}