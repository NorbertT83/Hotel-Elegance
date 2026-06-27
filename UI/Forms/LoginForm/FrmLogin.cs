using Hotel_erp_Winforms_App.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Hotel_erp_Winforms_App.UI;
using Hotel_erp_Winforms_App.Services;
using Hotel_erp_Winforms_App.Security;
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

        private void btnLogin_Click(object sender, EventArgs e)
        {
            EmployeeService _employeeService = new EmployeeService();

            loggedInEmployee = _employeeService.GetEmployeeByTaxNumber(tbTaxNumber.Text);

            if (loggedInEmployee != null)
            {
                bool isPasswordValid = PasswordHelper.VerifyPassword(tbPassword.Text, loggedInEmployee.Password_hash);

                if (isPasswordValid)
                {
                    SessionManager.CurrentUser = loggedInEmployee;

                    FrmMain mainForm = new FrmMain(loggedInEmployee);
                    mainForm.Show();
                    this.Hide();
                }

                else
                {
                    MessageBox.Show("Hibás jelszó!", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            else
            {
                MessageBox.Show("A felhasználó nem létezik!", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmRegistration registrationFrom = new FrmRegistration();
            registrationFrom.Show();
            this.Hide();
        }
    }
}
