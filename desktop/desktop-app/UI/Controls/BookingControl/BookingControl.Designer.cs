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
            DataGridViewCellStyle dataGridViewCellStyle10 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle9 = new DataGridViewCellStyle();
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
            label9 = new Label();
            btnSearch = new Button();
            label1 = new Label();
            dbSearchType = new ComboBox();
            dtpFrom = new DateTimePicker();
            cbStatus = new ComboBox();
            dtpTo = new DateTimePicker();
            label2 = new Label();
            tbSearch = new TextBox();
            label8 = new Label();
            panel2 = new Panel();
            dgvBookings = new DataGridView();
            BookingId = new DataGridViewTextBoxColumn();
            colRoomNumber = new DataGridViewTextBoxColumn();
            RoomType = new DataGridViewTextBoxColumn();
            colBegOfStay = new DataGridViewTextBoxColumn();
            colEndOfStay = new DataGridViewTextBoxColumn();
            colCheckIn = new DataGridViewTextBoxColumn();
            colCheckOut = new DataGridViewTextBoxColumn();
            colLevelOfService = new DataGridViewTextBoxColumn();
            pnlTop.SuspendLayout();
            panel7.SuspendLayout();
            panel6.SuspendLayout();
            panel5.SuspendLayout();
            panel3.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBookings).BeginInit();
            SuspendLayout();
            // 
            // pnlTop
            // 
            pnlTop.BackColor = Color.FromArgb(239, 246, 255);
            pnlTop.Controls.Add(panel7);
            pnlTop.Controls.Add(panel6);
            pnlTop.Controls.Add(panel5);
            pnlTop.Controls.Add(panel3);
            pnlTop.Dock = DockStyle.Top;
            pnlTop.Location = new Point(0, 0);
            pnlTop.Name = "pnlTop";
            pnlTop.Size = new Size(1191, 141);
            pnlTop.TabIndex = 0;
            // 
            // panel7
            // 
            panel7.BackColor = SystemColors.ButtonFace;
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
            panel6.BackColor = SystemColors.ButtonFace;
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
            label11.Location = new Point(1, 1);
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
            // 
            // panel5
            // 
            panel5.BackColor = SystemColors.ButtonFace;
            panel5.Controls.Add(label13);
            panel5.Controls.Add(label12);
            panel5.Controls.Add(label3);
            panel5.Controls.Add(label5);
            panel5.Controls.Add(label7);
            panel5.Controls.Add(label6);
            panel5.Controls.Add(label4);
            panel5.Location = new Point(1040, 0);
            panel5.Name = "panel5";
            panel5.Size = new Size(254, 141);
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
            panel1.BackColor = SystemColors.ButtonFace;
            panel1.Controls.Add(label9);
            panel1.Controls.Add(btnSearch);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(dbSearchType);
            panel1.Controls.Add(dtpFrom);
            panel1.Controls.Add(cbStatus);
            panel1.Controls.Add(dtpTo);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(tbSearch);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(652, 141);
            panel1.TabIndex = 6;
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
            btnSearch.Font = new Font("Segoe UI", 13F);
            btnSearch.Location = new Point(531, 80);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(115, 41);
            btnSearch.TabIndex = 5;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 13F);
            label1.Location = new Point(9, 39);
            label1.Name = "label1";
            label1.Size = new Size(56, 22);
            label1.TabIndex = 0;
            label1.Text = "From:";
            // 
            // dbSearchType
            // 
            dbSearchType.Font = new Font("Segoe UI", 12F);
            dbSearchType.FormattingEnabled = true;
            dbSearchType.Location = new Point(9, 88);
            dbSearchType.Name = "dbSearchType";
            dbSearchType.Size = new Size(121, 29);
            dbSearchType.TabIndex = 4;
            // 
            // dtpFrom
            // 
            dtpFrom.Font = new Font("Microsoft Sans Serif", 13F);
            dtpFrom.Location = new Point(68, 37);
            dtpFrom.Name = "dtpFrom";
            dtpFrom.Size = new Size(200, 27);
            dtpFrom.TabIndex = 1;
            // 
            // cbStatus
            // 
            cbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cbStatus.Font = new Font("Segoe UI", 12F);
            cbStatus.FormattingEnabled = true;
            cbStatus.Items.AddRange(new object[] { "All", "Pending", "Confirmed", "Cancelled", "Completed", "Expired" });
            cbStatus.Location = new Point(531, 35);
            cbStatus.Name = "cbStatus";
            cbStatus.Size = new Size(115, 29);
            cbStatus.TabIndex = 4;
            // 
            // dtpTo
            // 
            dtpTo.Font = new Font("Microsoft Sans Serif", 13F);
            dtpTo.Location = new Point(313, 37);
            dtpTo.Name = "dtpTo";
            dtpTo.Size = new Size(200, 27);
            dtpTo.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 13F);
            label2.Location = new Point(274, 39);
            label2.Name = "label2";
            label2.Size = new Size(37, 22);
            label2.TabIndex = 0;
            label2.Text = "To:";
            // 
            // tbSearch
            // 
            tbSearch.Font = new Font("Microsoft Sans Serif", 13F);
            tbSearch.Location = new Point(135, 88);
            tbSearch.Name = "tbSearch";
            tbSearch.Size = new Size(378, 27);
            tbSearch.TabIndex = 3;
            tbSearch.Text = "Search for a booking";
            tbSearch.TextAlign = HorizontalAlignment.Right;
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
            panel2.Controls.Add(dgvBookings);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 141);
            panel2.Name = "panel2";
            panel2.Size = new Size(1191, 420);
            panel2.TabIndex = 1;
            // 
            // dgvBookings
            // 
            dgvBookings.AllowUserToAddRows = false;
            dgvBookings.AllowUserToDeleteRows = false;
            dgvBookings.AllowUserToOrderColumns = true;
            dgvBookings.AllowUserToResizeColumns = false;
            dgvBookings.AllowUserToResizeRows = false;
            dgvBookings.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvBookings.BackgroundColor = Color.White;
            dgvBookings.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(30, 58, 138);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvBookings.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvBookings.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBookings.Columns.AddRange(new DataGridViewColumn[] { BookingId, colRoomNumber, RoomType, colBegOfStay, colEndOfStay, colCheckIn, colCheckOut, colLevelOfService });
            dataGridViewCellStyle10.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.BackColor = SystemColors.Window;
            dataGridViewCellStyle10.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle10.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle10.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = DataGridViewTriState.False;
            dgvBookings.DefaultCellStyle = dataGridViewCellStyle10;
            dgvBookings.Dock = DockStyle.Fill;
            dgvBookings.EnableHeadersVisualStyles = false;
            dgvBookings.GridColor = SystemColors.ControlLight;
            dgvBookings.Location = new Point(0, 0);
            dgvBookings.Margin = new Padding(5);
            dgvBookings.Name = "dgvBookings";
            dgvBookings.RowHeadersVisible = false;
            dgvBookings.RowTemplate.Height = 35;
            dgvBookings.Size = new Size(1191, 420);
            dgvBookings.TabIndex = 4;
            // 
            // BookingId
            // 
            BookingId.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            BookingId.DataPropertyName = "Id";
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            BookingId.DefaultCellStyle = dataGridViewCellStyle2;
            BookingId.FillWeight = 120F;
            BookingId.HeaderText = "Booking ID";
            BookingId.Name = "BookingId";
            BookingId.ReadOnly = true;
            // 
            // colRoomNumber
            // 
            colRoomNumber.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colRoomNumber.DataPropertyName = "RoomNumber";
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colRoomNumber.DefaultCellStyle = dataGridViewCellStyle3;
            colRoomNumber.HeaderText = "Room Number";
            colRoomNumber.Name = "colRoomNumber";
            colRoomNumber.ReadOnly = true;
            // 
            // RoomType
            // 
            RoomType.DataPropertyName = "SelectedRoomType";
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
            RoomType.DefaultCellStyle = dataGridViewCellStyle4;
            RoomType.HeaderText = "Room Type";
            RoomType.Name = "RoomType";
            RoomType.ReadOnly = true;
            // 
            // colBegOfStay
            // 
            colBegOfStay.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colBegOfStay.DataPropertyName = "BeginningOfStay";
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colBegOfStay.DefaultCellStyle = dataGridViewCellStyle5;
            colBegOfStay.FillWeight = 150F;
            colBegOfStay.HeaderText = "Booked From";
            colBegOfStay.Name = "colBegOfStay";
            colBegOfStay.ReadOnly = true;
            // 
            // colEndOfStay
            // 
            colEndOfStay.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colEndOfStay.DataPropertyName = "EndOfStay";
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colEndOfStay.DefaultCellStyle = dataGridViewCellStyle6;
            colEndOfStay.FillWeight = 150F;
            colEndOfStay.HeaderText = "Booked To";
            colEndOfStay.Name = "colEndOfStay";
            colEndOfStay.ReadOnly = true;
            // 
            // colCheckIn
            // 
            colCheckIn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colCheckIn.DataPropertyName = "CheckinDisplay";
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.ForeColor = Color.Black;
            colCheckIn.DefaultCellStyle = dataGridViewCellStyle7;
            colCheckIn.FillWeight = 150F;
            colCheckIn.HeaderText = "Actual Check-in";
            colCheckIn.Name = "colCheckIn";
            colCheckIn.ReadOnly = true;
            // 
            // colCheckOut
            // 
            colCheckOut.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colCheckOut.DataPropertyName = "CheckoutDisplay";
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.BottomCenter;
            colCheckOut.DefaultCellStyle = dataGridViewCellStyle8;
            colCheckOut.FillWeight = 150F;
            colCheckOut.HeaderText = "Actual Check-out";
            colCheckOut.Name = "colCheckOut";
            colCheckOut.ReadOnly = true;
            // 
            // colLevelOfService
            // 
            colLevelOfService.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colLevelOfService.DataPropertyName = "SelectedCateringLevel";
            dataGridViewCellStyle9.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colLevelOfService.DefaultCellStyle = dataGridViewCellStyle9;
            colLevelOfService.HeaderText = "Catering Level";
            colLevelOfService.Name = "colLevelOfService";
            colLevelOfService.ReadOnly = true;
            // 
            // BookingControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel2);
            Controls.Add(pnlTop);
            Name = "BookingControl";
            Size = new Size(1191, 561);
            Load += BookingControl_Load;
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
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvBookings).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlTop;
        private Panel panel2;
        private DataGridView dgvBookings;
        private Panel panel3;
        private TextBox tbSearch;
        private DateTimePicker dtpTo;
        private DateTimePicker dtpFrom;
        private Label label2;
        private Label label1;
        private Button button4;
        private ComboBox dbSearchType;
        private ComboBox cbStatus;
        private Button btnCheckout;
        private Button btnCheckin;
        private Button btnSearch;
        private Button btnCancel;
        private Button btnEdit;
        private Button btnAddBooking;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label6;
        private Label label7;
        private Label label8;
        private Panel panel1;
        private Panel panel7;
        private Panel panel6;
        private Panel panel5;
        private Label label10;
        private Label label9;
        private Label label11;
        private Label label12;
        private Label label13;
        private DataGridViewTextBoxColumn BookingId;
        private DataGridViewTextBoxColumn colRoomNumber;
        private DataGridViewTextBoxColumn RoomType;
        private DataGridViewTextBoxColumn colBegOfStay;
        private DataGridViewTextBoxColumn colEndOfStay;
        private DataGridViewTextBoxColumn colCheckIn;
        private DataGridViewTextBoxColumn colCheckOut;
        private DataGridViewTextBoxColumn colLevelOfService;
    }
}
