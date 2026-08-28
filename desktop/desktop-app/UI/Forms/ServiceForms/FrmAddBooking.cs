using Google.Protobuf.WellKnownTypes;
using Hotel_erp_Winforms_App.Helpers;
using Hotel_erp_Winforms_App.Models;
using Hotel_erp_Winforms_App.Services;
using Hotel_erp_Winforms_App.UI.Controls;
using Hotel_erp_Winforms_App.UI.Controls.RoomCardControl;
using K4os.Compression.LZ4.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Drawing.Text;
using System.Numerics;
using System.Reflection.Metadata;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Hotel_erp_Winforms_App.UI.Forms.ServiceForms
{
    public partial class FrmAddBooking : Form
    {
        //TODO:
        // hasvalidationerror-t kijavítani, personalDataValidationConfirmot is
        // special requests műveleteket egységesíteni az frmCheckin-ével (ln117)
        // ha már létezik az adatbázisban a vendég, akkor ki lehessen választani
        // Airport transfer oda, vissza vagy oda-vissza
        // a payment summnál a szoba ne egyesével jelenjen meg a táblázatban hanem csak egyszer, rosszul is van kiszámolva az ára
        // personal data-ban még mindig nem lehet kiválasztani nationalityt
        // document type-nak egyelőre semmi értelme
        // A birthdate - re legyen valami kiemelés
        // personal data edit még nincs kidolgozva
        // phone number format ellenőzés
        // email legyen textbox + @ + textbox
        // car plate number format ellenorzes
        // other fullel kezdeni valamit
        // pezsgő bekészítés service kezelése
        // departure notes service kezelése
        // egy vendéget ne lehesse többször menteni
        // a price_at_booking az egységár vagy összeg?

        // a selected Room a buttons->OnCardSelected-ben mentődik és a variables-ben van tárolva

        #region variables

        private BookingService bookingService = new BookingService();
        private RoomCardUserControl? selectedCard = null;
        private ErrorProvider _errorProvider = new ErrorProvider();
        private CommonHelper _commonHelper = new CommonHelper();

        public Room? selectedRoom { get; private set; } = null;

        private List<Guest> guests = new List<Guest>();
        private List<Service> services = new List<Service>();

        private FrmCheckin _frmCheckin = new FrmCheckin();

        private int nightsCount = 1;
        private int guestCount = 1;
        private CateringLevel selectedCatering = new CateringLevel();

        private StringBuilder subSelectedRoomString = new StringBuilder();

        #endregion

        public FrmAddBooking()
        {
            InitializeComponent();
        }

        private void FrmAddBooking_Load(object sender, EventArgs e)
        {
            #region UI defaults

            // FIRST PAGE
            btnConfirm.Visible = false;
            lbCurrentPage.Text = "1/5";
            tbDateOfArrival.Text = DateTime.Today.ToString("yyyy.MM.dd");
            dtpDeparture.Text = DateTime.Today.AddDays(1).ToString("yyyy.MM.dd");
            lbNumberOfNights.Text = "1";
            lbNumberOfGuests.Text = "1";
            lbSelectedSuite.Text = "-";
            lbSelectedRoomNumber.Text = "-";
            cbAdults.SelectedIndex = 0;
            cbChildren.SelectedIndex = 0;
            cbSuite.SelectedIndex = 0;
            cbGuests.SelectedIndex = 0;
            // ----------

            // THIRD PAGE
            cbCateringLevel.SelectedIndex = 0;
            cbAirportTransfer.SelectedIndex = 1;
            cbChampagne.SelectedIndex = 1;
            cbExtraBed.SelectedIndex = 0;
            cbDepartureNotes.SelectedIndex = 0;
            // ----------

            // FOR TESTING
            tbEmail.Text = "teszt.elek@example.com";
            tbDocumentNumber.Text = "123456AB";
            tbFirstName.Text = "Elek";
            tbLastName.Text = "Teszt";
            tbPhone.Text = "+36 70 388 9083";
            dtpBirthdate.Value = new DateTime(1995, 5, 15);
            cbNationality.Text = "Hungary";
            tbZipCode.Text = "1051";
            tbCity.Text = "Budapest";
            tbStreet.Text = "Fő utca 1.";
            tbCarPlateNumber.Text = "ABC-123";
            // ----------

            #endregion
        }

        //INFO
        // departure date picker
        // adults number picker
        // children number picker
        // suite type picker
        // special request selectors
        #region UI operators

        #region First page

        private void dtpDeparture_ValueChanged(object sender, EventArgs e)
        {
            RefreshCountOfNights();
        }

        private void cbAdults_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshCountOfGuests();
        }

        private void cbChildren_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshCountOfGuests();
        }

        private void cbSuite_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshRoomType();
        }

        #endregion

        #region Special Requests

        private void cbAirportTransfer_SelectedIndexChanged(object? sender, EventArgs e)
        {
            services.RemoveAll(s => s.NameHu == "Transzfer");

            if (cbAirportTransfer.SelectedIndex == 0)
            {
                bookingService.CreateNewService("Transzfer", services);
            }
        }

        public void cbCateringLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            services.RemoveAll(s => s.NameHu == "Félpanzió" || s.NameHu == "Teljes ellátás");

            if (cbCateringLevel.SelectedItem.ToString() == "Halfboard")
            {
                bookingService.CreateNewService("Halfboard", services);
                selectedCatering = (CateringLevel)System.Enum.Parse(typeof(CateringLevel), "halfboard", ignoreCase: true);
                lbSumCatering.Text = "Halfboard";
            }

            else if (cbCateringLevel.SelectedItem.ToString() == "Fullboard")
            {
                bookingService.CreateNewService("Fullboard", services);
                selectedCatering = (CateringLevel)System.Enum.Parse(typeof(CateringLevel), "fullboard", ignoreCase: true);
                lbSumCatering.Text = "Fullboard";
            }

            else
            {
                selectedCatering = (CateringLevel)System.Enum.Parse(typeof(CateringLevel), "breakfast", ignoreCase: true);
                lbSumCatering.Text = "Breakfast";
            }

        }

        private void cbChampagne_SelectedIndexChanged(object sender, EventArgs e)
        {
            services.RemoveAll(s => s.NameHu == "Pezsgő bekészítés");

            if (cbChampagne.SelectedIndex == 0)
            {
                bookingService.CreateNewService("Pezsgő bekészítés", services);
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

                bookingService.CreateNewService("Parkolás", services, nightsCount);
            }

            else { tbCarPlateNumber.ReadOnly = true; tbCarPlateNumber.Clear(); }
        }

        private void cbExtraBed_SelectedIndexChanged(object sender, EventArgs e)
        {
            services.RemoveAll(s => s.NameHu == "Pótágy" || s.NameHu == "Kiságy");

            if (cbExtraBed.SelectedIndex == 1)
            {
                bookingService.CreateNewService("Pótágy", services);
            }

            else if (cbExtraBed.SelectedIndex == 2)
            {
                bookingService.CreateNewService("Kiságy", services);
            }
        }

        private void cbDepartureNotes_SelectedIndexChanged(object sender, EventArgs e)
        {
            services.RemoveAll(s => s.NameHu == "Késői kijelentkezés" || s.NameHu == "Korai távozás");

            if (cbDepartureNotes.SelectedIndex == 1)
            {
                bookingService.CreateNewService("Késői kijelentkezés", services);
            }

            else if (cbDepartureNotes.SelectedIndex == 2)
            {
                bookingService.CreateNewService("Korai távozás", services);
            }
        }

        #endregion

        #endregion

        //INFO
        // next
        // back
        // showrooms
        // roomcard
        // save guest
        #region buttons

        private void btnNext_Click(object sender, EventArgs e)
        {
            switch (tcAddBooking.SelectedIndex)
            {
                case 0:
                    if (selectedRoom != null) bookingService.NextButtonClick(tcAddBooking, btnNext, btnBack, btnConfirm);
                    else
                    {
                        MessageBox.Show("You must select a room first!", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    break;
                case 1:

                    if (!PersonalDataValidationConfirm()) return;

                    if (int.TryParse(lbNumberOfGuests.Text, out int requiredGuests))
                    {
                        if (guests.Count() != requiredGuests)
                        {
                            MessageBox.Show($"The number of saved guests ({guests.Count()}) does not match the specified number ({requiredGuests})!",
                                "Missing Guests",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                            return;
                        }
                    }
                    bookingService.NextButtonClick(tcAddBooking, btnNext, btnBack, btnConfirm);
                    break;
                case 2:
                    bookingService.NextButtonClick(tcAddBooking, btnNext, btnBack, btnConfirm);
                    break;
                case 3:
                    bookingService.NextButtonClick(tcAddBooking, btnNext, btnBack, btnConfirm);
                    break;
                case 4:
                    bookingService.NextButtonClick(tcAddBooking, btnNext, btnBack, btnConfirm);
                    break;
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            bookingService.BackButtonClick(tcAddBooking, btnNext, btnBack, btnConfirm);
        }

        private async void btnShowRooms_Click(object sender, EventArgs e)
        {
            btnShowRooms.Enabled = false;
            this.UseWaitCursor = true;

            try
            {
                selectedCard = null;
                selectedRoom = null;
                lbSelectedRoomNumber.Text = "-";

                List<Room> rooms = await bookingService.FilterAvailableRoomsAsync(
                    Convert.ToDateTime(tbDateOfArrival.Text),
                    dtpDeparture.Value, Convert.ToInt32(lbNumberOfGuests.Text),
                    cbSuite.Text);

                bookingService.FillAvailableRooms(rooms, flpSelectRoom, OnCardSelected);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Database error: {ex.Message}");
            }
            finally
            {
                btnShowRooms.Enabled = true;
                this.UseWaitCursor = false;
            }
        }

        private void OnCardSelected(RoomCardUserControl clickedCard)
        {
            if (selectedCard != null)
            {
                selectedCard.SetSelected(false);
            }

            selectedCard = clickedCard;
            selectedCard.SetSelected(true);

            selectedRoom = clickedCard.SelectedRoom;
            lbSelectedRoomNumber.Text = selectedRoom.Room_number.ToString();

            bookingService.CreateNewService("Szoba", services, nightsCount, selectedRoom);
        }

        private void btnSaveGuest_Click(object sender, EventArgs e)
        {
            if (!PersonalDataValidationConfirm())
            {
                MessageBox.Show("You must save the Guests data first!", "Missing data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Guest guest = new Guest
            (
                0,
                tbEmail.Text,
                tbDocumentNumber.Text,
                tbFirstName.Text,
                tbLastName.Text,
                dtpBirthdate.Value,
                cbNationality.Text,
                tbZipCode.Text,
                tbCity.Text,
                tbStreet.Text,
                tbCarPlateNumber.Text,
                0,
                0
            );

            guests.Add(guest);

            MessageBox.Show("Guest data saved successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            if (cbGuests.SelectedIndex < Convert.ToInt32(lbNumberOfGuests.Text) - 1)
            {
                cbGuests.SelectedIndex++;
                ClearBoxes();
            }
        }

        private async void btnConfirm_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure all the details are correct?",
                "Confirmation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                try
                {
                    btnConfirm.Enabled = false;
                    Cursor.Current = Cursors.WaitCursor;

                    await bookingService.ConfirmNewBookingAsync(
                        selectedRoom,
                        guests,
                        services,
                        dtpDeparture.Value,
                        selectedCatering,
                        nightsCount
                    );

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }

                catch (Exception ex)
                {
                    MessageBox.Show(
                        "An unexpected error occured: " + ex.Message,
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }

                finally
                {
                    btnConfirm.Enabled = true;
                    Cursor.Current = Cursors.Default;
                }
            }
        }

        #endregion

        //INFO
        // load by page
        // count of nights
        // count of guests
        // bottom infos
        // selected guest -- guest list
        #region UI Refreshings, loadings by pages

        // oldalankénti load:
        private async void tcAddBooking_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<BillingItem> billingItems = await bookingService.MakeListOfBillsAsync(services, null, nightsCount, guestCount);

            bookingService.RefreshPageCount(tcAddBooking, lbCurrentPage);

            switch (tcAddBooking.SelectedIndex)
            {
                case 1:
                    cbGuests.SelectedIndex = 0;
                    break;

                case 3:
                    await bookingService.LoadBillItemsAsync(dgvPaymentSum, services, null, nightsCount, guestCount);

                    lbNetAmount.Text = bookingService.CalculateNetAmount(billingItems).ToString("C0");
                    lbTaxAmount.Text = bookingService.CalculateTaxAmount(billingItems).ToString("C0");
                    lbGrossAmount.Text = bookingService.CalculateGrossAmount(billingItems).ToString("C0");
                    break;

                case 4:
                    bookingService.FillSumSpecialRequests(services, lbSumExtras);

                    tcGuests.TabPages.Clear();

                    if (ckbParking.Checked && guests.Count > 0)
                    {
                        guests[0].CarPlateNumber = tbCarPlateNumber.Text.Trim();
                    }

                    foreach (var g in guests)
                    {
                        bookingService.AddGuestTabToSummary(g, guests, tcGuests);
                    }

                    lbSumRoomDetails.Text = bookingService.BuildSelectedRoomDetailsString(selectedRoom);
                    lbSumRemaining.Text = $"{bookingService.CalculateGrossAmount(billingItems) - Convert.ToInt32(lbSumPaid.Text):C0}";
                    lbSumTotal.Text = $"{bookingService.CalculateGrossAmount(billingItems):C0}";
                    lbSumPaid.Text = $"{Convert.ToInt32(lbSumPaid.Text)}";

                    break;
            }
        }
        // -----------------

        private void RefreshCountOfNights()
        {
            DateTime arrivalDate = Convert.ToDateTime(tbDateOfArrival.Text);
            nightsCount = Convert.ToInt32((dtpDeparture.Value - arrivalDate).TotalDays);

            lbNumberOfNights.Text = nightsCount.ToString();
        }

        private void RefreshCountOfGuests()
        {
            guestCount = Convert.ToInt32(cbAdults.SelectedItem) + Convert.ToInt32(cbChildren.SelectedItem);

            lbNumberOfGuests.Text = guestCount.ToString();
            RefreshGuestList(guestCount);
        }

        private void RefreshRoomType()
        {
            string roomType = cbSuite.Text;

            lbSelectedSuite.Text = roomType;
        }

        private void RefreshGuestList(int guestCount)
        {
            cbGuests.Items.Clear();

            for (int i = 0; i < guestCount; i++)
            {
                cbGuests.Items.Add($"Guest {i + 1}");
            }
        }

        private void cbGuests_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            SelectedGuestFromGuestList();
        }

        private void SelectedGuestFromGuestList()
        {
            int i = cbGuests.SelectedIndex;
            if (i >= 0 && i < guests.Count())
            {
                Guest selectedGuest = guests[i];

                tbEmail.Text = selectedGuest.Email;
                tbDocumentNumber.Text = selectedGuest.IdCardNumber;
                tbFirstName.Text = selectedGuest.FName;
                tbLastName.Text = selectedGuest.LName;
                dtpBirthdate.Value = Convert.ToDateTime(selectedGuest.DateOfBirth);
                cbNationality.Text = selectedGuest.Country;
                tbZipCode.Text = selectedGuest.ZipCode;
                tbCity.Text = selectedGuest.City;
                tbStreet.Text = selectedGuest.Street;
                tbCarPlateNumber.Text = selectedGuest.CarPlateNumber;
            }
            else ClearBoxes();
        }

        private void ClearBoxes()
        {
            tbEmail.Clear();
            tbDocumentNumber.Clear();
            tbFirstName.Clear();
            tbLastName.Clear();
            dtpBirthdate.Value = dtpBirthdate.MaxDate;
            cbNationality.SelectedItem = "Hungary";
            tbZipCode.Clear();
            tbCity.Clear();
            tbStreet.Clear();
            tbCarPlateNumber.Clear();
        }

        #endregion

        //INFO
        // keypress handlers
        // data validation
        #region Foolproofing

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

        private bool PersonalDataValidationConfirm()
        {
            bool isFirstNameValid = !_commonHelper.HasValidationError(tbFirstName, _errorProvider);
            bool isLastNameValid = !_commonHelper.HasValidationError(tbLastName, _errorProvider);
            bool isEmailValid = !_commonHelper.HasValidationError(tbEmail, _errorProvider);
            bool isPhoneValid = !_commonHelper.HasValidationError(tbPhone, _errorProvider);
            bool isZipValid = !_commonHelper.HasValidationError(tbZipCode, _errorProvider);
            bool isCityValid = !_commonHelper.HasValidationError(tbCity, _errorProvider);
            bool isDocValid = !_commonHelper.HasValidationError(tbDocumentNumber, _errorProvider);

            return isFirstNameValid && isLastNameValid && isEmailValid && isPhoneValid && isZipValid && isCityValid && isDocValid;
        }

        #endregion
    }
}