namespace Hotel_erp_Winforms_App
{
    partial class FrmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            panelHeader = new Panel();
            pnlHeaderContent = new Panel();
            lbControlTitle = new Label();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            panelLeft = new Panel();
            pnlLogoutButtonHolder = new Panel();
            btnLogout = new Button();
            btnEmployees = new Button();
            btnRooms = new Button();
            btnServices = new Button();
            btnHousekeeping = new Button();
            btnGuests = new Button();
            btnBookings = new Button();
            btnDashBoard = new Button();
            pnlMenuHeader = new Panel();
            pictureBox2 = new PictureBox();
            label2 = new Label();
            panelMainContent = new Panel();
            lbWelcomeMainForm = new Label();
            panelHeader.SuspendLayout();
            pnlHeaderContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panelLeft.SuspendLayout();
            pnlLogoutButtonHolder.SuspendLayout();
            pnlMenuHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            panelMainContent.SuspendLayout();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BorderStyle = BorderStyle.FixedSingle;
            panelHeader.Controls.Add(pnlHeaderContent);
            panelHeader.Controls.Add(pictureBox1);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(229, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(1004, 159);
            panelHeader.TabIndex = 0;
            // 
            // pnlHeaderContent
            // 
            pnlHeaderContent.Controls.Add(lbControlTitle);
            pnlHeaderContent.Controls.Add(label1);
            pnlHeaderContent.Dock = DockStyle.Fill;
            pnlHeaderContent.Location = new Point(117, 0);
            pnlHeaderContent.Name = "pnlHeaderContent";
            pnlHeaderContent.Size = new Size(885, 157);
            pnlHeaderContent.TabIndex = 3;
            // 
            // lbControlTitle
            // 
            lbControlTitle.Font = new Font("Franklin Gothic Medium", 48F, FontStyle.Regular, GraphicsUnit.Point, 238);
            lbControlTitle.ForeColor = Color.FromArgb(30, 41, 59);
            lbControlTitle.Location = new Point(0, 26);
            lbControlTitle.Name = "lbControlTitle";
            lbControlTitle.Size = new Size(445, 73);
            lbControlTitle.TabIndex = 1;
            lbControlTitle.Text = "Housekeeping";
            lbControlTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label1.ForeColor = SystemColors.ControlDark;
            label1.Location = new Point(16, 99);
            label1.Name = "label1";
            label1.Size = new Size(321, 21);
            label1.TabIndex = 2;
            label1.Text = "Hotel Elegance Management System";
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Left;
            pictureBox1.Image = Properties.Resources.hotel_logo;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(117, 157);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // panelLeft
            // 
            panelLeft.Controls.Add(pnlLogoutButtonHolder);
            panelLeft.Controls.Add(btnEmployees);
            panelLeft.Controls.Add(btnRooms);
            panelLeft.Controls.Add(btnServices);
            panelLeft.Controls.Add(btnHousekeeping);
            panelLeft.Controls.Add(btnGuests);
            panelLeft.Controls.Add(btnBookings);
            panelLeft.Controls.Add(btnDashBoard);
            panelLeft.Controls.Add(pnlMenuHeader);
            panelLeft.Dock = DockStyle.Left;
            panelLeft.Location = new Point(0, 0);
            panelLeft.Name = "panelLeft";
            panelLeft.Size = new Size(229, 656);
            panelLeft.TabIndex = 1;
            // 
            // pnlLogoutButtonHolder
            // 
            pnlLogoutButtonHolder.Controls.Add(btnLogout);
            pnlLogoutButtonHolder.Dock = DockStyle.Bottom;
            pnlLogoutButtonHolder.Location = new Point(0, 556);
            pnlLogoutButtonHolder.Name = "pnlLogoutButtonHolder";
            pnlLogoutButtonHolder.Padding = new Padding(10);
            pnlLogoutButtonHolder.Size = new Size(229, 100);
            pnlLogoutButtonHolder.TabIndex = 21;
            // 
            // btnLogout
            // 
            btnLogout.BackColor = Color.FromArgb(30, 58, 138);
            btnLogout.Dock = DockStyle.Bottom;
            btnLogout.Font = new Font("Segoe UI", 12F);
            btnLogout.ForeColor = Color.White;
            btnLogout.Location = new Point(10, 43);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(209, 47);
            btnLogout.TabIndex = 0;
            btnLogout.Text = "Log Out";
            btnLogout.UseVisualStyleBackColor = false;
            btnLogout.Click += btnLogout_Click;
            // 
            // btnEmployees
            // 
            btnEmployees.BackColor = Color.FromArgb(30, 58, 138);
            btnEmployees.Cursor = Cursors.Hand;
            btnEmployees.Dock = DockStyle.Top;
            btnEmployees.FlatAppearance.BorderSize = 0;
            btnEmployees.FlatAppearance.MouseOverBackColor = Color.FromArgb(59, 130, 246);
            btnEmployees.FlatStyle = FlatStyle.Flat;
            btnEmployees.Font = new Font("Segoe UI", 15F);
            btnEmployees.ForeColor = Color.White;
            btnEmployees.Image = Properties.Resources.menuEmp;
            btnEmployees.ImageAlign = ContentAlignment.MiddleLeft;
            btnEmployees.Location = new Point(0, 418);
            btnEmployees.Name = "btnEmployees";
            btnEmployees.Padding = new Padding(20, 0, 0, 0);
            btnEmployees.Size = new Size(229, 53);
            btnEmployees.TabIndex = 20;
            btnEmployees.Text = "Employees";
            btnEmployees.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnEmployees.UseVisualStyleBackColor = false;
            btnEmployees.Click += btnEmployees_Click;
            // 
            // btnRooms
            // 
            btnRooms.BackColor = Color.FromArgb(30, 58, 138);
            btnRooms.Cursor = Cursors.Hand;
            btnRooms.Dock = DockStyle.Top;
            btnRooms.FlatAppearance.BorderSize = 0;
            btnRooms.FlatAppearance.MouseOverBackColor = Color.FromArgb(59, 130, 246);
            btnRooms.FlatStyle = FlatStyle.Flat;
            btnRooms.Font = new Font("Segoe UI", 15F);
            btnRooms.ForeColor = Color.White;
            btnRooms.Image = Properties.Resources.menuRooms;
            btnRooms.ImageAlign = ContentAlignment.MiddleLeft;
            btnRooms.Location = new Point(0, 365);
            btnRooms.Name = "btnRooms";
            btnRooms.Padding = new Padding(20, 0, 0, 0);
            btnRooms.Size = new Size(229, 53);
            btnRooms.TabIndex = 16;
            btnRooms.Text = "Rooms";
            btnRooms.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnRooms.UseVisualStyleBackColor = false;
            btnRooms.Click += btnRooms_Click;
            // 
            // btnServices
            // 
            btnServices.BackColor = Color.FromArgb(30, 58, 138);
            btnServices.Cursor = Cursors.Hand;
            btnServices.Dock = DockStyle.Top;
            btnServices.FlatAppearance.BorderSize = 0;
            btnServices.FlatAppearance.MouseOverBackColor = Color.FromArgb(59, 130, 246);
            btnServices.FlatStyle = FlatStyle.Flat;
            btnServices.Font = new Font("Segoe UI", 15F);
            btnServices.ForeColor = Color.White;
            btnServices.Image = Properties.Resources.menuServices;
            btnServices.ImageAlign = ContentAlignment.MiddleLeft;
            btnServices.Location = new Point(0, 312);
            btnServices.Name = "btnServices";
            btnServices.Padding = new Padding(20, 0, 0, 0);
            btnServices.Size = new Size(229, 53);
            btnServices.TabIndex = 17;
            btnServices.Text = "Services";
            btnServices.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnServices.UseVisualStyleBackColor = false;
            btnServices.Click += btnServices_Click;
            // 
            // btnHousekeeping
            // 
            btnHousekeeping.BackColor = Color.FromArgb(30, 58, 138);
            btnHousekeeping.Cursor = Cursors.Hand;
            btnHousekeeping.Dock = DockStyle.Top;
            btnHousekeeping.FlatAppearance.BorderSize = 0;
            btnHousekeeping.FlatAppearance.MouseOverBackColor = Color.FromArgb(59, 130, 246);
            btnHousekeeping.FlatStyle = FlatStyle.Flat;
            btnHousekeeping.Font = new Font("Segoe UI", 15F);
            btnHousekeeping.ForeColor = Color.White;
            btnHousekeeping.Image = Properties.Resources.menuHK;
            btnHousekeeping.ImageAlign = ContentAlignment.MiddleLeft;
            btnHousekeeping.Location = new Point(0, 259);
            btnHousekeeping.Name = "btnHousekeeping";
            btnHousekeeping.Padding = new Padding(20, 0, 0, 0);
            btnHousekeeping.Size = new Size(229, 53);
            btnHousekeeping.TabIndex = 16;
            btnHousekeeping.Text = "Housekeeping";
            btnHousekeeping.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnHousekeeping.UseVisualStyleBackColor = false;
            btnHousekeeping.Click += btnHousekeeping_Click;
            // 
            // btnGuests
            // 
            btnGuests.BackColor = Color.FromArgb(30, 58, 138);
            btnGuests.Cursor = Cursors.Hand;
            btnGuests.Dock = DockStyle.Top;
            btnGuests.FlatAppearance.BorderSize = 0;
            btnGuests.FlatAppearance.MouseOverBackColor = Color.FromArgb(59, 130, 246);
            btnGuests.FlatStyle = FlatStyle.Flat;
            btnGuests.Font = new Font("Segoe UI", 15F);
            btnGuests.ForeColor = Color.White;
            btnGuests.Image = Properties.Resources.menuGuests;
            btnGuests.ImageAlign = ContentAlignment.MiddleLeft;
            btnGuests.Location = new Point(0, 206);
            btnGuests.Name = "btnGuests";
            btnGuests.Padding = new Padding(20, 0, 0, 0);
            btnGuests.Size = new Size(229, 53);
            btnGuests.TabIndex = 16;
            btnGuests.Text = "Guests";
            btnGuests.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnGuests.UseVisualStyleBackColor = false;
            btnGuests.Click += btnGuests_Click;
            // 
            // btnBookings
            // 
            btnBookings.BackColor = Color.FromArgb(30, 58, 138);
            btnBookings.Cursor = Cursors.Hand;
            btnBookings.Dock = DockStyle.Top;
            btnBookings.FlatAppearance.BorderSize = 0;
            btnBookings.FlatAppearance.MouseOverBackColor = Color.FromArgb(59, 130, 246);
            btnBookings.FlatStyle = FlatStyle.Flat;
            btnBookings.Font = new Font("Segoe UI", 15F);
            btnBookings.ForeColor = Color.White;
            btnBookings.Image = Properties.Resources.menuCalendar;
            btnBookings.ImageAlign = ContentAlignment.MiddleLeft;
            btnBookings.Location = new Point(0, 153);
            btnBookings.Name = "btnBookings";
            btnBookings.Padding = new Padding(20, 0, 0, 0);
            btnBookings.Size = new Size(229, 53);
            btnBookings.TabIndex = 15;
            btnBookings.Text = "Bookings";
            btnBookings.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnBookings.UseVisualStyleBackColor = false;
            btnBookings.Click += btnBookings_Click;
            // 
            // btnDashBoard
            // 
            btnDashBoard.BackColor = Color.FromArgb(30, 58, 138);
            btnDashBoard.Cursor = Cursors.Hand;
            btnDashBoard.Dock = DockStyle.Top;
            btnDashBoard.FlatAppearance.BorderSize = 0;
            btnDashBoard.FlatAppearance.MouseOverBackColor = Color.FromArgb(59, 130, 246);
            btnDashBoard.FlatStyle = FlatStyle.Flat;
            btnDashBoard.Font = new Font("Segoe UI", 15F);
            btnDashBoard.ForeColor = Color.White;
            btnDashBoard.Image = Properties.Resources.menuHome;
            btnDashBoard.ImageAlign = ContentAlignment.MiddleLeft;
            btnDashBoard.Location = new Point(0, 100);
            btnDashBoard.Name = "btnDashBoard";
            btnDashBoard.Padding = new Padding(20, 0, 0, 0);
            btnDashBoard.Size = new Size(229, 53);
            btnDashBoard.TabIndex = 22;
            btnDashBoard.Text = "Dashboard";
            btnDashBoard.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnDashBoard.UseVisualStyleBackColor = false;
            btnDashBoard.Click += btnDashboard_Click;
            // 
            // pnlMenuHeader
            // 
            pnlMenuHeader.BackColor = Color.FromArgb(30, 58, 138);
            pnlMenuHeader.Controls.Add(pictureBox2);
            pnlMenuHeader.Controls.Add(label2);
            pnlMenuHeader.Dock = DockStyle.Top;
            pnlMenuHeader.Location = new Point(0, 0);
            pnlMenuHeader.Name = "pnlMenuHeader";
            pnlMenuHeader.Size = new Size(229, 100);
            pnlMenuHeader.TabIndex = 23;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.hotel_logo;
            pictureBox2.Location = new Point(12, 25);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(44, 50);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 1;
            pictureBox2.TabStop = false;
            // 
            // label2
            // 
            label2.Font = new Font("Segoe UI", 17F);
            label2.ForeColor = Color.White;
            label2.Location = new Point(52, 35);
            label2.Name = "label2";
            label2.Size = new Size(167, 30);
            label2.TabIndex = 0;
            label2.Text = "Hotel Elegance";
            // 
            // panelMainContent
            // 
            panelMainContent.Controls.Add(lbWelcomeMainForm);
            panelMainContent.Dock = DockStyle.Fill;
            panelMainContent.Location = new Point(229, 159);
            panelMainContent.Name = "panelMainContent";
            panelMainContent.Size = new Size(1004, 497);
            panelMainContent.TabIndex = 3;
            // 
            // lbWelcomeMainForm
            // 
            lbWelcomeMainForm.Dock = DockStyle.Bottom;
            lbWelcomeMainForm.Font = new Font("Stencil", 50.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbWelcomeMainForm.ForeColor = Color.Teal;
            lbWelcomeMainForm.Location = new Point(0, -22);
            lbWelcomeMainForm.Name = "lbWelcomeMainForm";
            lbWelcomeMainForm.Size = new Size(1004, 519);
            lbWelcomeMainForm.TabIndex = 0;
            lbWelcomeMainForm.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // FrmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonHighlight;
            ClientSize = new Size(1233, 656);
            Controls.Add(panelMainContent);
            Controls.Add(panelHeader);
            Controls.Add(panelLeft);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "FrmMain";
            Text = "Hotel Elegance BackOffice";
            WindowState = FormWindowState.Maximized;
            Load += MainForm_Load;
            panelHeader.ResumeLayout(false);
            pnlHeaderContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panelLeft.ResumeLayout(false);
            pnlLogoutButtonHolder.ResumeLayout(false);
            pnlMenuHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            panelMainContent.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panelLeft;
        private Panel panelHeader;
        private Button btnEmployees;
        private Button btnServices;
        private Button btnHousekeeping;
        private Button btnBookings;
        private Panel panelMainContent;
        private PictureBox pictureBox1;
        private Label lbControlTitle;
        private Label lbWelcomeMainForm;
        private Button btnRooms;
        private Button btnGuests;
        private Panel pnlLogoutButtonHolder;
        private Button btnLogout;
        private Button btnDashBoard;
        private Label label1;
        private Panel pnlMenuHeader;
        private Label label2;
        private PictureBox pictureBox2;
        private Panel pnlHeaderContent;
    }
}
