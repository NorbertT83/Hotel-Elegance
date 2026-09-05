using Hotel_erp_Winforms_App.Models;
using Hotel_erp_Winforms_App.Services;
using Hotel_erp_Winforms_App.UI.Forms;
using Hotel_erp_Winforms_App.UI.Forms.ServiceForms;

namespace Hotel_erp_Winforms_App.UI.Controls
{
    public partial class BookingControl : UserControl
    {
        public BookingControl()
        {
            InitializeComponent();
        }

        #region TODO
        /*
         * 
         * 
        */
        #endregion

        #region variables

        public Booking? selectedBooking;

        public BookingService bookingService = new BookingService();
        private RoomService roomService = new RoomService();
        private CheckoutService checkoutService = new CheckoutService();
        private ServiceService serviceService = new ServiceService();

        private List<Booking> _bookingsList = new List<Booking>();

        #endregion

        #region on load functions, UI defaults

        private void BookingControl_Load(object sender, EventArgs e)
        {
            #region selectors

            cbFieldFilter.SelectedIndex = 0;
            cbStatusFilter.SelectedIndex = 0;
            cbSpanFilter.SelectedIndex = 0;
            dtpFrom.Value = DateTime.Today;
            dtpTo.Value = DateTime.Today.AddMonths(1);

            #endregion

            LoadBookings();
            ShowInfo();
            dgvBookings.ClearSelection();
        }

        #endregion

        #region INFO
        /*
            1.: Filter / Search
            2.: Refresh / Reload
            3.: Dgv cellclick
            4.: Check-in
            5.: Check-out
            6.: Add booking
            7.: Edit booking
            8.: Cancel booking
        */
        #endregion
        #region buttons

        // 1.
        private async void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                List<Booking> results = await bookingService.SearchBookings(
                    cbFieldFilter.SelectedIndex,
                    txtSearch.Text.Trim(),
                    cbStatusFilter.SelectedIndex,
                    cbSpanFilter.SelectedIndex,
                    dtpFrom.Value,
                    dtpTo.Value
                );

                _bookingsList = results;

                dgvBookings.DataSource = null;
                dgvBookings.DataSource = _bookingsList;
                dgvBookings.ClearSelection();
                lbKpiTotalBookingsValue.Text = _bookingsList.Count().ToString();
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

        // 2.
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

        // 3.
        private void dgvBookings_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                RowSelection(e.RowIndex);
            }
        }

        // 4.
        private void btnCheckin_Click(object sender, EventArgs e)
        {
            DialogResult result = new DialogResult();

            if (selectedBooking != null && selectedBooking.Checkin == null)
            {
                if (selectedBooking.BeginningOfStay.Date != DateTime.Today.Date)
                {
                    result = MessageBox.Show(
                        "The check-in date for this booking is not today. Are you sure you want to continue?",
                        "Confirm Early Checkout",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning);
                }

                if (result == DialogResult.No)
                {
                    return;
                }
                else
                {
                    FrmCheckin checkinForm = new FrmCheckin(selectedBooking);
                    checkinForm.ShowDialog();
                    LoadBookings();
                    ShowInfo();
                }
            }
            else
            {
                MessageBox.Show("Please select a booking that is not yet checked in.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // 5.
        private async void btnCheckout_Click(object sender, EventArgs e)
        {
            if (selectedBooking != null && selectedBooking.Checkin != null && selectedBooking.Checkout == null)
            {
                DialogResult result = DialogResult.Yes;

                if (selectedBooking.EndOfStay.Date != DateTime.Today.Date)
                {
                    result = MessageBox.Show(
                        "The check-out date for this booking is not today. Are you sure you want to continue?",
                        "Confirm Early Checkout",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning);
                }

                if (result == DialogResult.No) return;
                else
                {
                    using (var checkoutForm = new FrmCheckout(selectedBooking))
                    {
                        var checkoutResult = checkoutForm.ShowDialog();

                        if (checkoutResult == DialogResult.OK)
                        {
                            List<Booking> list = await bookingService.LoadDgvAsync();

                            dgvBookings.DataSource = null;
                            dgvBookings.DataSource = list;
                            dgvBookings.ClearSelection();
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select an active (checked-in) booking to check out.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // 6.
        private void btnAddBooking_Click(object sender, EventArgs e)
        {
            FrmAddBooking addBookingForm = new FrmAddBooking();
            addBookingForm.ShowDialog();
            LoadBookings();
            ShowInfo();
        }

        // 7.
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

        // 8.
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

        #endregion

        #region INFO
        /*
            1.: Load all bookings into DataGridView
            2.: Fill input fields on row selection
            3.: Refresh KPI dashboard labels
            4.: Calculate financial totals for selected booking
        */
        #endregion
        #region Helpers

        // 1.
        public async void LoadBookings()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                _bookingsList = await bookingService.LoadDgvAsync("SELECT * FROM bookings");

                dgvBookings.AutoGenerateColumns = false;
                dgvBookings.DataSource = _bookingsList;
                dgvBookings.ClearSelection();

                lbKpiTotalBookingsValue.Text = _bookingsList.Count.ToString();
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

        // 2.
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

            RefreshFinancialSum(selectedBooking);
        }

        // 3.
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

        // 4.
        private async void RefreshFinancialSum(Booking selectedBooking)
        {
            // ÁR ÖSSZEGEK

            int days = (selectedBooking.EndOfStay.Date - Convert.ToDateTime(selectedBooking.BeginningOfStay).Date).Days;
            List<CheckoutSumHelper> items = await checkoutService.GetServiceItemsAsync(selectedBooking.Id);

            // ----- Room price ------
            List<Room> rooms = await roomService.GetAllRoomsAsync();

            Room selectedRoom = rooms.Find(r => r.Room_number == selectedBooking.RoomNumber);
            int roomPrice = selectedRoom.Price * days;

            // ----- Extras price ----
            int extrasPrice = items?.Sum(item => item.TotalPrice) ?? 0;

            // ---- Catering price ---
            List<Service> services = await serviceService.GetAllServicesFromDbAsync();

            int cateringPrice = 0;
            Service selectedCatering = null;

            switch (selectedBooking.SelectedCateringLevel)
            {
                case CateringLevel.breakfast:
                    cateringPrice = 0;
                    break;
                case CateringLevel.halfboard:
                    selectedCatering = services.Find(s => s.NameHu == "Félpanzió");
                    cateringPrice = (int)selectedCatering.Price;
                    break;
                case CateringLevel.fullboard:
                    selectedCatering = services.Find(s => s.NameHu == "Teljes ellátás");
                    cateringPrice = (int)selectedCatering.Price;
                    break;
            }

            // ----- Total -----

            lbFinanceTotal.Text = $"Total: {(roomPrice + extrasPrice + cateringPrice * days):N0} HUF";

            lbFinanceRemaining.Text = $"{(roomPrice + extrasPrice + cateringPrice * days):N0} HUF";
        }

        #endregion
    }
}