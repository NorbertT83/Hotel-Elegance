import { useEffect, useMemo, useState } from 'react';
import { useLanguage } from '../../context/LanguageContext';
import { createData, getData } from '../../services/apiService';
import FoodBevItem from '../../components/FoodBevItem';
import CartModal from '../../components/CartModal';
import s from '../../styles/GuestSubPages.module.css';
import { guestPageText } from '../../translations';
import { useGuest } from '../../context/GuestContext';
import MessageBoxModal from '../../components/MessageBoxModal';
import { useLocalStorageState } from '../../hooks/useLocalStorage';


export type FoodBev = {
    id: number;
    category: 'breakfast' | 'starter' | 'soup' | 'main_course' | 'dessert' | 'coffee' | 'soft_drink' | 'alcoholic_drink';
    name_hu: string;
    description_hu: string;
    name_en: string;
    description_en: string;
    price: number;
    measure: string;
};

export type OrderItem = {
    item: FoodBev;
    quantity: number;
};

const categoryOrder: FoodBev['category'][] = [
    'breakfast', 'starter', 'soup', 'main_course', 'dessert', 'coffee', 'soft_drink', 'alcoholic_drink'
];


export default function RoomService() {
    const { language } = useLanguage();
    const labels = guestPageText[language].guestPage.menuRoomservice;
    const [foodAndBeverage, setFoodAndBeverage] = useState<FoodBev[]>([]);
    const [cart, setCart] = useLocalStorageState<OrderItem[]>('guest-cart-roomservice', []);
    const { currentBooking, services, refreshBookedServices } = useGuest();
    const [isCartOpen, setIsCartOpen] = useState<boolean>(false);
    const [showSuccessModal, setShowSuccessModal] = useState<boolean>(false);

    useEffect(() => {
        const hydrateFoodBev = async () => {
            const foodBevResponse = await getData('foodbeverage/all');
            if (foodBevResponse) setFoodAndBeverage(foodBevResponse as FoodBev[]);
        };
        hydrateFoodBev();
    }, []);

    const sortedGroupedData = useMemo(() => {
        const grouped = foodAndBeverage.reduce<Partial<Record<FoodBev['category'], FoodBev[]>>>((acc, item) => {
            if (!acc[item.category]) {
                acc[item.category] = [];
            }
            acc[item.category]?.push(item);
            return acc;
        }, {});

        const result: Partial<Record<FoodBev['category'], FoodBev[]>> = {};
        
        Object.keys(grouped).forEach((key) => {
            const categoryKey = key as FoodBev['category'];
            const items = grouped[categoryKey];
            if (items) {
                result[categoryKey] = [...items].sort((a, b) => {
                    const nameA = a[`name_${language}` as keyof FoodBev] as string;
                    const nameB = b[`name_${language}` as keyof FoodBev] as string;
                    return nameA.localeCompare(nameB, language);
                });
            }
        });

        return result;
    }, [foodAndBeverage, language]);

    function handleCartChange(id: FoodBev["id"], quantity: number) {
        setCart(prev => {
            const currentCart = prev ?? [];

            if (quantity <= 0) {
                return currentCart.filter(orderItem => orderItem.item.id !== id);
            }

            const existingItemIndex = currentCart.findIndex(orderItem => orderItem.item.id === id);

            if (existingItemIndex > -1) {
                const updatedCart = [...currentCart];
                updatedCart[existingItemIndex] = {
                    ...updatedCart[existingItemIndex],
                    quantity
                };
                return updatedCart;
            } else {
                const foodItem = foodAndBeverage.find(food => food.id === id);
                if (!foodItem) return currentCart;
                
                return [...currentCart, { item: foodItem, quantity }];
            }
        });
    }

    async function placeOrder(cartValue: number) {
        try {
            const response: any = await createData('servicebooking', {
                booking_id: currentBooking?.id,
                service_id: services.find((service) => service.name_en === 'Room service')?.id,
                quantity: 1,
                price_at_booking: cartValue
            });

            if (response && response.success) {
                console.log("Sikeres foglalás rögzítve! ID:", response.id);
                setCart([]);
                setShowSuccessModal(true);
                refreshBookedServices();
            } else {
                console.error("Sikertelen foglalás: Nem érkezett sikeres válasz a szervertől.");
            }
        } catch (err: any) {
            console.error("Hiba történt a foglalási folyamat során:", err.message);
        }
    }


    const totalItemsInCart = (cart ?? []).reduce((sum, current) => sum + current.quantity, 0);

    useEffect(() => {
        if (!totalItemsInCart) setIsCartOpen(false);
    }, [totalItemsInCart])

    return ( <>
        {showSuccessModal && 
            <MessageBoxModal
                headerText={language === 'hu' ? 'Információ' : 'Information'}
                message={language === 'hu' ? 'Sikeres szobaszerviz rendelés! Köszönjük!' : 'Room service order placed successfully! Thank you!'}
                timeout={2500}
                onClose={() => setShowSuccessModal(false)}
            />
        }
        {isCartOpen && <CartModal
            cart={cart ?? []}
            isCartOpen={isCartOpen}
            setIsCartOpen={setIsCartOpen}
            handleCartChange={handleCartChange}
            placeOrder={placeOrder}
        /> }

        <div className={s.cardWrapper}>
            <div className={`${s.card} ${s.roomServiceCard}`}>
                <div className={s.cardHeader}>
                    <div className={s.headerText}>{labels.headerText}</div>
                    {totalItemsInCart > 0 && (
                        <div className={s.cart} title={labels.cartTitle} onClick={() => setIsCartOpen(true)}>
                            <span className="material-symbols-outlined">hand_meal</span>
                            <div className={s.cartCounter}>{totalItemsInCart}</div>
                        </div>
                    )}
                </div>

                <div className={s.content}>
                    {categoryOrder.map(categoryKey => {
                        const categoryItems = sortedGroupedData[categoryKey];
                        if (!categoryItems || categoryItems.length === 0) return null;

                        return (
                            <div key={categoryKey} className={s.categorySection}>
                                <h2 className={s.categoryTitle}>
                                    {labels.categories[categoryKey]}
                                </h2>
                                
                                <div className={s.categoryItems}>
                                    {categoryItems.map(item => {
                                        const cartItem = (cart ?? []).find(orderItem => orderItem.item.id === item.id);
                                        const currentAmount = cartItem ? cartItem.quantity : 0;
                                        return <FoodBevItem
                                                key={item.id}
                                                item={item}
                                                amount={currentAmount}
                                                handleCartChange={handleCartChange}
                                        />
                                    })}
                                </div>
                            </div>
                        );
                    })}
                </div>
            </div>
        </div>
    </>
    );
}
