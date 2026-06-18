import { useGuest } from "../../context/GuestContext";
import { useLanguage } from "../../context/LanguageContext";
import { guestPageText } from "../../utils/translations";
import { dateFormatter } from "../../utils/utils";
import { BookedService, Room } from "../../types/booking";
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

const roomStatusIcons = {
    available: {
        icon: 'check_circle', // vagy 'meeting_room'
        color: 'var(--primary)',
    },
    unavailable: {
        icon: 'block',
        color: 'var(--error)',
    },
    cleaning: {
        icon: 'cleaning', //vacuum
        color: 'var(--on-surface-variant)',
    },
    needs_cleaning: {
        icon: 'cleaning_services',
        color: 'aqua',
    },
    occupied: {
        icon: 'person_check', //sensor_occupied
        color: 'var(--on-surface-variant)',
    },
    under_maintenance: {
        icon: 'construction',
        color: 'var(--primary)',
    },
}

export default function Overview() {
    const { language } = useLanguage();
    const { guest, currentBooking, currentRoom, currentBookedServices, refreshBookedServices, updateRoomFeature } = useGuest();
    const labels = guestPageText[language].guestPage.menuOverview;
    const [optimisticTemp, setOptimisticTemp] = useState<number | null>(null);
    const [optimisticLocked, setOptimisticLocked] = useState<boolean | null>(null);
    const [optimisticDoNotDisturb, setOptimisticDoNotDisturb] = useState<boolean | null>(null);
    const debounceTimer = useRef<ReturnType<typeof setTimeout> | null>(null);
    const lockDebounceTimer = useRef<ReturnType<typeof setTimeout> | null>(null);
    const doNotDisturbDebounceTimer = useRef<ReturnType<typeof setTimeout> | null>(null);
    const lastSentTemp = useRef<number | null>(null);
    const lastSentLocked = useRef<boolean | null>(null);
    const lastSentDoNotDisturb = useRef<boolean | null>(null);

    useEffect(() => {
        if (currentRoom) {
            setOptimisticTemp(currentRoom.ac_temp);
            setOptimisticLocked(currentRoom.door_locked);
            lastSentTemp.current = currentRoom.ac_temp;
            lastSentLocked.current = currentRoom.door_locked;
        }
    }, [currentRoom]);

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
            debounceTimer,
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

    const getVisibleTemperature = () => optimisticTemp ?? currentRoom?.ac_temp ?? 0;
    const changeBaseTemp = () => (getVisibleTemperature() === 0 ? 22 : getVisibleTemperature());

    const getVisibleDoorLocked = () => optimisticLocked ?? currentRoom?.door_locked ?? false;
    const getVisibleDoNotDisturb = () => optimisticDoNotDisturb ?? currentRoom?.dont_disturb ?? false;

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
            <div className={`${s.card} ${s.guestCard}`}>
                <div className={s.cardHeader}>
                    <div className={s.headerText}>{currentBooking.id}</div>
                    <div className={s.vipLevel} title={language=='hu' ? 'VIP szintje' : 'Your VIP level'}>{guest.loyalty_level}</div>
                </div>

                <div className={s.content}>
                    <div>{labels.guestCard.nameText}</div>
                    <div>{guest.lname} {guest.fname}</div>
                    <div>{labels.guestCard.emailText}</div>
                    <div className={s.truncate}>{guest.email}</div>
                    <div className={s.span3}>{labels.guestCard.addressText}</div>
                    <div>{guest.country} {guest.zip_code}</div>
                    <div>{guest.city}</div>
                    <div>{guest.street}</div>
                    {guest.car_plate_number ? <>
                        <div>{labels.guestCard.car}</div>
                        <div>{guest.car_plate_number}</div>
                        </> : ''}
                    
                    <div>{labels.guestCard.nightsSlept}</div>
                    <div>{guest.total_nights}</div>

                </div>
            </div>

            <div className={`${s.card} ${s.weatherCard}`}>
                <div className={s.cardHeader}>
                    <div style={{display: 'flex', alignItems: 'center', gap: '.5rem'}}>
                        <div className={s.headerText}>{labels.weatherCard.headerText}</div>
                    </div>
                    <CurrentWeatherHeader lat={47.52956} lon={19.0766} />
                </div>

                <div className={s.content}>
                    <WeatherCard lat={47.52956} lon={19.0766} />
                </div>
            </div>

            <div className={`${s.card} ${s.roomCard}`}>
                <div className={s.cardHeader}>
                    <div className={s.headerText}>{labels.roomCard.room} <strong>#{currentRoom.room_number}</strong></div>
                    <img className={s.headerIcon} src={FloorPlanIcon} alt="floorplan" />
                </div>

                <div className={s.content}>
                    <div className={s.infoContainer}>
                        <div className={s.infoItem}>
                            <span className="material-symbols-outlined" title={labels.roomCard.roomSize}>square_foot</span>
                            <span>{currentRoom.floorspace} m<sup style={{fontSize: '.6rem'}}>2</sup></span>
                        </div>
                        <div className={s.infoItem}>
                            <span className="material-symbols-outlined" title={labels.roomCard.bedtype}>king_bed</span>
                            <span>{currentRoom.bed_type}</span>
                        </div>
                        <div className={s.infoItem}>
                            <span className="material-symbols-outlined" title={labels.roomCard.roomType}>hotel</span>
                            <span>{currentRoom.room_type}</span>
                        </div>
                        <div className={s.infoItem}>
                            <span className="material-symbols-outlined" title={labels.roomCard.status}>{roomStatusIcons[currentRoom.status].icon}</span>
                            <span>{currentRoom.status.replace(/_/g, ' ')}</span>
                        </div>
                        <div className={s.infoItem}>
                            <span className="material-symbols-outlined" title={labels.roomCard.view}>visibility</span>
                            <span>{currentRoom.has_view}</span>
                        </div>
                        <div className={s.infoItem}>
                            <span className="material-symbols-outlined" title={labels.roomCard.extras}>room_service</span>
                            <span>{currentRoom.extras}</span>
                        </div>
                    </div>

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

                </div>
            </div>

            <div className={`${s.card} ${s.serviceCard}`}>
                <div className={s.cardHeader}>
                    <div className={s.headerText}>{labels.serviceCard.headerText}</div>
                </div>

                <div className={s.content}>
                    <div className={s.serviceTableHead}>
                        <span> {labels.serviceCard.description} </span>
                        <span> {labels.serviceCard.latestUpdate} </span>
                        <span> {labels.serviceCard.status} </span>
                    </div>
                    {currentBookedServices.sort((prev, curr) => +new Date(curr.updated_at) - +new Date(prev.updated_at)).map((sb) => (
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