import s from '../../styles/BookingPage.module.css';

interface Step2Props {
    roomType: RoomType;
    setRoomType: (type: RoomType) => void;
    onBack: () => void;
    onNext: () => void;
}

export type RoomType = "standard" | "elite" | "suite";

const ROOM_OPTIONS: { id: RoomType; label: string }[] = [
    { id: "standard", label: "Standard" },
    { id: "elite", label: "Elite" },
    { id: "suite", label: "Suite" },
];

export default function Step2RoomSelection({ roomType, setRoomType, onBack, onNext }: Step2Props) {
    return (
        <div className={s.cardContainer}>
            <div className={s.card}>
                <h2>Lakosztály</h2>
                <h3>Válassza ki az Önnek megfelelő lakosztályunk egyikét</h3>
                
                {/* A szobaválasztó most már interaktív és kap egy s.active osztályt a kijelölttől */}
                <div className={s.chooseRoom}>
                    {ROOM_OPTIONS.map((room) => (
                        <div 
                            key={room.id}
                            className={`${s.roomOption} ${roomType === room.id ? s.active : ''}`}
                            onClick={() => setRoomType(room.id)}
                        >
                            <p>{room.label}</p>
                        </div>
                    ))}
                </div>

                <div className={s.buttonContainer}>
                    <button className="btn btn-secondary" onClick={onBack}>Vissza</button>
                    <button className="btn btn-primary" onClick={onNext}>
                        <span>Tovább</span><span className="material-symbols-outlined">arrow_forward</span>
                    </button>
                </div>
            </div>
        </div>
    );
}