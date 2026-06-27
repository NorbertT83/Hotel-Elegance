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
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            cbRoomNum = new ComboBox();
            dtpStart = new DateTimePicker();
            tbName = new TextBox();
            btnSave = new Button();
            groupBox1 = new GroupBox();
            label4 = new Label();
            lbSumTotal = new Label();
            label1 = new Label();
            btnClear = new Button();
            gpRooms = new GroupBox();
            tbLevel = new TextBox();
            label5 = new Label();
            label3 = new Label();
            dtpEnd = new DateTimePicker();
            lbCheckInDate = new Label();
            lbRoomNum = new Label();
            gbGuest = new GroupBox();
            tbGuestId = new MaskedTextBox();
            label2 = new Label();
            lbEmail = new Label();
            tbEmail = new TextBox();
            lbPhone = new Label();
            tbPhone = new TextBox();
            lbName = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            dgvBookings = new DataGridView();
            colRoomNumber = new DataGridViewTextBoxColumn();
            colBegOfStay = new DataGridViewTextBoxColumn();
            colEndOfStay = new DataGridViewTextBoxColumn();
            colCheckIn = new DataGridViewTextBoxColumn();
            colCheckOut = new DataGridViewTextBoxColumn();
            colLevelOfService = new DataGridViewTextBoxColumn();
            groupBox1.SuspendLayout();
            gpRooms.SuspendLayout();
            gbGuest.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBookings).BeginInit();
            SuspendLayout();
            // 
            // cbRoomNum
            // 
            cbRoomNum.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cbRoomNum.BackColor = SystemColors.Window;
            cbRoomNum.DropDownStyle = ComboBoxStyle.DropDownList;
            cbRoomNum.FormattingEnabled = true;
            cbRoomNum.Location = new Point(120, 38);
            cbRoomNum.Name = "cbRoomNum";
            cbRoomNum.Size = new Size(91, 29);
            cbRoomNum.TabIndex = 1;
            // 
            // dtpStart
            // 
            dtpStart.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dtpStart.Location = new Point(119, 127);
            dtpStart.MinDate = new DateTime(2026, 4, 28, 0, 0, 0, 0);
            dtpStart.Name = "dtpStart";
            dtpStart.Size = new Size(225, 29);
            dtpStart.TabIndex = 2;
            // 
            // tbName
            // 
            tbName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tbName.Location = new Point(110, 40);
            tbName.Name = "tbName";
            tbName.Size = new Size(161, 29);
            tbName.TabIndex = 3;
            // 
            // btnSave
            // 
            btnSave.Anchor = AnchorStyles.None;
            btnSave.BackColor = Color.LimeGreen;
            btnSave.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnSave.Location = new Point(68, 152);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(200, 41);
            btnSave.TabIndex = 5;
            btnSave.Text = "Foglalás Mentése";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(lbSumTotal);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(btnClear);
            groupBox1.Controls.Add(btnSave);
            groupBox1.Font = new Font("Segoe UI", 12F);
            groupBox1.Location = new Point(678, 5);
            groupBox1.Margin = new Padding(5);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(326, 240);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Összesítés";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label4.Location = new Point(300, 51);
            label4.Name = "label4";
            label4.Size = new Size(24, 21);
            label4.TabIndex = 9;
            label4.Text = "Ft";
            // 
            // lbSumTotal
            // 
            lbSumTotal.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lbSumTotal.Location = new Point(213, 48);
            lbSumTotal.Name = "lbSumTotal";
            lbSumTotal.Size = new Size(91, 25);
            lbSumTotal.TabIndex = 8;
            lbSumTotal.Text = "0";
            lbSumTotal.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label1.Location = new Point(6, 51);
            label1.Name = "label1";
            label1.Size = new Size(213, 21);
            label1.TabIndex = 7;
            label1.Text = "Szobáért fizetendő összeg:";
            // 
            // btnClear
            // 
            btnClear.Anchor = AnchorStyles.None;
            btnClear.BackColor = Color.FromArgb(192, 0, 0);
            btnClear.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnClear.Location = new Point(68, 94);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(200, 41);
            btnClear.TabIndex = 6;
            btnClear.Text = "Mezők Törlése";
            btnClear.UseVisualStyleBackColor = false;
            // 
            // gpRooms
            // 
            gpRooms.Controls.Add(tbLevel);
            gpRooms.Controls.Add(label5);
            gpRooms.Controls.Add(label3);
            gpRooms.Controls.Add(dtpEnd);
            gpRooms.Controls.Add(lbCheckInDate);
            gpRooms.Controls.Add(lbRoomNum);
            gpRooms.Controls.Add(cbRoomNum);
            gpRooms.Controls.Add(dtpStart);
            gpRooms.Font = new Font("Segoe UI", 12F);
            gpRooms.Location = new Point(307, 5);
            gpRooms.Margin = new Padding(5);
            gpRooms.Name = "gpRooms";
            gpRooms.Size = new Size(361, 240);
            gpRooms.TabIndex = 1;
            gpRooms.TabStop = false;
            gpRooms.Text = "Szoba adatai";
            // 
            // tbLevel
            // 
            tbLevel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tbLevel.Location = new Point(148, 84);
            tbLevel.Name = "tbLevel";
            tbLevel.Size = new Size(139, 29);
            tbLevel.TabIndex = 7;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(6, 87);
            label5.Name = "label5";
            label5.Size = new Size(136, 21);
            label5.TabIndex = 6;
            label5.Text = "Szolgáltatási szint:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 179);
            label3.Name = "label3";
            label3.Size = new Size(108, 21);
            label3.TabIndex = 5;
            label3.Text = "Távozás napja:";
            // 
            // dtpEnd
            // 
            dtpEnd.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dtpEnd.Location = new Point(119, 173);
            dtpEnd.MinDate = new DateTime(2026, 4, 28, 0, 0, 0, 0);
            dtpEnd.Name = "dtpEnd";
            dtpEnd.Size = new Size(225, 29);
            dtpEnd.TabIndex = 4;
            // 
            // lbCheckInDate
            // 
            lbCheckInDate.AutoSize = true;
            lbCheckInDate.Location = new Point(7, 133);
            lbCheckInDate.Name = "lbCheckInDate";
            lbCheckInDate.Size = new Size(107, 21);
            lbCheckInDate.TabIndex = 3;
            lbCheckInDate.Text = "Érkezés napja:";
            // 
            // lbRoomNum
            // 
            lbRoomNum.AutoSize = true;
            lbRoomNum.Location = new Point(23, 41);
            lbRoomNum.Name = "lbRoomNum";
            lbRoomNum.Size = new Size(91, 21);
            lbRoomNum.TabIndex = 2;
            lbRoomNum.Text = "Szobaszám:";
            // 
            // gbGuest
            // 
            gbGuest.Controls.Add(tbGuestId);
            gbGuest.Controls.Add(label2);
            gbGuest.Controls.Add(lbEmail);
            gbGuest.Controls.Add(tbEmail);
            gbGuest.Controls.Add(lbPhone);
            gbGuest.Controls.Add(tbPhone);
            gbGuest.Controls.Add(lbName);
            gbGuest.Controls.Add(tbName);
            gbGuest.Font = new Font("Segoe UI", 12F);
            gbGuest.Location = new Point(3, 3);
            gbGuest.Name = "gbGuest";
            gbGuest.Size = new Size(296, 244);
            gbGuest.TabIndex = 0;
            gbGuest.TabStop = false;
            gbGuest.Text = "Vendég adatai:";
            // 
            // tbGuestId
            // 
            tbGuestId.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tbGuestId.Location = new Point(110, 178);
            tbGuestId.Name = "tbGuestId";
            tbGuestId.Size = new Size(161, 29);
            tbGuestId.TabIndex = 10;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(18, 181);
            label2.Name = "label2";
            label2.Size = new Size(86, 21);
            label2.TabIndex = 9;
            label2.Text = "SZIG szám:";
            // 
            // lbEmail
            // 
            lbEmail.AutoSize = true;
            lbEmail.Location = new Point(18, 135);
            lbEmail.Name = "lbEmail";
            lbEmail.Size = new Size(86, 21);
            lbEmail.TabIndex = 8;
            lbEmail.Text = "E-mail cím:";
            // 
            // tbEmail
            // 
            tbEmail.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tbEmail.Location = new Point(110, 132);
            tbEmail.Name = "tbEmail";
            tbEmail.Size = new Size(161, 29);
            tbEmail.TabIndex = 7;
            // 
            // lbPhone
            // 
            lbPhone.AutoSize = true;
            lbPhone.Location = new Point(6, 89);
            lbPhone.Name = "lbPhone";
            lbPhone.Size = new Size(98, 21);
            lbPhone.TabIndex = 6;
            lbPhone.Text = "Telefonszám:";
            // 
            // tbPhone
            // 
            tbPhone.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tbPhone.Location = new Point(110, 86);
            tbPhone.Name = "tbPhone";
            tbPhone.Size = new Size(161, 29);
            tbPhone.TabIndex = 5;
            // 
            // lbName
            // 
            lbName.AutoSize = true;
            lbName.Location = new Point(63, 43);
            lbName.Name = "lbName";
            lbName.Size = new Size(41, 21);
            lbName.TabIndex = 4;
            lbName.Text = "Név:";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 36.868187F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.20119F));
            tableLayoutPanel1.Controls.Add(gbGuest, 0, 0);
            tableLayoutPanel1.Controls.Add(groupBox1, 2, 0);
            tableLayoutPanel1.Controls.Add(gpRooms, 1, 0);
            tableLayoutPanel1.Controls.Add(dgvBookings, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 250F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(1009, 561);
            tableLayoutPanel1.TabIndex = 3;
            // 
            // dgvBookings
            // 
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.ButtonFace;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvBookings.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvBookings.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBookings.Columns.AddRange(new DataGridViewColumn[] { colRoomNumber, colBegOfStay, colEndOfStay, colCheckIn, colCheckOut, colLevelOfService });
            tableLayoutPanel1.SetColumnSpan(dgvBookings, 3);
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.BackColor = SystemColors.Window;
            dataGridViewCellStyle8.Font = new Font("Segoe UI", 12F);
            dataGridViewCellStyle8.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = DataGridViewTriState.False;
            dgvBookings.DefaultCellStyle = dataGridViewCellStyle8;
            dgvBookings.Dock = DockStyle.Fill;
            dgvBookings.Location = new Point(5, 255);
            dgvBookings.Margin = new Padding(5);
            dgvBookings.Name = "dgvBookings";
            dgvBookings.RowHeadersVisible = false;
            dgvBookings.Size = new Size(999, 301);
            dgvBookings.TabIndex = 3;
            // 
            // colRoomNumber
            // 
            colRoomNumber.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colRoomNumber.DataPropertyName = "RoomNumber";
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colRoomNumber.DefaultCellStyle = dataGridViewCellStyle2;
            colRoomNumber.HeaderText = "Szobaszám";
            colRoomNumber.Name = "colRoomNumber";
            colRoomNumber.ReadOnly = true;
            // 
            // colBegOfStay
            // 
            colBegOfStay.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colBegOfStay.DataPropertyName = "BeginningOfStay";
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colBegOfStay.DefaultCellStyle = dataGridViewCellStyle3;
            colBegOfStay.HeaderText = "Foglalás kezdete";
            colBegOfStay.Name = "colBegOfStay";
            colBegOfStay.ReadOnly = true;
            // 
            // colEndOfStay
            // 
            colEndOfStay.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colEndOfStay.DataPropertyName = "EndOfStay";
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colEndOfStay.DefaultCellStyle = dataGridViewCellStyle4;
            colEndOfStay.HeaderText = "Foglalás vége";
            colEndOfStay.Name = "colEndOfStay";
            colEndOfStay.ReadOnly = true;
            // 
            // colCheckIn
            // 
            colCheckIn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colCheckIn.DataPropertyName = "CheckinDisplay";
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.ForeColor = Color.Black;
            colCheckIn.DefaultCellStyle = dataGridViewCellStyle5;
            colCheckIn.HeaderText = "Becsekkolás";
            colCheckIn.Name = "colCheckIn";
            colCheckIn.ReadOnly = true;
            // 
            // colCheckOut
            // 
            colCheckOut.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colCheckOut.DataPropertyName = "Checkout";
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.BottomCenter;
            colCheckOut.DefaultCellStyle = dataGridViewCellStyle6;
            colCheckOut.HeaderText = "Kicsekkolás";
            colCheckOut.Name = "colCheckOut";
            colCheckOut.ReadOnly = true;
            // 
            // colLevelOfService
            // 
            colLevelOfService.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colLevelOfService.DataPropertyName = "LevelOfService";
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colLevelOfService.DefaultCellStyle = dataGridViewCellStyle7;
            colLevelOfService.HeaderText = "Szolgáltatási szint";
            colLevelOfService.Name = "colLevelOfService";
            colLevelOfService.ReadOnly = true;
            // 
            // BookingControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel1);
            Name = "BookingControl";
            Size = new Size(1009, 561);
            Load += BookingControl_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            gpRooms.ResumeLayout(false);
            gpRooms.PerformLayout();
            gbGuest.ResumeLayout(false);
            gbGuest.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvBookings).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private ComboBox cbRoomNum;
        private DateTimePicker dtpStart;
        private TextBox tbName;
        private Button btnSave;
        private GroupBox gbGuest;
        private Label lbEmail;
        private TextBox tbEmail;
        private Label lbPhone;
        private TextBox tbPhone;
        private Label lbName;
        private GroupBox gpRooms;
        private Label lbRoomNum;
        private Label label3;
        private DateTimePicker dtpEnd;
        private Label lbCheckInDate;
        private GroupBox groupBox1;
        private Label lbSumTotal;
        private Label label1;
        private Button btnClear;
        private Label label4;
        private TableLayoutPanel tableLayoutPanel1;
        private DataGridView dgvBookings;
        private DataGridViewTextBoxColumn colRoomNumber;
        private DataGridViewTextBoxColumn colBegOfStay;
        private DataGridViewTextBoxColumn colEndOfStay;
        private DataGridViewTextBoxColumn colCheckIn;
        private DataGridViewTextBoxColumn colCheckOut;
        private DataGridViewTextBoxColumn colLevelOfService;
        private MaskedTextBox tbGuestId;
        private Label label2;
        private Label label5;
        private TextBox tbLevel;
    }
}
