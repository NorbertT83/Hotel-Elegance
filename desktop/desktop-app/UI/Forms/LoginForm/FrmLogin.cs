using Hotel_erp_Winforms_App.Models;
using Hotel_erp_Winforms_App.Services;
using Hotel_erp_Winforms_App.Helpers;
using Hotel_erp_Winforms_App.UI.Forms;
using Hotel_erp_Winforms_App.Security;

namespace Hotel_erp_Winforms_App.Forms
{
    public partial class FrmLogin : Form
    {
        public Employee? loggedInEmployee = new Employee();

        public FrmLogin()
        {
            InitializeComponent();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            // FOR TESTING
            tbEmail.Text = "kocsis.gergo@ceg.hu";
            tbPassword.Text = "KocsisGergo1#";
            // -----------------------------------------------------------------------

            System.Diagnostics.Debug.WriteLine($"Employees id = 11 email: kocsis.gergo@ceg.hu // Manager");
            System.Diagnostics.Debug.WriteLine($"Employees id = 1 jelszava: KocsisGergo1# ");
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            EmployeeService _employeeService = new EmployeeService();

            loggedInEmployee = new Employee();

            loggedInEmployee = await _employeeService.GetEmployeeByEmailAsync(tbEmail.Text.Trim().ToLower());

            if (loggedInEmployee != null)
            {
                CurrentUser.Id = loggedInEmployee.Id;
                CurrentUser.Name = loggedInEmployee.FName ?? "User";
                CurrentUser.Role = loggedInEmployee.JobTitle.ToString() switch
                {
                    "HK Manager" => UserRole.HKManager,
                    "Receptionist" => UserRole.Receptionist,
                    "Front Office Manager" => UserRole.FrontOffMan,
                    "Hotel Manager" => UserRole.Manager,
                    "Admin" => UserRole.Admin,
                    _ => UserRole.Guest
                };

                string password = tbPassword.Text.Trim();

                if (PasswordHelper.VerifyPassword(password, loggedInEmployee.Password) == false)
                {
                    MessageBox.Show(
                        "Invalid email address or password. Please try again.",
                        "Login Failed",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    tbPassword.Clear();

                    return;
                }



                else
                {
                    Cursor.Current = Cursors.WaitCursor;
                    FrmMain mainForm = new FrmMain(loggedInEmployee);
                    mainForm.Show();
                    this.Hide();
                    Cursor.Current = Cursors.Default;
                }
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

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            bool hidePassword = !chkShowPassword.Checked;

            tbPassword.UseSystemPasswordChar = hidePassword;
        }
    }
}
