import { useEffect, useState, useCallback } from 'react';
import { getData } from '../api/apiService.js';

export default function Services() {
    const [loading, setLoading] = useState(false);
    const [error, setError] = useState(null);
    const [services, setServices] = useState([]);

    const fetchServices = useCallback(async (serviceId = "") => {
        setLoading(true);
        setError(null);
        try {
            const data = await getData(`service/${serviceId ? serviceId : "all"}?sort=name`);
            setServices(data);
        } catch (err) {
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
        <section className='services-section' id='services'>
            <ul>
                {services.map((service) => (
                    <li key={service.id}>{service.name}</li>)
                )}
            </ul>
        </section>
    )
}