using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel_erp_Winforms_App.Models
{
    public enum ServiceTypeHu { Wellness, Extrák, Logisztika}
    public enum ServiceTypeEn { Wellness, Extras, Logistics}

    public class Service
    {
        public Service(int id, string nameHu, string descriptionHu, ServiceTypeHu selectedServiceTypeHu, decimal price, string nameEn, string descriptionEn, ServiceTypeEn selectedServiceTypeEn)
        {
            Id = id;
            NameHu = nameHu;
            DescriptionHu = descriptionHu;
            SelectedServiceTypeHu = selectedServiceTypeHu;
            Price = price;
            NameEn = nameEn;
            DescriptionEn = descriptionEn;
            SelectedServiceTypeEn = selectedServiceTypeEn;
        }

        public int Id { get; set; }
        public string NameHu { get; set; }
        public string DescriptionHu { get; set; }
        public ServiceTypeHu SelectedServiceTypeHu { get; set; }
        public decimal Price { get; set; }
        public string NameEn { get; set; }
        public string DescriptionEn { get; set; }
        public ServiceTypeEn SelectedServiceTypeEn { get; set; }
    }
}
