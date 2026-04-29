import s from '../styles/NavBar.module.css'

import { useGlobal } from '../context/GlobalContext';
import { NavLink } from 'react-router-dom';
import Logo from '../assets/Logo-horizontal.png';

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
        path: "logout",
        icon: "right-from-bracket",
        label: {
            en: "Logout",
            hu: "Kijelentkezés"
        }
    }
];

export default function NavBar() {
    const { language } = useGlobal();

    return (
        <nav>
            <div className={s.navHeader}>
                <img src={Logo} alt="logo"></img>
            </div>
            <ul className={s.menu}>
                {
                    pages.map((page) => {
                    return <li className={s.menuitem} key={page.path}>
                        <NavLink
                            to={page.path}
                            className={({ isActive }) => isActive ? s.selected : ''}
                        >
                            <i className={`fa-solid fa-${page.icon}`}></i>
                            <span>{page.label[language]}</span>
                        </NavLink>
                    </li>
                    })
                }
            </ul>
        </nav>
    )    
}