using Hotel_erp_Winforms_App.Security;
using Hotel_erp_Winforms_App.Services;
using Hotel_erp_Winforms_App.Models;
using Hotel_erp_Winforms_App.Helpers;
using Hotel_erp_Winforms_App.UI.Forms.ServiceForms.ChangeEmail;

namespace Hotel_erp_Winforms_App.UI.Forms.ServiceForms.AddBackOfficeProf
{
    public partial class AddBackOfficeProfileForm : Form
    {
        Employee _employee;

        public AddBackOfficeProfileForm(Employee selectedEmployee)
        {
            InitializeComponent();

            _employee = selectedEmployee;
        }

        #region variables

        EmployeeService _employeeService = new EmployeeService();
        CommonHelper commonHelper = new CommonHelper();

        #endregion

        #region onLoad functions

        private void AddBackOfficeProfileForm_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(_employee.Email))
            {
                tbEmail.Text = _employee.Email;
            }
        }

        #endregion

        #region buttons

        // GENERATE PASSWORD
        private void btnGeneratePassword_Click(object sender, EventArgs e)
        {
            const string lower = "abcdefghijklmnopqrstuvwxyz";
            const string upper = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string digits = "0123456789";
            const string special = "!@#$%^&*()_+-=";
            const string allChars = lower + upper + digits + special;

            var random = new Random();
            var chars = new char[12];

            chars[0] = lower[random.Next(lower.Length)];
            chars[1] = upper[random.Next(upper.Length)];
            chars[2] = digits[random.Next(digits.Length)];
            chars[3] = special[random.Next(special.Length)];

            for (int i = 4; i < chars.Length; i++)
            {
                chars[i] = allChars[random.Next(allChars.Length)];
            }

            for (int i = chars.Length - 1; i > 0; i--)
            {
                int j = random.Next(i + 1);
                var temp = chars[i];
                chars[i] = chars[j];
                chars[j] = temp;
            }

            string generatedPassword = new string(chars);

            tbPassword.Text = generatedPassword;
            tbConfirmPassword.Text = generatedPassword;
        }

        // SHOW PASSWORD
        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            tbPassword.PasswordChar = chkShowPassword.Checked ? '\0' : '*';
            tbConfirmPassword.PasswordChar = chkShowPassword.Checked ? '\0' : '*';
        }

        // SAVE
        private async void btnSave_Click(object sender, EventArgs e)
        {
            string email = tbEmail.Text.Trim();
            string password = tbPassword.Text;
            string confirmPassword = tbConfirmPassword.Text;

            if (!email.Contains('@') || string.IsNullOrWhiteSpace(tbEmail.Text))
            {
                MessageBox.Show(
                    "Please enter a valid email address containing an '@' symbol.",
                    "Invalid Email Format",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                tbEmail.Clear();
                tbEmail.Focus();

                return;
            }

            if (string.IsNullOrWhiteSpace(tbPassword.Text) || string.IsNullOrWhiteSpace(tbConfirmPassword.Text))
            {
                MessageBox.Show(
                    "Please enter a password.",
                    "Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                tbPassword.Focus();
                return;
            }

            var hasUpper = tbPassword.Text.Any(char.IsUpper);
            var hasLower = tbPassword.Text.Any(char.IsLower);
            var hasDigit = tbPassword.Text.Any(char.IsDigit);
            var hasSpecial = tbPassword.Text.Any(c => !char.IsLetterOrDigit(c));
            var isLongEnough = tbPassword.Text.Length >= 8;

            if (!isLongEnough || !hasUpper || !hasLower || !hasDigit || !hasSpecial)
            {
                MessageBox.Show(
                    "Password must be at least 8 characters long and contain:\n" +
                    "• At least one uppercase letter (A-Z)\n" +
                    "• At least one lowercase letter (a-z)\n" +
                    "• At least one number (0-9)\n" +
                    "• At least one special character (!@#$%^&*)",
                    "Weak Password",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                tbPassword.Clear();
                tbConfirmPassword.Clear();

                tbPassword.Focus();
                return;
            }

            if (password != tbConfirmPassword.Text)
            {
                MessageBox.Show(
                    "The passwords you entered do not match. Please check and try again.",
                    "Password Mismatch",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                tbPassword.Clear();
                tbConfirmPassword.Clear();

                tbPassword.Focus();

                return;
            }

            if (await _employeeService.IsEmailAlreadyUsed(email, _employeeService))
            {
                MessageBox.Show(
                    "This email address is already in use. Please enter a different one.",
                    "Email Already Exists",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                tbEmail.Clear();
                tbEmail.Focus();

                return;
            }

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                string hashedPassword = PasswordHelper.HashPassword(password);
                await _employeeService.SaveNewBackofficeProfileAsync(hashedPassword, email, _employee.Id);

                MessageBox.Show(
                    "BackOffice profile created successfully!",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                this.Close();
            }

            catch (Exception ex)
            {
                commonHelper.MBErrorMessage(ex);

                return;
            }

            finally
            {
                Cursor.Current = Cursors.Default;
            }

        }

        // CANCEL
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // CHANGE EMAIL
        private async void llbChangeEmail_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();

            using (var frmChangeEmail = new FrmChangeEmail(_employee))
            {
                if (frmChangeEmail.ShowDialog() == DialogResult.OK)
                {
                    this.Show();

                    tbEmail.Text = await _employeeService.GetEmployeesEmailAsync(_employee);
                }

                else
                {
                    this.Show();
                }
            }
        }

        #endregion

        #region helpers



        #endregion
    }
}
