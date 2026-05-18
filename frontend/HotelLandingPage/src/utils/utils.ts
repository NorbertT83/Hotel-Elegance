export function getNameOfDay(date:string, language:string) {
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