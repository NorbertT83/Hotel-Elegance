using Google.Protobuf.WellKnownTypes;
using Hotel_erp_Winforms_App.Models;
using Hotel_erp_Winforms_App.Services;
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
        public Service service;
        private bool _isRequestInitialized = false;
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

            #region Personal Data

            lbCurrentPage.Text = "1/5";

            FillNationalityCb();
            cbNationality.SelectedItem = "Hungary";

            Guest guest = _bookingService.FillPersonalData(selectedBooking);

            tbFirstName.Text = guest.FName;
            tbLastName.Text = guest.LName;
            tbEmail.Text = guest.Email;
            tbCarPlateNumber.Text = guest.CarPlateNumber;

            dtpBirthdate.MaxDate = DateTime.Today;
            dtpBirthdate.Value = guest.DateOfBirth ?? DateTime.Today;
            cbNationality.Text = guest.Country;
            tbZipCode.Text = guest.ZipCode;
            tbCity.Text = guest.City;
            tbStreet.Text = guest.Street;
            tbDocumentNumber.Text = guest.IdCardNumber;

            tbFirstName.ReadOnly = (tbFirstName.Text != "");
            tbLastName.ReadOnly = (tbLastName.Text != "");
            tbEmail.ReadOnly = (tbEmail.Text != "");
            tbCarPlateNumber.ReadOnly = (tbCarPlateNumber.Text != "");
            tbZipCode.ReadOnly = (tbZipCode.Text != "");
            tbCity.ReadOnly = tbCity.Text != "";
            tbStreet.ReadOnly = tbStreet.Text != "";
            tbDocumentNumber.ReadOnly = tbDocumentNumber.Text != "";

            cbDocumentType.SelectedIndex = 0;
            #endregion

            // FOR TESTING!!!
            tbPhone.Text = "111";
            tbDocumentNumber.Text = "asd";
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
            pnlChosenRoomCardHolder.Controls.Clear();
            pnlChosenRoomCardHolder.Controls.Add(cardControl);

            ckbBalcony.Visible = false;
            ckbView.Visible = false;
            ckbHotTub.Visible = false;

            RefreshRoomCards();
            #endregion

            #region Special Requests
            tbCarPlateNumber.ReadOnly = true;

            if(_bookingService.GetSpecialRequestsFromDb(selectedBooking, "Transzfer")) { cbAirportTransfer.SelectedIndex = 0; }
            if(_bookingService.GetSpecialRequestsFromDb(selectedBooking, "Pótágy")) { cbExtraBed.SelectedIndex = 1; }
            if(_bookingService.GetSpecialRequestsFromDb(selectedBooking, "Kiságy")) { cbExtraBed.SelectedIndex = 2; }
            if(_bookingService.GetSpecialRequestsFromDb(selectedBooking, "Parkolás")) 
                { ckbParking.Checked = true; tbCarPlateNumber.Text = _bookingService.GetCarPlateNumberByBooking(selectedBooking); }
            if (_bookingService.IsChampagneOrdered(selectedBooking)) { cbChampagne.SelectedIndex = 0; }

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

        // ------------------

        // Select Room UI műveletek
        public void CardControl_CardSelected(object sender, EventArgs e)
        {
            RoomCardUserControl selectedCard = (RoomCardUserControl)sender;
            Room room = selectedCard.SelectedRoom;

            selectedBooking.RoomNumber = room.Room_number;
            tcCheckin.SelectedIndex += 1;
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

        private void dgvPaymentSum_SelectionChanged(object sender, EventArgs e)
        {
            dgvPaymentSum.ClearSelection();
        }

        public void LoadBillItems()
        {
            billingItems = _bookingService.MakeListOfBills(services, selectedBooking);
            var bindingList = new BindingList<BillingItem>(billingItems);

            dgvPaymentSum.DataSource = bindingList;

            // DATAGRIDVIEW STYLE
            dgvPaymentSum.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvPaymentSum.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvPaymentSum.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvPaymentSum.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvPaymentSum.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvPaymentSum.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvPaymentSum.Columns[0].DefaultCellStyle.Format = "yyyy.MM.dd";

            dgvPaymentSum.Columns[2].DefaultCellStyle.Format = "C0";
            dgvPaymentSum.Columns[5].DefaultCellStyle.Format = "C0";

            dgvPaymentSum.Columns[4].DefaultCellStyle.Format = "P0";
            // -----------------
        }

        // Oldalankénti betöltés
        public void tcCheckin_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tcCheckin.SelectedIndex == 0) lbCurrentPage.Text = "1/5";
            if (tcCheckin.SelectedIndex == 1) lbCurrentPage.Text = "2/5";

            if (tcCheckin.SelectedIndex == 2)
            {
                lbCurrentPage.Text = "3/5";

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
                lbCurrentPage.Text = "4/5";

                LoadBillItems();

                lbNetAmount.Text = _bookingService.CalculateNetAmount(billingItems).ToString("C0");
                lbTaxAmount.Text = _bookingService.CalculateTaxAmount(billingItems).ToString("C0");
                lbGrossAmount.Text = _bookingService.CalculateGrossAmount(billingItems).ToString("C0");
            }

            if (tcCheckin.SelectedIndex == 4) lbCurrentPage.Text = "5/5";
        }
        // ---------------------

        #region Special Requests

        private void cbAirportTransfer_SelectedIndexChanged(object? sender, EventArgs e)
        {
            services.RemoveAll(s => s.NameHu == "Transzfer");

            if (cbAirportTransfer.SelectedIndex == 0)
            {
                service = new Service(
                    0,
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
                        0,
                        "Félpanzió",
                        "Félpanziós ellátás reggelivel és vacsorával",
                        ServiceTypeHu.Logisztika,
                        17000,
                        "Half board",
                        "Half-board service including breakfast and dinner.",
                        ServiceTypeEn.Logistics
                    );
                    services.Add(service);
                }

                else if (cbCateringLevel.SelectedItem.ToString() == "Fullboard")
                {
                    Service service = new Service(
                        0,
                        "Teljes ellátás",
                        "Teljes ellátás reggelivel, ebéddel és vacsorával.",
                        ServiceTypeHu.Logisztika,
                        28000,
                        "Full board",
                        "Full-board service including breakfast, lunch and dinner.",
                        ServiceTypeEn.Logistics
                    );
                    services.Add(service);
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
                    0,
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
                    0,
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

            else { tbCarPlateNumber.ReadOnly = true; }
        }

        private void tbCarPlateNumber_TextChanged(object sender, EventArgs e)
        {
            services.RemoveAll(s => s.NameHu == "Parkolás");

            if (parkingChecked)
            {
                service = new Service(
                    0,
                    "Parkolás",
                    "Zárt parkoló napi díj",
                    ServiceTypeHu.Logisztika,
                    3000,
                    "Parking",
                    "Gated parking daily fee",
                    ServiceTypeEn.Logistics
                );
                services.Add(service);
            }
        }

        private void cbExtraBed_SelectedIndexChanged(object sender, EventArgs e)
        {
            services.RemoveAll(s => s.NameHu == "Pótágy" || s.NameHu == "Kiságy");

            if (cbExtraBed.SelectedIndex == 1)
            {
                service = new Service(
                    0,
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
                    0,
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
                    0,
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
                    0,
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
            }

            if (tcCheckin.SelectedIndex < 4)
            {
                tcCheckin.SelectedIndex += 1;
            }

            btnBack.Visible = (tcCheckin.SelectedIndex > 0);
            btnNext.Visible = (tcCheckin.SelectedIndex < 4);
            btnConfirm.Visible = (tcCheckin.SelectedIndex == 4);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (tcCheckin.SelectedIndex > 0)
            {
                tcCheckin.SelectedIndex -= 1;
            }

            btnBack.Visible = (tcCheckin.SelectedIndex > 0);
            btnNext.Visible = (tcCheckin.SelectedIndex < 4);
            btnConfirm.Visible = (tcCheckin.SelectedIndex == 4);
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            Guest guest = new Guest
            (
                tbEmail.Text,
                tbDocumentNumber.Text,
                tbFirstName.Text,
                tbLastName.Text,
                dtpBirthdate.Value,
                cbNationality.SelectedIndex.ToString(),
                tbZipCode.Text,
                tbCity.Text,
                tbStreet.Text,
                tbCarPlateNumber.Text,
                0,
                0
            );

            _bookingService.SaveGuest(guest);
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
