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
            panelHeader = new Panel();
            pictureBox1 = new PictureBox();
            lbControlTitle = new Label();
            panelLeft = new Panel();
            btnSettings = new Button();
            btnMaintenance = new Button();
            btnBilling = new Button();
            btnGuests = new Button();
            btnHousekeeping = new Button();
            btnStatistics = new Button();
            btnServices = new Button();
            btnBookings = new Button();
            btnEmployees = new Button();
            panelMainContent = new Panel();
            lbWelcomeMainForm = new Label();
            panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panelLeft.SuspendLayout();
            panelMainContent.SuspendLayout();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BorderStyle = BorderStyle.FixedSingle;
            panelHeader.Controls.Add(pictureBox1);
            panelHeader.Controls.Add(lbControlTitle);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(1233, 116);
            panelHeader.TabIndex = 0;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.hotel_logo;
            pictureBox1.Location = new Point(11, -1);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(158, 134);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // lbControlTitle
            // 
            lbControlTitle.Dock = DockStyle.Top;
            lbControlTitle.Font = new Font("Segoe UI", 36F, FontStyle.Bold, GraphicsUnit.Point, 238);
            lbControlTitle.Location = new Point(0, 0);
            lbControlTitle.Name = "lbControlTitle";
            lbControlTitle.Size = new Size(1231, 114);
            lbControlTitle.TabIndex = 1;
            lbControlTitle.Text = "Home Page";
            lbControlTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panelLeft
            // 
            panelLeft.Controls.Add(btnSettings);
            panelLeft.Controls.Add(btnStatistics);
            panelLeft.Controls.Add(btnEmployees);
            panelLeft.Controls.Add(btnMaintenance);
            panelLeft.Controls.Add(btnBilling);
            panelLeft.Controls.Add(btnServices);
            panelLeft.Controls.Add(btnHousekeeping);
            panelLeft.Controls.Add(btnGuests);
            panelLeft.Controls.Add(btnBookings);
            panelLeft.Dock = DockStyle.Left;
            panelLeft.Location = new Point(0, 116);
            panelLeft.Name = "panelLeft";
            panelLeft.Size = new Size(183, 540);
            panelLeft.TabIndex = 1;
            // 
            // btnSettings
            // 
            btnSettings.BackColor = Color.FromArgb(30, 58, 138);
            btnSettings.Cursor = Cursors.Hand;
            btnSettings.Dock = DockStyle.Top;
            btnSettings.FlatAppearance.BorderSize = 0;
            btnSettings.FlatAppearance.MouseOverBackColor = Color.FromArgb(59, 130, 246);
            btnSettings.FlatStyle = FlatStyle.Flat;
            btnSettings.Font = new Font("Segoe UI", 15F);
            btnSettings.ForeColor = Color.White;
            btnSettings.Location = new Point(0, 424);
            btnSettings.Name = "btnSettings";
            btnSettings.Padding = new Padding(20, 0, 0, 0);
            btnSettings.Size = new Size(183, 53);
            btnSettings.TabIndex = 16;
            btnSettings.Text = "Settings";
            btnSettings.TextAlign = ContentAlignment.MiddleLeft;
            btnSettings.UseVisualStyleBackColor = false;
            btnSettings.Click += btnSettings_Click;
            // 
            // btnMaintenance
            // 
            btnMaintenance.BackColor = Color.FromArgb(30, 58, 138);
            btnMaintenance.Cursor = Cursors.Hand;
            btnMaintenance.Dock = DockStyle.Top;
            btnMaintenance.FlatAppearance.BorderSize = 0;
            btnMaintenance.FlatAppearance.MouseOverBackColor = Color.FromArgb(59, 130, 246);
            btnMaintenance.FlatStyle = FlatStyle.Flat;
            btnMaintenance.Font = new Font("Segoe UI", 15F);
            btnMaintenance.ForeColor = Color.White;
            btnMaintenance.Location = new Point(0, 265);
            btnMaintenance.Name = "btnMaintenance";
            btnMaintenance.Padding = new Padding(20, 0, 0, 0);
            btnMaintenance.Size = new Size(183, 53);
            btnMaintenance.TabIndex = 16;
            btnMaintenance.Text = "Maintenance";
            btnMaintenance.TextAlign = ContentAlignment.MiddleLeft;
            btnMaintenance.UseVisualStyleBackColor = false;
            btnMaintenance.Click += btnMaintenance_Click;
            // 
            // btnBilling
            // 
            btnBilling.BackColor = Color.FromArgb(30, 58, 138);
            btnBilling.Cursor = Cursors.Hand;
            btnBilling.Dock = DockStyle.Top;
            btnBilling.FlatAppearance.BorderSize = 0;
            btnBilling.FlatAppearance.MouseOverBackColor = Color.FromArgb(59, 130, 246);
            btnBilling.FlatStyle = FlatStyle.Flat;
            btnBilling.Font = new Font("Segoe UI", 15F);
            btnBilling.ForeColor = Color.White;
            btnBilling.Location = new Point(0, 212);
            btnBilling.Name = "btnBilling";
            btnBilling.Padding = new Padding(20, 0, 0, 0);
            btnBilling.Size = new Size(183, 53);
            btnBilling.TabIndex = 16;
            btnBilling.Text = "Billing";
            btnBilling.TextAlign = ContentAlignment.MiddleLeft;
            btnBilling.UseVisualStyleBackColor = false;
            btnBilling.Click += btnBilling_Click;
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
            btnGuests.Location = new Point(0, 53);
            btnGuests.Name = "btnGuests";
            btnGuests.Padding = new Padding(20, 0, 0, 0);
            btnGuests.Size = new Size(183, 53);
            btnGuests.TabIndex = 16;
            btnGuests.Text = "Guests";
            btnGuests.TextAlign = ContentAlignment.MiddleLeft;
            btnGuests.UseVisualStyleBackColor = false;
            btnGuests.Click += btnGuests_Click;
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
            btnHousekeeping.Location = new Point(0, 106);
            btnHousekeeping.Name = "btnHousekeeping";
            btnHousekeeping.Padding = new Padding(20, 0, 0, 0);
            btnHousekeeping.Size = new Size(183, 53);
            btnHousekeeping.TabIndex = 16;
            btnHousekeeping.Text = "Housekeeping";
            btnHousekeeping.TextAlign = ContentAlignment.MiddleLeft;
            btnHousekeeping.UseVisualStyleBackColor = false;
            btnHousekeeping.Click += btnHousekeeping_Click;
            // 
            // btnStatistics
            // 
            btnStatistics.BackColor = Color.FromArgb(30, 58, 138);
            btnStatistics.Cursor = Cursors.Hand;
            btnStatistics.Dock = DockStyle.Top;
            btnStatistics.FlatAppearance.BorderSize = 0;
            btnStatistics.FlatAppearance.MouseOverBackColor = Color.FromArgb(59, 130, 246);
            btnStatistics.FlatStyle = FlatStyle.Flat;
            btnStatistics.Font = new Font("Segoe UI", 15F);
            btnStatistics.ForeColor = Color.White;
            btnStatistics.Location = new Point(0, 371);
            btnStatistics.Name = "btnStatistics";
            btnStatistics.Padding = new Padding(20, 0, 0, 0);
            btnStatistics.Size = new Size(183, 53);
            btnStatistics.TabIndex = 18;
            btnStatistics.Text = "Statistics";
            btnStatistics.TextAlign = ContentAlignment.MiddleLeft;
            btnStatistics.UseVisualStyleBackColor = false;
            btnStatistics.Click += btnStatistics_Click;
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
            btnServices.Location = new Point(0, 159);
            btnServices.Name = "btnServices";
            btnServices.Padding = new Padding(20, 0, 0, 0);
            btnServices.Size = new Size(183, 53);
            btnServices.TabIndex = 17;
            btnServices.Text = "Services";
            btnServices.TextAlign = ContentAlignment.MiddleLeft;
            btnServices.UseVisualStyleBackColor = false;
            btnServices.Click += btnServices_Click;
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
            btnBookings.Location = new Point(0, 0);
            btnBookings.Name = "btnBookings";
            btnBookings.Padding = new Padding(20, 0, 0, 0);
            btnBookings.Size = new Size(183, 53);
            btnBookings.TabIndex = 15;
            btnBookings.Text = "Bookings";
            btnBookings.TextAlign = ContentAlignment.MiddleLeft;
            btnBookings.UseVisualStyleBackColor = false;
            btnBookings.Click += btnBookings_Click;
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
            btnEmployees.Location = new Point(0, 318);
            btnEmployees.Name = "btnEmployees";
            btnEmployees.Padding = new Padding(20, 0, 0, 0);
            btnEmployees.Size = new Size(183, 53);
            btnEmployees.TabIndex = 20;
            btnEmployees.Text = "Employees";
            btnEmployees.TextAlign = ContentAlignment.MiddleLeft;
            btnEmployees.UseVisualStyleBackColor = false;
            btnEmployees.Click += btnEmployees_Click;
            // 
            // panelMainContent
            // 
            panelMainContent.Controls.Add(lbWelcomeMainForm);
            panelMainContent.Dock = DockStyle.Fill;
            panelMainContent.Location = new Point(183, 116);
            panelMainContent.Name = "panelMainContent";
            panelMainContent.Size = new Size(1050, 540);
            panelMainContent.TabIndex = 3;
            // 
            // lbWelcomeMainForm
            // 
            lbWelcomeMainForm.Dock = DockStyle.Fill;
            lbWelcomeMainForm.Font = new Font("Stencil", 50.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbWelcomeMainForm.ForeColor = Color.Teal;
            lbWelcomeMainForm.Location = new Point(0, 0);
            lbWelcomeMainForm.Name = "lbWelcomeMainForm";
            lbWelcomeMainForm.Size = new Size(1050, 540);
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
            Controls.Add(panelLeft);
            Controls.Add(panelHeader);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MinimizeBox = false;
            Name = "FrmMain";
            Text = "Kezdőoldal";
            WindowState = FormWindowState.Maximized;
            Load += MainForm_Load;
            panelHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panelLeft.ResumeLayout(false);
            panelMainContent.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panelLeft;
        private Panel panelHeader;
        private Button btnEmployees;
        private Button btnStatistics;
        private Button btnServices;
        private Button btnHousekeeping;
        private Button btnBookings;
        private Panel panelMainContent;
        private PictureBox pictureBox1;
        private Label lbControlTitle;
        private Label lbWelcomeMainForm;
        private Button btnMaintenance;
        private Button btnBilling;
        private Button btnGuests;
        private Button btnSettings;
    }
}
