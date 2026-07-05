using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows.Forms;
using Hotel_erp_Winforms_App.Models;
using Hotel_erp_Winforms_App.Services;

namespace Hotel_erp_Winforms_App.UI.Controls
{
    public partial class BookingControl : UserControl
    {
        public BookingControl()
        {
            InitializeComponent();
        }

        private void BookingControl_Load(object sender, EventArgs e)
        {
            LoadBookings();
            cbStatus.SelectedIndex = 0;
        }

        private BookingService _bookingService = new BookingService();
        public void LoadBookings()
        {
            try
            {
                List<Booking> list = _bookingService.LoadDgv("SELECT * FROM bookings");

                dgvBookings.AutoGenerateColumns = false;
                dgvBookings.DataSource = null;
                dgvBookings.DataSource = list;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba a betöltéskor:" + ex.Message);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

            var results = _bookingService.SearchBookings(
                cbField.SelectedIndex,
                tbSearch.Text,
                cbStatus.SelectedIndex,
                tcSearch.SelectedIndex,
                cbSpan.SelectedIndex,
                dtpFrom.Value,
                dtpTo.Value
                );

            dgvBookings.DataSource = results;
        }
    }
}
