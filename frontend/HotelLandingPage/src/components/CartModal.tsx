import { OrderItem } from '../pages/guest/RoomService';
import s from '../styles/GuestSubPages.module.css'
import FoodBevItem from './FoodBevItem';

interface CartModalProps {
    cart: OrderItem[];
    isCartOpen: boolean;
    setIsCartOpen: React.Dispatch<React.SetStateAction<boolean>>;
    handleCartChange: (id: number, quantity: number) => void;
}

export default function CartModal({cart, isCartOpen, setIsCartOpen, handleCartChange }: CartModalProps) {
    return <>
        {cart.length !== 0 && isCartOpen &&
        <div className={s.cartModal}>
            <button className={s.closeButton} onClick={() => setIsCartOpen(false)}>Close</button>
            <div className={`${s.card} ${s.cartWrapper}`}>
                <div className={`${s.cardHeader} ${s.cartHeader}`}>
                    <div className={s.headerText}>
                        Kosár tartalma:
                    </div>
                </div>
                <div className={s.cartContent}>
                    {cart.map(orderitem => (
                        <FoodBevItem 
                            key={orderitem.item.id}
                            item={orderitem.item}
                            amount={orderitem.quantity}
                            handleCartChange={handleCartChange}
                        />)
                    )}
                    <button className='btn btn-primary'>Megrendelés</button>
                </div>
            </div>
        </div>
        }
    </>
}
