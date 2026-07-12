using Google.Protobuf.WellKnownTypes;
using Hotel_erp_Winforms_App.Models;
using Hotel_erp_Winforms_App.Services;
using Hotel_erp_Winforms_App.UI.Controls.RoomCardControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows.Forms;

namespace Hotel_erp_Winforms_App.UI.Forms.ServiceForms
{
    public partial class FrmCheckin : Form
    {
        private Booking _selectedBooking;
        private BookingService _bookingService;
        public List<Service> services = new List<Service>();
        public Service service;
        private ServiceBookings _serviceBookings;
        private bool _isRequestInitialized = false;
        RoomCardUserControl cardControl;
        ErrorProvider _errorProvider = new ErrorProvider();

        public FrmCheckin(Booking booking)
        {
            InitializeComponent();
            _selectedBooking = booking;
            _bookingService = new BookingService();
        }

        private void FrmCheckin_Load(object sender, EventArgs e)
        {
            tcCheckin.SelectedIndex = 0;
            btnBack.Visible = false;
            btnConfirm.Visible = false;

            // error handler icon
            using (var ms = new System.IO.MemoryStream(Properties.Resources.error))
            {
                _errorProvider.Icon = new System.Drawing.Icon(ms);
            }
            _errorProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink;
            // ------------------

            cbDocumentType.SelectedIndex = 0;

            // for Testing
            tbFirstName.Text = "asd";
            tbLastName.Text = "asd";
            tbEmail.Text = "asd";
            tbPhone.Text = "123";
            tbZipCode.Text = "123";
            tbCity.Text = "asd";
            tbStreet.Text = "asd";
            tbDocumentNumber.Text = "asd";
            // -----------

            // Choose Room
            List<Room> selectedRooms = _bookingService.SelectedRoomsByBooking(_selectedBooking);
            flpCardHolder.Controls.Clear();

            foreach (var room in selectedRooms)
            {
                cardControl = new RoomCardUserControl();
                cardControl.LoadCardData(room);

                cardControl.CardSelected += CardControl_CardSelected;
                flpCardHolder.Controls.Add(cardControl);
            }
            // -----------
        }

        // SZOBA BOOKINGHOZ RENDELÉS
        public void CardControl_CardSelected(object sender, EventArgs e)
        {
            RoomCardUserControl selectedCard = (RoomCardUserControl)sender;
            Room room = selectedCard.SelectedRoom;

            _selectedBooking.RoomNumber = room.Room_number;
            tcCheckin.SelectedIndex += 1;
        }

        #region Special Requests

        public void tcCheckin_SeledIndexChanged(object sender, EventArgs e)
        {
            if (tcCheckin.SelectedIndex == 2)
            {
                if (!_isRequestInitialized)
                {
                    string cateringLevel = _selectedBooking.SelectedCateringLevel.ToString();
                    cateringLevel = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(cateringLevel.ToLower());
                    cbCateringLevel.SelectedItem = cateringLevel;

                    cbExtraBed.SelectedIndex = 0;
                    cbDepartureNotes.SelectedIndex = 0;
                    cbPet.SelectedIndex = 1;

                    _isRequestInitialized = true;
                }
            }

            if (tcCheckin.SelectedIndex == 3)
            {
                MessageBox.Show($"{_selectedBooking.RoomNumber}: {services.Count}");
            }
        }

        private void CbPet_SelectedIndexChanged(object? sender, EventArgs e)
        {
            services.RemoveAll(s => s.NameHu == "Kisállat");

            if (cbPet.SelectedIndex == 0)
            {
                service = new Service(
                    0,
                    "Kisállat",
                    "Házi kedvencek elszállásolása felár ellenében.",
                    ServiceTypeHu.Logisztika,
                    5000,
                    "Pet",
                    "Accommodation for pets, surcharges apply.",
                    ServiceTypeEn.Logistics
                );
                services.Add(service);
            }
        }

        public void cbCateringLevel_SelectedIndexChanges(object sender, EventArgs e)
        {
            _selectedBooking.SelectedCateringLevel = (CateringLevel)System.Enum.Parse(typeof(CateringLevel), cbCateringLevel.SelectedItem.ToString().ToLower());
        }

        private void cbPet_SelectedIndexChanged(object sender, EventArgs e)
        {
            services.RemoveAll(s => s.NameHu == "Kisállat");

            if (cbPet.SelectedIndex == 0)
            {
                service = new Service(
                    0,
                    "Kisállat",
                    "Házi kedvencek elszállásolása felár ellenében.",
                    ServiceTypeHu.Logisztika,
                    5000,
                    "Pet",
                    "Accommodation for pets, surcharges apply.",
                    ServiceTypeEn.Logistics
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
            }
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

            if(cbDepartureNotes.SelectedIndex == 1)
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

            else if(cbDepartureNotes.SelectedIndex == 2)
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
