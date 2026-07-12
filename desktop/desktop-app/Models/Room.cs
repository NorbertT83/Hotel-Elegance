using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel_erp_Winforms_App.Models
{
    public class Room
    {
        public enum RoomType { standard, deluxe, suite }
        public enum Status { available, occupied, unavailable, under_maintenance }
        public enum BedType { single, twin, kingsize }
        public enum HasView { city, garden, panorama}

        public Room(int room_number, RoomType roomsRoomType, int floorSpace, BedType roomsBedType, int hasBalcony,HasView roomsView, int maxAdults, 
            string extras, Status currentStatus, int price, int doorLocked, int needsCleaning, int dontDisturb, int isCleaning, int acTemp)
        {
            Room_number = room_number;
            RoomsRoomtype = roomsRoomType;
            FloorSpace = floorSpace;
            RoomsBedType = roomsBedType;
            HasBalcony = hasBalcony;
            RoomsView = roomsView;
            MaxAdults = maxAdults;
            Extras = extras;
            CurrentStatus = currentStatus;
            Price = price;
            DoorLocked = doorLocked;
            NeedsCleaning = needsCleaning;
            DontDisturb = dontDisturb;
            IsCleaning = isCleaning;
            AcTemp = acTemp;
            
        }

        public int Room_number { get; set; }
        public RoomType RoomsRoomtype { get; set; }
        public int FloorSpace { get; set; }
        public BedType RoomsBedType { get; set; }
        public int HasBalcony { get; set; }
        public HasView RoomsView { get; set; }
        public int MaxAdults { get; set; }
        public string Extras { get; set; }
        public Status CurrentStatus { get; set; }
        public int Price { get; set; }
        public int DoorLocked { get; set; }
        public int NeedsCleaning { get; set; }
        public int DontDisturb { get; set; }
        public int IsCleaning { get; set; }
        public int AcTemp { get; set; }
    }
}
