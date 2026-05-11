export default function Booking() {
    return (
        <section className="booking-section">
            <div className="booking-bar">
                <div className="input-group">
                    <label>Érkezés</label>
                    <input type="date"/>
                </div>
                <div className="input-group">
                    <label>Távozás</label>
                    <input type="date"/>
                </div>
                <div className="input-group">
                    <label>Vendégek</label>
                    <select>
                        <option>2 felnőtt, 0 gyermek</option>
                        <option>1 felnőtt, 0 gyermek</option>
                        <option>2 felnőtt, 1 gyermek</option>
                    </select>
                </div>
                <div className="submit-group">
                    <button className="btn btn-primary btn-large">Szobafoglalás</button>
                </div>
            </div>
        </section>
    )
}