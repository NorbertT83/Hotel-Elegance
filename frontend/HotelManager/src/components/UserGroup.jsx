import s from '../styles/UserGroup.module.css'
import { useUser } from "../context/UserContext"

export default function UserGroup() {
    const { user } = useUser();
    return (
        <div className={s.userGroup}>
            <div className="separator"></div>
            <div>
                <p className={s.userName}>{user.name}</p>
                <p className={s.userRole}>{user.role}</p>
            </div>
            <div className={s.profilePic}>
                <i className="fa-regular fa-user"></i>
            </div>
        </div>
    )
}