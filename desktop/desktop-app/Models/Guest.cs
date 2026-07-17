using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;

namespace Hotel_erp_Winforms_App.Models
{
    public class Guest
    {
        public Guest(string email, string idCardNumber, string fName, string lName, DateTime? dateOfBirth, 
            string country, string zipCode, string city, string street, string carPlateNumber, int totalNights, int loyaltyLevel)
        {
            Email = email;
            IdCardNumber = idCardNumber;
            FName = fName;
            LName = lName;
            DateOfBirth = dateOfBirth;
            Country = country;
            ZipCode = zipCode;
            City = city;
            Street = street;
            CarPlateNumber = carPlateNumber;
            TotalNights = totalNights;
            LoyaltyLevel = loyaltyLevel;
        }

        public string Email { get; set; }
        public string IdCardNumber { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string CarPlateNumber { get; set; }
        public int TotalNights { get; set; }
        public int LoyaltyLevel { get; set; }
    }
}
