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
            btnHousekeeping = new Button();
            btnStatistics = new Button();
            btnStock = new Button();
            btnServices = new Button();
            btnBookings = new Button();
            btnEmployees = new Button();
            panelRight = new Panel();
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
            pictureBox1.Location = new Point(49, -10);
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
            panelLeft.Controls.Add(btnHousekeeping);
            panelLeft.Controls.Add(btnStatistics);
            panelLeft.Controls.Add(btnStock);
            panelLeft.Controls.Add(btnServices);
            panelLeft.Controls.Add(btnBookings);
            panelLeft.Controls.Add(btnEmployees);
            panelLeft.Dock = DockStyle.Left;
            panelLeft.Location = new Point(0, 116);
            panelLeft.Name = "panelLeft";
            panelLeft.Size = new Size(262, 540);
            panelLeft.TabIndex = 1;
            // 
            // btnHousekeeping
            // 
            btnHousekeeping.BackColor = Color.Transparent;
            btnHousekeeping.Cursor = Cursors.Hand;
            btnHousekeeping.Dock = DockStyle.Top;
            btnHousekeeping.FlatAppearance.BorderSize = 0;
            btnHousekeeping.FlatAppearance.MouseOverBackColor = Color.FromArgb(59, 130, 246);
            btnHousekeeping.FlatStyle = FlatStyle.Flat;
            btnHousekeeping.Font = new Font("Segoe UI", 15F);
            btnHousekeeping.ForeColor = Color.Black;
            btnHousekeeping.Location = new Point(0, 265);
            btnHousekeeping.Name = "btnHousekeeping";
            btnHousekeeping.Size = new Size(262, 53);
            btnHousekeeping.TabIndex = 16;
            btnHousekeeping.Text = "Housekeeping";
            btnHousekeeping.UseVisualStyleBackColor = false;
            // 
            // btnStatistics
            // 
            btnStatistics.BackColor = Color.Transparent;
            btnStatistics.Cursor = Cursors.Hand;
            btnStatistics.Dock = DockStyle.Top;
            btnStatistics.FlatAppearance.BorderSize = 0;
            btnStatistics.FlatAppearance.MouseOverBackColor = Color.FromArgb(59, 130, 246);
            btnStatistics.FlatStyle = FlatStyle.Flat;
            btnStatistics.Font = new Font("Segoe UI", 15F);
            btnStatistics.ForeColor = Color.Black;
            btnStatistics.Location = new Point(0, 212);
            btnStatistics.Name = "btnStatistics";
            btnStatistics.Size = new Size(262, 53);
            btnStatistics.TabIndex = 18;
            btnStatistics.Text = "Statistics";
            btnStatistics.UseVisualStyleBackColor = false;
            // 
            // btnStock
            // 
            btnStock.BackColor = Color.Transparent;
            btnStock.Cursor = Cursors.Hand;
            btnStock.Dock = DockStyle.Top;
            btnStock.FlatAppearance.BorderSize = 0;
            btnStock.FlatAppearance.MouseOverBackColor = Color.FromArgb(59, 130, 246);
            btnStock.FlatStyle = FlatStyle.Flat;
            btnStock.Font = new Font("Segoe UI", 15F);
            btnStock.ForeColor = Color.Black;
            btnStock.Location = new Point(0, 159);
            btnStock.Name = "btnStock";
            btnStock.Size = new Size(262, 53);
            btnStock.TabIndex = 19;
            btnStock.Text = "Stock";
            btnStock.UseVisualStyleBackColor = false;
            // 
            // btnServices
            // 
            btnServices.BackColor = Color.Transparent;
            btnServices.Cursor = Cursors.Hand;
            btnServices.Dock = DockStyle.Top;
            btnServices.FlatAppearance.BorderSize = 0;
            btnServices.FlatAppearance.MouseOverBackColor = Color.FromArgb(59, 130, 246);
            btnServices.FlatStyle = FlatStyle.Flat;
            btnServices.Font = new Font("Segoe UI", 15F);
            btnServices.ForeColor = Color.Black;
            btnServices.Location = new Point(0, 106);
            btnServices.Name = "btnServices";
            btnServices.Size = new Size(262, 53);
            btnServices.TabIndex = 17;
            btnServices.Text = "Products";
            btnServices.UseVisualStyleBackColor = false;
            // 
            // btnBookings
            // 
            btnBookings.BackColor = Color.Transparent;
            btnBookings.Cursor = Cursors.Hand;
            btnBookings.Dock = DockStyle.Top;
            btnBookings.FlatAppearance.BorderSize = 0;
            btnBookings.FlatAppearance.MouseOverBackColor = Color.FromArgb(59, 130, 246);
            btnBookings.FlatStyle = FlatStyle.Flat;
            btnBookings.Font = new Font("Segoe UI", 15F);
            btnBookings.ForeColor = Color.Black;
            btnBookings.Location = new Point(0, 53);
            btnBookings.Name = "btnBookings";
            btnBookings.Size = new Size(262, 53);
            btnBookings.TabIndex = 15;
            btnBookings.Text = "Bookings";
            btnBookings.UseVisualStyleBackColor = false;
            // 
            // btnEmployees
            // 
            btnEmployees.BackColor = Color.Transparent;
            btnEmployees.Cursor = Cursors.Hand;
            btnEmployees.Dock = DockStyle.Top;
            btnEmployees.FlatAppearance.BorderSize = 0;
            btnEmployees.FlatAppearance.MouseOverBackColor = Color.FromArgb(59, 130, 246);
            btnEmployees.FlatStyle = FlatStyle.Flat;
            btnEmployees.Font = new Font("Segoe UI", 15F);
            btnEmployees.ForeColor = Color.Black;
            btnEmployees.Location = new Point(0, 0);
            btnEmployees.Name = "btnEmployees";
            btnEmployees.Size = new Size(262, 53);
            btnEmployees.TabIndex = 20;
            btnEmployees.Text = "Employees";
            btnEmployees.UseVisualStyleBackColor = false;
            btnEmployees.Click += btnEmployees_Click;
            // 
            // panelRight
            // 
            panelRight.Dock = DockStyle.Right;
            panelRight.Location = new Point(809, 116);
            panelRight.Name = "panelRight";
            panelRight.Size = new Size(424, 540);
            panelRight.TabIndex = 2;
            // 
            // panelMainContent
            // 
            panelMainContent.Controls.Add(lbWelcomeMainForm);
            panelMainContent.Dock = DockStyle.Fill;
            panelMainContent.Location = new Point(262, 116);
            panelMainContent.Name = "panelMainContent";
            panelMainContent.Size = new Size(547, 540);
            panelMainContent.TabIndex = 3;
            // 
            // lbWelcomeMainForm
            // 
            lbWelcomeMainForm.Dock = DockStyle.Fill;
            lbWelcomeMainForm.Font = new Font("Stencil", 50.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbWelcomeMainForm.ForeColor = Color.Teal;
            lbWelcomeMainForm.Location = new Point(0, 0);
            lbWelcomeMainForm.Name = "lbWelcomeMainForm";
            lbWelcomeMainForm.Size = new Size(547, 540);
            lbWelcomeMainForm.TabIndex = 0;
            lbWelcomeMainForm.Text = "valami";
            lbWelcomeMainForm.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonHighlight;
            ClientSize = new Size(1233, 656);
            Controls.Add(panelMainContent);
            Controls.Add(panelRight);
            Controls.Add(panelLeft);
            Controls.Add(panelHeader);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MinimizeBox = false;
            Name = "MainForm";
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
        private Button btnStock;
        private Button btnStatistics;
        private Button btnServices;
        private Button btnHousekeeping;
        private Button btnBookings;
        private UI.Controls.EmployeeControl.EmployeeControl employeeControl;
        private Panel panelRight;
        private Panel panelMainContent;
        private PictureBox pictureBox1;
        private Label lbControlTitle;
        private Label lbWelcomeMainForm;
    }
}
