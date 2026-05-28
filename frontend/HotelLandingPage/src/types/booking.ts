import { Country } from "../utils/countries";

export type RoomType = "standard" | "deluxe" | "suite";
export type CateringType = "breakfast" | "halfboard" | "fullboard";
export type ExtraOption = "balcony" | "panorama"| "garden" | "jacuzzi" | "kitchen" | "latecheckout" | "transfer" | "champagne";
export interface FormData { lname: string; fname: string; email: string; country: string; zip: string; city: string; street: string; }

export interface BookingState {
    guests: { adult: number; child: number };
    arrivalDate: string;
    departureDate: string;
    roomTypeChosen: RoomType;
    cateringChosen: CateringType;
    extrasChosen: ExtraOption[];
    formData: FormData;
    freeRooms: Room[];
}

export interface Room {
    room_number: number;
    room_type: RoomType;
    floorspace: number;
    bedtype: "single"|"twin"|"queen"|"kingsize";
    has_balcony: number;
    has_view: "city"|"garden"|"panorama";
    max_adults: number;
    extras: "jacuzzi"|"kitchen";
    status: "available"|"needs_cleaning"|"cleaning"|"occupied"|"dont_disturb"|"under_maintenance"|"unavailable";
    price_per_night: number;
}

export interface Guest {
    id: number,
    fname: string,
    lname: string,
    email: string,
    id_card_number: string | null,
    date_of_birth: Date | null,
    country: Country['name'],
    zip_code: string,
    city: string,
    street: string,
    car_plate_number: string | null,
    total_nights: number,
    loyalty_level: number,
    role: string
}