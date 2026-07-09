namespace Hotel_erp_Winforms_App.UI.Controls
{
    partial class BookingControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
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
            label8 = new Label();
            panel2 = new Panel();
            panel9 = new Panel();
            dgvBookings = new DataGridView();
            BookingId = new DataGridViewTextBoxColumn();
            colRoomNumber = new DataGridViewTextBoxColumn();
            RoomType = new DataGridViewTextBoxColumn();
            colBegOfStay = new DataGridViewTextBoxColumn();
            colEndOfStay = new DataGridViewTextBoxColumn();
            colCheckIn = new DataGridViewTextBoxColumn();
            colCheckOut = new DataGridViewTextBoxColumn();
            colLevelOfService = new DataGridViewTextBoxColumn();
            pnlTopContainer = new Panel();
            pnlTop = new Panel();
            panel7 = new Panel();
            label10 = new Label();
            btnCancel = new Button();
            btnAddBooking = new Button();
            btnEdit = new Button();
            panel6 = new Panel();
            label11 = new Label();
            btnCheckout = new Button();
            btnCheckin = new Button();
            panel5 = new Panel();
            label13 = new Label();
            label12 = new Label();
            label3 = new Label();
            label5 = new Label();
            label7 = new Label();
            label6 = new Label();
            label4 = new Label();
            panel3 = new Panel();
            panel1 = new Panel();
            tcSearch = new TabControl();
            tabPage1 = new TabPage();
            label15 = new Label();
            label16 = new Label();
            cbField = new ComboBox();
            tbSearch = new TextBox();
            cbStatus = new ComboBox();
            tabPage2 = new TabPage();
            cbSpan = new ComboBox();
            label14 = new Label();
            label1 = new Label();
            dtpFrom = new DateTimePicker();
            dtpTo = new DateTimePicker();
            label2 = new Label();
            label9 = new Label();
            btnSearch = new Button();
            panel4 = new Panel();
            panel2.SuspendLayout();
            panel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBookings).BeginInit();
            pnlTopContainer.SuspendLayout();
            pnlTop.SuspendLayout();
            panel7.SuspendLayout();
            panel6.SuspendLayout();
            panel5.SuspendLayout();
            panel3.SuspendLayout();
            panel1.SuspendLayout();
            tcSearch.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            SuspendLayout();
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.FlatStyle = FlatStyle.Flat;
            label8.ForeColor = Color.Black;
            label8.Location = new Point(6, 11);
            label8.Name = "label8";
            label8.Size = new Size(28, 21);
            label8.TabIndex = 0;
            label8.Text = "74";
            // 
            // panel2
            // 
            panel2.Controls.Add(panel9);
            panel2.Controls.Add(pnlTopContainer);
            panel2.Controls.Add(panel4);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(1637, 561);
            panel2.TabIndex = 1;
            // 
            // panel9
            // 
            panel9.Controls.Add(dgvBookings);
            panel9.Dock = DockStyle.Fill;
            panel9.Location = new Point(0, 141);
            panel9.Name = "panel9";
            panel9.Size = new Size(1237, 420);
            panel9.TabIndex = 7;
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
            dgvBookings.Columns.AddRange(new DataGridViewColumn[] { BookingId, colRoomNumber, RoomType, colBegOfStay, colEndOfStay, colCheckIn, colCheckOut, colLevelOfService });
            dataGridViewCellStyle11.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle11.BackColor = SystemColors.Window;
            dataGridViewCellStyle11.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 238);
            dataGridViewCellStyle11.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle11.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = DataGridViewTriState.False;
            dgvBookings.DefaultCellStyle = dataGridViewCellStyle11;
            dgvBookings.Dock = DockStyle.Fill;
            dgvBookings.EnableHeadersVisualStyles = false;
            dgvBookings.GridColor = SystemColors.ControlLight;
            dgvBookings.Location = new Point(0, 0);
            dgvBookings.Margin = new Padding(5);
            dgvBookings.Name = "dgvBookings";
            dgvBookings.RowHeadersVisible = false;
            dgvBookings.RowTemplate.Height = 35;
            dgvBookings.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBookings.Size = new Size(1237, 420);
            dgvBookings.TabIndex = 4;
            dgvBookings.CellClick += dgvBookings_CellClick;
            // 
            // BookingId
            // 
            BookingId.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            BookingId.DataPropertyName = "Id";
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            BookingId.DefaultCellStyle = dataGridViewCellStyle3;
            BookingId.FillWeight = 120F;
            BookingId.HeaderText = "Booking ID";
            BookingId.Name = "BookingId";
            BookingId.ReadOnly = true;
            // 
            // colRoomNumber
            // 
            colRoomNumber.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colRoomNumber.DataPropertyName = "RoomNumber";
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colRoomNumber.DefaultCellStyle = dataGridViewCellStyle4;
            colRoomNumber.HeaderText = "Room Number";
            colRoomNumber.Name = "colRoomNumber";
            colRoomNumber.ReadOnly = true;
            // 
            // RoomType
            // 
            RoomType.DataPropertyName = "SelectedRoomType";
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleCenter;
            RoomType.DefaultCellStyle = dataGridViewCellStyle5;
            RoomType.HeaderText = "Room Type";
            RoomType.Name = "RoomType";
            RoomType.ReadOnly = true;
            // 
            // colBegOfStay
            // 
            colBegOfStay.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colBegOfStay.DataPropertyName = "BeginningOfStay";
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colBegOfStay.DefaultCellStyle = dataGridViewCellStyle6;
            colBegOfStay.FillWeight = 150F;
            colBegOfStay.HeaderText = "Booked From";
            colBegOfStay.Name = "colBegOfStay";
            colBegOfStay.ReadOnly = true;
            // 
            // colEndOfStay
            // 
            colEndOfStay.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colEndOfStay.DataPropertyName = "EndOfStay";
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colEndOfStay.DefaultCellStyle = dataGridViewCellStyle7;
            colEndOfStay.FillWeight = 150F;
            colEndOfStay.HeaderText = "Booked To";
            colEndOfStay.Name = "colEndOfStay";
            colEndOfStay.ReadOnly = true;
            // 
            // colCheckIn
            // 
            colCheckIn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colCheckIn.DataPropertyName = "CheckinDisplay";
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.ForeColor = Color.Black;
            colCheckIn.DefaultCellStyle = dataGridViewCellStyle8;
            colCheckIn.FillWeight = 150F;
            colCheckIn.HeaderText = "Actual Check-in";
            colCheckIn.Name = "colCheckIn";
            colCheckIn.ReadOnly = true;
            // 
            // colCheckOut
            // 
            colCheckOut.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colCheckOut.DataPropertyName = "CheckoutDisplay";
            dataGridViewCellStyle9.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colCheckOut.DefaultCellStyle = dataGridViewCellStyle9;
            colCheckOut.FillWeight = 150F;
            colCheckOut.HeaderText = "Actual Check-out";
            colCheckOut.Name = "colCheckOut";
            colCheckOut.ReadOnly = true;
            // 
            // colLevelOfService
            // 
            colLevelOfService.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colLevelOfService.DataPropertyName = "SelectedCateringLevel";
            dataGridViewCellStyle10.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colLevelOfService.DefaultCellStyle = dataGridViewCellStyle10;
            colLevelOfService.HeaderText = "Catering Level";
            colLevelOfService.Name = "colLevelOfService";
            colLevelOfService.ReadOnly = true;
            // 
            // pnlTopContainer
            // 
            pnlTopContainer.Controls.Add(pnlTop);
            pnlTopContainer.Dock = DockStyle.Top;
            pnlTopContainer.Location = new Point(0, 0);
            pnlTopContainer.Name = "pnlTopContainer";
            pnlTopContainer.Size = new Size(1237, 141);
            pnlTopContainer.TabIndex = 6;
            // 
            // pnlTop
            // 
            pnlTop.BackColor = Color.FromArgb(239, 246, 255);
            pnlTop.Controls.Add(panel7);
            pnlTop.Controls.Add(panel6);
            pnlTop.Controls.Add(panel5);
            pnlTop.Controls.Add(panel3);
            pnlTop.Dock = DockStyle.Fill;
            pnlTop.Location = new Point(0, 0);
            pnlTop.Name = "pnlTop";
            pnlTop.Size = new Size(1237, 141);
            pnlTop.TabIndex = 0;
            // 
            // panel7
            // 
            panel7.BackColor = Color.FromArgb(239, 246, 255);
            panel7.Controls.Add(label10);
            panel7.Controls.Add(btnCancel);
            panel7.Controls.Add(btnAddBooking);
            panel7.Controls.Add(btnEdit);
            panel7.Location = new Point(652, 0);
            panel7.Name = "panel7";
            panel7.Size = new Size(174, 141);
            panel7.TabIndex = 6;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 238);
            label10.Location = new Point(1, 1);
            label10.Name = "label10";
            label10.Size = new Size(54, 17);
            label10.TabIndex = 7;
            label10.Text = "Actions";
            // 
            // btnCancel
            // 
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI", 12F);
            btnCancel.Image = Properties.Resources.cancel;
            btnCancel.ImageAlign = ContentAlignment.MiddleLeft;
            btnCancel.Location = new Point(6, 100);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(161, 32);
            btnCancel.TabIndex = 0;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnAddBooking
            // 
            btnAddBooking.FlatStyle = FlatStyle.Flat;
            btnAddBooking.Font = new Font("Segoe UI", 12F);
            btnAddBooking.Image = Properties.Resources.add;
            btnAddBooking.ImageAlign = ContentAlignment.MiddleLeft;
            btnAddBooking.Location = new Point(6, 29);
            btnAddBooking.Name = "btnAddBooking";
            btnAddBooking.Size = new Size(161, 32);
            btnAddBooking.TabIndex = 0;
            btnAddBooking.Text = "New Booking";
            btnAddBooking.TextAlign = ContentAlignment.MiddleRight;
            btnAddBooking.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnAddBooking.UseVisualStyleBackColor = true;
            // 
            // btnEdit
            // 
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.Font = new Font("Segoe UI", 12F);
            btnEdit.Image = Properties.Resources.edit;
            btnEdit.ImageAlign = ContentAlignment.MiddleLeft;
            btnEdit.Location = new Point(6, 66);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(161, 29);
            btnEdit.TabIndex = 0;
            btnEdit.Text = "Edit";
            btnEdit.UseVisualStyleBackColor = true;
            // 
            // panel6
            // 
            panel6.BackColor = Color.FromArgb(239, 246, 255);
            panel6.Controls.Add(label11);
            panel6.Controls.Add(btnCheckout);
            panel6.Controls.Add(btnCheckin);
            panel6.Location = new Point(825, 0);
            panel6.Name = "panel6";
            panel6.Size = new Size(216, 141);
            panel6.TabIndex = 5;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 238);
            label11.Location = new Point(13, 1);
            label11.Name = "label11";
            label11.Size = new Size(44, 17);
            label11.TabIndex = 8;
            label11.Text = "Check";
            // 
            // btnCheckout
            // 
            btnCheckout.FlatStyle = FlatStyle.Flat;
            btnCheckout.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            btnCheckout.Location = new Point(13, 87);
            btnCheckout.Name = "btnCheckout";
            btnCheckout.Size = new Size(196, 45);
            btnCheckout.TabIndex = 7;
            btnCheckout.Text = "Check-Out";
            btnCheckout.UseVisualStyleBackColor = false;
            // 
            // btnCheckin
            // 
            btnCheckin.FlatStyle = FlatStyle.Flat;
            btnCheckin.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            btnCheckin.Location = new Point(13, 29);
            btnCheckin.Name = "btnCheckin";
            btnCheckin.Size = new Size(196, 45);
            btnCheckin.TabIndex = 6;
            btnCheckin.Text = "Check-In";
            btnCheckin.UseVisualStyleBackColor = false;
            btnCheckin.Click += btnCheckin_Click;
            // 
            // panel5
            // 
            panel5.BackColor = Color.FromArgb(239, 246, 255);
            panel5.Controls.Add(label13);
            panel5.Controls.Add(label12);
            panel5.Controls.Add(label3);
            panel5.Controls.Add(label5);
            panel5.Controls.Add(label7);
            panel5.Controls.Add(label6);
            panel5.Controls.Add(label4);
            panel5.Location = new Point(1040, 0);
            panel5.Name = "panel5";
            panel5.Size = new Size(192, 141);
            panel5.TabIndex = 4;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Microsoft Sans Serif", 12.75F, FontStyle.Bold);
            label13.Location = new Point(106, 104);
            label13.Name = "label13";
            label13.Size = new Size(45, 20);
            label13.TabIndex = 10;
            label13.Text = "74%";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 238);
            label12.Location = new Point(1, 1);
            label12.Name = "label12";
            label12.Size = new Size(78, 17);
            label12.TabIndex = 9;
            label12.Text = "Occupation";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 12.75F);
            label3.Location = new Point(8, 32);
            label3.Name = "label3";
            label3.Size = new Size(134, 20);
            label3.TabIndex = 0;
            label3.Text = "Today's Arrivals:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft Sans Serif", 12.75F);
            label5.Location = new Point(8, 104);
            label5.Name = "label5";
            label5.Size = new Size(98, 20);
            label5.TabIndex = 0;
            label5.Text = "Occupancy:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Microsoft Sans Serif", 12.75F, FontStyle.Bold);
            label7.Location = new Point(166, 68);
            label7.Name = "label7";
            label7.Size = new Size(19, 20);
            label7.TabIndex = 1;
            label7.Text = "5";
            label7.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Microsoft Sans Serif", 12.75F, FontStyle.Bold);
            label6.Location = new Point(141, 32);
            label6.Name = "label6";
            label6.Size = new Size(29, 20);
            label6.TabIndex = 1;
            label6.Text = "12";
            label6.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 12.75F);
            label4.Location = new Point(8, 68);
            label4.Name = "label4";
            label4.Size = new Size(161, 20);
            label4.TabIndex = 0;
            label4.Text = "Today's Departures:";
            // 
            // panel3
            // 
            panel3.Controls.Add(panel1);
            panel3.Dock = DockStyle.Left;
            panel3.Location = new Point(0, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(652, 141);
            panel3.TabIndex = 1;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(239, 246, 255);
            panel1.Controls.Add(tcSearch);
            panel1.Controls.Add(label9);
            panel1.Controls.Add(btnSearch);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(652, 141);
            panel1.TabIndex = 6;
            // 
            // tcSearch
            // 
            tcSearch.Controls.Add(tabPage1);
            tcSearch.Controls.Add(tabPage2);
            tcSearch.Location = new Point(1, 29);
            tcSearch.Name = "tcSearch";
            tcSearch.SelectedIndex = 0;
            tcSearch.Size = new Size(528, 103);
            tcSearch.TabIndex = 5;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(label15);
            tabPage1.Controls.Add(label16);
            tabPage1.Controls.Add(cbField);
            tabPage1.Controls.Add(tbSearch);
            tabPage1.Controls.Add(cbStatus);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(520, 75);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "By Field";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Microsoft Sans Serif", 13F, FontStyle.Bold);
            label15.Location = new Point(140, 7);
            label15.Name = "label15";
            label15.Size = new Size(73, 22);
            label15.TabIndex = 8;
            label15.Text = "Status:";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Font = new Font("Microsoft Sans Serif", 13F, FontStyle.Bold);
            label16.Location = new Point(6, 7);
            label16.Name = "label16";
            label16.Size = new Size(60, 22);
            label16.TabIndex = 9;
            label16.Text = "Field:";
            // 
            // cbField
            // 
            cbField.DropDownStyle = ComboBoxStyle.DropDownList;
            cbField.Font = new Font("Segoe UI", 12F);
            cbField.FormattingEnabled = true;
            cbField.Items.AddRange(new object[] { "Not Selected", "Booking ID", "Room Number", "Room Type", "Booked From", "Booked To", "Check-in", "Check-out", "Catering Level" });
            cbField.Location = new Point(6, 35);
            cbField.Name = "cbField";
            cbField.Size = new Size(121, 29);
            cbField.TabIndex = 4;
            // 
            // tbSearch
            // 
            tbSearch.Font = new Font("Microsoft Sans Serif", 13F);
            tbSearch.Location = new Point(268, 35);
            tbSearch.Name = "tbSearch";
            tbSearch.PlaceholderText = "Search for a booking";
            tbSearch.Size = new Size(245, 27);
            tbSearch.TabIndex = 3;
            tbSearch.TextAlign = HorizontalAlignment.Right;
            // 
            // cbStatus
            // 
            cbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cbStatus.Font = new Font("Segoe UI", 12F);
            cbStatus.FormattingEnabled = true;
            cbStatus.Items.AddRange(new object[] { "All", "Upcoming", "Current", "Past" });
            cbStatus.Location = new Point(140, 35);
            cbStatus.Name = "cbStatus";
            cbStatus.Size = new Size(115, 29);
            cbStatus.TabIndex = 4;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(cbSpan);
            tabPage2.Controls.Add(label14);
            tabPage2.Controls.Add(label1);
            tabPage2.Controls.Add(dtpFrom);
            tabPage2.Controls.Add(dtpTo);
            tabPage2.Controls.Add(label2);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(520, 75);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "By Period";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // cbSpan
            // 
            cbSpan.DropDownStyle = ComboBoxStyle.DropDownList;
            cbSpan.Font = new Font("Microsoft Sans Serif", 13F);
            cbSpan.FormattingEnabled = true;
            cbSpan.Items.AddRange(new object[] { "Booked From", "Booked To", "Enclosing" });
            cbSpan.Location = new Point(360, 34);
            cbSpan.Name = "cbSpan";
            cbSpan.Size = new Size(154, 28);
            cbSpan.TabIndex = 3;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Microsoft Sans Serif", 13F, FontStyle.Bold);
            label14.Location = new Point(360, 7);
            label14.Name = "label14";
            label14.Size = new Size(62, 22);
            label14.TabIndex = 2;
            label14.Text = "Span:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 13F, FontStyle.Bold);
            label1.Location = new Point(6, 7);
            label1.Name = "label1";
            label1.Size = new Size(61, 22);
            label1.TabIndex = 0;
            label1.Text = "From:";
            // 
            // dtpFrom
            // 
            dtpFrom.Font = new Font("Microsoft Sans Serif", 13F);
            dtpFrom.Format = DateTimePickerFormat.Short;
            dtpFrom.Location = new Point(6, 35);
            dtpFrom.Name = "dtpFrom";
            dtpFrom.Size = new Size(154, 27);
            dtpFrom.TabIndex = 1;
            // 
            // dtpTo
            // 
            dtpTo.Font = new Font("Microsoft Sans Serif", 13F);
            dtpTo.Format = DateTimePickerFormat.Short;
            dtpTo.Location = new Point(192, 35);
            dtpTo.Name = "dtpTo";
            dtpTo.Size = new Size(136, 27);
            dtpTo.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 13F, FontStyle.Bold);
            label2.Location = new Point(192, 7);
            label2.Name = "label2";
            label2.Size = new Size(40, 22);
            label2.TabIndex = 0;
            label2.Text = "To:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 238);
            label9.Location = new Point(1, 1);
            label9.Name = "label9";
            label9.Size = new Size(40, 17);
            label9.TabIndex = 6;
            label9.Text = "Filter";
            // 
            // btnSearch
            // 
            btnSearch.Font = new Font("Microsoft Sans Serif", 13F);
            btnSearch.Location = new Point(531, 74);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(115, 41);
            btnSearch.TabIndex = 5;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // panel4
            // 
            panel4.BackColor = Color.White;
            panel4.Dock = DockStyle.Right;
            panel4.Location = new Point(1237, 0);
            panel4.Name = "panel4";
            panel4.Size = new Size(400, 561);
            panel4.TabIndex = 5;
            // 
            // BookingControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel2);
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 238);
            Name = "BookingControl";
            Size = new Size(1637, 561);
            Load += BookingControl_Load;
            panel2.ResumeLayout(false);
            panel9.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvBookings).EndInit();
            pnlTopContainer.ResumeLayout(false);
            pnlTop.ResumeLayout(false);
            panel7.ResumeLayout(false);
            panel7.PerformLayout();
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            panel3.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            tcSearch.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Panel panel2;
        private DataGridView dgvBookings;
        private Button button4;
        private Label label8;
        private DataGridViewTextBoxColumn BookingId;
        private DataGridViewTextBoxColumn colRoomNumber;
        private DataGridViewTextBoxColumn RoomType;
        private DataGridViewTextBoxColumn colBegOfStay;
        private DataGridViewTextBoxColumn colEndOfStay;
        private DataGridViewTextBoxColumn colCheckIn;
        private DataGridViewTextBoxColumn colCheckOut;
        private DataGridViewTextBoxColumn colLevelOfService;
        private Panel panel4;
        private Panel pnlTop;
        private Panel panel7;
        private Label label10;
        private Button btnCancel;
        private Button btnAddBooking;
        private Button btnEdit;
        private Panel panel6;
        private Label label11;
        private Button btnCheckout;
        private Button btnCheckin;
        private Panel panel5;
        private Label label13;
        private Label label12;
        private Label label3;
        private Label label5;
        private Label label7;
        private Label label6;
        private Label label4;
        private Panel panel3;
        private Panel panel1;
        private TabControl tcSearch;
        private TabPage tabPage1;
        private Label label15;
        private Label label16;
        private ComboBox cbField;
        private TextBox tbSearch;
        private ComboBox cbStatus;
        private TabPage tabPage2;
        private ComboBox cbSpan;
        private Label label14;
        private Label label1;
        private DateTimePicker dtpFrom;
        private DateTimePicker dtpTo;
        private Label label2;
        private Label label9;
        private Button btnSearch;
        private Panel panel9;
        private Panel pnlTopContainer;
    }
}
