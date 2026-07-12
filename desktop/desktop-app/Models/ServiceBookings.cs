using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel_erp_Winforms_App.Models
{
    public enum Status { created, pending, completed, deleted }

    public class ServiceBookings
    {
        public ServiceBookings(int id, string bookingId, int serviceId, DateTime requestedAt, DateTime updatedAt, int quantity, Status currentStatus, int price)
        {
            Id = id;
            BookingId = bookingId;
            ServiceId = serviceId;
            RequestedAt = requestedAt;
            UpdatedAt = updatedAt;
            Quantity = quantity;
            CurrentStatus = currentStatus;
            Price = price;
        }

        public int Id { get; set; }
        public string BookingId { get; set; }
        public int ServiceId { get; set; }
        public DateTime RequestedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int Quantity { get; set; }
        public Status CurrentStatus { get; set; }
        public int Price { get; set; }
    }
}
