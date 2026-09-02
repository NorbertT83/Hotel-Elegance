using Hotel_erp_Winforms_App.Models;
using Hotel_erp_Winforms_App.UI.Controls;
using Hotel_erp_Winforms_App.UI.Controls.EmployeeControl;
using Hotel_erp_Winforms_App.UI.Controls.Settings;
using Hotel_erp_Winforms_App.UI.Controls.Rooms;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Hotel_erp_Winforms_App
{
    public partial class FrmMain : Form
    {
        public readonly Employee currentuser;

        public FrmMain(Employee loggedInEmployee)
        {
            InitializeComponent();
            currentuser = loggedInEmployee;
            lbWelcomeMainForm.Text = $"Welcome {loggedInEmployee.FName}!";
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Color sotetKek = Color.FromArgb(30, 58, 138);
            Color elenkKek = Color.FromArgb(59, 130, 246);
            Color feher = Color.White;

            panelLeft.BackColor = sotetKek;
            panelHeader.BackColor = feher;
            panelMainContent.BackColor = feher;

            FormatMenuButton(btnBookings, sotetKek, elenkKek, feher);
            FormatMenuButton(btnGuests, sotetKek, elenkKek, feher);
            FormatMenuButton(btnRooms, sotetKek, elenkKek, feher);
            FormatMenuButton(btnHousekeeping, sotetKek, elenkKek, feher);
            FormatMenuButton(btnServices, sotetKek, elenkKek, feher);
            FormatMenuButton(btnBilling, sotetKek, elenkKek, feher);
            FormatMenuButton(btnEmployees, sotetKek, elenkKek, feher);
            FormatMenuButton(btnStatistics, sotetKek, elenkKek, feher);
            FormatMenuButton(btnSettings, sotetKek, elenkKek, feher);
        }

        private void FormatMenuButton(Button btn, Color backColor, Color hoverColor, Color textColor)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.BackColor = Color.Transparent;
            btn.ForeColor = textColor;
            btn.FlatAppearance.MouseOverBackColor = hoverColor;
        }

        #region Menu buttons
        private void btnBookings_Click(object sender, EventArgs e)
        {
            ShowControl(new BookingControl());
            lbControlTitle.Text = "Bookings";
        }

        private void btnGuests_Click(object sender, EventArgs e)
        {
            ShowControl(new GuestsControl());
            lbControlTitle.Text = "Guests";
        }

        private void btnRooms_Click(object sender, EventArgs e)
        {
            ShowControl(new RoomsControl());
            lbControlTitle.Text = "Rooms Management";
        }

        private void btnHousekeeping_Click(object sender, EventArgs e)
        {
            ShowControl(new HousekeepingControl());
            lbControlTitle.Text = "Housekeeping";
        }

        private void btnServices_Click(object sender, EventArgs e)
        {
            ShowControl(new ProductContol());
            lbControlTitle.Text = "Services";
        }

        private void btnBilling_Click(object sender, EventArgs e)
        {
            ShowControl(new BillingsControl());
            lbControlTitle.Text = "Billings and Invoicing";
        }

        private void btnEmployees_Click(object sender, EventArgs e)
        {
            ShowControl(new EmployeeControl());
            lbControlTitle.Text = "Employees";
        }

        private void btnStatistics_Click(object sender, EventArgs e)
        {
            ShowControl(new StatisticsControl());
            lbControlTitle.Text = "Statistics";
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            ShowControl(new SettingsControl());
            lbControlTitle.Text = "System Settings";
        }
        #endregion

        private void ShowControl(UserControl control)
        {
            panelMainContent.SuspendLayout();
            panelMainContent.Controls.Clear();
            panelMainContent.Controls.Add(control);
            control.Dock = DockStyle.Fill;
            control.BringToFront();
            panelMainContent.ResumeLayout();
        }
    }
}