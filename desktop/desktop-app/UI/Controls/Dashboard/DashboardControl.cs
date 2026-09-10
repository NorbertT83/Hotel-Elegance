using Hotel_erp_Winforms_App.Helpers;
using Hotel_erp_Winforms_App.Models;
using Hotel_erp_Winforms_App.Services;
using Hotel_erp_Winforms_App.UI.Forms.ServiceForms;
using Hotel_erp_Winforms_App.UI.Forms.ServiceForms.Change_Password;
using System.Net;
using System.Text;

namespace Hotel_erp_Winforms_App.UI.Controls.Dashboard
{
    public partial class DashboardControl : UserControl
    {
        public DashboardControl(Employee? user = null)
        {
            InitializeComponent();
            _currentUser = user;
        }

        #region TODO
        /*
        */
        #endregion

        #region variables

        private readonly Employee? _currentUser;

        private readonly BookingService _bookingService = new BookingService();
        private readonly RoomService _roomService = new RoomService();
        private readonly GuestService _guestService = new GuestService();
        private readonly EmployeeService _employeeService = new EmployeeService();
        private readonly CommonHelper _commonHelper = new CommonHelper();

        private readonly System.Windows.Forms.Timer _clockTimer = new System.Windows.Forms.Timer();

        private List<TodayMovementDto> _allMovements = new List<TodayMovementDto>();

        public class TodayMovementDto
        {
            public string MovementType { get; set; } = "";
            public string BookingId { get; set; } = "";
            public int RoomNumber { get; set; }
            public string GuestName { get; set; } = "";
            public string StayPeriod { get; set; } = "";
            public string StatusText { get; set; } = "";
            public Booking RawBooking { get; set; } = null!;
        }

        #endregion

        #region on load functions, UI defaults

        private void DashboardControl_Load(object sender, EventArgs e)
        {
            if (_currentUser != null)
            {
                lbGreeting.Text = $"Welcome back, {_currentUser.FName}!";
                lbGreetingSub.Text = $"Role: {_currentUser.JobTitle ?? "Staff"} • Hotel Elegance Dashboard";
            }

            _clockTimer.Interval = 1000;
            _clockTimer.Tick += (s, ev) =>
            {
                lbDateTimeClock.Text = DateTime.Now.ToString("yyyy.MM.dd | HH:mm:ss");
            };
            _clockTimer.Start();
            lbDateTimeClock.Text = DateTime.Now.ToString("yyyy.MM.dd | HH:mm:ss");

            LoadDashboardData();
            SetBoxesVisibility(false);
        }

        #endregion

        #region INFO
        /*
            1.: Reload / Load dashboard data
            2.: Filter All
            3.: Filter Arrivals
            4.: Filter Departures
            5.: Refresh button click
            6.: Quick new booking
            7.: Quick check-in
            8.: Dgv movements cell double click
        */
        #endregion
        #region buttons

        // 2.
        private void btnFilterAll_Click(object sender, EventArgs e)
        {
            SetActiveFilterButton(btnFilterAll);
            BindMovementsGrid(_allMovements);
        }

        // 3.
        private void btnFilterArrivals_Click(object sender, EventArgs e)
        {
            SetActiveFilterButton(btnFilterArrivals);
            BindMovementsGrid(_allMovements.Where(m => m.MovementType == "ARRIVAL").ToList());
        }

        // 4.
        private void btnFilterDepartures_Click(object sender, EventArgs e)
        {
            SetActiveFilterButton(btnFilterDepartures);
            BindMovementsGrid(_allMovements.Where(m => m.MovementType == "DEPARTURE").ToList());
        }

        // 5.
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadDashboardData();
        }

        // 6.
        private void btnQuickNewBooking_Click(object sender, EventArgs e)
        {
            FrmAddBooking addBooking = new FrmAddBooking();
            addBooking.ShowDialog();
            LoadDashboardData();
        }

        // 7.
        private void btnQuickCheckin_Click(object sender, EventArgs e)
        {
            if (dgvMovements.CurrentRow?.DataBoundItem is TodayMovementDto item && item.RawBooking != null)
            {
                if (item.RawBooking.Checkin == null)
                {
                    FrmCheckin checkin = new FrmCheckin(item.RawBooking);
                    checkin.ShowDialog();
                    LoadDashboardData();
                }
                else
                {
                    MessageBox.Show("This booking is already checked in!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Please select an arrival row from the table to check-in.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // 8.
        private void dgvMovements_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnQuickCheckin_Click(sender, e);
        }

        // 9.
        private void btnEditProfile_Click(object sender, EventArgs e)
        {
            SetBoxesVisibility(true);
        }

        // 10.
        private async void btnSaveProfileData_Click(object sender, EventArgs e)
        {
            if (_currentUser != null)
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;

                    var emp = new Employee(
                        _currentUser.Id,
                        tbFname.Text.Trim(),
                        tbLname.Text.Trim(),
                        tbTaxNumber.Text.Trim(),
                        _currentUser.PaidHolidaysLeft,
                        tbAddress.Text.Trim(),
                        dtpBirthdate.Value.Date,
                        _currentUser.DateOfHiring,
                        _currentUser.JobTitle!,
                        _currentUser.Salary,
                        _currentUser.CreatedAt,
                        DateTime.Now,
                        tbEmail.Text.Trim(),
                        _currentUser.Password
                    );

                    bool isUnchanged = tbFname.Text.Trim() == _currentUser.FName &&
                       tbLname.Text.Trim() == _currentUser.LName &&
                       tbTaxNumber.Text.Trim() == _currentUser.TaxNumber &&
                       tbAddress.Text == _currentUser.Address &&
                       dtpBirthdate.Value.Date == _currentUser.DateOfBirth.Date &&
                       tbEmail.Text.Trim() == _currentUser.Email;

                    if (isUnchanged)
                    {
                        MessageBox.Show("No data were changed.", "No Data Changes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        SetBoxesVisibility(false);
                        return;
                    }

                    await _employeeService.SaveEmployeeToDbAsync(emp, SaveOrUpdate.Update);

                    MessageBox.Show(
                        "Your Profile Data were updated successfully.",
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    _commonHelper.MBErrorMessage(ex);
                }
                finally
                {
                    Cursor.Current = Cursors.Default;
                }
            }
        }

        // 11.
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to discard the canges?",
                "Discard changes?",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                SetBoxesVisibility(false);
            }
        }

        // 12.
        private void llbChangePassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if(_currentUser != null)
            {
                var frmChangePassword = new FrmChangePassword(_currentUser);
                frmChangePassword.ShowDialog();
            }
        }

        #endregion

        #region INFO
        /*
            1.: Bind movements list to DataGridView
            2.: Set active filter button UI styles
        */
        #endregion
        #region Helpers

        // 1.
        private void BindMovementsGrid(List<TodayMovementDto> list)
        {
            dgvMovements.AutoGenerateColumns = false;
            dgvMovements.DataSource = null;
            dgvMovements.DataSource = list.ToList();

            lbNoData.BringToFront();
            lbNoData.Visible = list.Count == 0;
        }

        // 2.
        private void SetActiveFilterButton(Button activeBtn)
        {
            btnFilterAll.BackColor = SystemColors.ButtonFace;
            btnFilterAll.ForeColor = Color.Black;
            btnFilterArrivals.BackColor = SystemColors.ButtonFace;
            btnFilterArrivals.ForeColor = Color.Black;
            btnFilterDepartures.BackColor = SystemColors.ButtonFace;
            btnFilterDepartures.ForeColor = Color.Black;

            activeBtn.BackColor = Color.FromArgb(24, 60, 142);
            activeBtn.ForeColor = Color.White;
        }

        // 3.
        public async void LoadDashboardData()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                var bookings = await _bookingService.LoadDgvAsync("SELECT * FROM bookings");
                var rooms = await _roomService.GetAllRoomsAsync();
                var guests = await _guestService.GetAllGuestsFromDbAsync();

                int arrivalsCount = _bookingService.GetTodaysArrivalsCount();
                int departuresCount = _bookingService.GetTodaysDeparturesCount();
                int occupancy = _bookingService.GetOccupancyRate();
                int alertRooms = rooms.Count(r => r.NeedsCleaning == 1 || r.CurrentStatus == Room.Status.under_maintenance);

                lbKpiArrivalsValue.Text = arrivalsCount.ToString();
                lbKpiDeparturesValue.Text = departuresCount.ToString();
                lbKpiOccupancyValue.Text = $"{occupancy} %";
                lbKpiAlertsValue.Text = alertRooms.ToString();

                int available = rooms.Count(r => r.CurrentStatus == Room.Status.available && r.NeedsCleaning == 0);
                int occupied = rooms.Count(r => r.CurrentStatus == Room.Status.occupied || r.CurrentStatus == Room.Status.unavailable);
                int dirty = rooms.Count(r => r.NeedsCleaning == 1 || r.IsCleaning == 1);
                int maintenance = rooms.Count(r => r.CurrentStatus == Room.Status.under_maintenance);

                lbStatAvailable.Text = $"🟢 Ready / Available: {available}";
                lbStatOccupied.Text = $"🔵 Occupied / In-Stay: {occupied}";
                lbStatDirty.Text = $"🟡 Needs Cleaning / Dirty: {dirty}";
                lbStatMaintenance.Text = $"🔴 Under Maintenance: {maintenance}";

                DateTime today = DateTime.Today;
                _allMovements.Clear();

                foreach (var b in bookings)
                {
                    var guest = guests.FirstOrDefault(g => g.Id == b.GuestId);
                    string gName = guest != null ? $"{guest.LName} {guest.FName}" : $"Guest #{b.GuestId}";

                    if (b.BeginningOfStay.Date == today)
                    {
                        _allMovements.Add(new TodayMovementDto
                        {
                            MovementType = "ARRIVAL",
                            BookingId = b.Id,
                            RoomNumber = b.RoomNumber,
                            GuestName = gName,
                            StayPeriod = $"{b.BeginningOfStay:MM.dd} - {b.EndOfStay:MM.dd}",
                            StatusText = b.Checkin.HasValue ? "Checked In" : "Expected",
                            RawBooking = b
                        });
                    }

                    if (b.EndOfStay.Date == today)
                    {
                        _allMovements.Add(new TodayMovementDto
                        {
                            MovementType = "DEPARTURE",
                            BookingId = b.Id,
                            RoomNumber = b.RoomNumber,
                            GuestName = gName,
                            StayPeriod = $"{b.BeginningOfStay:MM.dd} - {b.EndOfStay:MM.dd}",
                            StatusText = b.Checkout.HasValue ? "Checked Out" : "Departing Today",
                            RawBooking = b
                        });
                    }
                }

                BindMovementsGrid(_allMovements);

                var vipGuests = guests.Where(g => g.LoyaltyLevel == 2).ToList();
                StringBuilder vipSb = new StringBuilder();
                if (vipGuests.Any())
                {
                    vipSb.AppendLine($"• Total VIP Guests in DB: {vipGuests.Count}");
                    foreach (var v in vipGuests.Take(3))
                    {
                        vipSb.AppendLine($"• VIP: {v.LName} {v.FName} ({v.Email})");
                    }
                }
                else
                {
                    vipSb.AppendLine("• No VIP check-ins pending today.");
                    vipSb.AppendLine("• Daily operations running as scheduled.");
                }
                lbVipList.Text = vipSb.ToString();

                if (_currentUser != null)
                {
                    lbNameValue.Text = $"{_currentUser.LName} {_currentUser.FName}";
                    lbTaxNumberValue.Text = $"{_currentUser.TaxNumber}";
                    lbEmailValue.Text = _currentUser.Email;
                    lbBirthdateValue.Text = _currentUser.DateOfBirth.Date.ToString("yyyy.MM.dd");
                    lbHolidaysLeftValue.Text = $"{_currentUser.PaidHolidaysLeft.ToString()} days";
                    lbAddressValue.Text = _currentUser.Address;
                }
            }
            catch (Exception ex)
            {
                var ch = new CommonHelper();
                ch.MBErrorMessage(ex);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        // 4.
        private void SetBoxesVisibility(bool isVisible)
        {
            if (isVisible)
            {
                tbFname.Clear();
                tbLname.Clear();
                tbEmail.Clear();
                tbAddress.Clear();
                tbTaxNumber.Clear();
                //dtpBirthdate.Clear();

                lbNameValue.Visible = false;
                lbTaxNumberValue.Visible = false;
                lbEmailValue.Visible = false;
                lbBirthdateValue.Visible = false;
                lbAddressValue.Visible = false;

                tbFname.Visible = true;
                tbLname.Visible = true;
                tbEmail.Visible = true;
                tbAddress.Visible = true;
                tbTaxNumber.Visible = true;
                dtpBirthdate.Visible = true;

                btnSaveProfile.Visible = true;
                btnCancel.Visible = true;

                btnEditProfile.Visible = false;

                if (_currentUser != null)
                {
                    tbFname.Text = _currentUser.FName;
                    tbLname.Text = _currentUser.LName;
                    tbEmail.Text = _currentUser.Email;
                    tbAddress.Text = _currentUser.Address;
                    tbTaxNumber.Text = _currentUser.TaxNumber;
                    dtpBirthdate.Value = _currentUser.DateOfBirth.Date;

                    llbChangePassword.Visible = !string.IsNullOrEmpty(_currentUser.Password);
                }

                dtpBirthdate.MaxDate = DateTime.Today.AddYears(-18);
            }

            else
            {
                tbFname.Visible = false;
                tbLname.Visible = false;
                tbEmail.Visible = false;
                tbAddress.Visible = false;
                tbTaxNumber.Visible = false;
                dtpBirthdate.Visible = false;

                btnSaveProfile.Visible = false;
                btnCancel.Visible = false;
                btnEditProfile.Visible = true;

                lbNameValue.Visible = true;
                lbTaxNumberValue.Visible = true;
                lbEmailValue.Visible = true;
                lbBirthdateValue.Visible = true;
                lbAddressValue.Visible = true;

                llbChangePassword.Visible = false;
            }
        }
        #endregion
    }
}