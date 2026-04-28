export default function UserGroup({ user }) {
return (
    <div id="user-wrapper">
        <div className="separator"></div>
        <div>
            <p className="user-name">{user.name}</p>
            <p className="user-title">{user.title}</p>
        </div>
        <div className="profile-pic">
            <i className="fa-regular fa-user"></i>
        </div>
    </div>
    )
}