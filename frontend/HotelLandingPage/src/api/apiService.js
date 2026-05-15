const apiURL = "https://nrbrt-codes.hu/hotelmanager/api/";
// const apiURL = "http://localhost/api/";

export async function getData(endpoint="" , params=[], timeout = 5000) {
    
    const controller = new AbortController();
    const controllerID = setTimeout(() => controller.abort(), timeout);

    try {
        const url = new URL(apiURL+endpoint);
        Object.keys(params).forEach(key => url.searchParams.append(key, params[key]));
        const response = await fetch(url, {
            signal: controller.signal
        });

        if (!response.ok) {
            throw new Error(`HTTP hiba: ${response.status}`);
        }

        return await response.json();

    } catch (error) {
        if (error.name === "AbortError") {
            throw new Error("Időtúllépés történt");
        }
        throw error;
    } finally {
        clearTimeout(controllerID);
    }
}


export async function createData(endpoint = "", data = {}, timeout = 5000) {
    const controller = new AbortController();
    const timeoutId = setTimeout(() => controller.abort(), timeout);

    try {
        const url = `${apiURL}${endpoint}`;

        const response = await fetch(url, {
            method: "POST",
            signal: controller.signal,
            headers: {
                "Content-Type": "application/json",
                // Szükség esetén: "Authorization": `Bearer ${token}`
            },
            body: JSON.stringify(data),
        });

        if (!response.ok) {
            const errorBody = await response.text().catch(() => "Ismeretlen hiba");
            throw new Error(`HTTP hiba: ${response.status} - ${errorBody}`);
        }

        return await response.json();

    } catch (error) {
        if (error.name === "AbortError") {
            throw new Error("Időtúllépés: A szerver nem mentette el az adatokat időben.");
        }
        console.error("Create hiba:", error);
        throw error;
    } finally {
        clearTimeout(timeoutId);
    }
}


export async function updateData(endpoint="", id="" , data={}, timeout = 5000) {
    
    const controller = new AbortController();
    const controllerID = setTimeout(() => controller.abort(), timeout);

    try {
        const url = `${apiURL}${endpoint}/${id}`;

        const response = await fetch(url, {
            method: "PUT",
            signal: controller.signal,
            headers: {
                "Content-Type": "application/json",
            },
            body: JSON.stringify(data)
        });

        if (!response.ok) {
            throw new Error(`HTTP hiba: ${response.status}`);
        }

        return response;

    } catch (error) {

        if (error.name === "AbortError") {
            throw new Error("Időtúllépés történt");
        }
        throw error;
    } finally {
        clearTimeout(controllerID);
    }
}


export async function deleteData(endpoint="", id="", timeout = 5000) {
    
    const controller = new AbortController();
    const controllerID = setTimeout(() => controller.abort(), timeout);

    try {
        const url = `${apiURL}${endpoint}/${id}`;

        const response = await fetch(url, {
            method: "DELETE",
            signal: controller.signal,
            headers: {
                "Content-Type": "application/json",
            },
        });

        if (!response.ok) {
            const errorBody = await response.text().catch(() => "Ismeretlen hiba");
            throw new Error(`HTTP hiba: ${response.status} - ${errorBody}`);
        }
        if (response.status === 204) {
            return { success: true };
        }
        return await response.json();

    } catch (error) {
        if (error.name === "AbortError") {
            throw new Error("Időtúllépés történt");
        }
        throw error;
    } finally {
        clearTimeout(controllerID);
    }
}