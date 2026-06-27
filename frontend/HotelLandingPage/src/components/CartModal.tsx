import FoodBevItem from './FoodBevItem';
import { OrderItem } from '../pages/guest/RoomService';
import { guestPageText } from '../utils/translations';
import { useLanguage } from '../context/LanguageContext';
import s from '../styles/GuestSubPages.module.css'

interface CartModalProps {
    cart: OrderItem[];
    isCartOpen: boolean;
    setIsCartOpen: React.Dispatch<React.SetStateAction<boolean>>;
    handleCartChange: (id: number, quantity: number) => void;
    placeOrder: (cartValue: number) => void;
}


export default function CartModal({cart, isCartOpen, setIsCartOpen, handleCartChange, placeOrder }: CartModalProps) {
    const { language } = useLanguage()
    const labels = guestPageText[language].guestPage.menuRoomservice;

    const cartValue = cart.reduce((sum, current) => sum + (current.quantity * current.item.price), 0);

    return <>
        {cart.length !== 0 && isCartOpen &&
        <div className={s.cartModal}>
            <div className={`${s.card} ${s.cartWrapper}`}>
                <div className={`${s.cardHeader} ${s.cartHeader}`}>
                    <div className={s.headerText}>
                        {labels.cartTitle}
                    </div>
                    <button className={s.closeButton} onClick={() => setIsCartOpen(false)} aria-label="Bezárás">
                        <span className="material-symbols-outlined">close</span>
                    </button>
                </div>
                <div className={s.cartContent}>
                    <div className={s.categoryItems}>
                        {cart.map(orderitem => (
                            <FoodBevItem 
                                key={orderitem.item.id}
                                item={orderitem.item}
                                amount={orderitem.quantity}
                                handleCartChange={handleCartChange}
                            />)
                        )}
                    </div>
                </div>
                <div className={s.cartTotal}>
                    <span>{labels.cartTotal}</span>
                    <span className={s.price}>{Intl.NumberFormat(language === 'hu' ? 'hu-HU' : 'en-US').format(cartValue)} Ft</span>
                </div>
                <button className={`btn btn-secondary ${s.orderButton}`} onClick={() => placeOrder(cartValue)}>{labels.cartOrder}</button>
            </div>
        </div>
        }
    </>
}
