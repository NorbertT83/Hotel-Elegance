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
using Microsoft.Data.SqlClient;

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
            FillComboboxes();
        }

        private BookingService _bookingService = new BookingService();
        public void LoadBookings()
        {
            try
            {
                List<Booking> list = _bookingService.GetAllBookings();

                dgvBookings.AutoGenerateColumns = false;
                dgvBookings.DataSource = null;
                dgvBookings.DataSource = list;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba a betöltéskor:" + ex.Message);
            }
        }

        public void FillComboboxes()
        {
            cbRoomNum.Items.Clear();

            for (int i = 101; i <= 199; i++)
            {
                cbRoomNum.Items.Add(i);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cbRoomNum.SelectedItem == null || cbRoomNum.SelectedIndex == -1)
            {
                MessageBox.Show("Kérjük, válassza ki a szobaszámot!");
                return;
            }

            try
            {
                Booking booking = new Booking(
                    0,
                    Convert.ToInt32(cbRoomNum.SelectedItem),
                    Convert.ToInt32(tbGuestId.Text),
                    dtpStart.Value,
                    dtpEnd.Value,
                    null,
                    null,
                    0,
                    0,
                    0,
                    tbLevel.Text
                );

                _bookingService.AddBooking(booking);
                MessageBox.Show("Sikeres mentés!");
                LoadBookings();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba a mentésnél: " + ex.Message);
            }
        }

    }
}
