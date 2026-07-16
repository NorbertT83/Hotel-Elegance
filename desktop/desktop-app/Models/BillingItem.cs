using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel_erp_Winforms_App.Models
{
    public class BillingItem
    {
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public int UnitPrice { get; set; }
        public int Quantity { get; set; }
        public decimal Tax { get; set; }
        public decimal Total { get; set; }

        public BillingItem(DateTime date, string description, int unitPrice, int quantity, decimal tax, decimal total)
        {
            Date = date;
            Description = description;
            UnitPrice = unitPrice;
            Quantity = quantity;
            Tax = tax;
            Total = total;
        }
    }
}
