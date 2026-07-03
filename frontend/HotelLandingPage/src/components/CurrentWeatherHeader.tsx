import { useEffect, useState } from "react";
import s from '../styles/GuestSubPages.module.css';
import { formatLocalDateKey } from '../utils/utils';
import type { WeatherForecastResponse, WeatherTimeseriesEntry } from '../types/weather';

export default function CurrentWeatherHeader({ lat, lon }: { lat: number; lon: number }) {
    const [temp, setTemp] = useState<number | null>(null);
    const [hum, setHum] = useState<number | null>(null);

    useEffect(() => {
        const controller = new AbortController();
        const url = `https://api.met.no/weatherapi/locationforecast/2.0/compact?lat=${lat}&lon=${lon}`;

        const fetchWeather = async () => {
            try {
                const response = await fetch(url, {
                    headers: { 'Accept': 'application/json' },
                    signal: controller.signal,
                });

                if (!response.ok) {
                    throw new Error('Failed to load weather data');
                }

                const json = (await response.json()) as WeatherForecastResponse;
                const timeseries = Array.isArray(json?.properties?.timeseries) ? json.properties.timeseries : [];
                const now = new Date();
                const todayKey = formatLocalDateKey(now);
                const currentHour = now.getHours();

                let found = timeseries.find((entry: WeatherTimeseriesEntry) => {
                    const entryDate = new Date(entry.time);
                    return formatLocalDateKey(entryDate) === todayKey && entryDate.getHours() === currentHour;
                });

                if (!found && timeseries.length) {
                    const closest = timeseries
                        .map((entry) => ({ entry, diff: Math.abs(new Date(entry.time).getHours() - currentHour) }))
                        .sort((a, b) => a.diff - b.diff)[0];
                    found = closest?.entry || timeseries[0];
                }

                const t = found?.data?.instant?.details?.air_temperature;
                const h = found?.data?.instant?.details?.relative_humidity;
                setTemp(typeof t === 'number' ? Math.round(t) : null);
                setHum(typeof h === 'number' ? Math.round(h) : null);
            } catch (error) {
                if (controller.signal.aborted) {
                    return;
                }

                setTemp(null);
                setHum(null);
            }
        };

        void fetchWeather();
        return () => {
            controller.abort();
        };
    }, [lat, lon]);

    if (temp === null || hum === null) return <div style={{ color: 'var(--on-surface-variant)' }}>—</div>;

    return (
        <div className={s.currentWeather} style={{ fontSize: '.9rem', color: 'var(--on-surface-variant)' }}>
            {temp} °C / {hum} %
        </div>
    );
}