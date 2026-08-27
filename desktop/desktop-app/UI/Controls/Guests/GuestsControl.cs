using Hotel_erp_Winforms_App.Models;
using Hotel_erp_Winforms_App.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hotel_erp_Winforms_App.UI.Controls
{
    public partial class GuestsControl : UserControl
    {
        public GuestsControl()
        {
            InitializeComponent();
        }

        #region TODO
        /*
         * loyalty category uj vendegnel default 0
         * hibakezeles: vagy csak szamok vagy csak betuk uj vendeg mentesnel
         * tabindexeket beállítani
         * true false részekből methodot csinálni
        */

        #endregion

        #region variables

        private GuestService _guestService = new GuestService();
        private BookingService _bookingService = new BookingService();

        private List<Guest> guests = new List<Guest>();

        private Guest _selectedGuest;

        bool addGuestClicked = false;

        #endregion

        #region on load functions, UI defaults
        private async void GuestsControl_Load(object sender, EventArgs e)
        {
            #region textboxes, buttons

            tbFullName.ReadOnly = true;
            tbEmail.ReadOnly = true;
            tbIdCard.ReadOnly = true;
            tbAddress.ReadOnly = true;
            tbNotes.ReadOnly = true;
            cbCategory.Enabled = false;

            btnSaveGuest.Visible = false;

            tbFname.Visible = false;
            tbLname.Visible = false;
            tbZip.Visible = false;
            tbCity.Visible = false;
            tbStreet.Visible = false;
            lbBirthdateTitle.Visible = false;
            dtpBirthdate.Visible = false;
            lbCountryTitle.Visible = false;
            tbCountry.Visible = false;

            #endregion

            #region selectors

            cbTypeFilter.SelectedIndex = 0;

            #endregion

            #region key performance indicators

            lbKpiTotalGuestsValue.Text = guests.Count.ToString();
            lbKpiVipValue.Text = _guestService.GetNumberOfVipGuests(guests).ToString();
            lbKpiInHouseValue.Text = _guestService.GetNumberOfCurrentlyStayers(await _bookingService.LoadDgvAsync()).ToString();
            lbKpiReturningValue.Text = _guestService.GetNumberOfReturningGuests(await _bookingService.LoadDgvAsync()).ToString();

            #endregion

            #region datagridview
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                guests = await _guestService.GetAllGuestsFromDbAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occured while trying to load database: {ex.Message}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
            dgvGuests.DataSource = guests;
            dgvGuests.CellFormatting += dgvGuests_CellFormatting;

            if (dgvGuests.Rows.Count > 0)
            {
                RowSelection(0);
            }
            #endregion
        }
        #endregion

        #region INFO
        /*
            1.: Filter
            2.: Reload
            3.: Dgv cellclick
            4.: Add guest
            5.: Save guest
        */
        #endregion
        #region buttons

        // 1.
        private async void btnSearch_Click(object sender, EventArgs e)
        {
            dgvGuests.DataSource = await _guestService.GetFilteredGuestListAsync(txtSearch.Text, cbTypeFilter.Text);
        }

        // 2.
        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                guests = await _guestService.GetAllGuestsFromDbAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occured while trying to load database: {ex.Message}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
            dgvGuests.DataSource = guests;
            dgvGuests.CellFormatting += dgvGuests_CellFormatting;
        }

        // 3.
        private void dgvGuests_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnSaveGuest.Visible = false;
            cbCategory.Enabled = false;

            if (e.RowIndex >= 0)
            {
                RowSelection(e.RowIndex);
            }
        }

        // 4.
        private void btnNewGuest_Click(object sender, EventArgs e)
        {
            addGuestClicked = true;

            dgvGuests.ClearSelection();

            tbFullName.Clear();
            tbEmail.Clear();
            tbIdCard.Clear();
            tbAddress.Clear();
            tbNotes.Clear();

            btnSaveGuest.Visible = true;
            cbCategory.Enabled = true;
            cbCategory.SelectedIndex = 0;

            tbFullName.Visible = false;
            tbEmail.ReadOnly = false;
            tbIdCard.ReadOnly = false;
            tbNotes.ReadOnly = false;
            tbAddress.Visible = false;

            tbFname.Visible = true;
            tbLname.Visible = true;
            tbZip.Visible = true;
            tbCity.Visible = true;
            tbStreet.Visible = true;
            lbBirthdateTitle.Visible = true;
            dtpBirthdate.Visible = true;
            lbCountryTitle.Visible = true;
            tbCountry.Visible = true;

            lbCategoryTitle.Location = new Point(lbCategoryTitle.Location.X, lbCategoryTitle.Location.Y + 55);
            cbCategory.Location = new Point(lbCategoryTitle.Location.X, 340);
            lbNotesTitle.Location = new Point(lbCategoryTitle.Location.X, lbCategoryTitle.Location.Y + 55);
            tbNotes.Location = new Point(lbCategoryTitle.Location.X, lbCategoryTitle.Location.Y + 55);
        }

        // 5.
        private async void btnSaveGuest_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure all the details are correct?",
                "Confirmation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
                );

            if(result == DialogResult.Yes)
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;

                    Guest g = new Guest
                    (
                        0,
                        tbEmail.Text,
                        tbIdCard.Text,
                        tbFname.Text,
                        tbLname.Text,
                        dtpBirthdate.Value,
                        tbCountry.Text,
                        tbZip.Text,
                        tbCity.Text,
                        tbStreet.Text,
                        "",
                        0,
                        0
                    );

                    await _guestService.SaveGuestToDatabaseAsync(g);

                    MessageBox.Show("Guest saved successfully!",
                        "Succession",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    RowSelection(0);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occured while trying to save the Guest into the database: " + ex.Message,
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

        #region INFO
        /*
            1.: dgv loyalty level cell formatting
            2.: fill textboxes and comboxes
        */
        #endregion
        #region Helpers
        // 1.
        private void dgvGuests_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvGuests.Columns[e.ColumnIndex].Name.Equals("colLoyalty", StringComparison.OrdinalIgnoreCase) ||
                dgvGuests.Columns[e.ColumnIndex].DataPropertyName.Equals("loyalty_level", StringComparison.OrdinalIgnoreCase))
            {
                if (e.Value != null && int.TryParse(e.Value.ToString(), out int loyalty))
                {
                    switch (loyalty)
                    {
                        case 0:
                            e.Value = "Standard";
                            break;
                        case 1:
                            e.Value = "Corporate";
                            break;
                        case 2:
                            e.Value = "VIP";
                            break;
                        default:
                            e.Value = "Unknown";
                            break;
                    }

                    e.FormattingApplied = true;
                }
            }
        }

        // 2.
        private void RowSelection(int rowIndex)
        {
            if (rowIndex < 0 || rowIndex >= dgvGuests.Rows.Count) return;

            _selectedGuest = dgvGuests.Rows[rowIndex].DataBoundItem as Guest;

            if (_selectedGuest == null) return;

            tbFullName.ReadOnly = true;
            tbFullName.Visible = true;
            tbEmail.ReadOnly = true;
            tbIdCard.ReadOnly = true;
            tbAddress.ReadOnly = true;
            tbAddress.Visible = true;
            tbNotes.ReadOnly = true;
            cbCategory.Enabled = false;

            tbFname.Clear();
            tbLname.Clear();
            tbZip.Clear();
            tbCity.Clear();
            tbStreet.Clear();

            tbFname.Visible = false;
            tbLname.Visible = false;
            tbZip.Visible = false;
            tbCity.Visible = false;
            tbStreet.Visible = false;
            lbBirthdateTitle.Visible = false;
            dtpBirthdate.Visible = false;
            lbCountryTitle.Visible = false;
            tbCountry.Visible = false;

            btnSaveGuest.Visible = false;

            if (addGuestClicked)
            {
                lbCategoryTitle.Location = new Point(lbCategoryTitle.Location.X, 265);
                cbCategory.Location = new Point(lbCategoryTitle.Location.X, 285);
                lbNotesTitle.Location = new Point(lbCategoryTitle.Location.X, 320);
                tbNotes.Location = new Point(lbCategoryTitle.Location.X, 340);
            }

            tbFullName.Text = $"{_selectedGuest?.LName} {_selectedGuest?.FName}";
            tbEmail.Text = $"{_selectedGuest?.Email}";

            tbAddress.Text = $"{_selectedGuest.ZipCode ?? ""}" +
                $"{(!string.IsNullOrWhiteSpace(_selectedGuest.ZipCode) ? " " : "")}" +
                $"{_selectedGuest.City ?? ""}" +
                $"{(!string.IsNullOrWhiteSpace(_selectedGuest.City) ? ", " : "")}" +
                $"{_selectedGuest.Street}";

            tbIdCard.Text = $"{_selectedGuest?.IdCardNumber}";

            switch (_selectedGuest.LoyaltyLevel)
            {
                case 0: cbCategory.SelectedIndex = 0; break;
                case 1: cbCategory.SelectedIndex = 2; break;
                case 2: cbCategory.SelectedIndex = 1; break;
            }
        }
        #endregion
    }
}