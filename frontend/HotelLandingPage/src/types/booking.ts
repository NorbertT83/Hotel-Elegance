import { Country } from "../utils/countries";

export type RoomType = "standard" | "deluxe" | "suite";
export type CateringType = "breakfast" | "halfboard" | "fullboard";
export type ExtraOption = "balcony" | "panorama"| "garden" | "jacuzzi" | "kitchen" | "latecheckout" | "transfer" | "champagne";
export interface FormData { lname: { value: string; isTouched: boolean }; fname: { value: string; isTouched: boolean }; email: { value: string; isTouched: boolean }; country: { value: string; isTouched: boolean }; zip: { value: string; isTouched: boolean }; city: { value: string; isTouched: boolean }; street: { value: string; isTouched: boolean }; }

export interface BookingState {
    bookingId: string;
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
    bed_type: "single"|"twin"|"queen"|"kingsize";
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

export interface BookedService {
    id: number,
    service_id: number,
    name_hu: string,
    description_hu: string,
    service_type_hu: string,
    name_en: string,
    description_en: string,
    service_type_en: string,
    price_at_booking: number,
    quantity: number,
    status: 'created' | 'pending' | 'completed' | 'deleted',
    requested_at: string,
    updated_at: string,
}

export interface HotelService {
    id: string | number;
    service_type_hu: string;
    service_type_en: string;
    name_hu: string;
    name_en: string;
    description_hu: string;
    description_en: string;
    price: number;
    [key: string]: any;
}