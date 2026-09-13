using Hotel_erp_Winforms_App.Helpers;
using Hotel_erp_Winforms_App.Models;
using Hotel_erp_Winforms_App.Services;
using Hotel_erp_Winforms_App.UI.Controls.RoomCardControl;
using System.Globalization;
using System.Text;

namespace Hotel_erp_Winforms_App.UI.Forms.ServiceForms
{
    public partial class FrmCheckin : Form
    {
        #region TODO:

        /*
            - Csak akkor lehessen rányomni egy foglalásnál a check-inre, ha aznap van az érkezési dátum
            - Ha már létezik a vendég az adatbázisban, akkor ne mentse újra a check in confirm
        */

        #endregion

        #region variables

        private Booking? selectedBooking;
        private BookingService _bookingService = new BookingService();
        private CommonHelper _commonHelper = new CommonHelper();
        public Service service;

        public List<Service> services = new List<Service>();
        public List<BillingItem> billingItems = new List<BillingItem>();
        public List<Room> selectedRooms;
        public List<Guest> guestsOfBooking = new List<Guest>();
        public List<Guest> dbGuestsOfBooking = new List<Guest>();

        private bool _isRequestInitialized = false;

        private int _editingGuestId = 0;
        private Room selectedRoom;

        RoomCardUserControl cardControl;
        ErrorProvider _errorProvider = new ErrorProvider();
        private StringBuilder sumSelectedRoomString = new StringBuilder();

        #endregion

        public FrmCheckin(Booking? booking = null)
        {
            InitializeComponent();

            selectedBooking = booking;
        }

        private async void FrmCheckin_Load(object sender, EventArgs e)
        {
            tcCheckin.SelectedIndex = 0;
            btnBack.Visible = false;
            btnConfirm.Visible = false;
            ckbEditData.Visible = false;

            #region Personal Data

            var gs = new GuestService();

            if(selectedBooking != null)
            {
                var list = await gs.GetAllGuestsFromDbAsync();

                int?[] guestIds = new int?[]
                {
                    selectedBooking.GuestId,
                    selectedBooking.GuestId2,
                    selectedBooking.GuestId3,
                    selectedBooking.GuestId4
                };

                foreach (var guestId in guestIds)
                {
                    if (guestId.HasValue && guestId.Value != 0)
                    {
                        var matchingGuest = list.FirstOrDefault(g => g.Id == guestId.Value);

                        if (matchingGuest != null)
                        {
                            dbGuestsOfBooking.Add(matchingGuest);
                        }
                    }
                }
            }

            lbCurrentPage.Text = "1/5";
            cbGuests.Visible = false;

            FillNationalityCb();
            LoadGuestDataToUI();

            cbNationality.SelectedItem = "Hungary";
            dtpBirthdate.MaxDate = DateTime.Today;

            tbFirstName.ReadOnly = !string.IsNullOrEmpty(tbFirstName.Text);
            tbLastName.ReadOnly = !string.IsNullOrEmpty(tbLastName.Text);
            tbEmail.ReadOnly = !string.IsNullOrEmpty(tbEmail.Text);
            tbCarPlateNumber.ReadOnly = !string.IsNullOrEmpty(tbCarPlateNumber.Text);
            tbZipCode.ReadOnly = !string.IsNullOrEmpty(tbZipCode.Text);
            tbCity.ReadOnly = !string.IsNullOrEmpty(tbCity.Text);
            tbStreet.ReadOnly = !string.IsNullOrEmpty(tbStreet.Text);
            tbDocumentNumber.ReadOnly = !string.IsNullOrEmpty(tbDocumentNumber.Text);

            #endregion

            #region Error Handler
            using (var ms = new System.IO.MemoryStream(Properties.Resources.error))
            {
                _errorProvider.Icon = new System.Drawing.Icon(ms);
            }
            _errorProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink;
            #endregion

            #region Select Room

            flpCardHolder.Visible = false;

            if (selectedBooking is not null)
            {
                selectedRooms = await _bookingService.SelectedRoomsByBookingAsync(selectedBooking);
            }

            flpCardHolder.Controls.Clear();

            cardControl = new RoomCardUserControl();
            if (selectedBooking is not null)
            {
                await cardControl.LoadSelectedRoomCardDataAsync(selectedBooking);
            }
            cardControl.Dock = DockStyle.Fill;
            cardControl.CardSelected += CardControl_CardSelected;

            pnlChosenRoomCardHolder.Controls.Clear();
            pnlChosenRoomCardHolder.Controls.Add(cardControl);

            ckbBalcony.Visible = false;
            ckbView.Visible = false;
            ckbHotTub.Visible = false;

            RefreshRoomCards();
            #endregion

            #region Special Requests
            tbCarPlateNumber.ReadOnly = true;

            if (selectedBooking is not null)
            {
                if (await _bookingService.GetSpecialRequestsFromDbAsync(selectedBooking, "Transzfer")) { cbAirportTransfer.SelectedIndex = 0; }
                else { cbAirportTransfer.SelectedIndex = 1; }

                if (await _bookingService.GetSpecialRequestsFromDbAsync(selectedBooking, "Pótágy")) { cbExtraBed.SelectedIndex = 1; }
                else if (await _bookingService.GetSpecialRequestsFromDbAsync(selectedBooking, "Kiságy")) { cbExtraBed.SelectedIndex = 2; }
                else { cbExtraBed.SelectedIndex = 0; }

                if (await _bookingService.GetSpecialRequestsFromDbAsync(selectedBooking, "Parkolás"))
                { ckbParking.Checked = true; tbCarPlateNumber.Text = await _bookingService.GetCarPlateNumberByBookingAsync(selectedBooking); }

                if (await _bookingService.IsChampagneOrderedAsync(selectedBooking)) { cbChampagne.SelectedIndex = 0; }
                else { cbChampagne.SelectedIndex = 1; }
            }
            #endregion

            #region Summary

            tcGuests.TabPages.Clear();

            #endregion
        }

        #region Personal data UI actions

        private void FillNationalityCb()
        {
            List<string> countries = new List<string>();

            foreach (CultureInfo ci in CultureInfo.GetCultures(CultureTypes.SpecificCultures))
            {
                try
                {
                    RegionInfo ri = new RegionInfo(ci.Name);

                    string countryNameEn = ri.EnglishName;

                    if (!countries.Contains(countryNameEn))
                    {
                        countries.Add(countryNameEn);
                    }
                }

                catch
                {

                }
            }

            countries.Sort();

            cbNationality.DataSource = countries;
        }

        private void ckbEditData_CheckedChanged(object sender, EventArgs e)
        {
            bool isEditing = ckbEditData.Checked;

            tbFirstName.ReadOnly = !isEditing && !string.IsNullOrEmpty(tbFirstName.Text);
            tbLastName.ReadOnly = !isEditing && !string.IsNullOrEmpty(tbLastName.Text);
            tbEmail.ReadOnly = !isEditing && !string.IsNullOrEmpty(tbEmail.Text);
            tbCarPlateNumber.ReadOnly = !isEditing && !string.IsNullOrEmpty(tbCarPlateNumber.Text);
            tbZipCode.ReadOnly = !isEditing && !string.IsNullOrEmpty(tbZipCode.Text);
            tbCity.ReadOnly = !isEditing && !string.IsNullOrEmpty(tbCity.Text);
            tbStreet.ReadOnly = !isEditing && !string.IsNullOrEmpty(tbStreet.Text);
            tbDocumentNumber.ReadOnly = !isEditing && !string.IsNullOrEmpty(tbDocumentNumber.Text);
        }

        private bool guestIsSaved = true;
        private bool dataModified = false;

        private void btnAddGuest_Click(object sender, EventArgs e)
        {
            if (!guestIsSaved)
            {
                MessageBox.Show("Please save the current guest details before adding a new guest.",
                    "Save Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            cbGuests.SelectedIndex = -1;

            ClearInputFields();

            if (guestsOfBooking.Count > 0)
            {
                tbEmail.Text = guestsOfBooking[0].Email;
            }

            dataModified = false;
            guestIsSaved = false;
            ckbEditData.Checked = true;
        }

        private void btnEditGuestData_Click(object sender, EventArgs e)
        {
            if (cbGuests.SelectedIndex < 0) return;

            dataModified = true;
            guestIsSaved = false;
            ckbEditData.Checked = true;
        }

        private async void btnSaveGuest_Click(object sender, EventArgs e)
        {
            if (!PersonalDataValidationConfirm()) return;

            if (guestIsSaved && !dataModified && cbGuests.SelectedIndex >= 0)
            {
                MessageBox.Show("No changes detected to save.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult result = MessageBox.Show("Are you sure the details are correct?",
                "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result != DialogResult.Yes) return;

            int selectedIndex = cbGuests.SelectedIndex;

            // MEGLÉVŐ VENDÉG MÓDOSÍTÁSA
            if (selectedIndex >= 0 && selectedIndex < guestsOfBooking.Count)
            {
                UpdateGuestFromInput(guestsOfBooking[selectedIndex]);
            }
            // ÚJ VENDÉG MENTÉSE
            else
            {
                var gs = new GuestService();
                var allGuestsFromDb = await gs.GetAllGuestsFromDbAsync();

                bool idExistsInDb = allGuestsFromDb.Any(g =>
                    !string.IsNullOrWhiteSpace(g.IdCardNumber) &&
                    g.IdCardNumber.Trim().Equals(tbDocumentNumber.Text.Trim(), StringComparison.OrdinalIgnoreCase) &&
                    !dbGuestsOfBooking.Any(dbG =>
                        !string.IsNullOrWhiteSpace(dbG.IdCardNumber) &&
                        dbG.IdCardNumber.Trim().Equals(g.IdCardNumber.Trim(), StringComparison.OrdinalIgnoreCase))
                );

                if (idExistsInDb)
                {
                    MessageBox.Show("This ID card number is already registered in the system!",
                        "Already Exists", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var newGuest = GetGuestFromInput();
                guestsOfBooking.Add(newGuest);

                int nextGuestNumber = guestsOfBooking.Count;
                cbGuests.Items.Add($"Guest {nextGuestNumber}");
                cbGuests.SelectedIndex = cbGuests.Items.Count - 1;
            }

            tcGuests.TabPages.Clear();
            foreach (var g in guestsOfBooking)
            {
                await _bookingService.AddGuestTabToSummaryAsync(g, guestsOfBooking, tcGuests);
            }

            dataModified = false;
            guestIsSaved = true;
            ckbEditData.Checked = false;
            cbGuests.Visible = true;

            MessageBox.Show("Guest details saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void cbGuests_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = cbGuests.SelectedIndex;

            btnFillData.Visible = index > 0;
            tbEmail.Enabled = index == 0;

            if (index >= 0 && index < guestsOfBooking.Count)
            {
                FillGuestPersonalData(index);
                guestIsSaved = true;
                dataModified = false;
                ckbEditData.Checked = false;
            }
        }

        public void FillGuestPersonalData(int i)
        {
            if (i < 0 || i >= guestsOfBooking.Count)
            {
                ClearInputFields();
                return;
            }

            var guest = guestsOfBooking[i];

            tbFirstName.Text = guest.FName ?? "";
            tbLastName.Text = guest.LName ?? "";
            tbEmail.Text = guestsOfBooking.Count > 0 ? guestsOfBooking[0].Email : "";
            dtpBirthdate.Value = guest.DateOfBirth ?? DateTime.Today.AddYears(-18);
            cbNationality.SelectedItem = string.IsNullOrEmpty(guest.Country) ? "Hungary" : guest.Country;
            tbZipCode.Text = guest.ZipCode ?? "";
            tbCity.Text = guest.City ?? "";
            tbStreet.Text = guest.Street ?? "";
            tbDocumentNumber.Text = guest.IdCardNumber ?? "";
            tbCarPlateNumber.Text = guest.CarPlateNumber ?? "";
        }

        private Guest GetGuestFromInput()
        {
            return new Guest
            (
                _editingGuestId,
                tbEmail.Text.Trim(),
                tbDocumentNumber.Text.Trim(),
                tbFirstName.Text.Trim(),
                tbLastName.Text.Trim(),
                dtpBirthdate.Value,
                cbNationality.SelectedItem?.ToString() ?? "Hungary",
                tbZipCode.Text.Trim(),
                tbCity.Text.Trim(),
                tbStreet.Text.Trim(),
                tbCarPlateNumber.Text.Trim(),
                0, 0
            );
        }

        private async void LoadGuestDataToUI()
        {
            dtpBirthdate.MinDate = DateTime.Today.AddYears(-120);
            dtpBirthdate.MaxDate = DateTime.Today.AddYears(-18);

            Guest? existingGuest = selectedBooking is not null
                ? await _bookingService.FillPersonalDataAsync(selectedBooking)
                : null;

            if (existingGuest != null)
            {
                _editingGuestId = existingGuest.Id ?? 0;

                tbEmail.Text = existingGuest.Email;
                tbDocumentNumber.Text = string.IsNullOrWhiteSpace(existingGuest.IdCardNumber)
                    ? await _bookingService.GetIdCardNumberAsync(selectedBooking)
                    : existingGuest.IdCardNumber;
                tbFirstName.Text = existingGuest.FName;
                tbLastName.Text = existingGuest.LName;
                dtpBirthdate.Value = existingGuest.DateOfBirth ?? DateTime.Today;

                if (!string.IsNullOrEmpty(existingGuest.Country))
                {
                    cbNationality.SelectedItem = existingGuest.Country;
                }
                else { cbNationality.SelectedItem = "Hungary"; }

                tbZipCode.Text = existingGuest.ZipCode ?? "";
                tbCity.Text = existingGuest.City ?? "";
                tbStreet.Text = existingGuest.Street ?? "";
                tbCarPlateNumber.Text = existingGuest.CarPlateNumber ?? "";
            }

            else
            {
                _editingGuestId = 0;
                cbNationality.SelectedItem = "Hungary";
            }
        }

        #endregion

        #region Room selections UI actions
        bool cardIsSelected = false;
        private RoomCardUserControl? _activeRoomCard = null;

        public void CardControl_CardSelected(object? sender, EventArgs e)
        {
            if (sender is RoomCardUserControl clickedCard)
            {
                if (_activeRoomCard != null)
                {
                    _activeRoomCard.SetSelected(false);
                }

                _activeRoomCard = clickedCard;
                _activeRoomCard.SetSelected(true);

                Room room = clickedCard.SelectedRoom;
                if (selectedBooking != null)
                {
                    selectedBooking.RoomNumber = room.Room_number;
                }

                selectedRoom = room;
                cardIsSelected = true;
            }
        }

        private void ckbSelectOtherRoom_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbSelectOtherRoom.Checked)
            {
                flpCardHolder.Visible = true;
                ckbBalcony.Visible = true;
                ckbView.Visible = true;
                ckbHotTub.Visible = true;
            }
            else
            {
                flpCardHolder.Visible = false;
                ckbBalcony.Visible = false;
                ckbView.Visible = false;
                ckbHotTub.Visible = false;
            }
        }

        private void ckbBalcony_CheckedChanged(object sender, EventArgs e)
        {
            FilterRoomsBySpecialRequests();
        }

        private void ckbView_CheckedChanged(object sender, EventArgs e)
        {
            FilterRoomsBySpecialRequests();
        }

        private void ckbHotTub_CheckedChanged(object sender, EventArgs e)
        {
            FilterRoomsBySpecialRequests();
        }

        private async void FilterRoomsBySpecialRequests()
        {
            StringBuilder sb = new StringBuilder();

            if (ckbBalcony.Checked)
            {
                sb.Append(" AND rooms.has_balcony = 1 ");
            }

            if (ckbView.Checked)
            {
                sb.Append(" AND rooms.has_view IS NOT NULL ");
            }

            if (ckbHotTub.Checked)
            {
                sb.Append(" AND rooms.extras = 'jacuzzi' ");
            }

            selectedRooms.Clear();
            if (selectedBooking is not null)
            {
                selectedRooms = await _bookingService.SelectedRoomsByBookingAsync(selectedBooking, sb.ToString());
            }

            RefreshRoomCards();
        }
        #endregion

        #region Payment summary

        private void dgvPaymentSum_SelectionChanged(object sender, EventArgs e)
        {
            dgvPaymentSum.ClearSelection();
        }
        #endregion

        // - Oldalankénti betöltés -
        public async void tcCheckin_SelectedIndexChanged(object sender, EventArgs e)
        {
            _bookingService.RefreshPageCount(tcCheckin, lbCurrentPage);
            billingItems = await _bookingService.MakeListOfBillsAsync(services, selectedBooking);

            int netAmount;
            int taxAmount;
            int grossAmount;

            switch (tcCheckin.SelectedIndex)
            {
                case 2:
                    if (!_isRequestInitialized)
                    {
                        string cateringLevel = selectedBooking.SelectedCateringLevel.ToString();
                        cateringLevel = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(cateringLevel.ToLower());
                        cbCateringLevel.SelectedItem = cateringLevel;

                        _isRequestInitialized = true;
                    }
                    break;

                case 3:
                    colNameOfService.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    colUnitPrice.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    colQuantity.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    colTax.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    colTotal.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;

                    colNameOfService.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    colQuantity.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    colUnitPrice.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    colUnitPrice.DefaultCellStyle.Format = "C0";
                    colTax.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    colTax.DefaultCellStyle.Format = "P0";
                    colTotal.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    colTotal.DefaultCellStyle.Format = "C0";

                    await _bookingService.LoadBillItemsAsync(dgvPaymentSum, services, selectedBooking);

                    netAmount = await _bookingService.CalculateNetAmountAsync(billingItems);
                    taxAmount = await _bookingService.CalculateTaxAmountAsync(billingItems);
                    grossAmount = await _bookingService.CalculateGrossAmountAsync(billingItems);

                    lbNetAmount.Text = netAmount.ToString("C0");
                    lbTaxAmount.Text = taxAmount.ToString("C0");
                    lbGrossAmount.Text = grossAmount.ToString("C0");

                    break;

                case 4:
                    lbSumRoomDetails.Text = sumSelectedRoomString.ToString();
                    _bookingService.FillSumSpecialRequests(services, lbSumExtras);
                    grossAmount = await _bookingService.CalculateGrossAmountAsync(billingItems);

                    tcGuests.TabPages.Clear();

                    if (ckbParking.Checked && guestsOfBooking.Count > 0)
                    {
                        guestsOfBooking[0].CarPlateNumber = tbCarPlateNumber.Text.Trim();
                    }

                    foreach (var g in guestsOfBooking)
                    {
                        await _bookingService.AddGuestTabToSummaryAsync(g, guestsOfBooking, tcGuests);
                    }

                    lbSumRoomDetails.Text = _bookingService.BuildSelectedRoomDetailsString(selectedRoom);
                    lbSumRemaining.Text = $"{grossAmount - Convert.ToInt32(lbSumPaid.Text):C0}";
                    lbSumTotal.Text = $"{grossAmount:C0}";
                    lbSumPaid.Text = $"{Convert.ToInt32(lbSumPaid.Text)}";

                    break;
            }
        }
        // -------------------------

        #region Special Requests

        private void cbAirportTransfer_SelectedIndexChanged(object? sender, EventArgs e)
        {
            services.RemoveAll(s => s.NameHu == "Transzfer");

            if (cbAirportTransfer.SelectedIndex == 0)
            {
                _bookingService.CreateNewService("Transzfer", services);
            }
        }

        public void cbCateringLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbCateringLevel?.SelectedItem?.ToString() != selectedBooking.SelectedCateringLevel.ToString())
            {
                services.RemoveAll(s => s.NameHu == "Félpanzió" || s.NameHu == "Teljes ellátás");

                if (cbCateringLevel?.SelectedItem?.ToString() == "Halfboard")
                {
                    _bookingService.CreateNewService("Halfboard", services);
                    selectedBooking.SelectedCateringLevel = System.Enum.Parse<CateringLevel>("halfboard", ignoreCase: true);
                    lbSumCatering.Text = "Halfboard";
                }

                else if (cbCateringLevel?.SelectedItem?.ToString() == "Fullboard")
                {
                    _bookingService.CreateNewService("Fullboard", services);
                    selectedBooking.SelectedCateringLevel = System.Enum.Parse<CateringLevel>("fullboard", ignoreCase: true);
                    lbSumCatering.Text = "Fullboard";
                }

                else
                {
                    lbSumCatering.Text = "Breakfast";
                    selectedBooking.SelectedCateringLevel = System.Enum.Parse<CateringLevel>("breakfast", ignoreCase: true);
                }
            }

            if (cbCateringLevel?.SelectedItem != null &&
                System.Enum.TryParse<CateringLevel>(cbCateringLevel.SelectedItem.ToString(), true, out var cateringLevel))
            {
                selectedBooking.SelectedCateringLevel = cateringLevel;
            }
        }

        private void cbChampagne_SelectedIndexChanged(object sender, EventArgs e)
        {
            services.RemoveAll(s => s.NameHu == "Pezsgő bekészítés");

            if (cbChampagne.SelectedIndex == 0)
            {
                _bookingService.CreateNewService("Pezsgő bekészítés", services);
            }
        }

        bool parkingChecked = false;
        private void ckbParking_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbParking.Checked)
            {
                tbCarPlateNumber.Enabled = true;
                tbCarPlateNumber.Focus();

                services.RemoveAll(s => s.NameHu == "Parkolás");
                _bookingService.CreateNewService("Parkolás", services);
            }
            else
            {
                tbCarPlateNumber.Clear();
                tbCarPlateNumber.Enabled = false;

                services.RemoveAll(s => s.NameHu == "Parkolás");
            }
        }

        private void cbExtraBed_SelectedIndexChanged(object sender, EventArgs e)
        {
            services.RemoveAll(s => s.NameHu == "Pótágy" || s.NameHu == "Kiságy");

            if (cbExtraBed.SelectedIndex == 1)
            {
                _bookingService.CreateNewService("Pótágy", services);
            }

            else if (cbExtraBed.SelectedIndex == 2)
            {
                _bookingService.CreateNewService("Kiságy", services);
            }
        }

        private void cbDepartureNotes_SelectedIndexChanged(object sender, EventArgs e)
        {
            services.RemoveAll(s => s.NameHu == "Késői kijelentkezés" || s.NameHu == "Korai távozás");

            if (cbDepartureNotes.SelectedIndex == 1)
            {
                _bookingService.CreateNewService("Késői kijelentkezés", services);
            }

            else if (cbDepartureNotes.SelectedIndex == 2)
            {
                _bookingService.CreateNewService("Korai távozás", services);
            }
        }

        private void RefreshRoomCards()
        {
            flpCardHolder.Controls.Clear();
            foreach (var room in selectedRooms)
            {
                RoomCardUserControl roomCard = new RoomCardUserControl();
                roomCard.LoadCardData(room);
                roomCard.CardSelected += CardControl_CardSelected;
                flpCardHolder.Controls.Add(roomCard);
            }
        }

        #endregion

        #region Buttons

        private void btnNext_Click(object sender, EventArgs e)
        {
            switch (tcCheckin.SelectedIndex)
            {
                case 0:
                    if (!PersonalDataValidationConfirm())
                    {
                        return;
                    }

                    if (guestsOfBooking.Count() == 0 || dataModified)
                    {
                        MessageBox.Show("Please save the guest details before proceeding.",
                            "Guest Details Missing",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                        return;
                    }

                    if (dataModified && !guestIsSaved) return;
                    break;

                case 1:
                    if (!cardIsSelected)
                    {
                        MessageBox.Show("You must select a Room first!", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    break;
            }

            _bookingService.NextButtonClick(tcCheckin, btnNext, btnBack, btnConfirm);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            _bookingService.BackButtonClick(tcCheckin, btnNext, btnBack, btnConfirm);
        }

        private async void btnConfirm_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show(
                "Are you sure all the details are correct?",
                "Cofirmation",
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Question
            );

            if (dr == DialogResult.Yes)
            {
                try
                {
                    if (selectedBooking is not null)
                    {
                        await _bookingService.ConfirmCheckinAsync(selectedBooking, guestsOfBooking, services);
                    }
                    MessageBox.Show("Check-in confirmation successful.", "Confirmed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    this.Close();
                }
            }

            else { return; }
        }

        private void btnFillData_Click(object sender, EventArgs e)
        {
            if (guestsOfBooking.Count > 0)
            {
                tbZipCode.Text = guestsOfBooking[0].ZipCode;
                tbCity.Text = guestsOfBooking[0].City;
                tbStreet.Text = guestsOfBooking[0].Street;
                cbNationality.Text = guestsOfBooking[0].Country;
            }
        }

        #endregion

        #region Foolproofing

        private bool PersonalDataValidationConfirm()
        {
            bool isFirstNameValid = !_commonHelper.HasValidationError(tbFirstName, _errorProvider);
            bool isLastNameValid = !_commonHelper.HasValidationError(tbLastName, _errorProvider);
            bool isEmailValid = !_commonHelper.HasValidationError(tbEmail, _errorProvider)
                        && !string.IsNullOrWhiteSpace(tbEmail.Text)
                        && tbEmail.Text.Contains("@");

            if (!isEmailValid)
            {
                _errorProvider.SetError(tbEmail, "Invalid email address (must contain '@')");
            }
            else
            {
                _errorProvider.SetError(tbEmail, "");
            }

            bool isZipValid = !_commonHelper.HasValidationError(tbZipCode, _errorProvider);
            bool isCityValid = !_commonHelper.HasValidationError(tbCity, _errorProvider);
            bool isDocValid = !_commonHelper.HasValidationError(tbDocumentNumber, _errorProvider);

            return isFirstNameValid && isLastNameValid && isEmailValid && isZipValid && isCityValid && isDocValid;
        }

        private void tbFirstName_KeyPress(object sender, KeyPressEventArgs e)
        {
            CommonHelper.InputValidationService.BlockDigits(e);
        }

        private void tbLastName_KeyPress(object sender, KeyPressEventArgs e)
        {
            CommonHelper.InputValidationService.BlockDigits(e);
        }

        private void tbPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            CommonHelper.InputValidationService.BlockLetters(e);
        }

        private void tbZipCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            CommonHelper.InputValidationService.BlockLetters(e);
        }

        private void tbCity_KeyPress(object sender, KeyPressEventArgs e)
        {
            CommonHelper.InputValidationService.BlockDigits(e);
        }

        #endregion

        #region helpers

        private void ClearInputFields()
        {
            tbFirstName.Clear();
            tbLastName.Clear();
            tbDocumentNumber.Clear();
            tbEmail.Clear();
            tbZipCode.Clear();
            tbCity.Clear();
            tbStreet.Clear();
            tbCarPlateNumber.Clear();
            dtpBirthdate.Value = DateTime.Today.AddYears(-18);
            cbNationality.SelectedItem = "Hungary";
        }

        private void UpdateGuestFromInput(Guest guest)
        {
            guest.FName = tbFirstName.Text.Trim();
            guest.LName = tbLastName.Text.Trim();
            guest.IdCardNumber = tbDocumentNumber.Text.Trim();
            guest.Email = tbEmail.Text.Trim();
            guest.DateOfBirth = dtpBirthdate.Value;
            guest.Country = cbNationality.SelectedItem?.ToString() ?? "Hungary";
            guest.ZipCode = tbZipCode.Text.Trim();
            guest.City = tbCity.Text.Trim();
            guest.Street = tbStreet.Text.Trim();
            guest.CarPlateNumber = tbCarPlateNumber.Text.Trim();
        }

        #endregion
    }
}