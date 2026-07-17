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
using Hotel_erp_Winforms_App.UI.Forms.ServiceForms;

namespace Hotel_erp_Winforms_App.UI.Controls
{
    public partial class BookingControl : UserControl
    {
        public Booking selectedBooking;

        public BookingControl()
        {
            InitializeComponent();
        }

        private void BookingControl_Load(object sender, EventArgs e)
        {
            LoadBookings();
            cbStatus.SelectedIndex = 1;
        }

        public BookingService bookingService = new BookingService();

        public void LoadBookings()
        {
            try
            {
                List<Booking> list = bookingService.LoadDgv("SELECT * FROM bookings");

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

            var results = bookingService.SearchBookings(
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

        private void dgvBookings_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvBookings.Rows[e.RowIndex];
                string id = row.Cells["BookingId"].Value?.ToString();

                if (!string.IsNullOrEmpty(id))
                {
                    selectedBooking = bookingService.GetBookingById(id);
                }
            }
        }

        private void btnCheckin_Click(object sender, EventArgs e)
        {
            if (selectedBooking != null && selectedBooking.Checkin == null)
            {
                FrmCheckin checkinForm = new FrmCheckin(selectedBooking);
                checkinForm.ShowDialog();
            }

            else { MessageBox.Show("This booking is already checked in.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void ShowInfo()
        {
            string todaysArriavals = bookingService.GetTodaysArrivalsCount().ToString();
            string todaysDepartures = bookingService.GetTodaysDeparturesCount().ToString();

            try
            {
                lbArrivals.Text = todaysArriavals;
                lbDepartures.Text = todaysDepartures;
            }

            catch (Exception ex)
            {
                MessageBox.Show("There was an error while loading statistics: " + ex.Message, "Database error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
