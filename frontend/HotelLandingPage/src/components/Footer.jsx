export default function Footer() {
    return (
        <footer className="footer">
            <div className="footer-container">
                <div className="footer-brand">
                    <div className="footer-logo">Hotel Elegance</div>
                    <p>A csendes luxus menedéke, amely kifogástalan kiszolgálást és időtlen élményeket nyújt az igényes utazók számára.</p>
                </div>
                <div className="footer-links-grid">
                    <div className="footer-col">
                        <h4>Jogi tudnivalók</h4>
                        <a href="#">Adatvédelmi irányelvek</a>
                        <a href="#">Felhasználási feltételek</a>
                    </div>
                    <div className="footer-col">
                        <h4>Kapcsolat</h4>
                        <a href="#">Kapcsolatfelvétel</a>
                        <a href="#">Sajtóanyagok</a>
                    </div>
                    <div className="footer-col footer-address">
                        <h4>Helyszín</h4>
                        <address>
                            <span>123 Serenity Lane</span><br/>
                            <span>Metropolis, NY 10001</span><br/>
                            <a href="mailto:info@hotelelegance.hu" className="email-link">info@hotelelegance.hu</a>
                        </address>
                    </div>
                </div>
                <div className="footer-bottom">
                    <span>© 2026 Hotel Elegance. Minden jog fenntartva.</span>
                </div>
            </div>
        </footer>
    )
}