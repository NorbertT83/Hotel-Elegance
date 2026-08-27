import { useEffect, useState } from "react";
import s from "../styles/MessageBoxModal.module.css";

interface MessageBoxProps {
    headerText: string;
    message: string;
    timeout?: number;
    onClose: () => void;
    type?: 'success' | 'info' | 'warning' | 'error';
}

export default function MessageBoxModal({
    headerText,
    message,
    timeout = 0,
    onClose,
    type = 'success',
}: MessageBoxProps) {
    const [showMessageBox, setShowMessageBox] = useState(true);
    const [isClosing, setIsClosing] = useState(false);

    const handleClose = () => {
        if (isClosing) return;
        setIsClosing(true);
        setTimeout(() => {
            setShowMessageBox(false);
            if (onClose) onClose();
        }, 220);
    };

    useEffect(() => {
        if (timeout <= 0) return;

        const timer = setTimeout(() => {
            handleClose();
        }, timeout);

        return () => clearTimeout(timer);
    }, [timeout]);

    useEffect(() => {
        const handleKeyDown = (e: KeyboardEvent) => {
            if (e.key === 'Escape') {
                handleClose();
            }
        };

        document.addEventListener('keydown', handleKeyDown);
        return () => document.removeEventListener('keydown', handleKeyDown);
    }, []);

    if (!showMessageBox) {
        return null;
    }

    const iconName = type === 'error' ? 'error' : type === 'warning' ? 'warning' : type === 'info' ? 'info' : 'check_circle';

    return (
        <div
            className={`${s.modalBackground} ${isClosing ? s.fadeOut : ''}`}
            onClick={(e) => {
                if (e.target === e.currentTarget) {
                    handleClose();
                }
            }}
            role="presentation"
        >
            <div
                className={`${s.modalContainer} ${isClosing ? s.slideOut : ''}`}
                role="dialog"
                aria-modal="true"
                aria-labelledby="messagebox-title"
                aria-describedby="messagebox-body"
            >
                <button
                    className={s.closeButton}
                    onClick={handleClose}
                    aria-label="Close"
                >
                    <span className="material-symbols-outlined">close</span>
                </button>

                <div className={s.iconWrapper}>
                    <span className={`material-symbols-outlined ${s.statusIcon}`}>
                        {iconName}
                    </span>
                </div>

                <div className={s.modalContent}>
                    <h3 id="messagebox-title" className={s.messageBoxHeader}>
                        {headerText}
                    </h3>
                    <p id="messagebox-body" className={s.messageBoxBody}>
                        {message}
                    </p>
                </div>

                <div className={s.buttonContainer}>
                    <button
                        className={s.confirmBtn}
                        onClick={handleClose}
                    >
                        OK
                    </button>
                </div>

                {timeout > 0 && (
                    <div className={s.progressBarContainer}>
                        <div
                            className={s.progressBar}
                            style={{ animationDuration: `${timeout}ms` }}
                        />
                    </div>
                )}
            </div>
        </div>
    );
}