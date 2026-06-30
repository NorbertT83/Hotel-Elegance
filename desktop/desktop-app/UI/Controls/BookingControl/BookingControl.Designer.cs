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
            panel1 = new Panel();
            panel3 = new Panel();
            btnFinished = new Button();
            btnIncoming = new Button();
            btnCurrent = new Button();
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
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBookings).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(239, 246, 255);
            panel1.Controls.Add(panel3);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1009, 130);
            panel1.TabIndex = 0;
            // 
            // panel3
            // 
            panel3.Controls.Add(btnFinished);
            panel3.Controls.Add(btnIncoming);
            panel3.Controls.Add(btnCurrent);
            panel3.Dock = DockStyle.Left;
            panel3.Location = new Point(0, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(196, 130);
            panel3.TabIndex = 1;
            // 
            // btnFinished
            // 
            btnFinished.BackColor = Color.White;
            btnFinished.Dock = DockStyle.Top;
            btnFinished.FlatStyle = FlatStyle.Flat;
            btnFinished.Font = new Font("Segoe UI", 13F);
            btnFinished.Location = new Point(0, 89);
            btnFinished.Name = "btnFinished";
            btnFinished.Size = new Size(196, 43);
            btnFinished.TabIndex = 0;
            btnFinished.Text = "Finished";
            btnFinished.UseVisualStyleBackColor = false;
            btnFinished.Click += btnFinished_Click;
            // 
            // btnIncoming
            // 
            btnIncoming.BackColor = Color.White;
            btnIncoming.Dock = DockStyle.Top;
            btnIncoming.FlatStyle = FlatStyle.Flat;
            btnIncoming.Font = new Font("Segoe UI", 13F);
            btnIncoming.Location = new Point(0, 45);
            btnIncoming.Name = "btnIncoming";
            btnIncoming.Size = new Size(196, 44);
            btnIncoming.TabIndex = 0;
            btnIncoming.Text = "Incoming";
            btnIncoming.UseVisualStyleBackColor = false;
            btnIncoming.Click += btnIncoming_Click;
            // 
            // btnCurrent
            // 
            btnCurrent.BackColor = Color.White;
            btnCurrent.Dock = DockStyle.Top;
            btnCurrent.FlatStyle = FlatStyle.Flat;
            btnCurrent.Font = new Font("Segoe UI", 13F);
            btnCurrent.Location = new Point(0, 0);
            btnCurrent.Name = "btnCurrent";
            btnCurrent.Size = new Size(196, 45);
            btnCurrent.TabIndex = 0;
            btnCurrent.Text = "Current";
            btnCurrent.UseVisualStyleBackColor = false;
            btnCurrent.Click += btnCurrent_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(dgvBookings);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 130);
            panel2.Name = "panel2";
            panel2.Size = new Size(1009, 431);
            panel2.TabIndex = 1;
            // 
            // dgvBookings
            // 
            dgvBookings.BackgroundColor = Color.White;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.ButtonFace;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvBookings.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvBookings.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBookings.Columns.AddRange(new DataGridViewColumn[] { BookingId, colRoomNumber, RoomType, colBegOfStay, colEndOfStay, colCheckIn, colCheckOut, colLevelOfService });
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = SystemColors.Window;
            dataGridViewCellStyle8.Font = new Font("Segoe UI", 12F);
            dataGridViewCellStyle8.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = DataGridViewTriState.False;
            dgvBookings.DefaultCellStyle = dataGridViewCellStyle8;
            dgvBookings.Dock = DockStyle.Fill;
            dgvBookings.Location = new Point(0, 0);
            dgvBookings.Margin = new Padding(5);
            dgvBookings.Name = "dgvBookings";
            dgvBookings.RowHeadersVisible = false;
            dgvBookings.Size = new Size(1009, 431);
            dgvBookings.TabIndex = 4;
            // 
            // BookingId
            // 
            BookingId.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            BookingId.DataPropertyName = "Id";
            BookingId.FillWeight = 120F;
            BookingId.HeaderText = "Booking ID";
            BookingId.Name = "BookingId";
            BookingId.ReadOnly = true;
            // 
            // colRoomNumber
            // 
            colRoomNumber.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colRoomNumber.DataPropertyName = "RoomNumber";
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colRoomNumber.DefaultCellStyle = dataGridViewCellStyle2;
            colRoomNumber.HeaderText = "Room Number";
            colRoomNumber.Name = "colRoomNumber";
            colRoomNumber.ReadOnly = true;
            // 
            // RoomType
            // 
            RoomType.DataPropertyName = "SelectedRoomType";
            RoomType.HeaderText = "Room Type";
            RoomType.Name = "RoomType";
            RoomType.ReadOnly = true;
            // 
            // colBegOfStay
            // 
            colBegOfStay.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colBegOfStay.DataPropertyName = "BeginningOfStay";
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colBegOfStay.DefaultCellStyle = dataGridViewCellStyle3;
            colBegOfStay.FillWeight = 150F;
            colBegOfStay.HeaderText = "Beginning Of Stay";
            colBegOfStay.Name = "colBegOfStay";
            colBegOfStay.ReadOnly = true;
            // 
            // colEndOfStay
            // 
            colEndOfStay.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colEndOfStay.DataPropertyName = "EndOfStay";
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colEndOfStay.DefaultCellStyle = dataGridViewCellStyle4;
            colEndOfStay.FillWeight = 150F;
            colEndOfStay.HeaderText = "End Of Stay";
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
            colCheckIn.FillWeight = 150F;
            colCheckIn.HeaderText = "Check In";
            colCheckIn.Name = "colCheckIn";
            colCheckIn.ReadOnly = true;
            // 
            // colCheckOut
            // 
            colCheckOut.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colCheckOut.DataPropertyName = "CheckoutDisplay";
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.BottomCenter;
            colCheckOut.DefaultCellStyle = dataGridViewCellStyle6;
            colCheckOut.FillWeight = 150F;
            colCheckOut.HeaderText = "Check Out";
            colCheckOut.Name = "colCheckOut";
            colCheckOut.ReadOnly = true;
            // 
            // colLevelOfService
            // 
            colLevelOfService.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colLevelOfService.DataPropertyName = "SelectedCateringLevel";
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colLevelOfService.DefaultCellStyle = dataGridViewCellStyle7;
            colLevelOfService.HeaderText = "Catering Level";
            colLevelOfService.Name = "colLevelOfService";
            colLevelOfService.ReadOnly = true;
            // 
            // BookingControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "BookingControl";
            Size = new Size(1009, 561);
            Load += BookingControl_Load;
            panel1.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvBookings).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private DataGridView dgvBookings;
        private DataGridViewTextBoxColumn BookingId;
        private DataGridViewTextBoxColumn colRoomNumber;
        private DataGridViewTextBoxColumn RoomType;
        private DataGridViewTextBoxColumn colBegOfStay;
        private DataGridViewTextBoxColumn colEndOfStay;
        private DataGridViewTextBoxColumn colCheckIn;
        private DataGridViewTextBoxColumn colCheckOut;
        private DataGridViewTextBoxColumn colLevelOfService;
        private Panel panel3;
        private Button btnFinished;
        private Button btnIncoming;
        private Button btnCurrent;
    }
}
