import { useGuest } from "../../context/GuestContext";
import { useLanguage } from "../../context/LanguageContext";
import { guestPageText } from "../../utils/translations";
import { dateFormatter } from "../../utils/utils";
import { BookedService } from "../../types/booking";
import { createData } from "../../services/apiService";
import s from '../../styles/GuestSubPages.module.css';
import FloorPlanIcon from '../../assets/floorplan.svg';
import CurrentWeatherHeader from "../../components/CurrentWeatherHeader";
import WeatherCard from "../../components/WeatherCard";
import { useEffect, useRef, useState } from "react";

const serviceStatusIcons = {
    created: {
        icon: 'assignment',
        color: 'var(--on-surface-variant)',
    },
    pending: {
        icon: 'pending_actions',
        color: 'var(--text-on-background)',
    },
    completed: {
        icon: 'check_circle',
        color: 'var(--primary)',
    },
    deleted: {
        icon: 'contract_delete',
        color: 'gray',
    },
}

export default function Overview() {
    const { language } = useLanguage();
    const { guest, currentBooking, currentRoom, currentBookedServices, refreshBookedServices, updateRoomFeature } = useGuest();
    const labels = guestPageText[language].guestPage.menuOverview;

    function usePersistedBoolean(key: string, initial: boolean) {
        const [value, setValue] = useState<boolean>(initial);
        useEffect(() => {
            try {
                const raw = localStorage.getItem(key);
                setValue(raw === null ? initial : raw === 'true');
            } catch { setValue(initial); }
        }, [key, initial]);

        useEffect(() => {
            try { localStorage.setItem(key, String(value)); } catch {}
        }, [key, value]);

        return [value, setValue] as const;
    }
    
    const [optimisticTemp, setOptimisticTemp] = useState<number | null>(null);
    const [optimisticLocked, setOptimisticLocked] = useState<boolean | null>(null);
    const [optimisticDoNotDisturb, setOptimisticDoNotDisturb] = useState<boolean | null>(null);
    const [optimisticNeedsCleaning, setOptimisticNeedsCleaning] = useState<boolean | null>(null);
    const acDebounceTimer = useRef<ReturnType<typeof setTimeout> | null>(null);
    const lockDebounceTimer = useRef<ReturnType<typeof setTimeout> | null>(null);
    const doNotDisturbDebounceTimer = useRef<ReturnType<typeof setTimeout> | null>(null);
    const needsCleaningDebounceTimer = useRef<ReturnType<typeof setTimeout> | null>(null);
    const lastSentTemp = useRef<number | null>(null);
    const lastSentLocked = useRef<boolean | null>(null);
    const lastSentDoNotDisturb = useRef<boolean | null>(null);
    const lastSentNeedsCleaning = useRef<boolean | null>(null);

    useEffect(() => {
        if (currentRoom) {
            setOptimisticTemp(currentRoom.ac_temp);
            setOptimisticLocked(currentRoom.door_locked);
            setOptimisticDoNotDisturb(currentRoom.dont_disturb);
            setOptimisticNeedsCleaning(currentRoom.needs_cleaning);
            lastSentTemp.current = currentRoom.ac_temp;
            lastSentLocked.current = currentRoom.door_locked;
            lastSentDoNotDisturb.current = currentRoom.dont_disturb;
            lastSentNeedsCleaning.current = currentRoom.needs_cleaning;
        }
    }, [currentRoom]);

    const guestKey = 'cardCollapsed:guest';
    const weatherKey = 'cardCollapsed:weather';
    const roomKey = 'cardCollapsed:room';
    const serviceKey = 'cardCollapsed:service';

    const [guestCollapsed, setGuestCollapsed] = usePersistedBoolean(guestKey, false);
    const [weatherCollapsed, setWeatherCollapsed] = usePersistedBoolean(weatherKey, false);
    const [roomCollapsed, setRoomCollapsed] = usePersistedBoolean(roomKey, false);
    const [serviceCollapsed, setServiceCollapsed] = usePersistedBoolean(serviceKey, false);

    const scheduleFeatureUpdate = <T,>(
        nextValue: T,
        setOptimistic: (value: T) => void,
        lastSentRef: { current: T | null },
        debounceRef: { current: ReturnType<typeof setTimeout> | null },
        updateFn: (value: T) => Promise<boolean>,
        fallbackValue: T
    ) => {
        setOptimistic(nextValue);

        if (debounceRef.current) {
            clearTimeout(debounceRef.current);
        }

        debounceRef.current = setTimeout(async () => {
            if (lastSentRef.current !== nextValue) {
                const success = await updateFn(nextValue);
                if (success) {
                    lastSentRef.current = nextValue;
                } else {
                    setOptimistic(fallbackValue);
                }
            }
        }, 1000);
    };

    const scheduleThermostatUpdate = (nextTemp: number) => {
        scheduleFeatureUpdate<number>(
            nextTemp,
            setOptimisticTemp,
            lastSentTemp,
            acDebounceTimer,
            (value) => updateRoomFeature('ac_temp', value),
            currentRoom?.ac_temp ?? 0
        );
    };

    const scheduleDoorLockUpdate = (nextLocked: boolean) => {
        scheduleFeatureUpdate<boolean>(
            nextLocked,
            setOptimisticLocked,
            lastSentLocked,
            lockDebounceTimer,
            (value) => updateRoomFeature('door_locked', value),
            currentRoom?.door_locked ?? false
        );
    };

    const scheduleDoNotDisturbUpdate = (nextValue: boolean) => {
        scheduleFeatureUpdate<boolean>(
            nextValue,
            setOptimisticDoNotDisturb,
            lastSentDoNotDisturb,
            doNotDisturbDebounceTimer,
            (value) => updateRoomFeature('dont_disturb', value),
            currentRoom?.dont_disturb ?? false
        );
    };

    const scheduleNeedsCleaningUpdate = (nextValue: boolean) => {
        scheduleFeatureUpdate<boolean>(
            nextValue,
            setOptimisticNeedsCleaning,
            lastSentNeedsCleaning,
            needsCleaningDebounceTimer,
            (value) => updateRoomFeature('needs_cleaning', value),
            currentRoom?.needs_cleaning ?? false
        );
    };

    const getVisibleTemperature = () => optimisticTemp ?? currentRoom?.ac_temp ?? 0;
    const changeBaseTemp = () => (getVisibleTemperature() === 0 ? 22 : getVisibleTemperature());
    const getVisibleDoorLocked = () => optimisticLocked ?? currentRoom?.door_locked ?? false;
    const getVisibleDoNotDisturb = () => optimisticDoNotDisturb ?? currentRoom?.dont_disturb ?? false;
    const getVisibleNeedsCleaning = () => optimisticNeedsCleaning ?? currentRoom?.needs_cleaning ?? false;

    const isOlderThanTwoHours = (timestamp: string) => {
        return Date.now() - new Date(timestamp).getTime() > 2 * 60 * 60 * 1000;
    };

    const visibleBookedServices = currentBookedServices
        .filter((sb) => !(sb.status === 'deleted' && isOlderThanTwoHours(sb.updated_at)))
        .slice()
        .sort((prev, curr) => +new Date(curr.updated_at) - +new Date(prev.updated_at));

    async function handleBookedServiceDelete(service: BookedService) {
        try {
            service.status = 'deleted';
            const response = await createData('servicebooking/updatestatus', service);
            if (!response && !response.success) {
                console.log(`Hiba: ${response?.error}`)
                return
            }
            refreshBookedServices();
        } catch {
            console.log('Hiba az update közben');
        }
    }

    if (!guest || !currentBooking || !currentRoom) return;

    return (
        <div className={s.cardWrapper}>
            <div className={`${s.card} ${s.guestCard} ${guestCollapsed ? s.collapsed : ''}`}>
                <div className={s.cardHeader}>
                    <div className={s.headerText}>{currentBooking.id}</div>
                    <div className={s.vipLevel} title={language=='hu' ? 'VIP szintje' : 'Your VIP level'}>{guest.loyalty_level}</div>
                    <button aria-label="Toggle guest card" className={s.collapseButton} onClick={() => setGuestCollapsed(!guestCollapsed)}>
                        <span className="material-symbols-outlined">{guestCollapsed ? 'expand_more' : 'expand_less'}</span>
                    </button>
                </div>

                <div className={s.content}>
                    <div className={s.firstCol}>{labels.guestCard.nameText}</div>
                    <div>{guest.lname} {guest.fname}</div>
                    <div className={s.firstCol}>{labels.guestCard.emailText}</div>
                    <div className={s.truncate}>{guest.email}</div>
                    <div className={`${s.span3} ${s.firstCol}`}>{labels.guestCard.addressText}</div>
                    <div>{guest.country} {guest.zip_code}</div>
                    <div>{guest.city}</div>
                    <div>{guest.street}</div>
                    {guest.car_plate_number ? <>
                        <div className={s.firstCol}>{labels.guestCard.car}</div>
                        <div>{guest.car_plate_number}</div>
                        </> : ''}
                    
                    <div className={s.firstCol}>{labels.guestCard.nightsSlept}</div>
                    <div>{guest.total_nights}</div>

                </div>
            </div>

            <div className={`${s.card} ${s.weatherCard} ${weatherCollapsed ? s.collapsed : ''}`}>
                <div className={s.cardHeader}>
                    <div style={{display: 'flex', alignItems: 'center', gap: '.5rem'}}>
                        <div className={s.headerText}>{labels.weatherCard.headerText}</div>
                    </div>
                    <CurrentWeatherHeader lat={47.52956} lon={19.0766} />
                    <button aria-label="Toggle weather card" className={s.collapseButton} onClick={() => setWeatherCollapsed(!weatherCollapsed)}>
                        <span className="material-symbols-outlined">{weatherCollapsed ? 'expand_more' : 'expand_less'}</span>
                    </button>
                </div>

                <div className={s.content}>
                    <WeatherCard lat={47.52956} lon={19.0766} />
                </div>
            </div>

            <div className={`${s.card} ${s.roomCard} ${roomCollapsed ? s.collapsed : ''}`}>
                <div className={s.cardHeader}>
                    <div className={s.headerText}>{labels.roomCard.room} <strong>#{currentRoom.room_number}</strong></div>
                    <img className={s.headerIcon} src={FloorPlanIcon} alt="floorplan" />
                    <button aria-label="Toggle room card" className={s.collapseButton} onClick={() => setRoomCollapsed(!roomCollapsed)}>
                        <span className="material-symbols-outlined">{roomCollapsed ? 'expand_more' : 'expand_less'}</span>
                    </button>
                </div>

                <div className={s.content}>
                    <div className={`${s.subCardContainer} ${getVisibleTemperature() === 0 ? s.acOff : s.rotateFan}`}>
                        <div className={s.icon}>A/C</div>
                        <div className={s.onOff}
                            onClick={() => scheduleThermostatUpdate(getVisibleTemperature() ? 0 : 22)}>
                                <span className="material-symbols-outlined">{getVisibleTemperature() ? 'mode_fan' : 'mode_fan_off'}
                                </span>
                        </div>
                        <div className={s.thermostat}>
                            <span className="material-symbols-outlined"
                                onClick={() => scheduleThermostatUpdate(changeBaseTemp() - 1)}>remove
                            </span>

                            <div className={s.tempDisplay}>{getVisibleTemperature()}</div>

                            <span className="material-symbols-outlined"
                                onClick={() => scheduleThermostatUpdate(changeBaseTemp() + 1)}>add
                            </span>
                        </div>
                    </div>
                    
                    <div className={s.infoContainer}>
                        <div className={s.infoItem} title={labels.roomCard.roomType}>
                            <span className="material-symbols-outlined">hotel</span>
                            <span>{currentRoom.room_type}</span>
                        </div>
                        <div className={s.infoItem} title={labels.roomCard.bedType}>
                            <span className="material-symbols-outlined">king_bed</span>
                            <span>{currentRoom.bed_type}</span>
                        </div>
                        <div className={s.infoItem} title={labels.roomCard.roomSize}>
                            <span className="material-symbols-outlined">square_foot</span>
                            <span>{currentRoom.floorspace} m<sup style={{fontSize: '.6rem'}}>2</sup></span>
                        </div>
                        <div className={s.infoItem} title={labels.roomCard.view}>
                            <span className="material-symbols-outlined">visibility</span>
                            <span>{currentRoom.has_view}</span>
                        </div>
                    </div>

                    <div className={`${s.subCardContainer} ${getVisibleDoorLocked() ? '' : s.unlocked}`}>
                        <div className={s.icon}> {labels.roomCard.door} </div>
                        <div className={s.toggle}
                            onClick={() => scheduleDoorLockUpdate(!getVisibleDoorLocked())}>
                                <span className="material-symbols-outlined">
                                    {getVisibleDoorLocked() ? 'lock' : 'lock_open'}
                                </span>
                        </div>
                        <div className={s.toggleStatus}>
                            {getVisibleDoorLocked() ? labels.roomCard.closed : labels.roomCard.open}
                        </div>
                    </div>

                    <div className={`${s.subCardContainer} ${getVisibleDoNotDisturb() ? '' : s.unlocked}`}>
                        <div className={s.icon}>{labels.roomCard.DND}</div>
                        <div className={s.toggle}
                            onClick={() => scheduleDoNotDisturbUpdate(!getVisibleDoNotDisturb())}>
                                <span className="material-symbols-outlined">
                                    {getVisibleDoNotDisturb() ? 'do_not_disturb_on' : 'do_not_disturb_off'}
                                </span>
                        </div>
                        <div className={s.toggleStatus}>
                            {getVisibleDoNotDisturb() ? labels.roomCard.DND_on : labels.roomCard.DND_off}
                        </div>
                    </div>

                    <div className={`${s.subCardContainer}`}>
                        <div className={s.icon}>{labels.roomCard.needsCleaning}</div>
                        <div className={s.toggle}
                            onClick={() => scheduleNeedsCleaningUpdate(!getVisibleNeedsCleaning())}>
                                <span className="material-symbols-outlined">
                                    {getVisibleNeedsCleaning() ? 'cleaning_services' : 'cleaning'}
                                </span>
                        </div>
                        <div className={s.toggleStatus}>
                            {getVisibleNeedsCleaning() ? labels.roomCard.needsCleaning_on : labels.roomCard.needsCleaning_off}
                        </div>
                    </div>

                </div>
            </div>

            <div className={`${s.card} ${s.serviceCard} ${serviceCollapsed ? s.collapsed : ''}`}>
                <div className={s.cardHeader}>
                    <div className={s.headerText}>{labels.serviceCard.headerText}</div>
                    <button aria-label="Toggle service card" className={s.collapseButton} onClick={() => setServiceCollapsed(!serviceCollapsed)}>
                        <span className="material-symbols-outlined">{serviceCollapsed ? 'expand_more' : 'expand_less'}</span>
                    </button>
                </div>

                <div className={s.content}>
                    <div className={s.serviceTableHead}>
                        <span> {labels.serviceCard.description} </span>
                        <span> {labels.serviceCard.latestUpdate} </span>
                        <span> {labels.serviceCard.status} </span>
                    </div>
                    {visibleBookedServices.map((sb) => (
                        <div key={sb.id} className={s.serviceItem}>
                            <span style={sb.status === 'deleted' ? {textDecoration: 'line-through'} : undefined}>{sb[`name_${language}`]}</span>
                            <span>{dateFormatter(sb.updated_at, language)}</span>
                            <div className={s.serviceStatusWrapper}>
                                <span style={{color: serviceStatusIcons[sb.status].color}} title={labels.serviceCard[sb.status]} className="material-symbols-outlined">{serviceStatusIcons[sb.status].icon}</span>
                                {sb.status === 'created' &&
                                    <button className={`btn ${s.deleteButton}`} onClick={()=>handleBookedServiceDelete(sb)}><span className="material-symbols-outlined">delete</span></button>
                                }
                            </div>
                        </div>
                    ))}
                </div>
            </div>

        </div>
    )
}