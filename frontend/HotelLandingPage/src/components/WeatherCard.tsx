import { useEffect, useState } from "react";
import { useLanguage } from "../context/LanguageContext";
import { formatLocalDateKey } from "../utils/utils";
import { guestPageText } from "../translations";
import type { WeatherForecastResponse, WeatherTimeseriesEntry } from '../types/weather';

const isError = (value: unknown): value is Error => value instanceof Error;

export default function WeatherCard({ lat, lon }: { lat: number; lon: number }) {
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState<string | null>(null);
    const [today, setToday] = useState<WeatherTimeseriesEntry | null>(null);
    const [tomorrow, setTomorrow] = useState<WeatherTimeseriesEntry | null>(null);
    const [dayAfterTomorrow, setDayAfterTomorrow] = useState<WeatherTimeseriesEntry | null>(null);
    const { language } = useLanguage();
    const labels = guestPageText[language].guestPage.menuOverview.weatherCard;

    useEffect(() => {
        const controller = new AbortController();
        const url = `https://api.met.no/weatherapi/locationforecast/2.0/compact?lat=${lat}&lon=${lon}`;

        const pickEntry = (arr: WeatherTimeseriesEntry[] | undefined, targetHour: number) => {
            if (!arr?.length) return null;
            const exactMatch = arr.find((entry) => new Date(entry.time).getHours() === targetHour);
            if (exactMatch) return exactMatch;
            const closest = arr
                .map((entry) => ({ entry, diff: Math.abs(new Date(entry.time).getHours() - targetHour) }))
                .sort((a, b) => a.diff - b.diff)[0];
            return closest?.entry || arr[0];
        };

        const fetchWeather = async () => {
            setLoading(true);
            setError(null);

            try {
                const response = await fetch(url, {
                    headers: { 'Accept': 'application/json' },
                    signal: controller.signal,
                });

                if (!response.ok) {
                    throw new Error('Fetch error');
                }

                const json = (await response.json()) as WeatherForecastResponse;
                const timeseries = Array.isArray(json?.properties?.timeseries) ? json.properties.timeseries : [];
                const byDate: Record<string, WeatherTimeseriesEntry[]> = {};

                for (const entry of timeseries) {
                    const dateKey = formatLocalDateKey(new Date(entry.time));
                    byDate[dateKey] = byDate[dateKey] || [];
                    byDate[dateKey].push(entry);
                }

                const todayKey = formatLocalDateKey(new Date());
                const tomorrowDate = new Date();
                tomorrowDate.setDate(tomorrowDate.getDate() + 1);
                const tomorrowKey = formatLocalDateKey(tomorrowDate);
                const dayAfterTomorrowDate = new Date();
                dayAfterTomorrowDate.setDate(dayAfterTomorrowDate.getDate() + 2);
                const dayAfterTomorrowKey = formatLocalDateKey(dayAfterTomorrowDate);

                setToday(pickEntry(byDate[todayKey], new Date().getHours()));
                setTomorrow(pickEntry(byDate[tomorrowKey], 12));
                setDayAfterTomorrow(pickEntry(byDate[dayAfterTomorrowKey], 12));
            } catch (err) {
                if (controller.signal.aborted) {
                    return;
                }
                setError(isError(err) ? err.message : 'Weather fetch failed');
            } finally {
                setLoading(false);
            }
        };

        void fetchWeather();
        const intervalId = window.setInterval(fetchWeather, 60 * 60 * 1000);

        return () => {
            controller.abort();
            window.clearInterval(intervalId);
        };
    }, [lat, lon]);

    const iconFor = (symbol?: string) => {
        if (!symbol) return '🌤️';
        if (symbol.includes('rain') || symbol.includes('sleet')) return '🌧️';
        if (symbol.includes('snow')) return '❄️';
        if (symbol.includes('clearsky') || symbol.includes('fair')) return '☀️';
        if (symbol.includes('cloud')) return '☁️';
        if (symbol.includes('fog')) return '🌫️';
        return '🌤️';
    };

    const getWeekdayLabel = (dateString: string, fallback: string) => {
        try {
            const date = new Date(dateString);
            return date.toLocaleDateString((language === 'hu' ? 'hu-HU' : 'en-US'), { weekday: 'long' });
        } catch {
            return fallback;
        }
    };

    const renderItem = (item: WeatherTimeseriesEntry | null, label: string) => {
        if (!item) return <div>{label}: N/A</div>;
        const temp = item.data?.instant?.details?.air_temperature;
        const hum = item.data?.instant?.details?.relative_humidity;
        const symbol = item.data?.next_1_hours?.summary?.symbol_code || item.data?.next_6_hours?.summary?.symbol_code || '';
        return (
            <div style={{ justifyItems: 'center' }}>
                <div style={{ fontWeight: 600, textTransform: 'capitalize' }}>{label}</div>
                <div style={{ fontSize: '1.5rem', userSelect: 'none' }}>{iconFor(symbol)}</div>
                <div style={{ display: 'flex', alignItems: 'center', gap: '.25rem' }}>
                    <div>{temp !== undefined ? `${Math.round(temp)}°C` : 'N/A'}</div>/
                    <div>{hum !== undefined ? `${Math.round(hum)}%` : 'N/A'}</div>
                </div>
            </div>
        );
    };

    if (loading) return <div>Loading weather...</div>;
    if (error) return <div>Weather error</div>;

    return <>
        {renderItem(today, labels.today)}
        <div style={{ width: '1px', height: 'inherit', backgroundColor: 'var(--secondary-container)' }}></div>
        {renderItem(tomorrow, labels.tomorrow)}
        <div style={{ width: '1px', height: 'inherit', backgroundColor: 'var(--secondary-container)' }}></div>
        {renderItem(dayAfterTomorrow, dayAfterTomorrow?.time ? getWeekdayLabel(dayAfterTomorrow.time, 'Day After Tomorrow') : 'Day After Tomorrow')}
    </>;
}
