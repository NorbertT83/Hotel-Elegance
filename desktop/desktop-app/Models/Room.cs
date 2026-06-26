using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel_erp_Winforms_App.Models
{
    internal class Room
    {
        public Room(int id, string roomtype, int floorSpace, string bedType, int hasBalcony,string hasView, int maxAdults, 
            string extras, string status, int price)
        {
            Id = id;
            Roomtype = roomtype;
            FloorSpace = floorSpace;
            BedType = bedType;
            HasBalcony = hasBalcony;
            HasView = hasView;
            MaxAdults = maxAdults;
            Extras = extras;
            Status = status;
            Price = price;
        }

        public int Id { get; set; }
        public string Roomtype { get; set; }
        public int FloorSpace { get; set; }
        public string BedType { get; set; }
        public int HasBalcony { get; set; }
        public string HasView { get; set; }
        public int MaxAdults { get; set; }
        public string Extras { get; set; }
        public string Status { get; set; }
        public int Price { get; set; }
    }
}
