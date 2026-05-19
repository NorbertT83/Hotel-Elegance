import { useEffect, useState, useCallback } from 'react';
import { useLanguage } from '../context/LanguageContext';
import { getData } from '../api/apiService';
import s from '../styles/Services.module.css';
import { landingPageText } from '../translations';

interface HotelService {
    id: string | number;
    service_type_hu: string;
    service_type_en: string;
    name_hu: string;
    name_en: string;
    description_hu: string;
    description_en: string;
    price: number;
    [key: string]: any;
}

export default function Services() {
    const { language } = useLanguage();
    const [loading, setLoading] = useState(false);
    const [error, setError] = useState<string | null>(null);
    const [services, setServices] = useState<HotelService[]>([]);
    const text = landingPageText[language].services;

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

                {[...new Set(services.map(ser => ser[`service_type_${language}`]))].map((type) => (
                    
                    <div className={s.serviceCard} key={type}>
                        <h2 className={s.cardTitle}>
                            {type.charAt(0).toUpperCase() + type.slice(1)}
                        </h2>
                        
                        <div className={s.serviceList}>
                            {services
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