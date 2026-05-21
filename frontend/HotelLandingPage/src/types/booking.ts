export type RoomType = "standard" | "deluxe" | "suite";
export type CateringType = "breakfast" | "halfboard" | "fullboard";
export type ExtraOption = "jacuzzi" | "kitchen";

export interface BookingState { guests: { adult: number; child: number }; arrivalDate: string; departureDate: string; extrasChosen: Record<string, boolean>; roomTypeChosen: RoomType; cateringChosen: CateringType; freeRooms: Room[]; }

export interface FormData { lname: string; fname: string; email: string; country: string; zip: string; city: string; street: string; }

export interface Room {
    room_number: number;
    room_type: RoomType;
    floor_space: number;
    bedtype: "single"|"twin"|"queen"|"kingsize";
    has_balcony: number;
    has_view: "city"|"garden"|"panorama";
    max_adults: number;
    extras: "jacuzzi"|"kitchen";
    status: "available"|"needs_cleaning"|"cleaning"|"occupied"|"dont_disturb"|"under_maintenance"|"unavailable";
    price_per_night: number;
}