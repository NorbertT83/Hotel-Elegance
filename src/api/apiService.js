// const apiURL = "https://nrbrt-codes.hu/hotelmanager/api/";
const apiURL = "http://localhost/api/";

export async function getData(endpoint="" , params=[], timeout = 5000) {
    
    const controller = new AbortController();
    const controllerID = setTimeout(() => controller.abort(), timeout);

    try {
        const url = new URL(apiURL+endpoint);
        Object.keys(params).forEach(key => url.searchParams.append(key, params[key]));
        const response = await fetch(url, {
            signal: controller.signal
        });

        clearTimeout(controllerID);

        if (!response.ok) {
            throw new Error(`HTTP hiba: ${response.status}`);
        }

        return await response.json();

    } catch (error) {
        clearTimeout(controllerID);
        if (error.name === "AbortError") {
            throw new Error("Időtúllépés történt");
        }
        throw error;
    }
}

export async function putData(endpoint="", id="" , data=[], timeout = 5000) {
    
    const controller = new AbortController();
    const controllerID = setTimeout(() => controller.abort(), timeout);

    try {
        const url = `${apiURL}${endpoint}${id}`;

        const response = await fetch(url, {
            method: "PUT",
            signal: controller.signal,
            headers: {
                "Content-Type": "application/json",
            },
            body: JSON.stringify(data)
        });

        clearTimeout(controllerID);

        if (!response.ok) {
            throw new Error(`HTTP hiba: ${response.status}`);
        }

        return response;

    } catch (error) {
        clearTimeout(controllerID);
        if (error.name === "AbortError") {
            throw new Error("Időtúllépés történt");
        }
        throw error;
    }
}