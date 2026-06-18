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
import { useState } from "react";

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
    dont_disturb: {
        icon: 'do_not_disturb_on_total_silence',
        color: 'var(--on-surface-variant)',
    },
    door_locked: {
        icon: 'door_open', //'door_front',
        color: 'var(--error)' //,'green'
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
    ac_temp: {
        icon: 'hvac',
        color: 'var(--primary)',
    }
}

export default function Overview() {
    const { language } = useLanguage();
    const { guest, currentBooking, currentRoom, currentBookedServices, refreshBookedServices, updateThermostat } = useGuest();
    const labels = guestPageText[language].guestPage.menuOverview;


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
                    <div><span className="material-symbols-outlined" title={`${labels.roomCard.roomSize}`}>square_foot</span></div>
                    <div>{currentRoom.floorspace} m<sup style={{fontSize: '.6rem'}}>2</sup></div>

                    <div><span className="material-symbols-outlined" title={`${labels.roomCard.bedtype}`}>king_bed</span></div>
                    <div>{currentRoom.bed_type}</div>

                    <div>{labels.roomCard.status}</div>
                        <div><span className="material-symbols-outlined">{roomStatusIcons[currentRoom.status].icon}</span>
                    </div>

                    <div className={s.thermostatContainer}>
                        <span className={`material-symbols-outlined ${s.icon}`}>hvac</span>
                        <div className={s.onOff} onClick={() => updateThermostat(0)}><span className="material-symbols-outlined">{currentRoom.ac_temp ? 'mode_fan' : 'mode_fan_off'}</span></div>
                        <div className={s.thermostat}>
                            <span className="material-symbols-outlined" onClick={() => updateThermostat(1)}>remove</span>
                            <span>{currentRoom.ac_temp}</span>
                            <span className="material-symbols-outlined" onClick={() => updateThermostat(-1)}>add</span>
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