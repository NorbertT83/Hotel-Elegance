import { useEffect, useState } from "react";

export default function CurrentWeatherHeader({ lat, lon }: { lat: number; lon: number }) {
    const [temp, setTemp] = useState<number | null>(null);
    const [hum, setHum] = useState<number | null>(null);

    useEffect(() => {
        let mounted = true;
        const url = `https://api.met.no/weatherapi/locationforecast/2.0/compact?lat=${lat}&lon=${lon}`;
        fetch(url, { headers: { 'Accept': 'application/json' } })
            .then(r => { if (!r.ok) throw new Error('fetch'); return r.json(); })
            .then(json => {
                if (!mounted) return;
                const timeseries = json?.properties?.timeseries || [];
                const now = new Date();
                const todayKey = now.toISOString().slice(0,10);
                const currentHour = now.getUTCHours();

                let found = timeseries.find((e:any) => {
                    const d = new Date(e.time);
                    return d.toISOString().slice(0,10) === todayKey && d.getUTCHours() === currentHour;
                });
                if (!found && timeseries.length) found = timeseries[0];

                const t = found?.data?.instant?.details?.air_temperature;
                const h = found?.data?.instant?.details?.relative_humidity;
                setTemp(typeof t === 'number' ? Math.round(t) : null);
                setHum(typeof h === 'number' ? Math.round(h) : null);
            })
            .catch(() => {
                if (!mounted) return;
            });

        return () => { mounted = false };
    }, [lat, lon]);

    if (temp === null || hum === null) return <div style={{color: 'var(--on-surface-variant)'}}>—</div>;

    return (
        <div style={{fontSize: '.9rem', color: 'var(--on-surface-variant)'}}>
            {temp} °C / {hum} %
        </div>
    );
}