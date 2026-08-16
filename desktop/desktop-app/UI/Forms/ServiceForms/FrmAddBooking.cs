using Hotel_erp_Winforms_App.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hotel_erp_Winforms_App.UI.Forms.ServiceForms
{
    public partial class FrmAddBooking : Form
    {
        #region variables
        BookingService bookingService = new BookingService();
        #endregion

        public FrmAddBooking()
        {
            InitializeComponent();
        }

        private void FrmAddBooking_Load(object sender, EventArgs e)
        {
            #region UI defaults

            btnConfirm.Visible = false;
            lbCurrentPage.Text = "1/5";
            tbDateOfArrival.Text = DateTime.Today.ToString("yyyy.MM.dd");
            dtpDeparture.Text = DateTime.Today.AddDays(1).ToString("yyyy.MM.dd");

            #endregion
        }

        #region UI Refreshings

        public void tcAddBooking_SelectedIndexChanged(object sender, EventArgs e)
        {
            bookingService.RefreshPageCount(tcAddBooking, lbCurrentPage);
        }

        #endregion

        #region buttons
        private void btnNext_Click(object sender, EventArgs e)
        {
            bookingService.NextButtonClick(tcAddBooking, btnNext, btnBack, btnConfirm);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            bookingService.BackButtonClick(tcAddBooking, btnNext, btnBack, btnConfirm);
        }
        #endregion
    }
}
