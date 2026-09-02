namespace Hotel_erp_Winforms_App.UI.Controls
{
    partial class BookingControl
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle11 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle9 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle10 = new DataGridViewCellStyle();
            pnlTop = new Panel();
            btnCancel = new Button();
            btnEdit = new Button();
            btnCheckout = new Button();
            btnCheckin = new Button();
            btnAddBooking = new Button();
            btnRefresh = new Button();
            lbUtility = new Label();
            btnSearch = new Button();
            cbSpanFilter = new ComboBox();
            lbSpanFilter = new Label();
            dtpTo = new DateTimePicker();
            lbDateTo = new Label();
            dtpFrom = new DateTimePicker();
            lbDateFrom = new Label();
            cbStatusFilter = new ComboBox();
            lbStatusFilter = new Label();
            cbFieldFilter = new ComboBox();
            lbFieldFilter = new Label();
            txtSearch = new TextBox();
            lbSearch = new Label();
            lbFilter = new Label();
            pnlKpiArrivals = new Panel();
            lbKpiArrivalsSub = new Label();
            lbKpiArrivalsValue = new Label();
            lbKpiArrivalsTitle = new Label();
            pnlKpiDepartures = new Panel();
            lbKpiDeparturesSub = new Label();
            lbKpiDeparturesValue = new Label();
            lbKpiDeparturesTitle = new Label();
            pnlKpiOccupancy = new Panel();
            lbKpiOccupancySub = new Label();
            lbKpiOccupancyValue = new Label();
            lbKpiOccupancyTitle = new Label();
            pnlKpiTotalBookings = new Panel();
            lbKpiTotalBookingsSub = new Label();
            lbKpiTotalBookingsValue = new Label();
            lbKpiTotalBookingsTitle = new Label();
            pnlGrid = new Panel();
            dgvBookings = new DataGridView();
            colBookingId = new DataGridViewTextBoxColumn();
            colRoomNumber = new DataGridViewTextBoxColumn();
            colRoomType = new DataGridViewTextBoxColumn();
            colBegOfStay = new DataGridViewTextBoxColumn();
            colEndOfStay = new DataGridViewTextBoxColumn();
            colCheckIn = new DataGridViewTextBoxColumn();
            colCheckOut = new DataGridViewTextBoxColumn();
            colCateringLevel = new DataGridViewTextBoxColumn();
            pnlEditor = new Panel();
            txtNotes = new TextBox();
            lbNotesTitle = new Label();
            pnlFinancial = new Panel();
            lbFinanceRemaining = new Label();
            lbFinanceRemainingTitle = new Label();
            lbFinancePaid = new Label();
            lbFinanceTotal = new Label();
            lbFinanceTitle = new Label();
            tbSource = new TextBox();
            lbSourceTitle = new Label();
            tbGuestEmail = new TextBox();
            lbGuestEmailTitle = new Label();
            tbGuestPhone = new TextBox();
            lbGuestPhoneTitle = new Label();
            tbGuestName = new TextBox();
            lbGuestNameTitle = new Label();
            lbEditorTitle = new Label();
            pnlTop.SuspendLayout();
            pnlKpiArrivals.SuspendLayout();
            pnlKpiDepartures.SuspendLayout();
            pnlKpiOccupancy.SuspendLayout();
            pnlKpiTotalBookings.SuspendLayout();
            pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBookings).BeginInit();
            pnlEditor.SuspendLayout();
            pnlFinancial.SuspendLayout();
            SuspendLayout();
            // 
            // pnlTop
            // 
            pnlTop.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlTop.BackColor = Color.FromArgb(245, 245, 248);
            pnlTop.BorderStyle = BorderStyle.FixedSingle;
            pnlTop.Controls.Add(btnCancel);
            pnlTop.Controls.Add(btnEdit);
            pnlTop.Controls.Add(btnCheckout);
            pnlTop.Controls.Add(btnCheckin);
            pnlTop.Controls.Add(btnAddBooking);
            pnlTop.Controls.Add(btnRefresh);
            pnlTop.Controls.Add(lbUtility);
            pnlTop.Controls.Add(btnSearch);
            pnlTop.Controls.Add(cbSpanFilter);
            pnlTop.Controls.Add(lbSpanFilter);
            pnlTop.Controls.Add(dtpTo);
            pnlTop.Controls.Add(lbDateTo);
            pnlTop.Controls.Add(dtpFrom);
            pnlTop.Controls.Add(lbDateFrom);
            pnlTop.Controls.Add(cbStatusFilter);
            pnlTop.Controls.Add(lbStatusFilter);
            pnlTop.Controls.Add(cbFieldFilter);
            pnlTop.Controls.Add(lbFieldFilter);
            pnlTop.Controls.Add(txtSearch);
            pnlTop.Controls.Add(lbSearch);
            pnlTop.Controls.Add(lbFilter);
            pnlTop.Location = new Point(10, 10);
            pnlTop.Name = "pnlTop";
            pnlTop.Size = new Size(1350, 85);
            pnlTop.TabIndex = 0;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCancel.BackColor = SystemColors.ButtonFace;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            btnCancel.ForeColor = Color.DarkRed;
            btnCancel.Location = new Point(1230, 44);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(105, 28);
            btnCancel.TabIndex = 10;
            btnCancel.Text = "Cancel Stay";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnEdit
            // 
            btnEdit.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnEdit.BackColor = SystemColors.ButtonFace;
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            btnEdit.Location = new Point(1115, 44);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(105, 28);
            btnEdit.TabIndex = 9;
            btnEdit.Text = "Edit Booking";
            btnEdit.UseVisualStyleBackColor = false;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnCheckout
            // 
            btnCheckout.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCheckout.BackColor = SystemColors.ButtonFace;
            btnCheckout.FlatStyle = FlatStyle.Flat;
            btnCheckout.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            btnCheckout.Location = new Point(1230, 12);
            btnCheckout.Name = "btnCheckout";
            btnCheckout.Size = new Size(105, 28);
            btnCheckout.TabIndex = 8;
            btnCheckout.Text = "Check-Out";
            btnCheckout.UseVisualStyleBackColor = false;
            btnCheckout.Click += btnCheckout_Click;
            // 
            // btnCheckin
            // 
            btnCheckin.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCheckin.BackColor = SystemColors.ButtonFace;
            btnCheckin.FlatStyle = FlatStyle.Flat;
            btnCheckin.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            btnCheckin.ForeColor = Color.DarkGreen;
            btnCheckin.Location = new Point(1115, 12);
            btnCheckin.Name = "btnCheckin";
            btnCheckin.Size = new Size(105, 28);
            btnCheckin.TabIndex = 7;
            btnCheckin.Text = "Check-In";
            btnCheckin.UseVisualStyleBackColor = false;
            btnCheckin.Click += btnCheckin_Click;
            // 
            // btnAddBooking
            // 
            btnAddBooking.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAddBooking.BackColor = SystemColors.ButtonFace;
            btnAddBooking.FlatStyle = FlatStyle.Flat;
            btnAddBooking.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            btnAddBooking.ForeColor = Color.FromArgb(24, 60, 142);
            btnAddBooking.Location = new Point(980, 12);
            btnAddBooking.Name = "btnAddBooking";
            btnAddBooking.Size = new Size(125, 28);
            btnAddBooking.TabIndex = 6;
            btnAddBooking.Text = "+ New Booking";
            btnAddBooking.UseVisualStyleBackColor = false;
            btnAddBooking.Click += btnAddBooking_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnRefresh.BackColor = SystemColors.ButtonFace;
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            btnRefresh.Location = new Point(980, 44);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(125, 28);
            btnRefresh.TabIndex = 11;
            btnRefresh.Text = "Reset / Reload";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // lbUtility
            // 
            lbUtility.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lbUtility.AutoSize = true;
            lbUtility.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lbUtility.ForeColor = Color.DimGray;
            lbUtility.Location = new Point(915, 17);
            lbUtility.Name = "lbUtility";
            lbUtility.Size = new Size(58, 15);
            lbUtility.TabIndex = 8;
            lbUtility.Text = "ACTIONS";
            // 
            // btnSearch
            // 
            btnSearch.BackColor = SystemColors.ButtonFace;
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnSearch.Location = new Point(695, 16);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(80, 56);
            btnSearch.TabIndex = 5;
            btnSearch.Text = "Filter";
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // cbSpanFilter
            // 
            cbSpanFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            cbSpanFilter.FormattingEnabled = true;
            cbSpanFilter.Items.AddRange(new object[] { "Booked From", "Booked To", "Stay Range" });
            cbSpanFilter.Location = new Point(540, 48);
            cbSpanFilter.Name = "cbSpanFilter";
            cbSpanFilter.Size = new Size(140, 25);
            cbSpanFilter.TabIndex = 4;
            // 
            // lbSpanFilter
            // 
            lbSpanFilter.AutoSize = true;
            lbSpanFilter.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            lbSpanFilter.Location = new Point(495, 53);
            lbSpanFilter.Name = "lbSpanFilter";
            lbSpanFilter.Size = new Size(38, 15);
            lbSpanFilter.TabIndex = 12;
            lbSpanFilter.Text = "Span:";
            // 
            // dtpTo
            // 
            dtpTo.Format = DateTimePickerFormat.Short;
            dtpTo.Location = new Point(365, 48);
            dtpTo.Name = "dtpTo";
            dtpTo.Size = new Size(115, 25);
            dtpTo.TabIndex = 3;
            // 
            // lbDateTo
            // 
            lbDateTo.AutoSize = true;
            lbDateTo.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            lbDateTo.Location = new Point(335, 53);
            lbDateTo.Name = "lbDateTo";
            lbDateTo.Size = new Size(24, 15);
            lbDateTo.TabIndex = 10;
            lbDateTo.Text = "To:";
            // 
            // dtpFrom
            // 
            dtpFrom.Format = DateTimePickerFormat.Short;
            dtpFrom.Location = new Point(205, 48);
            dtpFrom.Name = "dtpFrom";
            dtpFrom.Size = new Size(115, 25);
            dtpFrom.TabIndex = 2;
            // 
            // lbDateFrom
            // 
            lbDateFrom.AutoSize = true;
            lbDateFrom.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            lbDateFrom.Location = new Point(165, 53);
            lbDateFrom.Name = "lbDateFrom";
            lbDateFrom.Size = new Size(39, 15);
            lbDateFrom.TabIndex = 8;
            lbDateFrom.Text = "From:";
            // 
            // cbStatusFilter
            // 
            cbStatusFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            cbStatusFilter.FormattingEnabled = true;
            cbStatusFilter.Items.AddRange(new object[] { "All", "Upcoming", "Current", "Past" });
            cbStatusFilter.Location = new Point(540, 16);
            cbStatusFilter.Name = "cbStatusFilter";
            cbStatusFilter.Size = new Size(140, 25);
            cbStatusFilter.TabIndex = 1;
            // 
            // lbStatusFilter
            // 
            lbStatusFilter.AutoSize = true;
            lbStatusFilter.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            lbStatusFilter.Location = new Point(490, 21);
            lbStatusFilter.Name = "lbStatusFilter";
            lbStatusFilter.Size = new Size(45, 15);
            lbStatusFilter.TabIndex = 5;
            lbStatusFilter.Text = "Status:";
            // 
            // cbFieldFilter
            // 
            cbFieldFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            cbFieldFilter.FormattingEnabled = true;
            cbFieldFilter.Items.AddRange(new object[] { "Not Selected", "Name", "Booking ID", "Room Number", "Room Type", "Booked From", "Booked To", "Check-in", "Check-out", "Catering Level" });
            cbFieldFilter.Location = new Point(340, 16);
            cbFieldFilter.Name = "cbFieldFilter";
            cbFieldFilter.Size = new Size(140, 25);
            cbFieldFilter.TabIndex = 1;
            // 
            // lbFieldFilter
            // 
            lbFieldFilter.AutoSize = true;
            lbFieldFilter.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            lbFieldFilter.Location = new Point(295, 21);
            lbFieldFilter.Name = "lbFieldFilter";
            lbFieldFilter.Size = new Size(36, 15);
            lbFieldFilter.TabIndex = 3;
            lbFieldFilter.Text = "Field:";
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(65, 16);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Search text...";
            txtSearch.Size = new Size(215, 25);
            txtSearch.TabIndex = 0;
            // 
            // lbSearch
            // 
            lbSearch.AutoSize = true;
            lbSearch.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            lbSearch.Location = new Point(12, 21);
            lbSearch.Name = "lbSearch";
            lbSearch.Size = new Size(48, 15);
            lbSearch.TabIndex = 1;
            lbSearch.Text = "Search:";
            // 
            // lbFilter
            // 
            lbFilter.AutoSize = true;
            lbFilter.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            lbFilter.ForeColor = Color.DimGray;
            lbFilter.Location = new Point(12, 53);
            lbFilter.Name = "lbFilter";
            lbFilter.Size = new Size(122, 15);
            lbFilter.TabIndex = 0;
            lbFilter.Text = "PERIOD SELECTION:";
            // 
            // pnlKpiArrivals
            // 
            pnlKpiArrivals.BackColor = Color.White;
            pnlKpiArrivals.BorderStyle = BorderStyle.FixedSingle;
            pnlKpiArrivals.Controls.Add(lbKpiArrivalsSub);
            pnlKpiArrivals.Controls.Add(lbKpiArrivalsValue);
            pnlKpiArrivals.Controls.Add(lbKpiArrivalsTitle);
            pnlKpiArrivals.Location = new Point(10, 105);
            pnlKpiArrivals.Name = "pnlKpiArrivals";
            pnlKpiArrivals.Size = new Size(325, 85);
            pnlKpiArrivals.TabIndex = 1;
            // 
            // lbKpiArrivalsSub
            // 
            lbKpiArrivalsSub.AutoSize = true;
            lbKpiArrivalsSub.Font = new Font("Segoe UI", 8.5F);
            lbKpiArrivalsSub.ForeColor = Color.Gray;
            lbKpiArrivalsSub.Location = new Point(12, 60);
            lbKpiArrivalsSub.Name = "lbKpiArrivalsSub";
            lbKpiArrivalsSub.Size = new Size(127, 15);
            lbKpiArrivalsSub.TabIndex = 2;
            lbKpiArrivalsSub.Text = "Expected guest check-ins";
            // 
            // lbKpiArrivalsValue
            // 
            lbKpiArrivalsValue.AutoSize = true;
            lbKpiArrivalsValue.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lbKpiArrivalsValue.ForeColor = Color.FromArgb(24, 60, 142);
            lbKpiArrivalsValue.Location = new Point(10, 27);
            lbKpiArrivalsValue.Name = "lbKpiArrivalsValue";
            lbKpiArrivalsValue.Size = new Size(28, 32);
            lbKpiArrivalsValue.TabIndex = 1;
            lbKpiArrivalsValue.Text = "0";
            // 
            // lbKpiArrivalsTitle
            // 
            lbKpiArrivalsTitle.AutoSize = true;
            lbKpiArrivalsTitle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lbKpiArrivalsTitle.ForeColor = Color.DimGray;
            lbKpiArrivalsTitle.Location = new Point(12, 10);
            lbKpiArrivalsTitle.Name = "lbKpiArrivalsTitle";
            lbKpiArrivalsTitle.Size = new Size(111, 15);
            lbKpiArrivalsTitle.TabIndex = 0;
            lbKpiArrivalsTitle.Text = "TODAY'S ARRIVALS";
            // 
            // pnlKpiDepartures
            // 
            pnlKpiDepartures.BackColor = Color.White;
            pnlKpiDepartures.BorderStyle = BorderStyle.FixedSingle;
            pnlKpiDepartures.Controls.Add(lbKpiDeparturesSub);
            pnlKpiDepartures.Controls.Add(lbKpiDeparturesValue);
            pnlKpiDepartures.Controls.Add(lbKpiDeparturesTitle);
            pnlKpiDepartures.Location = new Point(350, 105);
            pnlKpiDepartures.Name = "pnlKpiDepartures";
            pnlKpiDepartures.Size = new Size(325, 85);
            pnlKpiDepartures.TabIndex = 2;
            // 
            // lbKpiDeparturesSub
            // 
            lbKpiDeparturesSub.AutoSize = true;
            lbKpiDeparturesSub.Font = new Font("Segoe UI", 8.5F);
            lbKpiDeparturesSub.ForeColor = Color.Gray;
            lbKpiDeparturesSub.Location = new Point(12, 60);
            lbKpiDeparturesSub.Name = "lbKpiDeparturesSub";
            lbKpiDeparturesSub.Size = new Size(127, 15);
            lbKpiDeparturesSub.TabIndex = 2;
            lbKpiDeparturesSub.Text = "Scheduled check-outs";
            // 
            // lbKpiDeparturesValue
            // 
            lbKpiDeparturesValue.AutoSize = true;
            lbKpiDeparturesValue.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lbKpiDeparturesValue.ForeColor = Color.DarkOrange;
            lbKpiDeparturesValue.Location = new Point(10, 27);
            lbKpiDeparturesValue.Name = "lbKpiDeparturesValue";
            lbKpiDeparturesValue.Size = new Size(28, 32);
            lbKpiDeparturesValue.TabIndex = 1;
            lbKpiDeparturesValue.Text = "0";
            // 
            // lbKpiDeparturesTitle
            // 
            lbKpiDeparturesTitle.AutoSize = true;
            lbKpiDeparturesTitle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lbKpiDeparturesTitle.ForeColor = Color.DimGray;
            lbKpiDeparturesTitle.Location = new Point(12, 10);
            lbKpiDeparturesTitle.Name = "lbKpiDeparturesTitle";
            lbKpiDeparturesTitle.Size = new Size(129, 15);
            lbKpiDeparturesTitle.TabIndex = 0;
            lbKpiDeparturesTitle.Text = "TODAY'S DEPARTURES";
            // 
            // pnlKpiOccupancy
            // 
            pnlKpiOccupancy.BackColor = Color.White;
            pnlKpiOccupancy.BorderStyle = BorderStyle.FixedSingle;
            pnlKpiOccupancy.Controls.Add(lbKpiOccupancySub);
            pnlKpiOccupancy.Controls.Add(lbKpiOccupancyValue);
            pnlKpiOccupancy.Controls.Add(lbKpiOccupancyTitle);
            pnlKpiOccupancy.Location = new Point(690, 105);
            pnlKpiOccupancy.Name = "pnlKpiOccupancy";
            pnlKpiOccupancy.Size = new Size(325, 85);
            pnlKpiOccupancy.TabIndex = 3;
            // 
            // lbKpiOccupancySub
            // 
            lbKpiOccupancySub.AutoSize = true;
            lbKpiOccupancySub.Font = new Font("Segoe UI", 8.5F);
            lbKpiOccupancySub.ForeColor = Color.Gray;
            lbKpiOccupancySub.Location = new Point(12, 60);
            lbKpiOccupancySub.Name = "lbKpiOccupancySub";
            lbKpiOccupancySub.Size = new Size(111, 15);
            lbKpiOccupancySub.TabIndex = 2;
            lbKpiOccupancySub.Text = "Current room ratio";
            // 
            // lbKpiOccupancyValue
            // 
            lbKpiOccupancyValue.AutoSize = true;
            lbKpiOccupancyValue.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lbKpiOccupancyValue.ForeColor = Color.DarkGreen;
            lbKpiOccupancyValue.Location = new Point(10, 27);
            lbKpiOccupancyValue.Name = "lbKpiOccupancyValue";
            lbKpiOccupancyValue.Size = new Size(57, 32);
            lbKpiOccupancyValue.TabIndex = 1;
            lbKpiOccupancyValue.Text = "0 %";
            // 
            // lbKpiOccupancyTitle
            // 
            lbKpiOccupancyTitle.AutoSize = true;
            lbKpiOccupancyTitle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lbKpiOccupancyTitle.ForeColor = Color.DimGray;
            lbKpiOccupancyTitle.Location = new Point(12, 10);
            lbKpiOccupancyTitle.Name = "lbKpiOccupancyTitle";
            lbKpiOccupancyTitle.Size = new Size(106, 15);
            lbKpiOccupancyTitle.TabIndex = 0;
            lbKpiOccupancyTitle.Text = "OCCUPANCY RATE";
            // 
            // pnlKpiTotalBookings
            // 
            pnlKpiTotalBookings.BackColor = Color.White;
            pnlKpiTotalBookings.BorderStyle = BorderStyle.FixedSingle;
            pnlKpiTotalBookings.Controls.Add(lbKpiTotalBookingsSub);
            pnlKpiTotalBookings.Controls.Add(lbKpiTotalBookingsValue);
            pnlKpiTotalBookings.Controls.Add(lbKpiTotalBookingsTitle);
            pnlKpiTotalBookings.Location = new Point(1035, 105);
            pnlKpiTotalBookings.Name = "pnlKpiTotalBookings";
            pnlKpiTotalBookings.Size = new Size(325, 85);
            pnlKpiTotalBookings.TabIndex = 4;
            // 
            // lbKpiTotalBookingsSub
            // 
            lbKpiTotalBookingsSub.AutoSize = true;
            lbKpiTotalBookingsSub.Font = new Font("Segoe UI", 8.5F);
            lbKpiTotalBookingsSub.ForeColor = Color.Gray;
            lbKpiTotalBookingsSub.Location = new Point(12, 60);
            lbKpiTotalBookingsSub.Name = "lbKpiTotalBookingsSub";
            lbKpiTotalBookingsSub.Size = new Size(125, 15);
            lbKpiTotalBookingsSub.TabIndex = 2;
            lbKpiTotalBookingsSub.Text = "Active records loaded";
            // 
            // lbKpiTotalBookingsValue
            // 
            lbKpiTotalBookingsValue.AutoSize = true;
            lbKpiTotalBookingsValue.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lbKpiTotalBookingsValue.ForeColor = Color.FromArgb(124, 58, 237);
            lbKpiTotalBookingsValue.Location = new Point(10, 27);
            lbKpiTotalBookingsValue.Name = "lbKpiTotalBookingsValue";
            lbKpiTotalBookingsValue.Size = new Size(28, 32);
            lbKpiTotalBookingsValue.TabIndex = 1;
            lbKpiTotalBookingsValue.Text = "0";
            // 
            // lbKpiTotalBookingsTitle
            // 
            lbKpiTotalBookingsTitle.AutoSize = true;
            lbKpiTotalBookingsTitle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lbKpiTotalBookingsTitle.ForeColor = Color.DimGray;
            lbKpiTotalBookingsTitle.Location = new Point(12, 10);
            lbKpiTotalBookingsTitle.Name = "lbKpiTotalBookingsTitle";
            lbKpiTotalBookingsTitle.Size = new Size(109, 15);
            lbKpiTotalBookingsTitle.TabIndex = 0;
            lbKpiTotalBookingsTitle.Text = "TOTAL BOOKINGS";
            // 
            // pnlGrid
            // 
            pnlGrid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlGrid.BackColor = Color.White;
            pnlGrid.Controls.Add(dgvBookings);
            pnlGrid.Location = new Point(10, 200);
            pnlGrid.Name = "pnlGrid";
            pnlGrid.Size = new Size(1350, 420);
            pnlGrid.TabIndex = 5;
            // 
            // dgvBookings
            // 
            dgvBookings.AllowUserToAddRows = false;
            dgvBookings.AllowUserToDeleteRows = false;
            dgvBookings.AllowUserToOrderColumns = true;
            dgvBookings.AllowUserToResizeColumns = false;
            dgvBookings.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(245, 248, 253);
            dgvBookings.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvBookings.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvBookings.BackgroundColor = Color.White;
            dgvBookings.BorderStyle = BorderStyle.None;
            dgvBookings.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(30, 58, 138);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvBookings.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvBookings.ColumnHeadersHeight = 40;
            dgvBookings.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvBookings.Columns.AddRange(new DataGridViewColumn[] { colBookingId, colRoomNumber, colRoomType, colBegOfStay, colEndOfStay, colCheckIn, colCheckOut, colCateringLevel });
            dataGridViewCellStyle11.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle11.BackColor = SystemColors.Window;
            dataGridViewCellStyle11.Font = new Font("Segoe UI", 9.75F);
            dataGridViewCellStyle11.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle11.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = DataGridViewTriState.False;
            dgvBookings.DefaultCellStyle = dataGridViewCellStyle11;
            dgvBookings.Dock = DockStyle.Fill;
            dgvBookings.EnableHeadersVisualStyles = false;
            dgvBookings.GridColor = SystemColors.ControlLight;
            dgvBookings.Location = new Point(0, 0);
            dgvBookings.MultiSelect = false;
            dgvBookings.Name = "dgvBookings";
            dgvBookings.ReadOnly = true;
            dgvBookings.RowHeadersVisible = false;
            dgvBookings.RowTemplate.Height = 35;
            dgvBookings.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBookings.Size = new Size(1350, 420);
            dgvBookings.TabIndex = 0;
            dgvBookings.CellClick += dgvBookings_CellClick;
            // 
            // colBookingId
            // 
            colBookingId.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colBookingId.DataPropertyName = "Id";
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colBookingId.DefaultCellStyle = dataGridViewCellStyle3;
            colBookingId.FillWeight = 110F;
            colBookingId.HeaderText = "Booking ID";
            colBookingId.Name = "colBookingId";
            colBookingId.ReadOnly = true;
            // 
            // colRoomNumber
            // 
            colRoomNumber.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colRoomNumber.DataPropertyName = "RoomNumber";
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colRoomNumber.DefaultCellStyle = dataGridViewCellStyle4;
            colRoomNumber.FillWeight = 85F;
            colRoomNumber.HeaderText = "Room #";
            colRoomNumber.Name = "colRoomNumber";
            colRoomNumber.ReadOnly = true;
            // 
            // colRoomType
            // 
            colRoomType.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colRoomType.DataPropertyName = "SelectedRoomType";
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colRoomType.DefaultCellStyle = dataGridViewCellStyle5;
            colRoomType.FillWeight = 85F;
            colRoomType.HeaderText = "Room Type";
            colRoomType.Name = "colRoomType";
            colRoomType.ReadOnly = true;
            // 
            // colBegOfStay
            // 
            colBegOfStay.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colBegOfStay.DataPropertyName = "BeginningOfStay";
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.Format = "yyyy.MM.dd";
            colBegOfStay.DefaultCellStyle = dataGridViewCellStyle6;
            colBegOfStay.FillWeight = 100F;
            colBegOfStay.HeaderText = "Booked From";
            colBegOfStay.Name = "colBegOfStay";
            colBegOfStay.ReadOnly = true;
            // 
            // colEndOfStay
            // 
            colEndOfStay.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colEndOfStay.DataPropertyName = "EndOfStay";
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.Format = "yyyy.MM.dd";
            colEndOfStay.DefaultCellStyle = dataGridViewCellStyle7;
            colEndOfStay.FillWeight = 100F;
            colEndOfStay.HeaderText = "Booked To";
            colEndOfStay.Name = "colEndOfStay";
            colEndOfStay.ReadOnly = true;
            // 
            // colCheckIn
            // 
            colCheckIn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colCheckIn.DataPropertyName = "CheckinDisplay";
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colCheckIn.DefaultCellStyle = dataGridViewCellStyle8;
            colCheckIn.FillWeight = 110F;
            colCheckIn.HeaderText = "Actual Check-In";
            colCheckIn.Name = "colCheckIn";
            colCheckIn.ReadOnly = true;
            // 
            // colCheckOut
            // 
            colCheckOut.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colCheckOut.DataPropertyName = "CheckoutDisplay";
            dataGridViewCellStyle9.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colCheckOut.DefaultCellStyle = dataGridViewCellStyle9;
            colCheckOut.FillWeight = 110F;
            colCheckOut.HeaderText = "Actual Check-Out";
            colCheckOut.Name = "colCheckOut";
            colCheckOut.ReadOnly = true;
            // 
            // colCateringLevel
            // 
            colCateringLevel.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colCateringLevel.DataPropertyName = "SelectedCateringLevel";
            dataGridViewCellStyle10.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colCateringLevel.DefaultCellStyle = dataGridViewCellStyle10;
            colCateringLevel.FillWeight = 90F;
            colCateringLevel.HeaderText = "Catering";
            colCateringLevel.Name = "colCateringLevel";
            colCateringLevel.ReadOnly = true;
            // 
            // pnlEditor
            // 
            pnlEditor.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            pnlEditor.BorderStyle = BorderStyle.FixedSingle;
            pnlEditor.Controls.Add(txtNotes);
            pnlEditor.Controls.Add(lbNotesTitle);
            pnlEditor.Controls.Add(pnlFinancial);
            pnlEditor.Controls.Add(tbSource);
            pnlEditor.Controls.Add(lbSourceTitle);
            pnlEditor.Controls.Add(tbGuestEmail);
            pnlEditor.Controls.Add(lbGuestEmailTitle);
            pnlEditor.Controls.Add(tbGuestPhone);
            pnlEditor.Controls.Add(lbGuestPhoneTitle);
            pnlEditor.Controls.Add(tbGuestName);
            pnlEditor.Controls.Add(lbGuestNameTitle);
            pnlEditor.Controls.Add(lbEditorTitle);
            pnlEditor.Location = new Point(1370, 10);
            pnlEditor.Name = "pnlEditor";
            pnlEditor.Size = new Size(355, 610);
            pnlEditor.TabIndex = 6;
            // 
            // txtNotes
            // 
            txtNotes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtNotes.Location = new Point(15, 450);
            txtNotes.Multiline = true;
            txtNotes.Name = "txtNotes";
            txtNotes.ReadOnly = true;
            txtNotes.ScrollBars = ScrollBars.Vertical;
            txtNotes.Size = new Size(320, 145);
            txtNotes.TabIndex = 6;
            // 
            // lbNotesTitle
            // 
            lbNotesTitle.AutoSize = true;
            lbNotesTitle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lbNotesTitle.Location = new Point(15, 430);
            lbNotesTitle.Name = "lbNotesTitle";
            lbNotesTitle.Size = new Size(164, 17);
            lbNotesTitle.TabIndex = 10;
            lbNotesTitle.Text = "Special Requests & Notes:";
            // 
            // pnlFinancial
            // 
            pnlFinancial.BackColor = Color.FromArgb(248, 250, 253);
            pnlFinancial.BorderStyle = BorderStyle.FixedSingle;
            pnlFinancial.Controls.Add(lbFinanceRemaining);
            pnlFinancial.Controls.Add(lbFinanceRemainingTitle);
            pnlFinancial.Controls.Add(lbFinancePaid);
            pnlFinancial.Controls.Add(lbFinanceTotal);
            pnlFinancial.Controls.Add(lbFinanceTitle);
            pnlFinancial.Location = new Point(15, 275);
            pnlFinancial.Name = "pnlFinancial";
            pnlFinancial.Size = new Size(320, 140);
            pnlFinancial.TabIndex = 8;
            // 
            // lbFinanceRemaining
            // 
            lbFinanceRemaining.AutoSize = true;
            lbFinanceRemaining.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lbFinanceRemaining.ForeColor = Color.Firebrick;
            lbFinanceRemaining.Location = new Point(12, 95);
            lbFinanceRemaining.Name = "lbFinanceRemaining";
            lbFinanceRemaining.Size = new Size(50, 25);
            lbFinanceRemaining.TabIndex = 4;
            lbFinanceRemaining.Text = "0 Ft";
            // 
            // lbFinanceRemainingTitle
            // 
            lbFinanceRemainingTitle.AutoSize = true;
            lbFinanceRemainingTitle.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            lbFinanceRemainingTitle.ForeColor = Color.Gray;
            lbFinanceRemainingTitle.Location = new Point(12, 75);
            lbFinanceRemainingTitle.Name = "lbFinanceRemainingTitle";
            lbFinanceRemainingTitle.Size = new Size(116, 15);
            lbFinanceRemainingTitle.TabIndex = 3;
            lbFinanceRemainingTitle.Text = "Remaining Balance:";
            // 
            // lbFinancePaid
            // 
            lbFinancePaid.AutoSize = true;
            lbFinancePaid.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lbFinancePaid.ForeColor = Color.DarkGreen;
            lbFinancePaid.Location = new Point(160, 40);
            lbFinancePaid.Name = "lbFinancePaid";
            lbFinancePaid.Size = new Size(69, 17);
            lbFinancePaid.TabIndex = 2;
            lbFinancePaid.Text = "Paid: 0 Ft";
            // 
            // lbFinanceTotal
            // 
            lbFinanceTotal.AutoSize = true;
            lbFinanceTotal.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lbFinanceTotal.ForeColor = Color.DimGray;
            lbFinanceTotal.Location = new Point(12, 40);
            lbFinanceTotal.Name = "lbFinanceTotal";
            lbFinanceTotal.Size = new Size(73, 17);
            lbFinanceTotal.TabIndex = 1;
            lbFinanceTotal.Text = "Total: 0 Ft";
            // 
            // lbFinanceTitle
            // 
            lbFinanceTitle.AutoSize = true;
            lbFinanceTitle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lbFinanceTitle.ForeColor = Color.FromArgb(24, 60, 142);
            lbFinanceTitle.Location = new Point(10, 10);
            lbFinanceTitle.Name = "lbFinanceTitle";
            lbFinanceTitle.Size = new Size(145, 17);
            lbFinanceTitle.TabIndex = 0;
            lbFinanceTitle.Text = "FINANCIAL SUMMARY";
            // 
            // tbSource
            // 
            tbSource.Location = new Point(15, 230);
            tbSource.Name = "tbSource";
            tbSource.ReadOnly = true;
            tbSource.Size = new Size(320, 25);
            tbSource.TabIndex = 3;
            // 
            // lbSourceTitle
            // 
            lbSourceTitle.AutoSize = true;
            lbSourceTitle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lbSourceTitle.Location = new Point(15, 210);
            lbSourceTitle.Name = "lbSourceTitle";
            lbSourceTitle.Size = new Size(130, 17);
            lbSourceTitle.TabIndex = 6;
            lbSourceTitle.Text = "Reservation Source:";
            // 
            // tbGuestEmail
            // 
            tbGuestEmail.Location = new Point(15, 175);
            tbGuestEmail.Name = "tbGuestEmail";
            tbGuestEmail.ReadOnly = true;
            tbGuestEmail.Size = new Size(320, 25);
            tbGuestEmail.TabIndex = 2;
            // 
            // lbGuestEmailTitle
            // 
            lbGuestEmailTitle.AutoSize = true;
            lbGuestEmailTitle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lbGuestEmailTitle.Location = new Point(15, 155);
            lbGuestEmailTitle.Name = "lbGuestEmailTitle";
            lbGuestEmailTitle.Size = new Size(99, 17);
            lbGuestEmailTitle.TabIndex = 4;
            lbGuestEmailTitle.Text = "Email Address:";
            // 
            // tbGuestPhone
            // 
            tbGuestPhone.Location = new Point(15, 120);
            tbGuestPhone.Name = "tbGuestPhone";
            tbGuestPhone.ReadOnly = true;
            tbGuestPhone.Size = new Size(320, 25);
            tbGuestPhone.TabIndex = 1;
            // 
            // lbGuestPhoneTitle
            // 
            lbGuestPhoneTitle.AutoSize = true;
            lbGuestPhoneTitle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lbGuestPhoneTitle.Location = new Point(15, 100);
            lbGuestPhoneTitle.Name = "lbGuestPhoneTitle";
            lbGuestPhoneTitle.Size = new Size(105, 17);
            lbGuestPhoneTitle.TabIndex = 2;
            lbGuestPhoneTitle.Text = "Phone Number:";
            // 
            // tbGuestName
            // 
            tbGuestName.Location = new Point(15, 65);
            tbGuestName.Name = "tbGuestName";
            tbGuestName.ReadOnly = true;
            tbGuestName.Size = new Size(320, 25);
            tbGuestName.TabIndex = 0;
            // 
            // lbGuestNameTitle
            // 
            lbGuestNameTitle.AutoSize = true;
            lbGuestNameTitle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lbGuestNameTitle.Location = new Point(15, 45);
            lbGuestNameTitle.Name = "lbGuestNameTitle";
            lbGuestNameTitle.Size = new Size(88, 17);
            lbGuestNameTitle.TabIndex = 1;
            lbGuestNameTitle.Text = "Guest Name:";
            // 
            // lbEditorTitle
            // 
            lbEditorTitle.AutoSize = true;
            lbEditorTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lbEditorTitle.ForeColor = Color.FromArgb(24, 60, 142);
            lbEditorTitle.Location = new Point(15, 12);
            lbEditorTitle.Name = "lbEditorTitle";
            lbEditorTitle.Size = new Size(187, 20);
            lbEditorTitle.TabIndex = 0;
            lbEditorTitle.Text = "SELECTED GUEST & STAY";
            // 
            // BookingControl
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 249, 250);
            Controls.Add(pnlEditor);
            Controls.Add(pnlGrid);
            Controls.Add(pnlKpiTotalBookings);
            Controls.Add(pnlKpiOccupancy);
            Controls.Add(pnlKpiDepartures);
            Controls.Add(pnlKpiArrivals);
            Controls.Add(pnlTop);
            Font = new Font("Segoe UI", 9.75F);
            Name = "BookingControl";
            Size = new Size(1740, 639);
            Load += BookingControl_Load;
            pnlTop.ResumeLayout(false);
            pnlTop.PerformLayout();
            pnlKpiArrivals.ResumeLayout(false);
            pnlKpiArrivals.PerformLayout();
            pnlKpiDepartures.ResumeLayout(false);
            pnlKpiDepartures.PerformLayout();
            pnlKpiOccupancy.ResumeLayout(false);
            pnlKpiOccupancy.PerformLayout();
            pnlKpiTotalBookings.ResumeLayout(false);
            pnlKpiTotalBookings.PerformLayout();
            pnlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvBookings).EndInit();
            pnlEditor.ResumeLayout(false);
            pnlEditor.PerformLayout();
            pnlFinancial.ResumeLayout(false);
            pnlFinancial.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlTop;
        private Label lbFilter;
        private Label lbSearch;
        private TextBox txtSearch;
        private Label lbFieldFilter;
        private ComboBox cbFieldFilter;
        private Label lbStatusFilter;
        private ComboBox cbStatusFilter;
        private Label lbDateFrom;
        private DateTimePicker dtpFrom;
        private Label lbDateTo;
        private DateTimePicker dtpTo;
        private Label lbSpanFilter;
        private ComboBox cbSpanFilter;
        private Button btnSearch;
        private Label lbUtility;
        private Button btnRefresh;
        private Button btnAddBooking;
        private Button btnCheckin;
        private Button btnCheckout;
        private Button btnEdit;
        private Button btnCancel;

        private Panel pnlKpiArrivals;
        private Label lbKpiArrivalsTitle;
        private Label lbKpiArrivalsValue;
        private Label lbKpiArrivalsSub;

        private Panel pnlKpiDepartures;
        private Label lbKpiDeparturesTitle;
        private Label lbKpiDeparturesValue;
        private Label lbKpiDeparturesSub;

        private Panel pnlKpiOccupancy;
        private Label lbKpiOccupancyTitle;
        private Label lbKpiOccupancyValue;
        private Label lbKpiOccupancySub;

        private Panel pnlKpiTotalBookings;
        private Label lbKpiTotalBookingsTitle;
        private Label lbKpiTotalBookingsValue;
        private Label lbKpiTotalBookingsSub;

        private Panel pnlGrid;
        private DataGridView dgvBookings;
        private DataGridViewTextBoxColumn colBookingId;
        private DataGridViewTextBoxColumn colRoomNumber;
        private DataGridViewTextBoxColumn colRoomType;
        private DataGridViewTextBoxColumn colBegOfStay;
        private DataGridViewTextBoxColumn colEndOfStay;
        private DataGridViewTextBoxColumn colCheckIn;
        private DataGridViewTextBoxColumn colCheckOut;
        private DataGridViewTextBoxColumn colCateringLevel;

        private Panel pnlEditor;
        private Label lbEditorTitle;
        private Label lbGuestNameTitle;
        private TextBox tbGuestName;
        private Label lbGuestPhoneTitle;
        private TextBox tbGuestPhone;
        private Label lbGuestEmailTitle;
        private TextBox tbGuestEmail;
        private Label lbSourceTitle;
        private TextBox tbSource;
        private Panel pnlFinancial;
        private Label lbFinanceTitle;
        private Label lbFinanceTotal;
        private Label lbFinancePaid;
        private Label lbFinanceRemainingTitle;
        private Label lbFinanceRemaining;
        private Label lbNotesTitle;
        private TextBox txtNotes;
    }
}