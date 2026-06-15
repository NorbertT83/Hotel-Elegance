import { useState } from "react";
import s from '../styles/GuestSubPages.module.css';
import { useLanguage } from "../context/LanguageContext";
import { FoodBev } from "../pages/guest/RoomService";

interface FoodBevProps {
    item: FoodBev;
    amount: number;
    handleCartChange: (id: FoodBev["id"], amount: number) => void;
}

export default function FoodBevItem({ item, handleCartChange, amount=0}: FoodBevProps ) {
    const { language } = useLanguage();

    return (
        <div className={s.itemRow}>
            <div className={s.itemDetails}>
                <div className={s.itemName} title={item[`name_${language}`]}>
                    {item[`name_${language}`]}
                </div>
                <div className={s.itemDescription}>
                    {item[`description_${language}`]}
                </div>
            </div>
            <div>
                <p className={s.price}>
                    {Intl.NumberFormat(language === 'hu' ? 'hu-HU' : 'en-US').format(item.price)} Ft
                </p>
                <div className={s.measure}>{item.measure}</div>
            </div>
            <div className={s.amountPicker}>
                <span className={s.amountModifier} onClick={() => handleCartChange(item.id, amount - 1)}>-</span>
                <span className={`${s.amountDisplay} ${amount > 0 ? s.hasAmount : ''}`}>{amount}</span>
                <span className={s.amountModifier} onClick={() => handleCartChange(item.id, amount + 1)}>+</span>
            </div>
        </div>
    );
}