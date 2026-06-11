
import { useGuest } from '../../context/GuestContext'
import { useLanguage } from '../../context/LanguageContext';
import s from '../../styles/GuestSubPages.module.css'


export default function Wellness() {
    const { services } = useGuest();
    const { language } = useLanguage();

    return (
        <div className={s.cardWrapper}>
            <div className={`${s.card} ${s.serviceCard}`}>
                <div className={s.cardHeader}>
                    Választható wellness szolgáltatásaink
                </div>

                <div className={s.content}>
                    {services.filter(s => s.service_type_en === "Wellness").map(service => (
                        <div key={service.id}>
                            <p>{service[`name_${language}`]}</p>
                        </div>
                    ))}
                </div>
            </div>
        </div>
    )
}