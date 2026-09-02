using Google.Protobuf.WellKnownTypes;
using Hotel_erp_Winforms_App.Models;
using Hotel_erp_Winforms_App.Services;
using Hotel_erp_Winforms_App.UI.Forms.ServiceForms;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Hotel_erp_Winforms_App.UI.Controls
{
    public partial class BookingControl : UserControl
    {
        public Booking? selectedBooking;
        public BookingService bookingService = new BookingService();
        private List<Booking> _bookingsList = new List<Booking>();

        public BookingControl()
        {
            InitializeComponent();
        }

        private void BookingControl_Load(object sender, EventArgs e)
        {
            cbFieldFilter.SelectedIndex = 0;
            cbStatusFilter.SelectedIndex = 0;
            cbSpanFilter.SelectedIndex = 0;
            dtpFrom.Value = DateTime.Today;
            dtpTo.Value = DateTime.Today.AddMonths(1);

            LoadBookings();
            ShowInfo();
        }

        public async void LoadBookings()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                _bookingsList = await bookingService.LoadDgvAsync("SELECT * FROM bookings");

                dgvBookings.AutoGenerateColumns = false;
                dgvBookings.DataSource = _bookingsList;
                lbKpiTotalBookingsValue.Text = _bookingsList.Count.ToString();

                if (dgvBookings.Rows.Count > 0)
                {
                    RowSelection(0);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading bookings: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            try 
            {
            var results = bookingService.SearchBookings(
                cbFieldFilter.SelectedIndex,
                tbSource.Text,
                cbStatusFilter.SelectedIndex,
                cbSpanFilter.SelectedIndex,
                dtpFrom.Value,
                dtpTo.Value
                );

            dgvBookings.DataSource = _bookingsList;
            lbKpiTotalBookingsValue.Text = _bookingsList.Count.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Search error: " + ex.Message);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
{
    txtSearch.Clear();
    cbFieldFilter.SelectedIndex = 0;
    cbStatusFilter.SelectedIndex = 0;
    cbSpanFilter.SelectedIndex = 0;
    dtpFrom.Value = DateTime.Today;
    dtpTo.Value = DateTime.Today.AddMonths(1);

    LoadBookings();
    ShowInfo();
}

private void RowSelection(int rowIndex)
{
    if (rowIndex < 0 || rowIndex >= dgvBookings.Rows.Count) return;

    selectedBooking = dgvBookings.Rows[rowIndex].DataBoundItem as Booking;
    if (selectedBooking == null) return;

    Guest? guest = bookingService.FillPersonalData(selectedBooking);
    if (guest != null)
    {
        tbGuestName.Text = $"{guest.LName} {guest.FName}";
        tbGuestEmail.Text = guest.Email;
        tbGuestPhone.Text = "+36 (Hotel Guest)";
    }
    else
    {
        tbGuestName.Text = "Guest #" + selectedBooking.GuestId;
        tbGuestEmail.Text = "-";
        tbGuestPhone.Text = "-";
    }

    tbSource.Text = "Direct Booking / System";
    txtNotes.Text = $"Catering: {selectedBooking.SelectedCateringLevel}\r\nStay: {selectedBooking.BeginningOfStay:yyyy.MM.dd} - {selectedBooking.EndOfStay:yyyy.MM.dd}\r\nStatus: {(selectedBooking.Checkin.HasValue ? (selectedBooking.Checkout.HasValue ? "Checked Out" : "Checked In") : "Upcoming")}";

    lbFinanceTotal.Text = "Total: 120,000 Ft";
    lbFinancePaid.Text = selectedBooking.Checkin.HasValue ? "Paid: 120,000 Ft" : "Paid: 0 Ft";
    lbFinanceRemaining.Text = selectedBooking.Checkin.HasValue ? "0 Ft" : "120,000 Ft";
}

private void dgvBookings_CellClick(object sender, DataGridViewCellEventArgs e)
{
    if (e.RowIndex >= 0)
    {
        RowSelection(e.RowIndex);
    }
}

private void btnCheckin_Click(object sender, EventArgs e)
{
    if (selectedBooking != null && selectedBooking.Checkin == null)
    {
        FrmCheckin checkinForm = new FrmCheckin(selectedBooking);
        checkinForm.ShowDialog();
        LoadBookings();
        ShowInfo();
    }
    else
    {
        MessageBox.Show("Please select a booking that is not yet checked in.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
}

private void btnCheckout_Click(object sender, EventArgs e)
{
    if (selectedBooking != null && selectedBooking.Checkin != null && selectedBooking.Checkout == null)
    {
        DialogResult res = MessageBox.Show($"Check out booking #{selectedBooking.Id} (Room {selectedBooking.RoomNumber})?", "Checkout Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        if (res == DialogResult.Yes)
        {
            MessageBox.Show("Guest checked out successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadBookings();
            ShowInfo();
        }
    }
    else
    {
        MessageBox.Show("Please select an active (checked-in) booking to check out.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
}

private void btnAddBooking_Click(object sender, EventArgs e)
{
    FrmAddBooking addBookingForm = new FrmAddBooking();
    addBookingForm.ShowDialog();
    LoadBookings();
    ShowInfo();
}

private void btnEdit_Click(object sender, EventArgs e)
{
    if (selectedBooking != null)
    {
        FrmCheckin editForm = new FrmCheckin(selectedBooking);
        editForm.ShowDialog();
        LoadBookings();
        ShowInfo();
    }
    else
    {
        MessageBox.Show("Please select a booking first!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
}

private void btnCancel_Click(object sender, EventArgs e)
{
    if (selectedBooking != null)
    {
        DialogResult res = MessageBox.Show($"Are you sure you want to cancel booking #{selectedBooking.Id}?", "Cancel Booking", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
        if (res == DialogResult.Yes)
        {
            MessageBox.Show("Booking cancelled successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadBookings();
            ShowInfo();
        }
    }
    else
    {
        MessageBox.Show("Please select a booking first!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
}

private void ShowInfo()
{
    try
    {
        lbKpiArrivalsValue.Text = bookingService.GetTodaysArrivalsCount().ToString();
        lbKpiDeparturesValue.Text = bookingService.GetTodaysDeparturesCount().ToString();
        lbKpiOccupancyValue.Text = $"{bookingService.GetOccupancyRate()} %";
    }
    catch
    {
        // Ignore initial query errors if db is empty
    }
}
    }
}