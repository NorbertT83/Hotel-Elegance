// const apiURL:string = "https://nrbrt-codes.hu/hotelmanager/api/";
// const apiURL:string = "http://192.168.2.162/api/";
const apiURL:string = "http://localhost/api/";

let currentAccessToken: string | null = null;
let logoutCallback: (() => void) | null = null;
let tokenRefreshCallback: ((newToken: string) => void) | null = null;

export const apiServiceConfig = {
    setToken: (token: string | null) => { currentAccessToken = token; },
    setLogoutCallback: (cb: () => void) => { logoutCallback = cb; },
    setTokenRefreshCallback: (cb: (newToken: string) => void) => { tokenRefreshCallback = cb; }
};

export async function tryToRefreshToken(): Promise<string | null> {
    try {
        const res = await fetch(`${apiURL}auth/refresh`, { 
            method: 'POST',
            credentials: 'include' 
        });
        
        if (res.ok) {
            const data = await res.json();
            
            currentAccessToken = data.accessToken;
            
            if (tokenRefreshCallback) {
                tokenRefreshCallback(data.accessToken);
            }
            
            return data.accessToken;
        }
        return null;
    } catch {
        return null;
    }
}

async function baseRequest(endpoint: string, options: RequestInit = {}, timeout = 5000): Promise<Response> {
    const controller = new AbortController();
    const timeoutId = setTimeout(() => controller.abort(), timeout);

    const headers: Record<string, string> = {
        "Content-Type": "application/json",
        ...(options.headers as Record<string, string>),
    };

    if (currentAccessToken) {
        headers["Authorization"] = `Bearer ${currentAccessToken}`;
    }

    try {
        let response = await fetch(`${apiURL}${endpoint}`, {
            ...options,
            headers,
            credentials: 'include',
            signal: controller.signal,
        });

        // 401 Auto-refresh kezelés
        if (response.status === 401 && !endpoint.startsWith('auth/')) {
            const newAccessToken = await tryToRefreshToken();

            if (newAccessToken) {
                headers["Authorization"] = `Bearer ${newAccessToken}`;
                response = await fetch(`${apiURL}${endpoint}`, {
                    ...options,
                    headers,
                    credentials: 'include',
                    signal: controller.signal,
                });
            } else {
                if (logoutCallback) logoutCallback();
                throw new Error("A munkamenet lejárt, kérjük jelentkezzen be újra.");
            }
        }

        return response;

    } catch (error) {
        if (error instanceof Error && error.name === "AbortError") {
            throw new Error("Időtúllépés történt a szerverrel való kommunikáció során.", { cause: error });
        }
        throw error;
    } finally {
        clearTimeout(timeoutId);
    }
}


export async function getData<T>(endpoint = "", params: Record<string, string> = {}, timeout = 5000): Promise<T> {
    const urlParams = new URLSearchParams();
    Object.entries(params).forEach(([key, value]) => {
        if (value !== undefined) urlParams.append(key, value);
    });

    const queryString = urlParams.toString();
    const fullEndpoint = queryString ? `${endpoint}?${queryString}` : endpoint;
    console.log(fullEndpoint);

    const response = await baseRequest(fullEndpoint, { method: "GET" }, timeout);

    if (response.status === 404) {
        return null as unknown as T;
    }

    if (!response.ok) {
        throw new Error(`HTTP hiba: ${response.status}`);
    }

    return await response.json() as T;
}

export async function createData<T, R = any>(endpoint = "", data:T = {} as T, timeout = 5000): Promise<R> {
    const response = await baseRequest(endpoint, {
        method: "POST",
        body: JSON.stringify(data),
    }, timeout);

    if (!response.ok) {
        const contentType = response.headers.get("content-type");
        if (contentType && contentType.includes("application/json")) {
            const errorJson = await response.json().catch(() => null);
            if (errorJson) {
                return errorJson as R;
            }
        }
        
        const errorBody = await response.text().catch(() => "Ismeretlen hiba");
        throw new Error(`HTTP hiba: ${response.status} - ${errorBody}`);
    }

    return await response.json() as R;
}

export async function updateData<T, R = Response>(endpoint = "", id = "", data: T = {} as T, timeout = 5000): Promise<R> {
    const response = await baseRequest(`${endpoint}/${id}`, {
        method: "PUT",
        body: JSON.stringify(data)
    }, timeout);

    if (!response.ok) {
        const errorBody = await response.text().catch(() => "Ismeretlen hiba");
        throw new Error(`HTTP hiba: ${response.status} - ${errorBody}`);
    }

    const contentType = response.headers.get("content-type");
    if (contentType && contentType.includes("application/json")) {
        return await response.json() as R;
    }

    return response as unknown as R;
}

export async function deleteData(endpoint = "", id = "", timeout = 5000) {
    const response = await baseRequest(`${endpoint}/${id}`, { method: "DELETE" }, timeout);

    if (!response.ok) {
        const errorBody = await response.text().catch(() => "Ismeretlen hiba");
        throw new Error(`HTTP hiba: ${response.status} - ${errorBody}`);
    }

    if (response.status === 204) {
        return { success: true };
    }

    return await response.json();
}