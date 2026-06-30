using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel_erp_Winforms_App.Models
{
    public class Booking
    {
        public Booking(int id, int roomNumber, int guestId, DateTime beginningOfStay, DateTime endOfStay, DateTime? checkin, DateTime? checkout,
            int guestId2, int guestId3, int guestId4, string levelOfService)
        {
            Id = id;
            RoomNumber = roomNumber;
            GuestId = guestId;
            BeginningOfStay = beginningOfStay;
            EndOfStay = endOfStay;
            Checkin = checkin;
            Checkout = checkout;
            GuestId2 = guestId2;
            GuestId3 = guestId3;
            GuestId4 = guestId4;
            LevelOfService = levelOfService;
        }

        public int Id { get; set; }
        public int RoomNumber { get; set; }
        public int GuestId { get; set; } // IDE KELL AZ 1 VAGY NEM?
        public DateTime BeginningOfStay { get; set; }
        public DateTime EndOfStay { get; set; }
        public DateTime? Checkin { get; set; }
        public string CheckinDisplay => Checkin.HasValue ? Checkin.Value.ToString("yyyy-MM-dd HH:mm") : "Még nincs adat";
        public DateTime? Checkout { get; set; }
        public int GuestId2 {  get; set; }
        public int GuestId3 { get; set; }
        public int GuestId4 { get; set; }
        public string? LevelOfService { get; set; }
        public Booking() { }
        // GUEST_ID3-4-5 STB KELL?
    }
}
