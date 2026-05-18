export type RoomType = "standard" | "elite" | "suite";
export type CateringType = "breakfast" | "halfboard" | "fullboard";
export interface BookingState { guests: { adult: number; child: number }; arrivalDate: string; departureDate: string; }
export interface FormData { lname: string; fname: string; email: string; country: string; zip: string; city: string; street: string; }
export interface ExtraOption { id: string; label: string; }