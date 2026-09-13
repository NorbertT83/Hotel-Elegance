using Hotel_erp_Winforms_App.Forms;
using Hotel_erp_Winforms_App.Helpers;
using Hotel_erp_Winforms_App.Models;
using Hotel_erp_Winforms_App.UI.Controls;
using Hotel_erp_Winforms_App.UI.Controls.Dashboard;
using Hotel_erp_Winforms_App.UI.Controls.EmployeeControl;
using Hotel_erp_Winforms_App.UI.Controls.Rooms;

namespace Hotel_erp_Winforms_App
{
    public partial class FrmMain : Form
    {
        public readonly Employee currentuser;
        private List<Button> _menuButtons = new List<Button>();

        public FrmMain(Employee loggedInEmployee)
        {
            InitializeComponent();
            currentuser = loggedInEmployee;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Color sotetKek = Color.FromArgb(30, 58, 138);
            Color elenkKek = Color.FromArgb(59, 130, 246);
            Color feher = Color.White;

            panelLeft.BackColor = sotetKek;
            panelHeader.BackColor = feher;
            panelMainContent.BackColor = feher;

            _menuButtons = new List<Button>
            {
                btnDashBoard,
                btnBookings,
                btnGuests,
                btnRooms,
                btnHousekeeping,
                btnServices,
                btnEmployees
            };

            foreach (var btn in _menuButtons)
            {
                FormatMenuButton(btn, sotetKek, elenkKek, feher);
            }

            ShowDashboard();
            PermissionManager.ApplyPermissions(this);
        }

        private void SetActiveMenuButton(Button activeButton)
        {
            Color inaktivHatter = Color.Transparent;
            Color aktivHatter = Color.FromArgb(59, 130, 246);

            foreach (var btn in _menuButtons)
            {
                if (btn == activeButton)
                {
                    btn.BackColor = aktivHatter;
                    btn.Font = new Font(btn.Font, FontStyle.Bold);
                }
                else
                {
                    btn.BackColor = inaktivHatter;
                    btn.Font = new Font(btn.Font, FontStyle.Regular);
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            ShowDashboard();
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
            SetActiveMenuButton(btnBookings);
            ShowControl(new BookingControl());
            lbControlTitle.Text = "Bookings";
        }

        private void btnGuests_Click(object sender, EventArgs e)
        {
            SetActiveMenuButton(btnGuests);
            ShowControl(new GuestsControl());
            lbControlTitle.Text = "Guests";
        }

        private void btnRooms_Click(object sender, EventArgs e)
        {
            SetActiveMenuButton(btnRooms);
            ShowControl(new RoomsControl());
            lbControlTitle.Text = "Rooms Management";
        }

        private void btnHousekeeping_Click(object sender, EventArgs e)
        {
            SetActiveMenuButton(btnHousekeeping);
            ShowControl(new HousekeepingControl());
            lbControlTitle.Text = "Housekeeping";
        }

        private void btnServices_Click(object sender, EventArgs e)
        {
            SetActiveMenuButton(btnServices);
            ShowControl(new ProductContol());
            lbControlTitle.Text = "Services";
        }

        private void btnEmployees_Click(object sender, EventArgs e)
        {
            SetActiveMenuButton(btnEmployees);
            ShowControl(new EmployeeControl());
            lbControlTitle.Text = "Employees";
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            ShowDashboard();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to log out?",
                "Confirm Log Out",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                FrmLogin frmLogin = new FrmLogin();

                frmLogin.Show();
                this.Close();
            }
        }

        #endregion

        #region helpers

        private void ShowControl(UserControl control)
        {
            panelMainContent.SuspendLayout();
            panelMainContent.Controls.Clear();
            panelMainContent.Controls.Add(control);
            control.Dock = DockStyle.Fill;
            control.BringToFront();
            panelMainContent.ResumeLayout();
        }

        public void ShowDashboard()
        {
            SetActiveMenuButton(btnDashBoard);
            ShowControl(new DashboardControl(currentuser));
            lbControlTitle.Text = "Dashboard";
        }

        #endregion
    }
}