const apiURL:string = "https://api.genderize.io/?name="; //&country_id=HU

interface GenderResponse {
    count: number;
    name: string;
    gender: "male" | "female" | null;
    probability: number;
}


export default async function checkGenderFor(nameToCheck:string, locale?: string) {
    try {
        let response;
        if (locale) {
            response = await fetch(apiURL + nameToCheck + `&country_id=${locale}`);
        } else {
            response = await fetch(apiURL + nameToCheck);
        }
        if (!response.ok) {
            throw new Error("Hiba történt a lekérdezés során!");
        }
        const data: GenderResponse = await response.json();
        console.log(`Név: ${data.name}, tippelt neme: ${data.gender==="male" ? "Férfi" : data.gender === "female" ? "Nő" : "Nem ismert"}, esélye: ${(data.probability * 100)}% `);
        return data.gender
    } catch (err) {
        console.error("Hiba:", err);
    }
}

checkGenderFor("andrea", "HU");