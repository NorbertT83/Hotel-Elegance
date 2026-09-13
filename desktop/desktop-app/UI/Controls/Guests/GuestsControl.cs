using Hotel_erp_Winforms_App.Helpers;
using Hotel_erp_Winforms_App.Models;
using Hotel_erp_Winforms_App.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Hotel_erp_Winforms_App.UI.Controls
{
    public partial class GuestsControl : UserControl
    {
        public GuestsControl()
        {
            InitializeComponent();
        }

        #region variables

        private readonly GuestService _guestService = new GuestService();
        private readonly BookingService _bookingService = new BookingService();
        private readonly CommonHelper _commonHelper = new CommonHelper();

        private List<Guest> guests = new List<Guest>();

        private Guest? _selectedGuest;
        private readonly ErrorProvider _errorProvider = new ErrorProvider();

        #endregion

        #region on load functions, UI defaults

        private async void GuestsControl_Load(object sender, EventArgs e)
        {
            ReadOnlyAndVisibility(false);

            cbTypeFilter.SelectedIndex = 0;
            dtpBirthdate.MaxDate = DateTime.Today;

            ConfigureMaxLengths();

            dgvGuests.CellFormatting += dgvGuests_CellFormatting;

            try
            {
                Cursor.Current = Cursors.WaitCursor;
                await ReloadGuestsDataAsync();

                if (dgvGuests.Rows.Count > 0)
                {
                    dgvGuests.Rows[0].Selected = true;
                    RowSelection(0);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while trying to load database: {ex.Message}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        #endregion

        #region buttons

        // 1.
        private async void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                string search = txtSearch.Text.Trim();
                guests = await _guestService.GetFilteredGuestListAsync(search, cbTypeFilter.Text);

                dgvGuests.DataSource = null;
                dgvGuests.DataSource = guests;
                dgvGuests.ClearSelection();

                lbNoData.BringToFront();
                lbNoData.Visible = guests.Count == 0;

                if (guests.Count > 0)
                {
                    dgvGuests.Rows[0].Selected = true;
                    RowSelection(0);
                }
                else
                {
                    _selectedGuest = null;
                    ClearInputBoxes();
                    ReadOnlyAndVisibility(false);
                }
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

        // 2.
        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                txtSearch.Clear();
                cbTypeFilter.SelectedIndex = 0;

                await ReloadGuestsDataAsync();

                if (dgvGuests.Rows.Count > 0)
                {
                    dgvGuests.Rows[0].Selected = true;
                    RowSelection(0);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while trying to load database: {ex.Message}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        // 3.
        private void dgvGuests_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                RowSelection(e.RowIndex);
            }
        }

        // 4.
        private void btnNewGuest_Click(object sender, EventArgs e)
        {
            _selectedGuest = null;
            ReadOnlyAndVisibility(true);
            tbFname.Focus();
        }

        // 5.
        private async void btnSaveGuest_Click(object sender, EventArgs e)
        {
            if (!PersonalDataValidationConfirm()) return;

            string email = tbEmail.Text.Trim();
            string idCard = tbIdCard.Text.Trim();

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (await _guestService.IsEmailAlreadyUsedAsync(email))
                {
                    _errorProvider.SetError(tbEmail, "This email address is already in use!");
                    MessageBox.Show(
                        "This email address is already registered to another guest!",
                        "Email Already Exists",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    tbEmail.Focus();
                    return;
                }

                if (await _guestService.IsIdCardAlreadyUsedAsync(idCard))
                {
                    _errorProvider.SetError(tbIdCard, "This ID card number is already in use!");
                    MessageBox.Show(
                        "This ID card number is already registered to another guest!",
                        "ID Card Already Exists",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    tbIdCard.Focus();
                    return;
                }
            }
            catch (Exception ex)
            {
                _commonHelper.MBErrorMessage(ex);
                return;
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }

            DialogResult result = MessageBox.Show(
                "Are you sure all the details are correct?",
                "Confirmation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result != DialogResult.Yes) return;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                Guest g = new Guest
                (
                    0,
                    email,
                    idCard,
                    tbFname.Text.Trim(),
                    tbLname.Text.Trim(),
                    dtpBirthdate.Value.Date,
                    tbCountry.Text.Trim(),
                    tbZip.Text.Trim(),
                    tbCity.Text.Trim(),
                    tbStreet.Text.Trim(),
                    "",
                    0,
                    0
                );

                await _guestService.SaveGuestToDatabaseAsync(g);

                MessageBox.Show("Guest saved successfully!",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                await ReloadGuestsDataAsync();

                ReadOnlyAndVisibility(false);

                int newIndex = guests.FindIndex(x =>
                    x.IdCardNumber.Equals(idCard, StringComparison.OrdinalIgnoreCase) ||
                    x.Email.Equals(email, StringComparison.OrdinalIgnoreCase));

                if (newIndex >= 0)
                {
                    dgvGuests.Rows[newIndex].Selected = true;
                    RowSelection(newIndex);
                }
                else if (dgvGuests.Rows.Count > 0)
                {
                    dgvGuests.Rows[0].Selected = true;
                    RowSelection(0);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while trying to save the Guest into the database: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        // 6.
        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (_selectedGuest == null)
            {
                MessageBox.Show("Please select a guest to delete!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult result = MessageBox.Show(
                $"Are you sure you wish to delete guest record: {_selectedGuest.FName} {_selectedGuest.LName}?",
                "Confirmation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;

                    await _guestService.DeleteGuestFromDbAsync(_selectedGuest);

                    MessageBox.Show(
                        "Guest deleted successfully!",
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    await ReloadGuestsDataAsync();

                    if (dgvGuests.Rows.Count > 0)
                    {
                        dgvGuests.Rows[0].Selected = true;
                        RowSelection(0);
                    }
                    else
                    {
                        _selectedGuest = null;
                        ClearInputBoxes();
                        ReadOnlyAndVisibility(false);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "An error occurred while trying to delete the Guest from database: " + ex.Message,
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
                finally
                {
                    Cursor.Current = Cursors.Default;
                }
            }
        }

        #endregion

        #region Helpers

        private async Task ReloadGuestsDataAsync()
        {
            guests = await _guestService.GetAllGuestsFromDbAsync();
            dgvGuests.DataSource = null;
            dgvGuests.DataSource = guests;
            dgvGuests.ClearSelection();

            lbNoData.BringToFront();
            lbNoData.Visible = guests.Count == 0;

            lbKpiTotalGuestsValue.Text = guests.Count.ToString();
            lbKpiVipValue.Text = _guestService.GetNumberOfVipGuests(guests).ToString();

            try
            {
                var bookings = await _bookingService.LoadDgvAsync();
                lbKpiInHouseValue.Text = _guestService.GetNumberOfCurrentlyStayers(bookings).ToString();
                lbKpiReturningValue.Text = _guestService.GetNumberOfReturningGuests(bookings).ToString();
            }
            catch
            {
                // Fallback ha a foglalások lekérése nem sikerül
            }
        }

        private void dgvGuests_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            var column = dgvGuests.Columns[e.ColumnIndex];
            if (column is null) return;

            bool isLoyaltyColumn = string.Equals(column.Name, "colLoyalty", StringComparison.OrdinalIgnoreCase) ||
                                   string.Equals(column.DataPropertyName, "loyalty_level", StringComparison.OrdinalIgnoreCase);

            if (isLoyaltyColumn && e.Value is not null and not DBNull)
            {
                if (int.TryParse(e.Value.ToString(), out int loyalty))
                {
                    e.Value = loyalty switch
                    {
                        0 => "Standard",
                        1 => "Corporate",
                        2 => "VIP",
                        _ => "Unknown"
                    };

                    e.FormattingApplied = true;
                }
            }
        }

        private void RowSelection(int rowIndex)
        {
            if (rowIndex < 0 || rowIndex >= dgvGuests.Rows.Count) return;

            _selectedGuest = dgvGuests.Rows[rowIndex].DataBoundItem as Guest;
            if (_selectedGuest == null) return;

            ReadOnlyAndVisibility(false);

            tbFullName.Text = $"{_selectedGuest.LName} {_selectedGuest.FName}".Trim();
            tbEmail.Text = _selectedGuest.Email ?? "";
            tbAddress.Text = $"{_selectedGuest.ZipCode ?? ""}" +
                $"{(!string.IsNullOrWhiteSpace(_selectedGuest.ZipCode) ? " " : "")}" +
                $"{_selectedGuest.City ?? ""}" +
                $"{(!string.IsNullOrWhiteSpace(_selectedGuest.City) ? ", " : "")}" +
                $"{_selectedGuest.Street ?? ""}";

            tbIdCard.Text = _selectedGuest.IdCardNumber ?? "";
            tbCountry.Text = _selectedGuest.Country ?? "";

            if (_selectedGuest.DateOfBirth.HasValue && _selectedGuest.DateOfBirth.Value <= DateTime.Today)
            {
                dtpBirthdate.Value = _selectedGuest.DateOfBirth.Value;
            }
            else
            {
                dtpBirthdate.Value = DateTime.Today;
            }

            switch (_selectedGuest.LoyaltyLevel)
            {
                case 0: cbCategory.SelectedIndex = 0; break;
                case 1: cbCategory.SelectedIndex = 2; break;
                case 2: cbCategory.SelectedIndex = 1; break;
                default: cbCategory.SelectedIndex = 0; break;
            }
        }

        private void ClearInputBoxes()
        {
            tbFname.Clear();
            tbLname.Clear();
            tbFullName.Clear();
            tbEmail.Clear();
            tbIdCard.Clear();
            tbZip.Clear();
            tbCity.Clear();
            tbStreet.Clear();
            tbCountry.Clear();
            tbAddress.Clear();
            dtpBirthdate.Value = DateTime.Today;
            cbCategory.SelectedIndex = 0;
            _errorProvider.Clear();
        }

        private void ReadOnlyAndVisibility(bool addingNewGuest)
        {
            if (addingNewGuest)
            {
                dgvGuests.ClearSelection();
                ClearInputBoxes();

                tbFullName.Visible = false;
                tbAddress.Visible = false;

                tbFname.Visible = true;
                tbLname.Visible = true;
                tbZip.Visible = true;
                tbCity.Visible = true;
                tbStreet.Visible = true;

                tbFname.ReadOnly = false;
                tbLname.ReadOnly = false;
                tbEmail.ReadOnly = false;
                tbIdCard.ReadOnly = false;
                tbZip.ReadOnly = false;
                tbCity.ReadOnly = false;
                tbStreet.ReadOnly = false;
                tbCountry.ReadOnly = false;
                dtpBirthdate.Enabled = true;

                lbBirthdateTitle.Visible = true;
                dtpBirthdate.Visible = true;
                lbCountryTitle.Visible = true;
                tbCountry.Visible = true;

                lbCategoryTitle.Visible = false;
                cbCategory.Visible = false;

                btnSaveGuest.Visible = true;
            }
            else
            {
                tbFullName.Visible = true;
                tbAddress.Visible = true;

                tbFullName.ReadOnly = true;
                tbEmail.ReadOnly = true;
                tbIdCard.ReadOnly = true;
                tbAddress.ReadOnly = true;
                tbCountry.ReadOnly = true;
                dtpBirthdate.Enabled = false;
                cbCategory.Enabled = false;

                btnSaveGuest.Visible = false;

                tbFname.Visible = false;
                tbLname.Visible = false;
                tbZip.Visible = false;
                tbCity.Visible = false;
                tbStreet.Visible = false;

                lbBirthdateTitle.Visible = true;
                dtpBirthdate.Visible = true;
                lbCountryTitle.Visible = true;
                tbCountry.Visible = true;
                lbCategoryTitle.Visible = true;
                cbCategory.Visible = true;
            }
        }

        private void ConfigureMaxLengths()
        {
            tbFname.MaxLength = 50;
            tbLname.MaxLength = 50;
            tbEmail.MaxLength = 64;
            tbIdCard.MaxLength = 20;
            tbZip.MaxLength = 10;
            tbCity.MaxLength = 40;
            tbStreet.MaxLength = 50;
            tbCountry.MaxLength = 50;
            tbFullName.MaxLength = 100;
            tbAddress.MaxLength = 100;
            txtSearch.MaxLength = 64;
        }

        #endregion

        #region Foolproofing & Validation

        private void tbFirstName_KeyPress(object sender, KeyPressEventArgs e)
        {
            CommonHelper.InputValidationService.BlockDigits(e);
        }

        private void tbLastName_KeyPress(object sender, KeyPressEventArgs e)
        {
            CommonHelper.InputValidationService.BlockDigits(e);
        }

        private void tbZipCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            CommonHelper.InputValidationService.BlockLetters(e);
        }

        private void tbCity_KeyPress(object sender, KeyPressEventArgs e)
        {
            CommonHelper.InputValidationService.BlockDigits(e);
        }

        private void tbCountry_KeyPress(object sender, KeyPressEventArgs e)
        {
            CommonHelper.InputValidationService.BlockDigits(e);
        }

        private bool PersonalDataValidationConfirm()
        {
            _errorProvider.Clear();

            bool isFirstNameValid = !_commonHelper.HasValidationError(tbFname, _errorProvider);
            bool isLastNameValid = !_commonHelper.HasValidationError(tbLname, _errorProvider);
            bool isZipValid = !_commonHelper.HasValidationError(tbZip, _errorProvider);
            bool isCityValid = !_commonHelper.HasValidationError(tbCity, _errorProvider);
            bool isStreetValid = !_commonHelper.HasValidationError(tbStreet, _errorProvider);
            bool isCountryValid = !_commonHelper.HasValidationError(tbCountry, _errorProvider);
            bool isDocValid = !_commonHelper.HasValidationError(tbIdCard, _errorProvider);

            string email = tbEmail.Text.Trim();
            bool isEmailValid = false;
            if (string.IsNullOrWhiteSpace(email))
            {
                _errorProvider.SetError(tbEmail, "Email address cannot be empty!");
            }
            else if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.IgnoreCase))
            {
                _errorProvider.SetError(tbEmail, "Invalid email format! (e.g. guest@example.com)");
            }
            else
            {
                _errorProvider.SetError(tbEmail, "");
                isEmailValid = true;
            }

            return isFirstNameValid && isLastNameValid && isEmailValid && isZipValid && isCityValid && isStreetValid && isCountryValid && isDocValid;
        }

        #endregion
    }
}