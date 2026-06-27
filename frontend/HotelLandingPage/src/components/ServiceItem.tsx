import { useLanguage } from "../context/LanguageContext";
import { HotelService } from "../types/booking";
import s from '../styles/GuestSubPages.module.css';

interface ServiceItemProps {
    item: HotelService;
    amount: number;
    handleCartChange: (id: HotelService['id'], amount: number) => void;
}

export default function ServiceItem({ item, handleCartChange, amount = 0 }: ServiceItemProps) {
    const { language } = useLanguage();

    const name = item[`name_${language}` as keyof HotelService] as string;
    const description = item[`description_${language}` as keyof HotelService] as string;

    return (
        <div className={s.itemRow}>
            <div className={s.itemDetails}>
                <div className={s.itemName} title={name}>
                    {name}
                </div>
                <div className={s.itemDescription}>
                    {description}
                </div>
            </div>
            <div>
                <p className={s.price}>
                    {Intl.NumberFormat(language === 'hu' ? 'hu-HU' : 'en-US').format(item.price)} Ft
                </p>
                <div className={s.measure}>1 {language === 'hu' ? 'alkalom' : 'session'}</div>
            </div>
            <div className={s.amountPicker}>
                <span className={s.amountModifier} onClick={() => handleCartChange(item.id, amount - 1)}>-</span>
                <span className={`${s.amountDisplay} ${amount > 0 ? s.hasAmount : ''}`}>{amount}</span>
                <span className={s.amountModifier} onClick={() => handleCartChange(item.id, amount + 1)}>+</span>
            </div>
        </div>
    );
}
