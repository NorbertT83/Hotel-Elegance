using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel_erp_Winforms_App.Models
{
    internal class Room
    {
        public Room(int id, string roomtype, int floorSpace, int bedType, bool hasBalcony, int maxAdults, string extras, Status currentStatus, int price)
        {
            Id = id;
            Roomtype = roomtype;
            FloorSpace = floorSpace;
            BedType = bedType;
            HasBalcony = hasBalcony;
            MaxAdults = maxAdults;
            Extras = extras;
            CurrentStatus = currentStatus;
            Price = price;
        }

        public int Id { get; set; }
        public string Roomtype { get; set; }
        public int FloorSpace { get; set; }
        public int BedType { get; set; }
        public bool HasBalcony { get; set; }
        public int MaxAdults { get; set; }
        public string Extras { get; set; }
        public enum Status
        {
            Available,
            Occupied,
            Dont_disturb,
            Needs_cleaning,
            Cleaning,
            Under_maintance,
            Unavailable
        }
        public Status CurrentStatus { get; set; }
        public int Price { get; set; }
    }
}

//TODO: A TÖBBI OSZTÁLY MEGÍRÁSA