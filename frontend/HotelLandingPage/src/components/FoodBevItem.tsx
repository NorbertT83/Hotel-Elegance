import { useState } from "react";
import s from '../styles/GuestSubPages.module.css';
import { Language } from "../context/LanguageContext";
import { FoodBev } from "../pages/guest/RoomService";

export default function FoodBevItem({
    fandb,
    language,
    handleCartChange
}: {
    fandb: FoodBev;
    language: Language;
    handleCartChange: (id: FoodBev["id"], quantity: number) => void;
}) {
    const [amount, setAmount] = useState(0);

    function handleAmountChange(change: number) {
        const newAmount = amount + change;

        if (newAmount < 0 || newAmount >= 20) return;

        setAmount(newAmount);
        handleCartChange(fandb.id, newAmount);
    }

    return (
        <div className={s.itemRow}>
            <div className={s.itemDetails}>
                <div className={s.itemName} title={fandb[`name_${language}`]}>
                    {fandb[`name_${language}`]}
                </div>
                <div className={s.itemDescription}>
                    {fandb[`description_${language}`]}
                </div>
            </div>
            <div>
                <p className={s.price}>
                    {Intl.NumberFormat(language === 'hu' ? 'hu-HU' : 'en-US').format(fandb.price)} Ft
                </p>
                <div className={s.measure}>{fandb.measure}</div>
            </div>
            <div className={s.amountPicker}>
                <span className={s.amountModifier} onClick={() => handleAmountChange(-1)}>-</span>
                <span className={`${s.amountDisplay} ${amount > 0 ? s.hasAmount : ''}`}>{amount}</span>
                <span className={s.amountModifier} onClick={() => handleAmountChange(1)}>+</span>
            </div>
        </div>
    );
}