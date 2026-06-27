import s from '../styles/PageHeader.module.css'

import labels from "../const/Labels"
import { useGlobal } from "../context/GlobalContext"

export default function PageHeader({page}) {
    const { language } = useGlobal();
    return (
        <div className={s.pageHeader}>
            <h2>{labels[language][page].header}</h2>
            <p>{labels[language][page].subtitle}</p>
        </div>
    )
}