import { Language } from "../context/LanguageContext";

export function dateFormatter(sent_at: string, language: Language) {
    let formattedDate;
    const now = new Date();
    let date = new Date(sent_at);
    const diff = +now - +date; // + jellel számmá kényszeríti (alternatív .getTime() használata)
    if (diff < 60000) {
        formattedDate = language === 'hu' ? 'most' : 'now';
    } else if (diff < 120000) {
        formattedDate = `${Math.floor((diff) / 60000)} ${language === 'hu' ? ' perce' : ' minute ago'}`;
    } else if (diff < 3600000) {
        formattedDate = `${Math.floor((diff) / 60000)} ${language === 'hu' ? ' perce' : ' minutes ago'}`;
    } else if (diff< 7200000) {
        formattedDate = `${Math.floor((diff) / 3600000)} ${language === 'hu' ? ' órája' : ' hour ago'}`;
    } else if (diff< 86400000) {
        formattedDate = `${Math.floor((diff) / 3600000)} ${language === 'hu' ? ' órája' : ' hours ago'}`;
    } else {
        // const month = String(date.getMonth() + 1).padStart(2, '0'); // Hónap (01-12)
        // const day = String(date.getDate()).padStart(2, '0'); // Nap (01-31)
        // formattedDate = `${month}.${day}.`;
        formattedDate = date.toLocaleString((language === 'hu' ? "hu-HU" : "en-US"), {
            month: '2-digit',
            day: '2-digit',
            hour: '2-digit',
            minute: '2-digit',
            second: '2-digit',
        });
    };
    return formattedDate;
};

export function getNameOfDay(date:string, language: Language) {
    const dayName = new Date(date).toLocaleDateString((language === 'hu' ? "hu-HU" : "en-US"), {weekday: "long"});
    return dayName
}

export function addDays(dateString:string, days:number) {
    if (!dateString) return "";

    const [year, month, day] = dateString.split("-").map(Number);
    const date = new Date(year, month - 1, day);

    date.setDate(date.getDate() + days);

    const yyyy = date.getFullYear();
    const mm = String(date.getMonth() + 1).padStart(2, "0");
    const dd = String(date.getDate()).padStart(2, "0");

    return `${yyyy}-${mm}-${dd}`;
}

export interface TokenPayload {
    guest_id: number;
    booking_id: string;
    exp: number;
    iat: number;
}

export function parseJwt(token: string): TokenPayload | null {
    try {
        const base64Url = token.split('.')[1];
        const base64 = base64Url.replace(/-/g, '+').replace(/_/g, '/');
        const jsonPayload = decodeURIComponent(
            window.atob(base64)
                .split('')
                .map(c => '%' + ('00' + c.charCodeAt(0).toString(16)).slice(-2))
                .join('')
        );
        return JSON.parse(jsonPayload) as TokenPayload;
    } catch (error) {
        console.error("Érvénytelen JWT token formátum", error);
        return null;
    }
}