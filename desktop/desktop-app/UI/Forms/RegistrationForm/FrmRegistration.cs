using Hotel_erp_Winforms_App.Models;
using Hotel_erp_Winforms_App.Security;
using Hotel_erp_Winforms_App.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Text;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace Hotel_erp_Winforms_App.UI.Forms
{
    public partial class FrmRegistration : Form
    {
        public FrmRegistration()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            EmployeeService _employeeService = new EmployeeService();

            Employee user = _employeeService.GetEmployeeByTaxNumber(tbRegTaxNumber.Text);

            if (user != null)
            {
                string password = tbRegPassword.Text;
                string confirmPassword = tbRegConfirmPassword.Text;

                if (password != confirmPassword)
                {
                    MessageBox.Show("Passwords are not matching!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (string.IsNullOrEmpty(password))
                {
                    MessageBox.Show("Password must be given!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string encryptedPassword = PasswordHelper.HashPassword(password);
                bool isSuccess = _employeeService.SaveEmployeesPassword(user.TaxNumber, encryptedPassword);

                if (isSuccess)
                {
                    MessageBox.Show("Password saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("This tax number does not exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
