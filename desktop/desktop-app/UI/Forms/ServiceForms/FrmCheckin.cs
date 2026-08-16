using Google.Protobuf.WellKnownTypes;
using Hotel_erp_Winforms_App.Models;
using Hotel_erp_Winforms_App.Services;
using Hotel_erp_Winforms_App.UI.Controls.GuestsDataSumControl;
using Hotel_erp_Winforms_App.UI.Controls.RoomCardControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.PerformanceData;
using System.Drawing;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows.Forms;

namespace Hotel_erp_Winforms_App.UI.Forms.ServiceForms
{
    public partial class FrmCheckin : Form
    {
        private Booking selectedBooking;
        private BookingService _bookingService;
        public List<Service> services = new List<Service>();
        public List<BillingItem> billingItems = new List<BillingItem>();
        public List<Room> selectedRooms;
        public List<Guest> guestsOfBooking = new List<Guest>();
        public Service service;
        private bool _isRequestInitialized = false;
        private StringBuilder sumSelectedRoomString = new StringBuilder();
        private int _editingGuestId = 0;
        RoomCardUserControl cardControl;
        ErrorProvider _errorProvider = new ErrorProvider();

        public FrmCheckin(Booking booking)
        {
            InitializeComponent();
            selectedBooking = booking;
            _bookingService = new BookingService();
        }

        private void FrmCheckin_Load(object sender, EventArgs e)
        {
            tcCheckin.SelectedIndex = 0;
            btnBack.Visible = false;
            btnConfirm.Visible = false;
            ckbEditData.Visible = false;

            #region Personal Data

            lbCurrentPage.Text = "1/5";
            cbGuests.Visible = false;

            FillNationalityCb();
            LoadGuestDataToUI();

            cbNationality.SelectedItem = "Hungary";
            dtpBirthdate.MaxDate = DateTime.Today;
            cbDocumentType.SelectedIndex = 0;

            tbFirstName.ReadOnly = !string.IsNullOrEmpty(tbFirstName.Text);
            tbLastName.ReadOnly = !string.IsNullOrEmpty(tbLastName.Text);
            tbEmail.ReadOnly = !string.IsNullOrEmpty(tbEmail.Text);
            tbCarPlateNumber.ReadOnly = !string.IsNullOrEmpty(tbCarPlateNumber.Text);
            tbZipCode.ReadOnly = !string.IsNullOrEmpty(tbZipCode.Text);
            tbCity.ReadOnly = !string.IsNullOrEmpty(tbCity.Text);
            tbStreet.ReadOnly = !string.IsNullOrEmpty(tbStreet.Text);
            tbDocumentNumber.ReadOnly = !string.IsNullOrEmpty(tbDocumentNumber.Text);

            #endregion

            // FOR TESTING!!!
            tbPhone.Text = "111";
            tbDocumentNumber.Text = "adsv";
            // --------------

            #region Error Handler
            using (var ms = new System.IO.MemoryStream(Properties.Resources.error))
            {
                _errorProvider.Icon = new System.Drawing.Icon(ms);
            }
            _errorProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink;
            #endregion

            #region Select Room

            flpCardHolder.Visible = false;

            selectedRooms = _bookingService.SelectedRoomsByBooking(selectedBooking);
            flpCardHolder.Controls.Clear();

            cardControl = new RoomCardUserControl();
            cardControl.LoadSelectedRoomCardData(selectedBooking);
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

            if (_bookingService.GetSpecialRequestsFromDb(selectedBooking, "Transzfer")) { cbAirportTransfer.SelectedIndex = 0; }
            else { cbAirportTransfer.SelectedIndex = 1; }

            if (_bookingService.GetSpecialRequestsFromDb(selectedBooking, "Pótágy")) { cbExtraBed.SelectedIndex = 1; }
            else if (_bookingService.GetSpecialRequestsFromDb(selectedBooking, "Kiságy")) { cbExtraBed.SelectedIndex = 2; }
            else { cbExtraBed.SelectedIndex = 0; }

            if (_bookingService.GetSpecialRequestsFromDb(selectedBooking, "Parkolás"))
            { ckbParking.Checked = true; tbCarPlateNumber.Text = _bookingService.GetCarPlateNumberByBooking(selectedBooking); }

            if (_bookingService.IsChampagneOrdered(selectedBooking)) { cbChampagne.SelectedIndex = 0; }
            else { cbChampagne.SelectedIndex = 1; }

            #endregion

            #region Summary

            tcGuests.TabPages.Clear();

            #endregion
        }

        // Personal Data UI műveletek

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
            if (!ckbEditData.Checked)
            {
                tbFirstName.ReadOnly = (tbFirstName.Text != "");
                tbLastName.ReadOnly = (tbLastName.Text != "");
                tbEmail.ReadOnly = (tbEmail.Text != "");
                tbCarPlateNumber.ReadOnly = (tbCarPlateNumber.Text != "");
                tbZipCode.ReadOnly = (tbZipCode.Text != "");
                tbCity.ReadOnly = tbCity.Text != "";
                tbStreet.ReadOnly = tbStreet.Text != "";
                tbDocumentNumber.ReadOnly = tbDocumentNumber.Text != "";
            }

            else
            {
                tbFirstName.ReadOnly = false;
                tbLastName.ReadOnly = false;
                tbEmail.ReadOnly = false;
                tbCarPlateNumber.ReadOnly = false;
                tbZipCode.ReadOnly = false;
                tbCity.ReadOnly = false;
                tbStreet.ReadOnly = false;
                tbDocumentNumber.ReadOnly = false;
            }
        }

        // TODO: TOTAL_NIGHTS & LOYALTY LEVEL KEZELÉS, KELLENE PHONE NUMBER A DB-BA
        int guestCount = 0;
        private void btnAddGuest_Click(object sender, EventArgs e)
        {
            if (!guestIsSaved)
            {
                MessageBox.Show("Please save the Guest details before adding a new Guest.",
                        "Save Required",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                return;
            }

            ckbEditData.Checked = true;

            guestCount += 1;
            cbGuests.Items.Add($"Guest {guestCount}");
            cbGuests.SelectedIndex = guestCount - 1;

            tbEmail.Clear();
            tbDocumentNumber.Clear();
            tbFirstName.Clear();
            tbLastName.Clear();
            tbPhone.Clear();
            dtpBirthdate.Value = DateTime.Today;
            cbNationality.SelectedItem = "Hungary";
            tbZipCode.Clear();
            tbCity.Clear();
            tbStreet.Clear();
            tbCarPlateNumber.Clear();
            ckbEditData.Checked = true;
            guestIsSaved = false;
        }

        bool dataModified = false;
        int modifiedGuestIndex;
        private void btnEditGuestData_Click(object sender, EventArgs e)
        {
            modifiedGuestIndex = cbGuests.SelectedIndex;
            dataModified = true;
            guestIsSaved = false;
            ckbEditData.Checked = true;
        }

        bool guestIsSaved = false;
        private void btnSaveGuest_Click(object sender, EventArgs e)
        {
            Guest guest;

            if (!PersonalDataValidationConfirm()) return;

            DialogResult result = MessageBox.Show("Are you sure the details are correct?",
               "Confirmation",
               MessageBoxButtons.YesNo,
               MessageBoxIcon.Question);

            if (cbGuests.Visible == false) cbGuests.Visible = true;

            if (result == DialogResult.Yes)
            {
                if (dataModified)
                {
                    guest = GetGuestFromInput();

                    if (guestsOfBooking.Count() > 0)
                    {
                        guest = guestsOfBooking[modifiedGuestIndex];
                    }
                    else
                    {
                        guestsOfBooking.Add(guest);

                        guestCount++;
                        cbGuests.Items.Add($"Guest {guestCount}");
                        cbGuests.SelectedIndex = guestCount - 1;
                    }

                    tcGuests.TabPages.Clear();
                    foreach(var g in guestsOfBooking) AddGuestTabToSummary(g);

                    dataModified = false;
                    guestIsSaved = true;
                    ckbEditData.Checked = false;
                }

                else if (!guestsOfBooking.Any(g => g.IdCardNumber == tbDocumentNumber.Text.Trim()))
                {
                    _editingGuestId = 0;

                    guest = GetGuestFromInput();

                    guestsOfBooking.Add(guest);
                    AddGuestTabToSummary(guest);
                    ckbEditData.Checked = false;

                    guestIsSaved = true;

                    if (guestCount == 0)
                    {
                        guestCount++;
                        cbGuests.Items.Add($"Guest {guestCount}");
                    }
                    cbGuests.SelectedIndex = guestCount - 1;
                }
                else { MessageBox.Show("This ID card number is already saved!", "Already exists", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void cbGuests_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbGuests.SelectedIndex >= 0)
            {
                FillGuestPersonalData(cbGuests.SelectedIndex);
            }
        }

        public void FillGuestPersonalData(int i)
        {
            if (guestsOfBooking.Count() > i) tbFirstName.Text = guestsOfBooking[i].FName;
            else { tbFirstName.Text = ""; }
            if (guestsOfBooking.Count() > i) tbLastName.Text = guestsOfBooking[i].LName;
            else { tbLastName.Text = ""; }
            if (guestsOfBooking.Count() > i) tbEmail.Text = guestsOfBooking[i].Email;
            else { tbEmail.Text = ""; }
            if (guestsOfBooking.Count() > i) dtpBirthdate.Value = Convert.ToDateTime(guestsOfBooking[i].DateOfBirth);
            else { dtpBirthdate.Value = DateTime.Today; }
            if (guestsOfBooking.Count() > i) cbNationality.SelectedItem = guestsOfBooking[i].Country;
            else { cbNationality.SelectedItem = "Hungary"; }
            if (guestsOfBooking.Count() > i) tbZipCode.Text = guestsOfBooking[i].ZipCode;
            else { tbZipCode.Text = ""; }
            if (guestsOfBooking.Count() > i) tbCity.Text = guestsOfBooking[i].City;
            else { tbCity.Text = ""; }
            if (guestsOfBooking.Count() > i) tbStreet.Text = guestsOfBooking[i].Street;
            else { tbStreet.Text = ""; }
            if (guestsOfBooking.Count() > i) tbDocumentNumber.Text = guestsOfBooking[i].IdCardNumber;
            else { tbDocumentNumber.Text = ""; }
        }

        public void AddGuestTabToSummary(Guest g)
        {
            int index = guestsOfBooking.IndexOf(g);

            GuestDataSumControl guestTab = new GuestDataSumControl();
            TabPage tp = new TabPage($"tpGuest{index}");

            tp.Text = $"Guest {index + 1}";
            tp.Controls.Add(guestTab);

            guestTab.FillGuestTabData(g);

            tcGuests.TabPages.Add(tp);
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

        private void LoadGuestDataToUI()
        {
            dtpBirthdate.MaxDate = DateTime.Now;
            Guest? existingGuest = _bookingService.FillPersonalData(selectedBooking);

            if(existingGuest != null)
            {
                _editingGuestId = existingGuest.Id ?? 0;

                tbEmail.Text = existingGuest.Email;
                tbDocumentNumber.Text = string.IsNullOrWhiteSpace(existingGuest.IdCardNumber)
                    ? _bookingService.GetIdCardNumber(selectedBooking)
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

        // --------------------------

        // Select Room UI műveletek
        bool cardIsSelected = false;
        public void CardControl_CardSelected(object sender, EventArgs e)
        {
            RoomCardUserControl selectedCard = (RoomCardUserControl)sender;
            Room room = selectedCard.SelectedRoom;

            selectedBooking.RoomNumber = room.Room_number;

            sumSelectedRoomString.Clear();
            string hasBalcony = room.HasBalcony == 1 ? "Balcony" : "No Balcony";
            sumSelectedRoomString.Append($"{room.Room_number.ToString()}  |  ");
            sumSelectedRoomString.Append($"{room.RoomsRoomtype.ToString()}  |  ");
            sumSelectedRoomString.Append($"{room.RoomsBedType.ToString()}  |  ");
            sumSelectedRoomString.Append($"{hasBalcony}  |  ");
            sumSelectedRoomString.Append($"{room.RoomsView.ToString()}");

            cardIsSelected = true;
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

        private void FilterRoomsBySpecialRequests()
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
            selectedRooms = _bookingService.SelectedRoomsByBooking(selectedBooking, sb.ToString());

            RefreshRoomCards();
        }
        // -------------------------

        // ------ Payment Sum ------
        private void dgvPaymentSum_SelectionChanged(object sender, EventArgs e)
        {
            dgvPaymentSum.ClearSelection();
        }

        public void LoadBillItems()
        {
            billingItems = _bookingService.MakeListOfBills(services, selectedBooking);
            billingItems = billingItems.OrderByDescending(e => e.Total).ToList();

            var bindingList = new BindingList<BillingItem>(billingItems);

            dgvPaymentSum.AutoGenerateColumns = false;
            dgvPaymentSum.Columns.Clear();

            LoadBillingitemToDgv("Date");
            LoadBillingitemToDgv("Description");
            LoadBillingitemToDgv("UnitPrice");
            LoadBillingitemToDgv("Quantity");
            LoadBillingitemToDgv("Tax");
            LoadBillingitemToDgv("Total");

            dgvPaymentSum.Columns[3].HeaderText = "Qty";

            dgvPaymentSum.DataSource = bindingList;

            // DATAGRIDVIEW STYLE
            dgvPaymentSum.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvPaymentSum.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvPaymentSum.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvPaymentSum.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvPaymentSum.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvPaymentSum.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvPaymentSum.Columns[0].DefaultCellStyle.Format = "yyyy.MM.dd";

            dgvPaymentSum.Columns[2].DefaultCellStyle.Format = "C0";
            dgvPaymentSum.Columns[5].DefaultCellStyle.Format = "C0";

            dgvPaymentSum.Columns[4].DefaultCellStyle.Format = "P0";
            // -----------------
        }

        private void LoadBillingitemToDgv(string description)
        {
            dgvPaymentSum.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = description,
                HeaderText = description
            });
        }

        // -------------------------

        // - Oldalankénti betöltés -
        public void tcCheckin_SelectedIndexChanged(object sender, EventArgs e)
        {
            _bookingService.RefreshPageCount(tcCheckin, lbCurrentPage);

            if (tcCheckin.SelectedIndex == 2)
            {
                if (!_isRequestInitialized)
                {
                    string cateringLevel = selectedBooking.SelectedCateringLevel.ToString();
                    cateringLevel = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(cateringLevel.ToLower());
                    cbCateringLevel.SelectedItem = cateringLevel;

                    _isRequestInitialized = true;
                }
            }

            if (tcCheckin.SelectedIndex == 3)
            {
                LoadBillItems();

                lbNetAmount.Text = _bookingService.CalculateNetAmount(billingItems).ToString("C0");
                lbTaxAmount.Text = _bookingService.CalculateTaxAmount(billingItems).ToString("C0");
                lbGrossAmount.Text = _bookingService.CalculateGrossAmount(billingItems).ToString("C0");
            }

            if (tcCheckin.SelectedIndex == 4)
            {
                MessageBox.Show($"{selectedBooking.SelectedCateringLevel}");

                lbSumRoomDetails.Text = sumSelectedRoomString.ToString();
                FillSumSpecialRequests();

                tcGuests.TabPages.Clear();

                if(ckbParking.Checked && guestsOfBooking.Count > 0)
                {
                    guestsOfBooking[0].CarPlateNumber = tbCarPlateNumber.Text.Trim();
                }

                foreach (var g in guestsOfBooking)
                {
                    AddGuestTabToSummary(g);
                }

                lbSumRemaining.Text = $"{_bookingService.CalculateGrossAmount(billingItems) - Convert.ToInt32(lbSumPaid.Text):C0}";
                lbSumTotal.Text = $"{_bookingService.CalculateGrossAmount(billingItems):C0}";
                lbSumPaid.Text = $"{Convert.ToInt32(lbSumPaid.Text)}";
            }
        }
        // -------------------------

        #region Special Requests

        private void cbAirportTransfer_SelectedIndexChanged(object? sender, EventArgs e)
        {
            services.RemoveAll(s => s.NameHu == "Transzfer");

            if (cbAirportTransfer.SelectedIndex == 0)
            {
                service = new Service(
                    3,
                    "Transzfer",
                    "Reptéri transzfer egy irányba",
                    ServiceTypeHu.Logisztika,
                    10000,
                    "Transfer",
                    "Airport transfer one way",
                    ServiceTypeEn.Logistics
                );
                services.Add(service);
            }
        }

        public void cbCateringLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbCateringLevel?.SelectedItem?.ToString() != selectedBooking.SelectedCateringLevel.ToString())
            {
                services.RemoveAll(s => s.NameHu == "Félpanzió" || s.NameHu == "Teljes ellátás");

                if (cbCateringLevel.SelectedItem.ToString() == "Halfboard")
                {
                    Service service = new Service(
                        19,
                        "Félpanzió",
                        "Félpanziós ellátás reggelivel és vacsorával",
                        ServiceTypeHu.Logisztika,
                        17000,
                        "Half board",
                        "Half-board service including breakfast and dinner.",
                        ServiceTypeEn.Logistics
                    );
                    services.Add(service);
                    selectedBooking.SelectedCateringLevel = System.Enum.Parse<CateringLevel>("halfboard", ignoreCase: true);
                    lbSumCatering.Text = "Halfboard";
                }

                else if (cbCateringLevel.SelectedItem.ToString() == "Fullboard")
                {
                    Service service = new Service(
                        20,
                        "Teljes ellátás",
                        "Teljes ellátás reggelivel, ebéddel és vacsorával.",
                        ServiceTypeHu.Logisztika,
                        28000,
                        "Full board",
                        "Full-board service including breakfast, lunch and dinner.",
                        ServiceTypeEn.Logistics
                    );
                    services.Add(service);
                    selectedBooking.SelectedCateringLevel = System.Enum.Parse<CateringLevel>("fullboard", ignoreCase: true);
                    lbSumCatering.Text = "Fullboard";
                }

                else 
                {
                    lbSumCatering.Text = "Breakfast";
                    selectedBooking.SelectedCateringLevel = System.Enum.Parse<CateringLevel>("breakfast", ignoreCase: true);
                }
            }

            selectedBooking.SelectedCateringLevel = (CateringLevel)System.Enum.Parse(typeof(CateringLevel), cbCateringLevel.SelectedItem.ToString().ToLower());
        }

        private void cbChampagne_SelectedIndexChanged(object sender, EventArgs e)
        {
            services.RemoveAll(s => s.NameHu == "Pezsgő bekészítés");

            if (cbChampagne.SelectedIndex == 0)
            {
                service = new Service(
                    21,
                    "Pezsgő bekészítés",
                    "A világ legikonikusabb champagne-ja; vibrálóan friss, citrusos és briósos jegyekkel, valamint tökéletesen elegáns textúrával.",
                    ServiceTypeHu.Extrák,
                    37000,
                    "Champagne",
                    "The world's most iconic champagne; vibrantly fresh with notes of citrus, brioche, and a perfectly elegant texture.",
                    ServiceTypeEn.Extras
                );
                services.Add(service);
            }
        }

        bool parkingChecked = false;
        private void ckbParking_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbParking.Checked)
            {
                tbCarPlateNumber.ReadOnly = false;
                parkingChecked = true;

                services.RemoveAll(s => s.NameHu == "Parkolás");

                int days = (selectedBooking.EndOfStay - selectedBooking.BeginningOfStay).Days;

                service = new Service(
                    2,
                    "Parkolás",
                    "Zárt parkoló napidíj",
                    ServiceTypeHu.Logisztika,
                    3000 * days,
                    "Parking",
                    "Gated parking daily fee",
                    ServiceTypeEn.Logistics
                );
                services.Add(service);
            }

            else { tbCarPlateNumber.ReadOnly = true; tbCarPlateNumber.Clear(); }
        }

        private void cbExtraBed_SelectedIndexChanged(object sender, EventArgs e)
        {
            services.RemoveAll(s => s.NameHu == "Pótágy" || s.NameHu == "Kiságy");

            if (cbExtraBed.SelectedIndex == 1)
            {
                service = new Service(
                    9,
                    "Pótágy",
                    "Extra ágy biztosítása",
                    ServiceTypeHu.Extrák,
                    7000,
                    "Extra bed",
                    "Provision of an extra bed",
                    ServiceTypeEn.Extras
                );
                services.Add(service);
            }

            else if (cbExtraBed.SelectedIndex == 2)
            {
                service = new Service(
                    10,
                    "Kiságy",
                    "Babaágy biztosítása",
                    ServiceTypeHu.Extrák,
                    3000,
                    "Baby cot",
                    "Provision of a baby cot",
                    ServiceTypeEn.Extras
                );
                services.Add(service);
            }
        }

        private void cbDepartureNotes_SelectedIndexChanged(object sender, EventArgs e)
        {
            services.RemoveAll(s => s.NameHu == "Késői kijelentkezés" || s.NameHu == "Korai távozás");

            if (cbDepartureNotes.SelectedIndex == 1)
            {
                service = new Service(
                    22,
                    "Késői kijelentkezés",
                    "Fizetős szobahosszabbítás a távozás napján.",
                    ServiceTypeHu.Logisztika,
                    20000,
                    "Late check-out",
                    "Paid room extension upon departure.",
                    ServiceTypeEn.Logistics
                );
                services.Add(service);
            }

            else if (cbDepartureNotes.SelectedIndex == 2)
            {
                service = new Service(
                    23,
                    "Korai távozás",
                    "Tervezettnél korábbi elutazás a szállodából.",
                    ServiceTypeHu.Logisztika,
                    30000,
                    "Early departure",
                    "eaving the hotel before schedule.",
                    ServiceTypeEn.Logistics
                );
                services.Add(service);
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

        private void FillSumSpecialRequests()
        {
            var validNames = services.Select(s => s.NameHu).Where(name => !string.IsNullOrWhiteSpace(name));

            if (!validNames.Any())
            {
                lbSumExtras.Text = "No special requests";
                return;
            }

            string sumRequests = string.Join(" | ", services.Select(s => s.NameHu));
            lbSumExtras.Text = sumRequests;
        }
        #endregion

        #region Buttons

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (tcCheckin.SelectedIndex == 0)
            {
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
            }

            if (tcCheckin.SelectedIndex == 1)
            {
                if (!cardIsSelected)
                {
                    MessageBox.Show("You must select a Room first!", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            _bookingService.NextButtonClick(tcCheckin, btnNext, btnBack, btnConfirm);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            _bookingService.BackButtonClick(tcCheckin, btnNext, btnBack, btnConfirm);
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show(
                "Are you sure all the details are correct?",
                "Cofirmation",
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Question
            );
            
            if(dr == DialogResult.Yes)
            {
                try
                {
                    _bookingService.ConfirmCheckin(selectedBooking, guestsOfBooking, services);
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

        private bool HasValidationError(TextBox textbox)
        {

            if (string.IsNullOrEmpty(textbox.Text.Trim()))
            {
                _errorProvider.SetError(textbox, "You can't leave empty spaces!");
                return true;
            }
            else { _errorProvider.SetError(textbox, ""); return false; }
        }

        private bool PersonalDataValidationConfirm()
        {
            bool isFirstNameValid = !HasValidationError(tbFirstName);
            bool isLastNameValid = !HasValidationError(tbLastName);
            bool isEmailValid = !HasValidationError(tbEmail);
            bool isPhoneValid = !HasValidationError(tbPhone);
            bool isZipValid = !HasValidationError(tbZipCode);
            bool isCityValid = !HasValidationError(tbCity);
            bool isDocValid = !HasValidationError(tbDocumentNumber);

            return isFirstNameValid && isLastNameValid && isEmailValid && isPhoneValid && isZipValid && isCityValid && isDocValid;
        }

        #endregion

        #region Foolproofing

        private void tbFirstName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void tbLastName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void tbPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void tbZipCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void tbCity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        #endregion
    }
}
