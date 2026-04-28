const apiURL = "https://nrbrt-codes.hu/hotelmanager/api/";

export async function getData(endpoint="" , params=[], timeout = 5000) {
    
    const controller = new AbortController();
    const id = setTimeout(() => controller.abort(), timeout);

    try {
        const url = new URL(apiURL+endpoint);
        Object.keys(params).forEach(key => url.searchParams.append(key, params[key]));
        const response = await fetch(url, {
            signal: controller.signal
        });

        clearTimeout(id);

        if (!response.ok) {
            throw new Error(`HTTP hiba: ${response.status}`);
        }

        return await response.json();

    } catch (error) {
        clearTimeout(id);
        if (error.name === "AbortError") {
            throw new Error("Időtúllépés történt");
        }
        throw error;
    }
}