import { useEffect, useState, useMemo } from 'react';
import { useGuest } from '../../context/GuestContext';
import { useLanguage } from '../../context/LanguageContext';
import { createData } from '../../services/apiService';
import ServiceItem from '../../components/ServiceItem';
import MessageBoxModal from '../../components/MessageBoxModal';
import s from '../../styles/GuestSubPages.module.css';
import { guestPageText } from '../../utils/translations';
import { HotelService } from '../../types/booking';

export type ServiceOrderItem = {
    item: HotelService;
    quantity: number;
};

export default function Logistics() {
    const { language } = useLanguage();
    const labels = guestPageText[language].guestPage.menuLogistics;
    const { currentBooking, services, refreshBookedServices } = useGuest();
    const [cart, setCart] = useState<ServiceOrderItem[]>([]);
    const [isCartOpen, setIsCartOpen] = useState<boolean>(false);
    const [showSuccessModal, setShowSuccessModal] = useState<boolean>(false);

    const logisticsServices = useMemo(() => {
        return services
            .filter((service) => service.service_type_en === 'Logistics')
            .sort((a, b) => {
                const nameA = String(a[`name_${language}` as keyof HotelService]);
                const nameB = String(b[`name_${language}` as keyof HotelService]);
                return nameA.localeCompare(nameB, language);
            });
    }, [language, services]);

    function handleCartChange(id: HotelService['id'], quantity: number) {
        setCart((prev) => {
            const idString = String(id);
            if (quantity <= 0) {
                return prev.filter((orderItem) => String(orderItem.item.id) !== idString);
            }
            const existingIndex = prev.findIndex((orderItem) => String(orderItem.item.id) === idString);
            if (existingIndex > -1) {
                const updated = [...prev];
                updated[existingIndex] = { ...updated[existingIndex], quantity };
                return updated;
            }
            const serviceItem = logisticsServices.find((service) => String(service.id) === idString);
            if (!serviceItem) return prev;
            return [...prev, { item: serviceItem, quantity }];
        });
    }

    async function placeOrder(cartValue: number) {
        try {
            await Promise.all(
                cart.map((orderItem) =>
                    createData('servicebooking', {
                        booking_id: currentBooking?.id,
                        service_id: orderItem.item.id,
                        quantity: orderItem.quantity,
                        price_at_booking: orderItem.item.price * orderItem.quantity,
                    })
                )
            );
            setCart([]);
            setShowSuccessModal(true);
            setIsCartOpen(false);
            refreshBookedServices();
        } catch (err: any) {
            console.error('Hiba történt a logisztikai szolgáltatás rendelése közben:', err?.message || err);
        }
    }

    const totalItemsInCart = cart.reduce((sum, current) => sum + current.quantity, 0);
    const cartValue = cart.reduce((sum, current) => sum + current.quantity * current.item.price, 0);

    useEffect(() => {
        if (!totalItemsInCart) setIsCartOpen(false);
    }, [totalItemsInCart]);

    return (
        <>
            {showSuccessModal && (
                <MessageBoxModal
                    headerText={language === 'hu' ? 'Információ' : 'Information'}
                    message={
                        language === 'hu'
                            ? 'Sikeres logisztikai szolgáltatás rendelés! Köszönjük!'
                            : 'Logistics service order placed successfully! Thank you!'
                    }
                    timeout={2500}
                    onClose={() => setShowSuccessModal(false)}
                />
            )}

            {isCartOpen && cart.length > 0 && (
                <div className={s.cartModal}>
                    <div className={`${s.card} ${s.cartWrapper}`}>
                        <div className={`${s.cardHeader} ${s.cartHeader}`}>
                            <div className={s.headerText}>{labels.cartTitle}</div>
                            <button className={s.closeButton} onClick={() => setIsCartOpen(false)} aria-label="Close">
                                <span className="material-symbols-outlined">close</span>
                            </button>
                        </div>
                        <div className={s.cartContent}>
                            <div className={s.categoryItems}>
                                {cart.map((orderItem) => (
                                    <ServiceItem
                                        key={String(orderItem.item.id)}
                                        item={orderItem.item}
                                        amount={orderItem.quantity}
                                        handleCartChange={handleCartChange}
                                    />
                                ))}
                            </div>
                        </div>
                        <div className={s.cartTotal}>
                            <span>{labels.cartTotal}</span>
                            <span className={s.price}>{Intl.NumberFormat(language === 'hu' ? 'hu-HU' : 'en-US').format(cartValue)} Ft</span>
                        </div>
                        <button className={`btn btn-secondary ${s.orderButton}`} onClick={() => placeOrder(cartValue)}>
                            {labels.cartOrder}
                        </button>
                    </div>
                </div>
            )}

            <div className={s.cardWrapper}>
                <div className={`${s.card} ${s.serviceCard}`}>
                    <div className={s.cardHeader}>
                        <div className={s.headerText}>{labels.headerText}</div>
                        {totalItemsInCart > 0 && (
                            <div className={s.cart} title={labels.cartTitle} onClick={() => setIsCartOpen(true)}>
                                <span className="material-symbols-outlined">shopping_cart</span>
                                <div className={s.cartCounter}>{totalItemsInCart}</div>
                            </div>
                        )}
                    </div>
                    <div className={s.content}>
                        {logisticsServices.map((service) => {
                            const cartItem = cart.find((orderItem) => String(orderItem.item.id) === String(service.id));
                            const currentAmount = cartItem ? cartItem.quantity : 0;
                            return (
                                <ServiceItem
                                    key={String(service.id)}
                                    item={service}
                                    amount={currentAmount}
                                    handleCartChange={handleCartChange}
                                />
                            );
                        })}
                    </div>
                </div>
            </div>
        </>
    );
}
