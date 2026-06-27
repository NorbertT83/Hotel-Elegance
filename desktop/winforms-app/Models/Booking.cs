using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel_erp_Winforms_App.Models
{
    internal class Booking
    {
        public Booking(int id, int roomNumber, int guestId, DateTime beginningOfStay, DateTime endOfStay, DateTime checkin, DateTime checkout, string levelOfService)
        {
            Id = id;
            RoomNumber = roomNumber;
            GuestId = guestId;
            BeginningOfStay = beginningOfStay;
            EndOfStay = endOfStay;
            Checkin = checkin;
            Checkout = checkout;
            LevelOfService = levelOfService;
        }

        public int Id { get; set; }
        public int RoomNumber { get; set; }
        public int GuestId { get; set; } // IDE KELL AZ 1 VAGY NEM?
        public DateTime BeginningOfStay { get; set; }
        public DateTime EndOfStay { get; set; }
        public DateTime Checkin { get; set; }
        public DateTime Checkout { get; set; }
        public string LevelOfService { get; set; }
        // GUEST_ID3-4-5 STB KELL?
    }
}
