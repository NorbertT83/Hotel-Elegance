import { useEffect, useState } from "react";

interface MessageBoxProps {
    headerText: string,
    message: string,
    timeout?: number,
    onClose: () => void
}

export default function MessageBoxModal({headerText, message, timeout = 0, onClose}: MessageBoxProps) {
    const [showMessageBox, setShowMessageBox] = useState(true);

    useEffect(() => {
        if (timeout <= 0) return;

        const timer = setTimeout(() => {
            setShowMessageBox(false);
            if (onClose) onClose();
        }, timeout);

        return () => clearTimeout(timer);
    }, [timeout]);

    if (!showMessageBox) {
        return null;
    }

    return (
        <div className="messageBoxModal">
            <div className="messageBoxHeader">{ headerText }</div>
            <div className="messageBoxBody">{ message }</div>
            <div>
                <button onClick={() => setShowMessageBox(false)}>
                    <span className="material-symbols-outlined">close</span>
                </button>
            </div>
        </div>
    )
}

// TODO - Style the modal!