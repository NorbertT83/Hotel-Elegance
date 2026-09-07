using Hotel_erp_Winforms_App.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Hotel_erp_Winforms_App.UI.Forms.ServiceForms;
using Hotel_erp_Winforms_App.Services;
using Hotel_erp_Winforms_App.Helpers;

namespace Hotel_erp_Winforms_App.UI.Forms.ServiceForms.ChangeEmail
{
    public partial class FrmChangeEmail : Form
    {
        Employee _employee;

        public FrmChangeEmail(Employee employee)
        {
            InitializeComponent();

            _employee = employee;
        }

        #region variables

        EmployeeService _employeeService = new EmployeeService();
        CommonHelper _ch = new CommonHelper();

        #endregion

        #region onLoad functions
        private void FrmChangeEmail_Load(object sender, EventArgs e)
        {
        }
        #endregion

        #region buttons

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (!tbNewEmail.Text.Trim().Contains('@') || string.IsNullOrWhiteSpace(tbNewEmail.Text.Trim()))
            {
                MessageBox.Show(
                    "Please enter a valid email address containing an '@' symbol.",
                    "Invalid Email Format",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                tbConfirmEmail.Clear();
                tbConfirmEmail.Focus();

                return;
            }

            if (tbNewEmail.Text.Trim() != tbConfirmEmail.Text.Trim())
            {
                MessageBox.Show(
                    "The email addresses you entered do not match. Please check and try again.",
                    "Password Mismatch",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                tbNewEmail.Focus();

                return;
            }

            if (await _employeeService.IsEmailAlreadyUsed(tbNewEmail.Text.Trim(), _employeeService))
            {
                MessageBox.Show(
                    "This email address is already in use. Please enter a different one.",
                    "Email Already Exists",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                tbNewEmail.Clear();
                tbConfirmEmail.Clear();
                tbNewEmail.Focus();

                return;
            }

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                await _employeeService.UpdateEmailAsync(_employee, tbNewEmail.Text.Trim());

                MessageBox.Show(
                    "Email address updated successfully!",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                _ch.MBErrorMessage(ex);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        #endregion

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
