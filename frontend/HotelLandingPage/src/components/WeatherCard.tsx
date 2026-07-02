import { useEffect, useState } from "react";
import { useLanguage } from "../context/LanguageContext";
import { formatLocalDateKey } from "../utils/utils";
import { guestPageText } from "../utils/translations";

export default function WeatherCard({ lat, lon }: { lat: number; lon: number }) {
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState<string | null>(null);
    const [today, setToday] = useState<any | null>(null);
    const [tomorrow, setTomorrow] = useState<any | null>(null);
    const [dayAfterTomorrow, setDayAfterTomorrow] = useState<any | null>(null);
    const { language } = useLanguage();
    const labels = guestPageText[language].guestPage.menuOverview.weatherCard

    useEffect(() => {
        let mounted = true;
        const url = `https://api.met.no/weatherapi/locationforecast/2.0/compact?lat=${lat}&lon=${lon}`;

        const fetchWeather = () => {
            setLoading(true);
            setError(null);

            fetch(url, { headers: { 'Accept': 'application/json' } })
                .then(res => {
                    if (!res.ok) throw new Error('Fetch error');
                    return res.json();
                })
                .then((json) => {
                    if (!mounted) return;
                    const timeseries = json?.properties?.timeseries || [];
                    const byDate: Record<string, any[]> = {};
                    for (const entry of timeseries) {
                        const date = formatLocalDateKey(new Date(entry.time));
                        if (!byDate[date]) byDate[date] = [];
                        byDate[date].push(entry);
                    }
                    const todayKey = formatLocalDateKey(new Date());
                    const tomorrowDate = new Date(); tomorrowDate.setDate(tomorrowDate.getDate()+1);
                    const tomorrowKey = formatLocalDateKey(tomorrowDate);
                    const dayAfterTomorrowDate = new Date(); dayAfterTomorrowDate.setDate(dayAfterTomorrowDate.getDate()+2);
                    const dayAfterTomorrowKey = formatLocalDateKey(dayAfterTomorrowDate);

                    const pick = (arr: any[], targetHour: number) => {
                        if (!arr || arr.length === 0) return null;
                        const exactMatch = arr.find((e:any) => new Date(e.time).getHours() === targetHour);
                        if (exactMatch) return exactMatch;
                        const closest = [...arr]
                            .map((entry) => ({ entry, diff: Math.abs(new Date(entry.time).getHours() - targetHour) }))
                            .sort((a, b) => a.diff - b.diff)[0];
                        return closest?.entry || arr[0];
                    }

                    setToday(pick(byDate[todayKey], new Date().getHours()));
                    setTomorrow(pick(byDate[tomorrowKey], 12));
                    setDayAfterTomorrow(pick(byDate[dayAfterTomorrowKey], 12));
                    setLoading(false);
                })
                .catch((err) => {
                    if (!mounted) return;
                    setError(err.message || 'Error');
                    setLoading(false);
                });
        };

        fetchWeather();
        const intervalId = window.setInterval(fetchWeather, 60 * 60 * 1000);

        return () => {
            mounted = false;
            window.clearInterval(intervalId);
        }
    }, [lat, lon]);

    const iconFor = (symbol?: string) => {
        if (!symbol) return '🌤️';
        if (symbol.includes('rain') || symbol.includes('sleet')) return '🌧️';
        if (symbol.includes('snow')) return '❄️';
        if (symbol.includes('clearsky') || symbol.includes('fair')) return '☀️';
        if (symbol.includes('cloud')) return '☁️';
        if (symbol.includes('fog')) return '🌫️';
        return '🌤️';
    }

    const getWeekdayLabel = (dateString: string, fallback: string) => {
        try {
            const date = new Date(dateString);
            return date.toLocaleDateString((language === 'hu' ? "hu-HU" : "en-US"), { weekday: 'long' });
        } catch {
            return fallback;
        }
    };

    const renderItem = (item: any, label: string) => {
        if (!item) return <div>{label}: N/A</div>;
        const temp = item.data?.instant?.details?.air_temperature;
        const hum = item.data?.instant?.details?.relative_humidity;
        const symbol = item.data?.next_1_hours?.summary?.symbol_code || item.data?.next_6_hours?.summary?.symbol_code || '';
        return (
            <div style={{justifyItems: 'center'}}>
                <div style={{fontWeight: 600, textTransform: 'capitalize'}}>{label}</div>
                <div style={{fontSize: '1.5rem', userSelect: 'none'}}>{iconFor(symbol)}</div>
                <div style={{display: 'flex', alignItems: 'center', gap: '.25rem'}}>
                    <div>{temp !== undefined ? `${Math.round(temp)}°C` : 'N/A'}</div>/
                    <div>{hum !== undefined ? `${Math.round(hum)}%` : 'N/A'}</div>
                </div>
            </div>
        )
    }

    if (loading) return <div>Loading weather...</div>;
    if (error) return <div>Weather error</div>;

    return <>
        {renderItem(today, labels.today)}
        <div style={{width: '1px', height: 'inherit', backgroundColor: 'var(--secondary-container)'}}></div>
        {renderItem(tomorrow, labels.tomorrow)}
        <div style={{width: '1px', height: 'inherit', backgroundColor: 'var(--secondary-container)'}}></div>
        {renderItem(dayAfterTomorrow, dayAfterTomorrow?.time ? getWeekdayLabel(dayAfterTomorrow.time, 'Day After Tomorrow') : 'Day After Tomorrow')}
    </>
}