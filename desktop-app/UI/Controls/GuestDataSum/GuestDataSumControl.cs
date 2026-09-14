using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Hotel_erp_Winforms_App.Models;

namespace Hotel_erp_Winforms_App.UI.Controls.GuestsDataSumControl
{
    public partial class GuestDataSumControl : UserControl
    {
        public GuestDataSumControl()
        {
            InitializeComponent();
        }

        public void FillGuestTabData(Guest guest)
        {
            tbSumName.Text = guest.FName + " " + guest.LName;
            tbSumBirth.Text = guest.DateOfBirth.Value.ToString("yyyy.MM.dd");
            tbSumCountry.Text = guest.Country;
            tbSumAddress.Text = guest.ZipCode + " " + guest.City + ", " + guest.Street;
            tbSumEmail.Text = guest.Email;
            tbSumCarPlate.Text = guest.CarPlateNumber;
            tbSumDocumentID.Text = guest.IdCardNumber;
        }
    }
}
