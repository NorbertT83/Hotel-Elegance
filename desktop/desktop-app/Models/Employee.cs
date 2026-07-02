using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel_erp_Winforms_App.Models
{
    public class Employee
    {
        public Employee() { }

        public Employee(int id, string fName, string lName, string taxNumber, int paidHolidaysLeft,
            string address, DateTime dateOfBirth, DateTime dateOfHiring, string jobTitle, int salary, DateTime createdAt, DateTime updatedAt)
        {
            Id = id;
            FName = fName;
            LName = lName;
            TaxNumber = taxNumber;
            PaidHolidaysLeft = paidHolidaysLeft;
            Address = address;
            DateOfBirth = dateOfBirth;
            DateOfHiring = dateOfHiring;
            JobTitle = jobTitle;
            Salary = salary;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }

        public int Id { get; set; }
        public string? FName { get; set; }
        public string? LName { get; set; }
        public string? TaxNumber { get; set; }
        public int PaidHolidaysLeft { get; set; }
        public string? Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime DateOfHiring { get; set; }
        public string? JobTitle { get; set; } //enum?
        public int Salary { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
