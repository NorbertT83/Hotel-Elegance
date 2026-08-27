using Hotel_erp_Winforms_App.Models;
using Hotel_erp_Winforms_App.UI.Controls;
using Hotel_erp_Winforms_App.UI.Controls.EmployeeControl;
using Hotel_erp_Winforms_App.UI.Forms.ServiceForms;
using Hotel_erp_Winforms_App.UI;
using Hotel_erp_Winforms_App.UI.Controls;
using Hotel_erp_Winforms_App.UI.Controls.Maintenance;
using Hotel_erp_Winforms_App.UI.Controls.Settings;

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
            Color vilagosKek = Color.FromArgb(239, 246, 255);
            Color feher = Color.White;

            panelLeft.BackColor = sotetKek;
            panelHeader.BackColor = feher;
            panelMainContent.BackColor = feher;

            FormatMenuButton(btnBookings, sotetKek, elenkKek, feher);
            FormatMenuButton(btnEmployees, sotetKek, elenkKek, feher);
            FormatMenuButton(btnServices, sotetKek, elenkKek, feher);
            FormatMenuButton(btnStatistics, sotetKek, elenkKek, feher);
            FormatMenuButton(btnHousekeeping, sotetKek, elenkKek, feher);
        }

        private void FormatMenuButton(Button btn, Color backColor, Color hoverColor, Color textColor)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.BackColor = Color.Transparent;
            btn.ForeColor = textColor;
            btn.FlatAppearance.MouseOverBackColor = hoverColor;
            btn.FlatAppearance.MouseDownBackColor = hoverColor;
        }

        #region Menu buttons
        private void btnServices_Click(object sender, EventArgs e)
        {
            lbControlTitle.Text = "Services";

            ProductContol productContol = new ProductContol();

            ShowControl(productContol);
        }

        private void btnStatistics_Click(object sender, EventArgs e)
        {
            lbControlTitle.Text = "Statistics";

            StatisticsControl statControl = new StatisticsControl();

            ShowControl(statControl);
        }

        private void btnHousekeeping_Click(object sender, EventArgs e)
        {
            lbControlTitle.Text = "Housekeeping";

            HousekeepingControl hkControl = new HousekeepingControl();

            ShowControl(hkControl);
        }

        private void btnBookings_Click(object sender, EventArgs e)
        {
            ShowControl(new BookingControl());
            lbControlTitle.Text = "Bookings";
        }

        private void btnEmployees_Click(object sender, EventArgs e)
        {
            EmployeeControl employeeControl = new EmployeeControl();

            ShowControl(employeeControl);
            lbControlTitle.Text = "Employees";

            btnBookings.BackColor = Color.FromArgb(40, 70, 120);
        }

        private void btnGuests_Click(object sender, EventArgs e)
        {
            ShowControl(new GuestsControl());
            lbControlTitle.Text = "Guests";
        }

        private void btnBilling_Click(object sender, EventArgs e)
        {
            ShowControl(new Hotel_erp_Winforms_App.UI.Controls.BillingsControl());
            lbControlTitle.Text = "Billings and Invoicing";
        }

        private void btnMaintenance_Click(object sender, EventArgs e)
        {
            ShowControl(new MaintenanceControl());
            lbControlTitle.Text = "Maintenance and Technical";
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
