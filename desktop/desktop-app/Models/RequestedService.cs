using System;
using System.Collections.Generic;
using System.Text;
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace Hotel_erp_Winforms_App.Models
{
    public enum ServiceStatus{ created, pending, completed, deleted }
    public enum ServiceType{ Wellness, Extras, Logistics}

    internal class RequestedService
    {
        public int RoomNumber { get; set; }
        public ServiceStatus CurrentServiceStatus { get; set; }
        public DateTime RequestedAt { get; set; }
        public string Name { get; set; }
        public ServiceType SelectedServiceType { get; set; }
        public int Price { get; set; }

        public RequestedService(int roomNumber, ServiceStatus currentServiceStatus, DateTime requestedAt, string name, ServiceType selectedServiceType, int price)
        {
            RoomNumber = roomNumber;
            CurrentServiceStatus = currentServiceStatus;
            RequestedAt = requestedAt;
            Name = name;
            SelectedServiceType = selectedServiceType;
            Price = price;
        }
    }
}
