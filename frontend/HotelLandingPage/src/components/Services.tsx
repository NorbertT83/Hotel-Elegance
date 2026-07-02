import { useEffect, useState, useCallback } from 'react';
import { useLanguage } from '../context/LanguageContext';
import { getData } from '../services/apiService';
import { HotelService } from '../types/booking';
import s from '../styles/Services.module.css';
import { landingPageText } from '../utils/translations';

export default function Services() {
    const { language } = useLanguage();
    const [loading, setLoading] = useState(false);
    const [error, setError] = useState<string | null>(null);
    const [services, setServices] = useState<HotelService[]>([]);
    const text = landingPageText[language].services;
    const filteredServices = services.filter((service) => {
        const serviceType = service[`service_type_${language}`];
        return typeof serviceType === 'string' && serviceType.trim().length > 0;
    });

    const fetchServices = useCallback(async (serviceId: string = "") => {
        setLoading(true);
        setError(null);
        try {
            const data = await getData<HotelService[]>(
                `service/${serviceId || "all"}`,
                {
                    sort: `name_${language}`
                }
            );

            setServices(data);
        } catch (err: any) {
            setError(err.message);
            throw err;
        } finally {
            setLoading(false);
        }
    }, []);

    useEffect(() => {
        fetchServices();
    }, [fetchServices]);

    return (
        <section className={s.servicesSection} id='services'>
            <h2>{text.sectionTitle}</h2>
            <p>{text.sectionDescription}</p>
            
            {error && <div className="error-msg">{error}</div>}
            {loading ? (
                <div className="loader" style={{textAlign: 'center'}}>Adatok betöltése...</div>
            ) : (
            <div className={s.servicesContainer}>

                {[...new Set(filteredServices.map(ser => ser[`service_type_${language}`]))].map((type) => (
                    
                    <div className={s.serviceCard} key={type}>
                        <h2 className={s.cardTitle}>
                            {type.charAt(0).toUpperCase() + type.slice(1)}
                        </h2>
                        
                        <div className={s.serviceList}>
                            {filteredServices
                                .filter((service) => service[`service_type_${language}`] === type)
                                .map((service) => (
                                    <div key={service.id} className={s.serviceItem}>
                                        {service[`name_${language}`]}
                                    </div>
                                ))
                            }
                        </div>
                    </div>
                ))}
            </div>
            )}
        </section>
    );
}