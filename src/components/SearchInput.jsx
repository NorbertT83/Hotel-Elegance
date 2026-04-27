export default function SearchInput({ placeholder } ) {
    return (
        <div className="search-input">
            <i className="fa-solid fa-magnifying-glass"></i>
            <input type="text" placeholder={placeholder}></input>
        </div>
)
}
