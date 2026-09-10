namespace Hotel_erp_Winforms_App.UI.Controls.Dashboard
{
    partial class DashboardControl
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
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            pnlTop = new Panel();
            btnRefresh = new Button();
            btnQuickCheckin = new Button();
            btnQuickNewBooking = new Button();
            lbDateTimeClock = new Label();
            lbGreetingSub = new Label();
            lbGreeting = new Label();
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
            pnlKpiAlerts = new Panel();
            lbKpiAlertsSub = new Label();
            lbKpiAlertsValue = new Label();
            lbKpiAlertsTitle = new Label();
            pnlMovements = new Panel();
            dgvMovements = new DataGridView();
            colType = new DataGridViewTextBoxColumn();
            colRoom = new DataGridViewTextBoxColumn();
            colGuestName = new DataGridViewTextBoxColumn();
            colStayDates = new DataGridViewTextBoxColumn();
            colStatus = new DataGridViewTextBoxColumn();
            lbNoData = new Label();
            pnlMovementsHeader = new Panel();
            btnFilterDepartures = new Button();
            btnFilterArrivals = new Button();
            btnFilterAll = new Button();
            lbMovementsTitle = new Label();
            pnlSideWidgets = new Panel();
            pnlVipAlerts = new Panel();
            lbVipList = new Label();
            lbVipTitle = new Label();
            pnlRoomMatrix = new Panel();
            lbStatMaintenance = new Label();
            lbStatDirty = new Label();
            lbStatOccupied = new Label();
            lbStatAvailable = new Label();
            lbMatrixTitle = new Label();
            pnlProfile = new Panel();
            llbChangePassword = new LinkLabel();
            dtpBirthdate = new DateTimePicker();
            tbFname = new TextBox();
            tbAddress = new TextBox();
            tbTaxNumber = new TextBox();
            tbEmail = new TextBox();
            tbLname = new TextBox();
            panel1 = new Panel();
            btnCancel = new Button();
            btnSaveProfile = new Button();
            btnEditProfile = new Button();
            pictureBox1 = new PictureBox();
            lbProfileTitle = new Label();
            lbNameTitle = new Label();
            lbNameValue = new Label();
            lbEmailTitle = new Label();
            lbEmailValue = new Label();
            lbTaxNumberTitle = new Label();
            lbTaxNumberValue = new Label();
            lbHolidaysLeftTitle = new Label();
            lbHolidaysLeftValue = new Label();
            lbAddressTitle = new Label();
            lbAddressValue = new Label();
            lbBirthdateTitle = new Label();
            lbBirthdateValue = new Label();
            pnlTop.SuspendLayout();
            pnlKpiArrivals.SuspendLayout();
            pnlKpiDepartures.SuspendLayout();
            pnlKpiOccupancy.SuspendLayout();
            pnlKpiAlerts.SuspendLayout();
            pnlMovements.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMovements).BeginInit();
            pnlMovementsHeader.SuspendLayout();
            pnlSideWidgets.SuspendLayout();
            pnlVipAlerts.SuspendLayout();
            pnlRoomMatrix.SuspendLayout();
            pnlProfile.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pnlTop
            // 
            pnlTop.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlTop.BackColor = Color.FromArgb(245, 245, 248);
            pnlTop.BorderStyle = BorderStyle.FixedSingle;
            pnlTop.Controls.Add(btnRefresh);
            pnlTop.Controls.Add(btnQuickCheckin);
            pnlTop.Controls.Add(btnQuickNewBooking);
            pnlTop.Controls.Add(lbDateTimeClock);
            pnlTop.Controls.Add(lbGreetingSub);
            pnlTop.Controls.Add(lbGreeting);
            pnlTop.Location = new Point(10, 10);
            pnlTop.Name = "pnlTop";
            pnlTop.Size = new Size(1720, 75);
            pnlTop.TabIndex = 0;
            // 
            // btnRefresh
            // 
            btnRefresh.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnRefresh.BackColor = SystemColors.ButtonFace;
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnRefresh.Location = new Point(1600, 22);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(105, 32);
            btnRefresh.TabIndex = 5;
            btnRefresh.Text = "↻ Refresh";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // btnQuickCheckin
            // 
            btnQuickCheckin.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnQuickCheckin.BackColor = SystemColors.ButtonFace;
            btnQuickCheckin.FlatStyle = FlatStyle.Flat;
            btnQuickCheckin.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnQuickCheckin.ForeColor = Color.DarkGreen;
            btnQuickCheckin.Location = new Point(1465, 22);
            btnQuickCheckin.Name = "btnQuickCheckin";
            btnQuickCheckin.Size = new Size(125, 32);
            btnQuickCheckin.TabIndex = 4;
            btnQuickCheckin.Text = "Quick Check-In";
            btnQuickCheckin.UseVisualStyleBackColor = false;
            btnQuickCheckin.Click += btnQuickCheckin_Click;
            // 
            // btnQuickNewBooking
            // 
            btnQuickNewBooking.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnQuickNewBooking.BackColor = Color.FromArgb(24, 60, 142);
            btnQuickNewBooking.FlatStyle = FlatStyle.Flat;
            btnQuickNewBooking.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnQuickNewBooking.ForeColor = Color.White;
            btnQuickNewBooking.Location = new Point(1320, 22);
            btnQuickNewBooking.Name = "btnQuickNewBooking";
            btnQuickNewBooking.Size = new Size(135, 32);
            btnQuickNewBooking.TabIndex = 3;
            btnQuickNewBooking.Text = "+ New Booking";
            btnQuickNewBooking.UseVisualStyleBackColor = false;
            btnQuickNewBooking.Click += btnQuickNewBooking_Click;
            // 
            // lbDateTimeClock
            // 
            lbDateTimeClock.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lbDateTimeClock.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lbDateTimeClock.ForeColor = Color.DimGray;
            lbDateTimeClock.Location = new Point(1020, 28);
            lbDateTimeClock.Name = "lbDateTimeClock";
            lbDateTimeClock.Size = new Size(280, 20);
            lbDateTimeClock.TabIndex = 2;
            lbDateTimeClock.Text = "2026.08.31 | 18:49:00";
            lbDateTimeClock.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lbGreetingSub
            // 
            lbGreetingSub.AutoSize = true;
            lbGreetingSub.Font = new Font("Segoe UI", 9F);
            lbGreetingSub.ForeColor = Color.Gray;
            lbGreetingSub.Location = new Point(16, 42);
            lbGreetingSub.Name = "lbGreetingSub";
            lbGreetingSub.Size = new Size(303, 15);
            lbGreetingSub.TabIndex = 1;
            lbGreetingSub.Text = "Here is today's operational summary for Hotel Elegance.";
            // 
            // lbGreeting
            // 
            lbGreeting.AutoSize = true;
            lbGreeting.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lbGreeting.ForeColor = Color.FromArgb(24, 60, 142);
            lbGreeting.Location = new Point(14, 14);
            lbGreeting.Name = "lbGreeting";
            lbGreeting.Size = new Size(200, 25);
            lbGreeting.TabIndex = 0;
            lbGreeting.Text = "Welcome to Elegance";
            // 
            // pnlKpiArrivals
            // 
            pnlKpiArrivals.BackColor = Color.White;
            pnlKpiArrivals.BorderStyle = BorderStyle.FixedSingle;
            pnlKpiArrivals.Controls.Add(lbKpiArrivalsSub);
            pnlKpiArrivals.Controls.Add(lbKpiArrivalsValue);
            pnlKpiArrivals.Controls.Add(lbKpiArrivalsTitle);
            pnlKpiArrivals.Location = new Point(10, 95);
            pnlKpiArrivals.Name = "pnlKpiArrivals";
            pnlKpiArrivals.Size = new Size(415, 85);
            pnlKpiArrivals.TabIndex = 1;
            // 
            // lbKpiArrivalsSub
            // 
            lbKpiArrivalsSub.AutoSize = true;
            lbKpiArrivalsSub.Font = new Font("Segoe UI", 8.5F);
            lbKpiArrivalsSub.ForeColor = Color.Gray;
            lbKpiArrivalsSub.Location = new Point(12, 60);
            lbKpiArrivalsSub.Name = "lbKpiArrivalsSub";
            lbKpiArrivalsSub.Size = new Size(142, 15);
            lbKpiArrivalsSub.TabIndex = 2;
            lbKpiArrivalsSub.Text = "Expected check-ins today";
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
            lbKpiArrivalsTitle.Size = new Size(116, 15);
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
            pnlKpiDepartures.Location = new Point(440, 95);
            pnlKpiDepartures.Name = "pnlKpiDepartures";
            pnlKpiDepartures.Size = new Size(415, 85);
            pnlKpiDepartures.TabIndex = 2;
            // 
            // lbKpiDeparturesSub
            // 
            lbKpiDeparturesSub.AutoSize = true;
            lbKpiDeparturesSub.Font = new Font("Segoe UI", 8.5F);
            lbKpiDeparturesSub.ForeColor = Color.Gray;
            lbKpiDeparturesSub.Location = new Point(12, 60);
            lbKpiDeparturesSub.Name = "lbKpiDeparturesSub";
            lbKpiDeparturesSub.Size = new Size(157, 15);
            lbKpiDeparturesSub.TabIndex = 2;
            lbKpiDeparturesSub.Text = "Scheduled check-outs today";
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
            lbKpiDeparturesTitle.Size = new Size(134, 15);
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
            pnlKpiOccupancy.Location = new Point(870, 95);
            pnlKpiOccupancy.Name = "pnlKpiOccupancy";
            pnlKpiOccupancy.Size = new Size(415, 85);
            pnlKpiOccupancy.TabIndex = 3;
            // 
            // lbKpiOccupancySub
            // 
            lbKpiOccupancySub.AutoSize = true;
            lbKpiOccupancySub.Font = new Font("Segoe UI", 8.5F);
            lbKpiOccupancySub.ForeColor = Color.Gray;
            lbKpiOccupancySub.Location = new Point(12, 60);
            lbKpiOccupancySub.Name = "lbKpiOccupancySub";
            lbKpiOccupancySub.Size = new Size(121, 15);
            lbKpiOccupancySub.TabIndex = 2;
            lbKpiOccupancySub.Text = "Total rooms in service";
            // 
            // lbKpiOccupancyValue
            // 
            lbKpiOccupancyValue.AutoSize = true;
            lbKpiOccupancyValue.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lbKpiOccupancyValue.ForeColor = Color.DarkGreen;
            lbKpiOccupancyValue.Location = new Point(10, 27);
            lbKpiOccupancyValue.Name = "lbKpiOccupancyValue";
            lbKpiOccupancyValue.Size = new Size(56, 32);
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
            lbKpiOccupancyTitle.Size = new Size(107, 15);
            lbKpiOccupancyTitle.TabIndex = 0;
            lbKpiOccupancyTitle.Text = "OCCUPANCY RATE";
            // 
            // pnlKpiAlerts
            // 
            pnlKpiAlerts.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlKpiAlerts.BackColor = Color.White;
            pnlKpiAlerts.BorderStyle = BorderStyle.FixedSingle;
            pnlKpiAlerts.Controls.Add(lbKpiAlertsSub);
            pnlKpiAlerts.Controls.Add(lbKpiAlertsValue);
            pnlKpiAlerts.Controls.Add(lbKpiAlertsTitle);
            pnlKpiAlerts.Location = new Point(1300, 95);
            pnlKpiAlerts.Name = "pnlKpiAlerts";
            pnlKpiAlerts.Size = new Size(430, 85);
            pnlKpiAlerts.TabIndex = 4;
            // 
            // lbKpiAlertsSub
            // 
            lbKpiAlertsSub.AutoSize = true;
            lbKpiAlertsSub.Font = new Font("Segoe UI", 8.5F);
            lbKpiAlertsSub.ForeColor = Color.Gray;
            lbKpiAlertsSub.Location = new Point(12, 60);
            lbKpiAlertsSub.Name = "lbKpiAlertsSub";
            lbKpiAlertsSub.Size = new Size(156, 15);
            lbKpiAlertsSub.TabIndex = 2;
            lbKpiAlertsSub.Text = "Rooms needing cleaning/fix";
            // 
            // lbKpiAlertsValue
            // 
            lbKpiAlertsValue.AutoSize = true;
            lbKpiAlertsValue.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lbKpiAlertsValue.ForeColor = Color.Firebrick;
            lbKpiAlertsValue.Location = new Point(10, 27);
            lbKpiAlertsValue.Name = "lbKpiAlertsValue";
            lbKpiAlertsValue.Size = new Size(28, 32);
            lbKpiAlertsValue.TabIndex = 1;
            lbKpiAlertsValue.Text = "0";
            // 
            // lbKpiAlertsTitle
            // 
            lbKpiAlertsTitle.AutoSize = true;
            lbKpiAlertsTitle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lbKpiAlertsTitle.ForeColor = Color.DimGray;
            lbKpiAlertsTitle.Location = new Point(12, 10);
            lbKpiAlertsTitle.Name = "lbKpiAlertsTitle";
            lbKpiAlertsTitle.Size = new Size(141, 15);
            lbKpiAlertsTitle.TabIndex = 0;
            lbKpiAlertsTitle.Text = "HOUSEKEEPING ALERTS";
            // 
            // pnlMovements
            // 
            pnlMovements.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlMovements.BackColor = Color.White;
            pnlMovements.BorderStyle = BorderStyle.FixedSingle;
            pnlMovements.Controls.Add(dgvMovements);
            pnlMovements.Controls.Add(lbNoData);
            pnlMovements.Controls.Add(pnlMovementsHeader);
            pnlMovements.Location = new Point(10, 190);
            pnlMovements.Name = "pnlMovements";
            pnlMovements.Size = new Size(1160, 747);
            pnlMovements.TabIndex = 5;
            // 
            // dgvMovements
            // 
            dgvMovements.AllowUserToAddRows = false;
            dgvMovements.AllowUserToDeleteRows = false;
            dgvMovements.AllowUserToOrderColumns = true;
            dgvMovements.AllowUserToResizeColumns = false;
            dgvMovements.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(245, 248, 253);
            dgvMovements.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvMovements.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMovements.BackgroundColor = Color.White;
            dgvMovements.BorderStyle = BorderStyle.None;
            dgvMovements.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(30, 58, 138);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvMovements.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvMovements.ColumnHeadersHeight = 35;
            dgvMovements.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvMovements.Columns.AddRange(new DataGridViewColumn[] { colType, colRoom, colGuestName, colStayDates, colStatus });
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = SystemColors.Window;
            dataGridViewCellStyle8.Font = new Font("Segoe UI", 9.75F);
            dataGridViewCellStyle8.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = DataGridViewTriState.False;
            dgvMovements.DefaultCellStyle = dataGridViewCellStyle8;
            dgvMovements.Dock = DockStyle.Fill;
            dgvMovements.EnableHeadersVisualStyles = false;
            dgvMovements.GridColor = SystemColors.ControlLight;
            dgvMovements.Location = new Point(0, 45);
            dgvMovements.MultiSelect = false;
            dgvMovements.Name = "dgvMovements";
            dgvMovements.ReadOnly = true;
            dgvMovements.RowHeadersVisible = false;
            dgvMovements.RowTemplate.Height = 35;
            dgvMovements.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMovements.Size = new Size(1158, 700);
            dgvMovements.TabIndex = 1;
            dgvMovements.CellDoubleClick += dgvMovements_CellDoubleClick;
            // 
            // colType
            // 
            colType.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colType.DataPropertyName = "MovementType";
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            colType.DefaultCellStyle = dataGridViewCellStyle3;
            colType.FillWeight = 15F;
            colType.HeaderText = "Type";
            colType.Name = "colType";
            colType.ReadOnly = true;
            // 
            // colRoom
            // 
            colRoom.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colRoom.DataPropertyName = "RoomNumber";
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colRoom.DefaultCellStyle = dataGridViewCellStyle4;
            colRoom.FillWeight = 12F;
            colRoom.HeaderText = "Room #";
            colRoom.Name = "colRoom";
            colRoom.ReadOnly = true;
            // 
            // colGuestName
            // 
            colGuestName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colGuestName.DataPropertyName = "GuestName";
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            colGuestName.DefaultCellStyle = dataGridViewCellStyle5;
            colGuestName.FillWeight = 30F;
            colGuestName.HeaderText = "Guest Name";
            colGuestName.Name = "colGuestName";
            colGuestName.ReadOnly = true;
            // 
            // colStayDates
            // 
            colStayDates.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colStayDates.DataPropertyName = "StayPeriod";
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colStayDates.DefaultCellStyle = dataGridViewCellStyle6;
            colStayDates.FillWeight = 25F;
            colStayDates.HeaderText = "Stay Period";
            colStayDates.Name = "colStayDates";
            colStayDates.ReadOnly = true;
            // 
            // colStatus
            // 
            colStatus.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colStatus.DataPropertyName = "StatusText";
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colStatus.DefaultCellStyle = dataGridViewCellStyle7;
            colStatus.FillWeight = 18F;
            colStatus.HeaderText = "Status";
            colStatus.Name = "colStatus";
            colStatus.ReadOnly = true;
            // 
            // lbNoData
            // 
            lbNoData.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lbNoData.AutoSize = true;
            lbNoData.Font = new Font("Segoe UI", 27.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 238);
            lbNoData.ForeColor = Color.DarkGray;
            lbNoData.Location = new Point(388, 365);
            lbNoData.Name = "lbNoData";
            lbNoData.Size = new Size(401, 50);
            lbNoData.TabIndex = 2;
            lbNoData.Text = "NO MATCHING DATA";
            lbNoData.Visible = false;
            // 
            // pnlMovementsHeader
            // 
            pnlMovementsHeader.BackColor = Color.FromArgb(248, 249, 250);
            pnlMovementsHeader.Controls.Add(btnFilterDepartures);
            pnlMovementsHeader.Controls.Add(btnFilterArrivals);
            pnlMovementsHeader.Controls.Add(btnFilterAll);
            pnlMovementsHeader.Controls.Add(lbMovementsTitle);
            pnlMovementsHeader.Dock = DockStyle.Top;
            pnlMovementsHeader.Location = new Point(0, 0);
            pnlMovementsHeader.Name = "pnlMovementsHeader";
            pnlMovementsHeader.Size = new Size(1158, 45);
            pnlMovementsHeader.TabIndex = 0;
            // 
            // btnFilterDepartures
            // 
            btnFilterDepartures.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnFilterDepartures.FlatStyle = FlatStyle.Flat;
            btnFilterDepartures.Location = new Point(1045, 9);
            btnFilterDepartures.Name = "btnFilterDepartures";
            btnFilterDepartures.Size = new Size(100, 26);
            btnFilterDepartures.TabIndex = 3;
            btnFilterDepartures.Text = "Departures";
            btnFilterDepartures.UseVisualStyleBackColor = true;
            btnFilterDepartures.Click += btnFilterDepartures_Click;
            // 
            // btnFilterArrivals
            // 
            btnFilterArrivals.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnFilterArrivals.FlatStyle = FlatStyle.Flat;
            btnFilterArrivals.Location = new Point(945, 9);
            btnFilterArrivals.Name = "btnFilterArrivals";
            btnFilterArrivals.Size = new Size(95, 26);
            btnFilterArrivals.TabIndex = 2;
            btnFilterArrivals.Text = "Arrivals";
            btnFilterArrivals.UseVisualStyleBackColor = true;
            btnFilterArrivals.Click += btnFilterArrivals_Click;
            // 
            // btnFilterAll
            // 
            btnFilterAll.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnFilterAll.BackColor = Color.FromArgb(24, 60, 142);
            btnFilterAll.FlatStyle = FlatStyle.Flat;
            btnFilterAll.ForeColor = Color.White;
            btnFilterAll.Location = new Point(875, 9);
            btnFilterAll.Name = "btnFilterAll";
            btnFilterAll.Size = new Size(65, 26);
            btnFilterAll.TabIndex = 1;
            btnFilterAll.Text = "All";
            btnFilterAll.UseVisualStyleBackColor = false;
            btnFilterAll.Click += btnFilterAll_Click;
            // 
            // lbMovementsTitle
            // 
            lbMovementsTitle.AutoSize = true;
            lbMovementsTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lbMovementsTitle.ForeColor = Color.FromArgb(24, 60, 142);
            lbMovementsTitle.Location = new Point(15, 12);
            lbMovementsTitle.Name = "lbMovementsTitle";
            lbMovementsTitle.Size = new Size(248, 20);
            lbMovementsTitle.TabIndex = 0;
            lbMovementsTitle.Text = "TODAY'S ARRIVALS & DEPARTURES";
            // 
            // pnlSideWidgets
            // 
            pnlSideWidgets.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            pnlSideWidgets.Controls.Add(pnlVipAlerts);
            pnlSideWidgets.Controls.Add(pnlRoomMatrix);
            pnlSideWidgets.Controls.Add(pnlProfile);
            pnlSideWidgets.Location = new Point(1180, 190);
            pnlSideWidgets.Name = "pnlSideWidgets";
            pnlSideWidgets.Size = new Size(550, 747);
            pnlSideWidgets.TabIndex = 6;
            // 
            // pnlVipAlerts
            // 
            pnlVipAlerts.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlVipAlerts.BackColor = Color.White;
            pnlVipAlerts.BorderStyle = BorderStyle.FixedSingle;
            pnlVipAlerts.Controls.Add(lbVipList);
            pnlVipAlerts.Controls.Add(lbVipTitle);
            pnlVipAlerts.Location = new Point(0, 205);
            pnlVipAlerts.Name = "pnlVipAlerts";
            pnlVipAlerts.Size = new Size(270, 542);
            pnlVipAlerts.TabIndex = 1;
            // 
            // lbVipList
            // 
            lbVipList.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lbVipList.Font = new Font("Segoe UI", 9.5F);
            lbVipList.ForeColor = Color.FromArgb(50, 50, 50);
            lbVipList.Location = new Point(15, 45);
            lbVipList.Name = "lbVipList";
            lbVipList.Size = new Size(238, 482);
            lbVipList.TabIndex = 1;
            lbVipList.Text = "• No pending special requests for today.\r\n• All VIP arrivals are pre-assigned.";
            // 
            // lbVipTitle
            // 
            lbVipTitle.AutoSize = true;
            lbVipTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lbVipTitle.ForeColor = Color.FromArgb(24, 60, 142);
            lbVipTitle.Location = new Point(15, 15);
            lbVipTitle.Name = "lbVipTitle";
            lbVipTitle.Size = new Size(242, 20);
            lbVipTitle.TabIndex = 0;
            lbVipTitle.Text = "VIP GUESTS / SPECIAL REQUESTS";
            // 
            // pnlRoomMatrix
            // 
            pnlRoomMatrix.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlRoomMatrix.BackColor = Color.White;
            pnlRoomMatrix.BorderStyle = BorderStyle.FixedSingle;
            pnlRoomMatrix.Controls.Add(lbStatMaintenance);
            pnlRoomMatrix.Controls.Add(lbStatDirty);
            pnlRoomMatrix.Controls.Add(lbStatOccupied);
            pnlRoomMatrix.Controls.Add(lbStatAvailable);
            pnlRoomMatrix.Controls.Add(lbMatrixTitle);
            pnlRoomMatrix.Location = new Point(0, 0);
            pnlRoomMatrix.Name = "pnlRoomMatrix";
            pnlRoomMatrix.Size = new Size(550, 195);
            pnlRoomMatrix.TabIndex = 0;
            // 
            // lbStatMaintenance
            // 
            lbStatMaintenance.AutoSize = true;
            lbStatMaintenance.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            lbStatMaintenance.ForeColor = Color.Firebrick;
            lbStatMaintenance.Location = new Point(290, 125);
            lbStatMaintenance.Name = "lbStatMaintenance";
            lbStatMaintenance.Size = new Size(179, 19);
            lbStatMaintenance.TabIndex = 4;
            lbStatMaintenance.Text = "🔴 Under Maintenance: 0";
            // 
            // lbStatDirty
            // 
            lbStatDirty.AutoSize = true;
            lbStatDirty.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            lbStatDirty.ForeColor = Color.DarkOrange;
            lbStatDirty.Location = new Point(25, 125);
            lbStatDirty.Name = "lbStatDirty";
            lbStatDirty.Size = new Size(200, 19);
            lbStatDirty.TabIndex = 3;
            lbStatDirty.Text = "\U0001f7e1 Needs Cleaning / Dirty: 0";
            // 
            // lbStatOccupied
            // 
            lbStatOccupied.AutoSize = true;
            lbStatOccupied.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            lbStatOccupied.ForeColor = Color.FromArgb(24, 60, 142);
            lbStatOccupied.Location = new Point(290, 65);
            lbStatOccupied.Name = "lbStatOccupied";
            lbStatOccupied.Size = new Size(173, 19);
            lbStatOccupied.TabIndex = 2;
            lbStatOccupied.Text = "🔵 Occupied / In-Stay: 0";
            // 
            // lbStatAvailable
            // 
            lbStatAvailable.AutoSize = true;
            lbStatAvailable.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            lbStatAvailable.ForeColor = Color.DarkGreen;
            lbStatAvailable.Location = new Point(25, 65);
            lbStatAvailable.Name = "lbStatAvailable";
            lbStatAvailable.Size = new Size(168, 19);
            lbStatAvailable.TabIndex = 1;
            lbStatAvailable.Text = "\U0001f7e2 Ready / Available: 0";
            // 
            // lbMatrixTitle
            // 
            lbMatrixTitle.AutoSize = true;
            lbMatrixTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lbMatrixTitle.ForeColor = Color.FromArgb(24, 60, 142);
            lbMatrixTitle.Location = new Point(15, 15);
            lbMatrixTitle.Name = "lbMatrixTitle";
            lbMatrixTitle.Size = new Size(192, 20);
            lbMatrixTitle.TabIndex = 0;
            lbMatrixTitle.Text = "ROOM CAPACITY MATRIX";
            // 
            // pnlProfile
            // 
            pnlProfile.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlProfile.BackColor = Color.White;
            pnlProfile.BorderStyle = BorderStyle.FixedSingle;
            pnlProfile.Controls.Add(llbChangePassword);
            pnlProfile.Controls.Add(dtpBirthdate);
            pnlProfile.Controls.Add(tbFname);
            pnlProfile.Controls.Add(tbAddress);
            pnlProfile.Controls.Add(tbTaxNumber);
            pnlProfile.Controls.Add(tbEmail);
            pnlProfile.Controls.Add(tbLname);
            pnlProfile.Controls.Add(panel1);
            pnlProfile.Controls.Add(pictureBox1);
            pnlProfile.Controls.Add(lbProfileTitle);
            pnlProfile.Controls.Add(lbNameTitle);
            pnlProfile.Controls.Add(lbNameValue);
            pnlProfile.Controls.Add(lbEmailTitle);
            pnlProfile.Controls.Add(lbEmailValue);
            pnlProfile.Controls.Add(lbTaxNumberTitle);
            pnlProfile.Controls.Add(lbTaxNumberValue);
            pnlProfile.Controls.Add(lbHolidaysLeftTitle);
            pnlProfile.Controls.Add(lbHolidaysLeftValue);
            pnlProfile.Controls.Add(lbAddressTitle);
            pnlProfile.Controls.Add(lbAddressValue);
            pnlProfile.Controls.Add(lbBirthdateTitle);
            pnlProfile.Controls.Add(lbBirthdateValue);
            pnlProfile.Location = new Point(280, 205);
            pnlProfile.Name = "pnlProfile";
            pnlProfile.Size = new Size(270, 542);
            pnlProfile.TabIndex = 2;
            // 
            // llbChangePassword
            // 
            llbChangePassword.AutoSize = true;
            llbChangePassword.Location = new Point(150, 391);
            llbChangePassword.Name = "llbChangePassword";
            llbChangePassword.Size = new Size(112, 17);
            llbChangePassword.TabIndex = 18;
            llbChangePassword.TabStop = true;
            llbChangePassword.Text = "Change Password";
            llbChangePassword.Visible = false;
            llbChangePassword.LinkClicked += llbChangePassword_LinkClicked;
            // 
            // dtpBirthdate
            // 
            dtpBirthdate.Location = new Point(110, 354);
            dtpBirthdate.MaxDate = new DateTime(2026, 9, 10, 0, 0, 0, 0);
            dtpBirthdate.MinDate = new DateTime(1900, 1, 1, 0, 0, 0, 0);
            dtpBirthdate.Name = "dtpBirthdate";
            dtpBirthdate.Size = new Size(152, 25);
            dtpBirthdate.TabIndex = 17;
            dtpBirthdate.Value = new DateTime(2026, 9, 10, 0, 0, 0, 0);
            // 
            // tbFname
            // 
            tbFname.Location = new Point(189, 203);
            tbFname.MaxLength = 30;
            tbFname.Name = "tbFname";
            tbFname.PlaceholderText = "First Name";
            tbFname.Size = new Size(73, 25);
            tbFname.TabIndex = 16;
            // 
            // tbAddress
            // 
            tbAddress.Location = new Point(110, 323);
            tbAddress.MaxLength = 255;
            tbAddress.Name = "tbAddress";
            tbAddress.PlaceholderText = "Zip, City, Street";
            tbAddress.Size = new Size(152, 25);
            tbAddress.TabIndex = 16;
            // 
            // tbTaxNumber
            // 
            tbTaxNumber.Location = new Point(110, 263);
            tbTaxNumber.MaxLength = 20;
            tbTaxNumber.Name = "tbTaxNumber";
            tbTaxNumber.PlaceholderText = "Tax Number";
            tbTaxNumber.Size = new Size(152, 25);
            tbTaxNumber.TabIndex = 16;
            // 
            // tbEmail
            // 
            tbEmail.Location = new Point(110, 233);
            tbEmail.MaxLength = 64;
            tbEmail.Name = "tbEmail";
            tbEmail.PlaceholderText = "E-mail address";
            tbEmail.Size = new Size(152, 25);
            tbEmail.TabIndex = 16;
            // 
            // tbLname
            // 
            tbLname.Location = new Point(111, 203);
            tbLname.MaxLength = 30;
            tbLname.Name = "tbLname";
            tbLname.PlaceholderText = "Last Name";
            tbLname.Size = new Size(73, 25);
            tbLname.TabIndex = 16;
            // 
            // panel1
            // 
            panel1.Controls.Add(btnCancel);
            panel1.Controls.Add(btnSaveProfile);
            panel1.Controls.Add(btnEditProfile);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 464);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(10, 20, 10, 20);
            panel1.Size = new Size(268, 76);
            panel1.TabIndex = 15;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.DarkRed;
            btnCancel.Dock = DockStyle.Left;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(10, 20);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(119, 36);
            btnCancel.TabIndex = 16;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Visible = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnSaveProfile
            // 
            btnSaveProfile.BackColor = Color.DarkGreen;
            btnSaveProfile.Dock = DockStyle.Right;
            btnSaveProfile.FlatStyle = FlatStyle.Flat;
            btnSaveProfile.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnSaveProfile.ForeColor = Color.White;
            btnSaveProfile.Location = new Point(139, 20);
            btnSaveProfile.Name = "btnSaveProfile";
            btnSaveProfile.Size = new Size(119, 36);
            btnSaveProfile.TabIndex = 15;
            btnSaveProfile.Text = "Save Profile";
            btnSaveProfile.UseVisualStyleBackColor = false;
            btnSaveProfile.Visible = false;
            btnSaveProfile.Click += btnSaveProfileData_Click;
            // 
            // btnEditProfile
            // 
            btnEditProfile.BackColor = Color.FromArgb(24, 60, 142);
            btnEditProfile.Dock = DockStyle.Fill;
            btnEditProfile.FlatStyle = FlatStyle.Flat;
            btnEditProfile.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnEditProfile.ForeColor = Color.White;
            btnEditProfile.Location = new Point(10, 20);
            btnEditProfile.Name = "btnEditProfile";
            btnEditProfile.Size = new Size(248, 36);
            btnEditProfile.TabIndex = 14;
            btnEditProfile.Text = "Edit Profile";
            btnEditProfile.UseVisualStyleBackColor = false;
            btnEditProfile.Click += btnEditProfile_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            pictureBox1.Image = Properties.Resources.person_icon;
            pictureBox1.InitialImage = Properties.Resources.person_icon;
            pictureBox1.Location = new Point(72, 56);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(126, 126);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 13;
            pictureBox1.TabStop = false;
            // 
            // lbProfileTitle
            // 
            lbProfileTitle.AutoSize = true;
            lbProfileTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lbProfileTitle.ForeColor = Color.FromArgb(24, 60, 142);
            lbProfileTitle.Location = new Point(76, 15);
            lbProfileTitle.Name = "lbProfileTitle";
            lbProfileTitle.Size = new Size(113, 20);
            lbProfileTitle.TabIndex = 0;
            lbProfileTitle.Text = "YOUR PROFILE";
            // 
            // lbNameTitle
            // 
            lbNameTitle.AutoSize = true;
            lbNameTitle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lbNameTitle.Location = new Point(15, 206);
            lbNameTitle.Name = "lbNameTitle";
            lbNameTitle.Size = new Size(48, 17);
            lbNameTitle.TabIndex = 1;
            lbNameTitle.Text = "Name:";
            // 
            // lbNameValue
            // 
            lbNameValue.AutoSize = true;
            lbNameValue.Font = new Font("Segoe UI", 9.5F);
            lbNameValue.Location = new Point(110, 206);
            lbNameValue.Name = "lbNameValue";
            lbNameValue.Size = new Size(63, 17);
            lbNameValue.TabIndex = 2;
            lbNameValue.Text = "John Doe";
            // 
            // lbEmailTitle
            // 
            lbEmailTitle.AutoSize = true;
            lbEmailTitle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lbEmailTitle.Location = new Point(15, 236);
            lbEmailTitle.Name = "lbEmailTitle";
            lbEmailTitle.Size = new Size(46, 17);
            lbEmailTitle.TabIndex = 3;
            lbEmailTitle.Text = "Email:";
            // 
            // lbEmailValue
            // 
            lbEmailValue.AutoSize = true;
            lbEmailValue.Font = new Font("Segoe UI", 9.5F);
            lbEmailValue.Location = new Point(110, 236);
            lbEmailValue.Name = "lbEmailValue";
            lbEmailValue.Size = new Size(130, 17);
            lbEmailValue.TabIndex = 4;
            lbEmailValue.Text = "john.doe@email.com";
            // 
            // lbTaxNumberTitle
            // 
            lbTaxNumberTitle.AutoSize = true;
            lbTaxNumberTitle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lbTaxNumberTitle.Location = new Point(15, 266);
            lbTaxNumberTitle.Name = "lbTaxNumberTitle";
            lbTaxNumberTitle.Size = new Size(88, 17);
            lbTaxNumberTitle.TabIndex = 5;
            lbTaxNumberTitle.Text = "Tax Number:";
            // 
            // lbTaxNumberValue
            // 
            lbTaxNumberValue.AutoSize = true;
            lbTaxNumberValue.Font = new Font("Segoe UI", 9.5F);
            lbTaxNumberValue.Location = new Point(110, 266);
            lbTaxNumberValue.Name = "lbTaxNumberValue";
            lbTaxNumberValue.Size = new Size(78, 17);
            lbTaxNumberValue.TabIndex = 6;
            lbTaxNumberValue.Text = "1234567890";
            // 
            // lbHolidaysLeftTitle
            // 
            lbHolidaysLeftTitle.AutoSize = true;
            lbHolidaysLeftTitle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lbHolidaysLeftTitle.Location = new Point(15, 296);
            lbHolidaysLeftTitle.Name = "lbHolidaysLeftTitle";
            lbHolidaysLeftTitle.Size = new Size(94, 17);
            lbHolidaysLeftTitle.TabIndex = 7;
            lbHolidaysLeftTitle.Text = "Holidays Left:";
            // 
            // lbHolidaysLeftValue
            // 
            lbHolidaysLeftValue.AutoSize = true;
            lbHolidaysLeftValue.Font = new Font("Segoe UI", 9.5F);
            lbHolidaysLeftValue.Location = new Point(110, 296);
            lbHolidaysLeftValue.Name = "lbHolidaysLeftValue";
            lbHolidaysLeftValue.Size = new Size(22, 17);
            lbHolidaysLeftValue.TabIndex = 8;
            lbHolidaysLeftValue.Text = "20";
            // 
            // lbAddressTitle
            // 
            lbAddressTitle.AutoSize = true;
            lbAddressTitle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lbAddressTitle.Location = new Point(15, 326);
            lbAddressTitle.Name = "lbAddressTitle";
            lbAddressTitle.Size = new Size(61, 17);
            lbAddressTitle.TabIndex = 9;
            lbAddressTitle.Text = "Address:";
            // 
            // lbAddressValue
            // 
            lbAddressValue.AutoSize = true;
            lbAddressValue.Font = new Font("Segoe UI", 9.5F);
            lbAddressValue.Location = new Point(110, 326);
            lbAddressValue.Name = "lbAddressValue";
            lbAddressValue.Size = new Size(105, 17);
            lbAddressValue.TabIndex = 10;
            lbAddressValue.Text = "123 Main St, City";
            // 
            // lbBirthdateTitle
            // 
            lbBirthdateTitle.AutoSize = true;
            lbBirthdateTitle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lbBirthdateTitle.Location = new Point(15, 356);
            lbBirthdateTitle.Name = "lbBirthdateTitle";
            lbBirthdateTitle.Size = new Size(69, 17);
            lbBirthdateTitle.TabIndex = 11;
            lbBirthdateTitle.Text = "Birthdate:";
            // 
            // lbBirthdateValue
            // 
            lbBirthdateValue.AutoSize = true;
            lbBirthdateValue.Font = new Font("Segoe UI", 9.5F);
            lbBirthdateValue.Location = new Point(110, 356);
            lbBirthdateValue.Name = "lbBirthdateValue";
            lbBirthdateValue.Size = new Size(74, 17);
            lbBirthdateValue.TabIndex = 12;
            lbBirthdateValue.Text = "1990-01-01";
            // 
            // DashboardControl
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 249, 250);
            Controls.Add(pnlSideWidgets);
            Controls.Add(pnlMovements);
            Controls.Add(pnlKpiAlerts);
            Controls.Add(pnlKpiOccupancy);
            Controls.Add(pnlKpiDepartures);
            Controls.Add(pnlKpiArrivals);
            Controls.Add(pnlTop);
            Font = new Font("Segoe UI", 9.75F);
            Name = "DashboardControl";
            Size = new Size(1740, 956);
            Load += DashboardControl_Load;
            pnlTop.ResumeLayout(false);
            pnlTop.PerformLayout();
            pnlKpiArrivals.ResumeLayout(false);
            pnlKpiArrivals.PerformLayout();
            pnlKpiDepartures.ResumeLayout(false);
            pnlKpiDepartures.PerformLayout();
            pnlKpiOccupancy.ResumeLayout(false);
            pnlKpiOccupancy.PerformLayout();
            pnlKpiAlerts.ResumeLayout(false);
            pnlKpiAlerts.PerformLayout();
            pnlMovements.ResumeLayout(false);
            pnlMovements.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMovements).EndInit();
            pnlMovementsHeader.ResumeLayout(false);
            pnlMovementsHeader.PerformLayout();
            pnlSideWidgets.ResumeLayout(false);
            pnlVipAlerts.ResumeLayout(false);
            pnlVipAlerts.PerformLayout();
            pnlRoomMatrix.ResumeLayout(false);
            pnlRoomMatrix.PerformLayout();
            pnlProfile.ResumeLayout(false);
            pnlProfile.PerformLayout();
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlTop;
        private Label lbGreeting;
        private Label lbGreetingSub;
        private Label lbDateTimeClock;
        private Button btnQuickNewBooking;
        private Button btnQuickCheckin;
        private Button btnRefresh;

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

        private Panel pnlKpiAlerts;
        private Label lbKpiAlertsTitle;
        private Label lbKpiAlertsValue;
        private Label lbKpiAlertsSub;

        private Panel pnlMovements;
        private Panel pnlMovementsHeader;
        private Label lbMovementsTitle;
        private Button btnFilterAll;
        private Button btnFilterArrivals;
        private Button btnFilterDepartures;
        private DataGridView dgvMovements;

        private Panel pnlSideWidgets;
        private Panel pnlRoomMatrix;
        private Label lbMatrixTitle;
        private Label lbStatAvailable;
        private Label lbStatOccupied;
        private Label lbStatDirty;
        private Label lbStatMaintenance;

        private Panel pnlVipAlerts;
        private Label lbVipTitle;
        private Label lbVipList;

        private DataGridViewTextBoxColumn colType;
        private DataGridViewTextBoxColumn colRoom;
        private DataGridViewTextBoxColumn colGuestName;
        private DataGridViewTextBoxColumn colStayDates;
        private DataGridViewTextBoxColumn colStatus;
        private Label lbNoData;
        private Panel pnlProfile;
        private Label lbProfileTitle;
        private Label lbNameTitle;
        private Label lbNameValue;
        private Label lbEmailTitle;
        private Label lbEmailValue;
        private Label lbTaxNumberTitle;
        private Label lbTaxNumberValue;
        private Label lbHolidaysLeftTitle;
        private Label lbHolidaysLeftValue;
        private Label lbAddressTitle;
        private Label lbAddressValue;
        private Label lbBirthdateTitle;
        private Label lbBirthdateValue;
        private PictureBox pictureBox1;
        private Panel panel1;
        private Button btnEditProfile;
        private Button btnSaveProfile;
        private TextBox tbFname;
        private TextBox tbLname;
        private TextBox tbAddress;
        private TextBox tbTaxNumber;
        private TextBox tbEmail;
        private DateTimePicker dtpBirthdate;
        private Button btnCancel;
        private LinkLabel llbChangePassword;
    }
}