import s from '../styles/SearchInput.module.css'

export default function SearchInput({ placeholder } ) {
    return (
        <div className={s.searchInput}>
            <i className="fa-solid fa-magnifying-glass"></i>
            <input type="text" placeholder={placeholder}></input>
        </div>
)
}
