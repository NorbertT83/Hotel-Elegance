export interface WeatherDetails {
    air_temperature?: number;
    relative_humidity?: number;
    [key: string]: number | undefined;
}

export interface WeatherSummary {
    symbol_code?: string;
}

export interface WeatherInstantData {
    details?: WeatherDetails;
}

export interface WeatherNextHoursData {
    summary?: WeatherSummary;
}

export interface WeatherTimeseriesEntry {
    time: string;
    data: {
        instant?: WeatherInstantData;
        next_1_hours?: WeatherNextHoursData;
        next_6_hours?: WeatherNextHoursData;
        next_12_hours?: WeatherNextHoursData;
    };
}

export interface WeatherForecastResponse {
    properties?: {
        timeseries?: WeatherTimeseriesEntry[];
    };
}
