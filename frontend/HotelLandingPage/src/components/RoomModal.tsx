import React, {useEffect} from 'react';
import s from '../styles/RoomModal.module.css'
import { RoomType } from '../types/booking';
import { landingPageText } from '../translations';
import { useLanguage } from '../context/LanguageContext';

interface Props {
    roomType: RoomType;
    isOpen: boolean;
    onClose?: () => void;
    className?: string;
}

export default function RoomModal({roomType, isOpen, onClose }:Props) {
    const { language } = useLanguage();
    const roomData = landingPageText[language].rooms.types[roomType];
    const standardData = landingPageText[language].rooms.types['standard'];

    function handleBgClick(e: React.MouseEvent<HTMLDivElement>) {
        if (e.target === e.currentTarget && onClose) {
            onClose();
        }
    }

    useEffect(() => {
        const handleKeyDown = (e: KeyboardEvent) => {
            if (e.key === 'Escape' && isOpen) {
                if (onClose) {
                    onClose();
                }
            }
        };

        document.addEventListener('keydown', handleKeyDown);
        return () => document.removeEventListener('keydown', handleKeyDown);
    }, [isOpen, onClose]);

    if (!isOpen) return null;

    return (
        <div className={s.modalBackground} onClick={handleBgClick}>
            <div className={s.modalContainer}>
                <div className={s.closeButton} onClick={onClose}>
                    <span className="material-symbols-outlined">close</span>
                </div>
                <div className={s.imgContainer}>
                    <img src={roomData.imageURL} alt={roomData.imageAlt} />
                </div>

                <div className={s.details}>
                    <h2>{roomData.title}</h2>
                    <p className={s.description}>{roomData.description}</p>
                    <div className={s.featureContainer}>
                        <ul className={s.featureList}>
                            {standardData.features.map((feature, index) => (
                                <li key={index}>{feature}</li>
                            ))}
                        </ul>
                        {roomType !== 'standard' && (<ul className={s.featureList}>
                            {roomData.features.map((feature, index) => (
                                <li key={index}>{feature}</li>
                            ))}
                        </ul>)}
                    </div>

                    <span className={s.price}>{roomData.price} <span>{roomData.priceSuffix}</span></span>
                </div>

            </div>
        </div>
    )
}
