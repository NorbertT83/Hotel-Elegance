import Logo from '../assets/Logo-horizontal.png';
import { NavLink } from 'react-router-dom';

const pages = [
    {
        path: "dashboard",
        icon: "tachometer-alt",
        label: "Irányítópult"
    },
    {
        path: "reception",
        icon: "bell",
        label: "Recepció"
    },
    {
        path: "housekeeping",
        icon: "bed",
        label: "Housekeeping"
    },
    {
        path: "foodbev",
        icon: "utensils",
        label: "Étel/ital"
    },
    {
        path: "roomservice",
        icon: "bell-concierge",
        label: "Szobaszerviz"
    },
    {
        path: "services",
        icon: "spa",
        label: "Szolgáltatások"
    },
    {
        path: "settings",
        icon: "user",
        label: "Beállítások"
    },
    {
        path: "logout",
        icon: "right-from-bracket",
        label: "Kijelentkezés"
    }
];

export default function NavBar() {
    return (
        <nav>
            <div className="nav-header">
                <img src={Logo} alt="logo"></img>
            </div>
            <ul id="menu">
                <div id="menu-indicator"></div>
                {
                    pages.map((page) => {
                    return <li className="menuitem" key={page.path}>
                        <NavLink
                            to={page.path}
                            className={({ isActive }) => isActive ? 'selected' : ''}
                        >
                            <i className={`fa-solid fa-${page.icon}`}></i>
                            <span>{page.label}</span>
                        </NavLink>
                    </li>
                    })
                }
            </ul>
        </nav>
    )    
}