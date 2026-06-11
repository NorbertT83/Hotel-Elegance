
import { useEffect, useState } from 'react';
import { Language, useLanguage } from '../../context/LanguageContext';
import { getData } from '../../services/apiService';
import s from '../../styles/GuestSubPages.module.css'

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

const categoryLabels: Record<FoodBev['category'], Record<Language, string>> = {
    breakfast: { hu: 'Reggeli', en: 'Breakfast' },
    starter: { hu: 'Előételek', en: 'Starters' },
    soup: { hu: 'Levesek', en: 'Soups' },
    main_course: { hu: 'Főételek', en: 'Main Courses' },
    dessert: { hu: 'Desszertek', en: 'Desserts' },
    hot_drink: { hu: 'Meleg italok', en: 'Hot Drinks' },
    soft_drink: { hu: 'Üdítők', en: 'Soft Drinks' },
    alcoholic_drink: { hu: 'Alkoholos italok', en: 'Alcoholic Drinks' }
};

const categoryOrder: FoodBev['category'][] = [
    'breakfast', 'starter', 'soup', 'main_course', 'dessert', 'hot_drink', 'soft_drink', 'alcoholic_drink'
];
        
export default function RoomService() {
    const { language } = useLanguage();
    const [foodAndBeverage, setFoodAndBeverage] = useState<FoodBev []>([]);

    const groupedData = foodAndBeverage.reduce<Partial<Record<FoodBev['category'], FoodBev[]>>>((acc, item) => {
        if (!acc[item.category]) {
            acc[item.category] = [];
        }
        acc[item.category]?.push(item);
        return acc;
    }, {});

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
                    {categoryOrder.map(categoryKey => {
                        const items = groupedData[categoryKey];
                        if (!items || items.length === 0) return null;

                        return (
                            <div key={categoryKey} className={s.categorySection}>
                                <h2 className={s.categoryTitle}>
                                    {categoryLabels[categoryKey][language]}
                                </h2>
                                
                                <div className={s.categoryItems}>
                                    {[...items]
                                        .sort((a, b) => {
                                            const nameA = a[`name_${language}`];
                                            const nameB = b[`name_${language}`];
                                            return nameA.localeCompare(nameB, language);
                                        })
                                        .map(fandb => (
                                            <div key={fandb.id} className={s.itemRow}>
                                                <div className={s.itemDetails}>
                                                    <div className={s.itemName}>{fandb[`name_${language}`]}</div>
                                                    <div className={s.itemDescription}>{fandb[`description_${language}`]}</div>
                                                </div>
                                                <div>
                                                    <p className={s.price}>{Intl.NumberFormat(language=== 'hu' ? 'hu-HU' : 'en-US').format(fandb.price)} Ft</p>
                                                    <div className={s.measure}>{fandb.measure}</div>
                                                </div>
                                            </div>
                                        ))
                                    }
                                </div>
                            </div>
                        );
                    })}

                </div>
            </div>
        </div>
    )
}