using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel_erp_Winforms_App.Models
{
    public class BillingItem
    {
        public int ServiceId { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public decimal Tax { get; set; }
        public decimal Total { get; set; }

        public BillingItem(int serviceId, DateTime date, string description, decimal unitPrice, int quantity, decimal tax, decimal total)
        {
            ServiceId = serviceId;
            Date = date;
            Description = description;
            UnitPrice = unitPrice;
            Quantity = quantity;
            Tax = tax;
            Total = total;
        }
    }
}
