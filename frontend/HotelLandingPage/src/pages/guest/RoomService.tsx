
import { useEffect, useState } from 'react';
import { useLanguage } from '../../context/LanguageContext';
import { getData } from '../../services/apiService';
import s from '../../styles/GuestOverview.module.css'

type FoodBev = {
    id: number,
    category: 'breakfast' | 'starter' | 'soup' | 'main_course' | 'dessert' | 'hot_drink' | 'soft_drink' | 'alcoholic_drink'
    name_hu: string,
    description_hu: string,
    name_en: string,
    description_en: string,
    price: number,
    measure: string
}

export default function RoomService() {
    const { language } = useLanguage();
    const [foodAndBeverage, setFoodAndBeverage] = useState<FoodBev []>([]);

    useEffect(() => {
        const hydrateFoodBev = async () => {
            const foodBevResponse: FoodBev [] = await getData('foodbeverage/all', {sort: `name_${language}`});
            if (foodBevResponse) setFoodAndBeverage(foodBevResponse);
        }
        hydrateFoodBev();
    }, []);

    return (
        <div className={s.cardWrapper}>
            <div className={`${s.card} ${s.roomServiceCard}`}>
                <div className={s.cardHeader}>
                    Étel- és ital kínálatunk
                </div>

                <div className={s.content}>
                    {foodAndBeverage.map(fandb => (
                        <div key={fandb.id}>
                            <span>{fandb[`name_${language}`]}</span>
                            <span>{fandb.price}</span>
                        </div>
                    ))}
                </div>
            </div>
        </div>
    )
}