using Hotel_erp_Winforms_App.Models;
using Hotel_erp_Winforms_App.UI.Controls;
using Hotel_erp_Winforms_App.UI.Controls.EmployeeControl;
using Hotel_erp_Winforms_App.UI.Forms.ServiceForms;
using Hotel_erp_Winforms_App.UI;
using System.Security.Cryptography;
using Hotel_erp_Winforms_App.Helpers;

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

        private void ShowControl(UserControl control)
        {
            panelMainContent.SuspendLayout();
            panelMainContent.Controls.Clear();
            panelMainContent.Controls.Add(control);
            control.Dock = DockStyle.Fill;
            control.BringToFront();
            panelMainContent.ResumeLayout();
        }

        private void btnBookings_Click(object sender, EventArgs e)
        {
            ShowControl(new BookingControl());
        }

        private void btnEmployees_Click(object sender, EventArgs e)
        {
            EmployeeControl employeeControl = new EmployeeControl();
            EmployeeSideControl sideControl = new EmployeeSideControl();

            employeeControl.EmployeeSelected += (src, employee) => sideControl.EmployeeDetails(employee);

            ShowControl(employeeControl);
            lbControlTitle.Text = "Employees";

            panelRight.SuspendLayout();
            panelRight.Controls.Clear();
            sideControl.Dock = DockStyle.Fill;
            panelRight.Controls.Add(sideControl);
            panelRight.ResumeLayout();

            if(currentuser != null)
            {
                sideControl.CurrentUserDetails(currentuser);
            }
            else if(SessionManager.CurrentUser != null)
            {
                sideControl.CurrentUserDetails(SessionManager.CurrentUser);
            }
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
            FormatMenuButton(btnStock, sotetKek, elenkKek, feher);
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
    }
}
