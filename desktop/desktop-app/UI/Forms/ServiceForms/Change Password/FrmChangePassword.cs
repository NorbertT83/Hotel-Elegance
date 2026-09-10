using Hotel_erp_Winforms_App.Helpers;
using Hotel_erp_Winforms_App.Models;
using Hotel_erp_Winforms_App.Security;
using Hotel_erp_Winforms_App.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ZstdSharp.Unsafe;

namespace Hotel_erp_Winforms_App.UI.Forms.ServiceForms.Change_Password
{
    public partial class FrmChangePassword : Form
    {
        Employee _currentEmployee;

        public FrmChangePassword(Employee _emplyoee)
        {
            InitializeComponent();

            _currentEmployee = _emplyoee;
        }

        #region variables

        EmployeeService employeeService = new EmployeeService();
        CommonHelper commonHelper = new CommonHelper();

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

            tbNewPassword.Text = generatedPassword;
            tbConfirmNewPassword.Text = generatedPassword;
        }

        // SHOW PASSWORD
        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            bool hidePassword = !chkShowPassword.Checked;

            tbNewPassword.UseSystemPasswordChar = hidePassword;
            tbOldPassword.UseSystemPasswordChar = hidePassword;
            tbConfirmNewPassword.UseSystemPasswordChar = hidePassword;
        }

        // RETURN
        private void btnCancel_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
                "Are you sure you want to discard the changes?",
                "Discard Changes?",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        // SAVE
        private async void btnSave_Click(object sender, EventArgs e)
        {
            string password = tbNewPassword.Text.Trim();
            string confirmPassword = tbConfirmNewPassword.Text.Trim();

            if (!PasswordHelper.VerifyPassword(tbOldPassword.Text.Trim(), _currentEmployee.Password))
            {
                MessageBox.Show(
                    "Your password is not correct.",
                    "Incorrect Password",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                tbOldPassword.Clear();
                tbOldPassword.Focus();

                return;
            }

            if (string.IsNullOrWhiteSpace(tbNewPassword.Text.Trim()) || string.IsNullOrWhiteSpace(tbConfirmNewPassword.Text.Trim()))
            {
                MessageBox.Show(
                    "Please enter a password.",
                    "Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                tbNewPassword.Focus();
                return;
            }

            var hasUpper = tbNewPassword.Text.Any(char.IsUpper);
            var hasLower = tbNewPassword.Text.Any(char.IsLower);
            var hasDigit = tbNewPassword.Text.Any(char.IsDigit);
            var hasSpecial = tbNewPassword.Text.Any(c => !char.IsLetterOrDigit(c));
            var isLongEnough = tbNewPassword.Text.Length >= 8;

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

                tbNewPassword.Clear();
                tbConfirmNewPassword.Clear();

                tbNewPassword.Focus();
                return;
            }

            if (password != tbConfirmNewPassword.Text.Trim())
            {
                MessageBox.Show(
                    "The passwords you entered do not match. Please check and try again.",
                    "Password Mismatch",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                tbNewPassword.Clear();
                tbConfirmNewPassword.Clear();

                tbNewPassword.Focus();

                return;
            }

            if (PasswordHelper.HashPassword(password) == _currentEmployee.Password)
            {
                MessageBox.Show(
                    "The new password cannot be the same as the old password.",
                    "Invalid Password",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                tbNewPassword.Clear();
                tbOldPassword.Clear();

                tbNewPassword.Focus();

                return;
            }
            
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                string hashedPassword = PasswordHelper.HashPassword(password);
                await employeeService.SaveEmployeesNewPasswordAsync(_currentEmployee, hashedPassword);

                MessageBox.Show(
                    "Password saved successfully.",
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

        #endregion

        #region helpers



        #endregion
    }
}
