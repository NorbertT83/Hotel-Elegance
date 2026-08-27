using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel_erp_Winforms_App.Models
{
    public enum RoomType { standard, deluxe, suite }
    public enum CateringLevel { breakfast, halfboard, fullboard }

    public class Booking
    {
        public Booking(string id, int roomNumber,RoomType roomType, int guestId, DateTime beginningOfStay,
            DateTime endOfStay, DateTime? checkin, DateTime? checkout, int? guestId2, int? guestId3,
            int? guestId4, CateringLevel cateringLevel, DateTime? createdAt)
        {
            Id = id;
            RoomNumber = roomNumber;
            SelectedRoomType = roomType;

            GuestId = guestId;
            GuestId2 = guestId2;
            GuestId3 = guestId3;
            GuestId4 = guestId4;

            BeginningOfStay = beginningOfStay;
            EndOfStay = endOfStay;
            Checkin = checkin;
            Checkout = checkout;
            
            SelectedCateringLevel = cateringLevel;
            CreatedAt = createdAt;
        }

        public string Id { get; set; }
        public int RoomNumber { get; set; }
        public RoomType SelectedRoomType { get; set; }

        public int GuestId { get; set; }
        public int? GuestId2 { get; set; }
        public int? GuestId3 { get; set; }
        public int? GuestId4 { get; set; }

        //public Guest MainGuest { get; set; }
        //public Guest Guest2 { get; set; }
        //public Guest Guest3 { get; set; }
        //public Guest Guest4 { get; set; }

        public DateTime BeginningOfStay { get; set; }
        public DateTime EndOfStay { get; set; }

        public DateTime? Checkin { get; set; }
        public string CheckinDisplay => Checkin.HasValue ? Checkin.Value.ToString("yyyy-MM-dd HH:mm") : "Not checked in";
        public DateTime? Checkout { get; set; }
        public string CheckoutDisplay => Checkout.HasValue ? Checkout.Value.ToString("yyyy-MM-dd HH:mm") : "Not checked out";

        public CateringLevel SelectedCateringLevel{ get; set; }
        
        public DateTime? CreatedAt { get; set; }
        public Booking() { }
    }
}
