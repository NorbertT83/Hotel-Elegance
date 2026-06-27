using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;

namespace Hotel_erp_Winforms_App.Models
{
    internal class Guest
    {
        public Guest(string email, string idCardNumber, string fName, string lName, DateTime dateOfBirth, 
            string country, string adress, string carPlateNumber, int comulativeNights, int loyaltyLevel)
        {
            Email = email;
            IdCardNumber = idCardNumber;
            FName = fName;
            LName = lName;
            DateOfBirth = dateOfBirth;
            Country = country;
            Adress = adress;
            CarPlateNumber = carPlateNumber;
            ComulativeNights = comulativeNights;
            LoyaltyLevel = loyaltyLevel;
        }

        public string Email { get; set; }
        public string IdCardNumber { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Country { get; set; }
        public string Adress { get; set; }
        public string CarPlateNumber { get; set; }
        public int ComulativeNights { get; set; }
        public int LoyaltyLevel { get; set; }
    }
}
