using Hotel_erp_Winforms_App.Models;
using Hotel_erp_Winforms_App.Services;
using Hotel_erp_Winforms_App.Helpers;
using Hotel_erp_Winforms_App.UI.Forms;

namespace Hotel_erp_Winforms_App.Forms
{
    public partial class FrmLogin : Form
    {
        public Employee loggedInEmployee = new Employee();

        public FrmLogin()
        {
            InitializeComponent();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            tbTaxNumber.Text = "TX100001";
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            //if (cbJobTitle.SelectedItem == null)
            //{
            //    MessageBox.Show(
            //        "Please select a title first!",
            //        "Selection Required",
            //        MessageBoxButtons.OK,
            //        MessageBoxIcon.Error);

            //    return;
            //}

            EmployeeService _employeeService = new EmployeeService();

            loggedInEmployee = _employeeService.GetEmployeeByTaxNumber(tbTaxNumber.Text.Trim());

            if (loggedInEmployee != null)
            {
                UserRole defaultUserRole = cbJobTitle.SelectedIndex switch
                {
                    0 => UserRole.Admin,
                    1 => UserRole.Manager,
                    2 => UserRole.Guest,
                    _ => UserRole.Guest
                };

                CurrentUser.Id = loggedInEmployee.Id;
                CurrentUser.Username = loggedInEmployee.FName ?? "User";
                CurrentUser.Role = loggedInEmployee.JobTitle.ToString() switch
                {
                    "HK Manager" => UserRole.HKManager,
                    "Receptionist" => UserRole.Receptionist,
                    "Front Office Manager" => UserRole.FrontOffMan,
                    _ => defaultUserRole
                };

                //if (cbJobTitle.SelectedItem is UserRole selectedRole)
                //{
                //    CurrentUser.Role = selectedRole;
                //}
                //else
                //{
                //    CurrentUser.Role = UserRole.Guest;
                //}

                FrmMain mainForm = new FrmMain(loggedInEmployee);
                mainForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("A felhasználó nem létezik!", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmRegistration registrationForm = new FrmRegistration();
            registrationForm.Show();
            this.Close();
        }
    }
}
