import Logo from '../assets/Logo-horizontal.png';
import { NavLink } from 'react-router-dom';

const pages = [
    {
        path: "dashboard",
        icon: "tachometer-alt",
        label: {
            en: "Dashboard",
            hu: "Irányítópult"
        }
    },
    {
        path: "reception",
        icon: "bell",
        label: {
            en: "Reception",
            hu: "Recepció"
        }
    },
    {
        path: "housekeeping",
        icon: "bed",
        label: {
            en: "Housekeeping",
            hu: "Szobagazdálkodás"
        }
    },
    {
        path: "foodbev",
        icon: "utensils",
        label: {
            en: "Food & Beverage",
            hu: "Étel & Ital"
        }
    },
    {
        path: "roomservice",
        icon: "bell-concierge",
        label: {
            en: "Room Service",
            hu: "Szobaszerviz"
        }
    },
    {
        path: "services",
        icon: "spa",
        label: {
            en: "Services",
            hu: "Szolgáltatások"
        }
    },
    {
        path: "settings",
        icon: "user",
        label: {
            en: "Settings",
            hu: "Beállítások"
        }
    },
    {
        path: "logout",
        icon: "right-from-bracket",
        label: {
            en: "Logout",
            hu: "Kijelentkezés"
        }
    }
];

export default function NavBar({ loggedInUser }) {
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
                            <span>{page.label[loggedInUser.lang]}</span>
                        </NavLink>
                    </li>
                    })
                }
            </ul>
        </nav>
    )    
}