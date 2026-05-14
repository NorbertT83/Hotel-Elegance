export function getNameOfDay(date, language) {
    const dayName = new Date(date).toLocaleDateString((language === 'hu' ? "hu-HU" : "en-US"), {weekday: "long"});
    return dayName
}