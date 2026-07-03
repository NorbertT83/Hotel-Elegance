// const apiURL:string = "https://nrbrt-codes.hu/hotelmanager/api/";
// const apiURL:string = "http://192.168.2.162/api/";
const apiURL: string = "http://localhost/api/";

let currentAccessToken: string | null = null;
let logoutCallback: (() => void) | null = null;
let tokenRefreshCallback: ((newToken: string) => void) | null = null;

export const apiServiceConfig = {
    setToken: (token: string | null) => { currentAccessToken = token; },
    setLogoutCallback: (cb: () => void) => { logoutCallback = cb; },
    setTokenRefreshCallback: (cb: (newToken: string) => void) => { tokenRefreshCallback = cb; }
};

export type ApiError = {
    success?: boolean;
    error?: string;
    message?: string;
} & Record<string, unknown>;
export type ApiResponse<T> = T | ApiError;

const DEFAULT_TIMEOUT = 5000;

export async function tryToRefreshToken(): Promise<string | null> {
    try {
        const res = await fetch(`${apiURL}auth/refresh`, {
            method: 'POST',
            credentials: 'include'
        });

        if (!res.ok) return null;
        const data = await res.json();

        currentAccessToken = data.accessToken;
        if (tokenRefreshCallback) tokenRefreshCallback(data.accessToken);
        return data.accessToken;
    } catch {
        return null;
    }
}

function isJsonResponse(response: Response): boolean {
    const contentType = response.headers.get('content-type') || '';
    return contentType.includes('application/json');
}

function buildQuery(params: Record<string, string> = {}): string {
    const urlParams = new URLSearchParams();
    Object.entries(params).forEach(([key, value]) => {
        if (value !== undefined && value !== null) urlParams.append(key, value);
    });
    const qs = urlParams.toString();
    return qs ? `?${qs}` : '';
}

async function parseResponse<T>(response: Response): Promise<T> {
    if (isJsonResponse(response)) {
        return await response.json() as T;
    }

    const text = await response.text();
    return text as unknown as T;
}

async function baseRequest(endpoint: string, options: RequestInit = {}, timeout = DEFAULT_TIMEOUT): Promise<Response> {
    const controller = new AbortController();
    const timeoutId = setTimeout(() => controller.abort(), timeout);

    const headers: Record<string, string> = {
        "Content-Type": "application/json",
        ...(options.headers as Record<string, string> || {}),
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
                throw new Error("Session expired");
            }
        }

        return response;
    } catch (error: unknown) {
        if (error instanceof Error && error.name === "AbortError") {
            throw new Error("Request timed out");
        }
        throw error;
    } finally {
        clearTimeout(timeoutId);
    }
}

export async function getData<T>(endpoint = "", params: Record<string, string> = {}, timeout = DEFAULT_TIMEOUT): Promise<T | null> {
    const fullEndpoint = `${endpoint}${buildQuery(params)}`;
    const response = await baseRequest(fullEndpoint, { method: 'GET' }, timeout);

    if (response.status === 404) return null;
    if (!response.ok) {
        throw new Error(`HTTP error: ${response.status}`);
    }

    return await parseResponse<T>(response);
}

export async function createData<T, R = unknown>(endpoint = "", data: T = {} as T, timeout = DEFAULT_TIMEOUT): Promise<R> {
    const response = await baseRequest(endpoint, {
        method: 'POST',
        body: JSON.stringify(data),
    }, timeout);

    if (!response.ok) {
        if (isJsonResponse(response)) {
            return await response.json() as R;
        }
        const errorBody = await response.text().catch(() => 'Unknown error');
        throw new Error(`HTTP error: ${response.status} - ${errorBody}`);
    }

    return await parseResponse<R>(response);
}

export async function updateData<T, R = unknown>(endpoint = "", id = "", data: T = {} as T, timeout = DEFAULT_TIMEOUT): Promise<R> {
    const response = await baseRequest(`${endpoint}/${id}`, {
        method: 'PUT',
        body: JSON.stringify(data),
    }, timeout);

    if (!response.ok) {
        const errorBody = await response.text().catch(() => 'Unknown error');
        throw new Error(`HTTP error: ${response.status} - ${errorBody}`);
    }

    return await parseResponse<R>(response);
}

export async function deleteData<R = unknown>(endpoint = "", id = "", timeout = DEFAULT_TIMEOUT): Promise<R> {
    const response = await baseRequest(`${endpoint}/${id}`, { method: 'DELETE' }, timeout);

    if (!response.ok) {
        const errorBody = await response.text().catch(() => 'Unknown error');
        throw new Error(`HTTP error: ${response.status} - ${errorBody}`);
    }

    if (response.status === 204) {
        return { success: true } as unknown as R;
    }

    return await parseResponse<R>(response);
}