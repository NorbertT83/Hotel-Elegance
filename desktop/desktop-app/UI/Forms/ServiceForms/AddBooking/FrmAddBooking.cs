using Hotel_erp_Winforms_App.Helpers;
using Hotel_erp_Winforms_App.Models;
using Hotel_erp_Winforms_App.Services;
using Hotel_erp_Winforms_App.UI.Controls.RoomCardControl;
using System.Data;
using System.Text;

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

        private readonly BookingService bookingService = new BookingService();
        private readonly ErrorProvider _errorProvider = new ErrorProvider();
        private readonly CommonHelper _commonHelper = new CommonHelper();
        private RoomCardUserControl? selectedCard = null;

        public Room? selectedRoom { get; private set; } = null;

        private List<Guest> guests = new List<Guest>();
        private List<Service> services = new List<Service>();
        private readonly List<Service> allServices = new List<Service>();

        private FrmCheckin _frmCheckin = new FrmCheckin();

        private int nightsCount = 1;
        private int guestCount = 1;
        private bool isEdited = false;
        private CateringLevel selectedCatering = new CateringLevel();
        private enum ChildOrAdult
        {
            Child,
            Adult
        }

        private StringBuilder subSelectedRoomString = new StringBuilder();

        #endregion

        public FrmAddBooking()
        {
            InitializeComponent();
        }

        #region onLoad events
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

            // SECOND PAGE

            List<string> countries = new List<string>
            {
                "Albania", "Andorra", "Australia", "Austria", "Belgium",
                "Bosnia and Herzegovina", "Bulgaria", "Canada", "Croatia", "Czech Republic",
                "Denmark", "Estonia", "Finland", "France", "Germany",
                "Greece", "Hungary", "Iceland", "Ireland", "Italy",
                "Latvia", "Liechtenstein", "Lithuania", "Luxembourg", "Malta",
                "Moldova", "Monaco", "Montenegro", "Netherlands", "North Macedonia",
                "Norway", "Poland", "Portugal", "Romania", "Russia",
                "San Marino", "Serbia", "Slovakia", "Slovenia", "Spain",
                "Sweden", "Switzerland", "Turkey", "Ukraine", "United Kingdom",
                "United States", "Vatican City"
            };

            List<string> sortedCountries = countries.OrderBy(c => c).ToList();

            sortedCountries.Insert(0, "Magyarország");

            cbNationality.DataSource = sortedCountries;
            cbNationality.SelectedIndex = 0;

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
            dtpBirthdate.Value = new DateTime(1995, 5, 15);
            cbNationality.Text = "Hungary";
            tbZipCode.Text = "1051";
            tbCity.Text = "Budapest";
            tbStreet.Text = "Fő utca 1.";
            tbCarPlateNumber.Text = "ABC-123";
            // ----------

            // DGV PAYMENT SUM
            foreach (DataGridViewColumn col in dgvPaymentSum.Columns)
            {
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            dgvPaymentSum.ClearSelection();
            // ----------


            #endregion
        }
        #endregion

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
                tbCarPlateNumber.Enabled = false;
                parkingChecked = true;

                services.RemoveAll(s => s.NameHu == "Parkolás");

                bookingService.CreateNewService("Parkolás", services, nightsCount);
            }

            else { tbCarPlateNumber.Enabled = true; tbCarPlateNumber.Clear(); }
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
        // confirm
        // filldata
        // editguestdata
        #region buttons

        // 1.
        private async void btnNext_Click(object sender, EventArgs e)
        {
            switch (tcAddBooking.SelectedIndex)
            {
                case 0:
                    if (selectedRoom != null)
                    {
                        bookingService.NextButtonClick(tcAddBooking, btnNext, btnBack, btnConfirm);
                    }
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

                    if (isEdited)
                    {
                        MessageBox.Show("Please save the modified guest details before proceeding.",
                            "Unsaved Changes",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);

                        return;
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

        // 2.
        private void btnBack_Click(object sender, EventArgs e)
                {
                    bookingService.BackButtonClick(tcAddBooking, btnNext, btnBack, btnConfirm);
                }

        // 3.
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

        // 4.
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

        // 5.
        private void btnSaveGuest_Click(object sender, EventArgs e)
        {
            if (!PersonalDataValidationConfirm())
            {
                MessageBox.Show("You must save the Guests data first!", "Missing data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int i = cbGuests.SelectedIndex;

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

            if (isEdited && i >= 0 && i < guests.Count)
            {
                guests[i] = guest;
                MessageBox.Show("Guest data updated successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                guests.Add(guest);
                MessageBox.Show("Guest data saved successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (cbGuests.SelectedIndex < Convert.ToInt32(lbNumberOfGuests.Text) - 1)
                {
                    cbGuests.SelectedIndex++;
                    ClearBoxes();
                }
                else
                {
                    SetBoxesReadibility(true);
                }
            }

            isEdited = false;
            cbGuests.Enabled = true;
        }

        // 6.
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

        // 7.
        private void btnFillData_Click(object sender, EventArgs e)
                {
                    int i = cbGuests.SelectedIndex;

                    if (guests.Count > 0)
                    {
                        tbZipCode.Text = guests[0].ZipCode;
                        tbCity.Text = guests[0].City;
                        tbStreet.Text = guests[0].Street;
                        cbNationality.Text = guests[0].Country;
                    }
                }

        // 8.
        private void btnEditGuestData_Click(object sender, EventArgs e)
        {
            SetBoxesReadibility(false);

            isEdited = true;
            cbGuests.Enabled = false;
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

                    dgvPaymentSum.Columns["colTax"]?.DefaultCellStyle.Format = "P0";

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
            int adults = Convert.ToInt32(cbAdults.SelectedItem);
            int children = Convert.ToInt32(cbChildren.SelectedItem);

            lbNumberOfGuests.Text = (adults + children).ToString();
            RefreshGuestList(adults, children);
        }

        private void RefreshRoomType()
        {
            string roomType = cbSuite.Text;

            lbSelectedSuite.Text = roomType;
        }

        private void RefreshGuestList(int adultsCount, int childrenCount)
        {
            cbGuests.Items.Clear();

            for (int i = 0; i < adultsCount; i++)
            {
                cbGuests.Items.Add($"Adult {i + 1}");
            }

            for (int i = 0; i < childrenCount; i++)
            {
                cbGuests.Items.Add($"Child {i + 1}");
            }
        }

        private void cbGuests_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            SelectedGuestFromGuestList();
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
            bool isZipValid = !_commonHelper.HasValidationError(tbZipCode, _errorProvider);
            bool isCityValid = !_commonHelper.HasValidationError(tbCity, _errorProvider);
            bool isDocValid = !_commonHelper.HasValidationError(tbDocumentNumber, _errorProvider);

            return isFirstNameValid && isLastNameValid && isEmailValid && isZipValid && isCityValid && isDocValid;
        }

        #endregion

        #region helpers

        // 1.
        private void SelectedGuestFromGuestList()
        {
            int i = cbGuests.SelectedIndex;

            var childOrAdult = cbGuests.Text.StartsWith('A')
                ? ChildOrAdult.Adult
                : ChildOrAdult.Child;

            // mentett vendégre vissza
            if (i >= 0 && i < guests.Count())
            {
                btnFillData.Visible = false;
                SetBoxesReadibility(true);

                Guest selectedGuest = guests[i];

                bool isAdult = childOrAdult == ChildOrAdult.Adult;

                dtpBirthdate.MinDate = DateTimePicker.MinimumDateTime;
                dtpBirthdate.MaxDate = DateTimePicker.MaximumDateTime;

                dtpBirthdate.MinDate = isAdult
                    ? new DateTime(1900, 1, 1)
                    : DateTime.Today.AddYears(-14);

                dtpBirthdate.MaxDate = isAdult
                    ? DateTime.Today.AddYears(-18)
                    : DateTime.Today;

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

            // nem mentett vendég adatok
            else
            {
                ClearBoxes();
                SetBoxesReadibility(false);

                bool isAdult = childOrAdult == ChildOrAdult.Adult;

                // Birthdate picker -----
                DateTime minDate = isAdult
                    ? new DateTime(1900, 1, 1)
                    : DateTime.Today.AddYears(-14);

                DateTime maxDate = isAdult
                    ? DateTime.Today.AddYears(-18)
                    : DateTime.Today;

                var defaultDate = isAdult ? maxDate : minDate;

                dtpBirthdate.MinDate = DateTimePicker.MinimumDateTime;
                dtpBirthdate.MaxDate = DateTimePicker.MaximumDateTime;

                dtpBirthdate.MinDate = minDate;
                dtpBirthdate.MaxDate = maxDate;
                dtpBirthdate.Value = defaultDate;
                // -----------------------

                // Autofill --------------

                btnFillData.Visible = cbGuests.SelectedIndex > 0;

                if (guests.Count > 0)
                {
                    tbEmail.Text = guests[0].Email;
                    tbEmail.Enabled = false;
                }

                // -----------------------
            }
        }

        // 2.
        private void SetBoxesReadibility(bool isReadOnly)
        {
            if (isReadOnly)
            {
                tbFirstName.Enabled = false;
                tbLastName.Enabled = false;
                tbEmail.Enabled = false;
                dtpBirthdate.Enabled = false;
                tbDocumentNumber.Enabled = false;
                cbNationality.Enabled = false;
                tbZipCode.Enabled = false;
                tbCity.Enabled = false;
                tbStreet.Enabled = false;
            }

            else
            {

                tbFirstName.Enabled = true;
                tbLastName.Enabled = true;
                tbEmail.Enabled = true;
                dtpBirthdate.Enabled = true;
                tbDocumentNumber.Enabled = true;
                cbNationality.Enabled = true;
                tbZipCode.Enabled = true;
                tbCity.Enabled = true;
                tbStreet.Enabled = true;
            }
        }
        #endregion
    }
}