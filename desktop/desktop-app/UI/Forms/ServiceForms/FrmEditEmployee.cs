using Hotel_erp_Winforms_App.Models;
using Hotel_erp_Winforms_App.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Hotel_erp_Winforms_App.UI.Forms.ServiceForms
{
    public partial class FrmEditEmployee : Form
    {
        private Employee? _selectedEmployee;

        public FrmEditEmployee(Employee employee)
        {
            InitializeComponent();
            _selectedEmployee = employee;
        }

        private void FrmEditEmployee_Load(object sender, EventArgs e)
        {
            DisplayEmployee(_selectedEmployee);
        }

        public void DisplayEmployee(Employee employee)
        {
            if (_selectedEmployee != null)
            _selectedEmployee = employee;

            tbAddFirstName.Text = _selectedEmployee?.FName ?? "";
            tbAddLastName.Text = _selectedEmployee?.LName ?? "";
            tbAddTaxNumber.Text = _selectedEmployee?.TaxNumber ?? "";
            cbAddHolidays.Text = _selectedEmployee?.PaidHolidaysLeft.ToString();
            tbAddAddress.Text = _selectedEmployee?.Address ?? "";
            dtpBirthdate.Value = _selectedEmployee?.DateOfBirth ?? DateTime.Now;
            cbAddJobTitle.Text = _selectedEmployee?.JobTitle ?? "";
            tbAddSalary.Text = _selectedEmployee?.Salary.ToString();
        }

        private void tbAddFirstName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void tbAddLastName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void tbAddSalary_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void tbAddTaxNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnSaveEmployee_Click(object sender, EventArgs e)
        {
            if (ErrorHandling()) return;

            DialogResult response = MessageBox.Show(
                "Are you sure the details are correnct?",
                "Confirm",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (response == DialogResult.Yes)
            {
                string connectionString = "Server=localhost;Database=hotelelegancedb;uid=root;pwd=";
                string checkQuery = "SELECT COUNT(*) FROM employees WHERE tax_number = @taxNumber";
                string query =
                    "INSERT INTO employees (fname, lname, tax_number, paid_holidays_left, address, date_of_birth, " +
                    "date_of_hiring, role, salary, created_at, updated_at) " +
                    "VALUES(@fname, @lname, @taxNumber, @holidays, @address, @birthDate, @hiring, @role, @salary, " +
                    "@created_at, @updated_at) ";
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();
                        MySqlCommand checkCmd = new MySqlCommand(checkQuery, connection);
                        checkCmd.Parameters.AddWithValue("taxNumber", tbAddTaxNumber.Text);

                        int existingCount = (int)checkCmd.ExecuteScalar();

                        if (existingCount > 0)
                        {
                            MessageBox.Show("This tax number already exists in the database! Try another one!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    
                        MySqlCommand cmd = new MySqlCommand(query, connection);

                        int salary = int.TryParse(tbAddSalary.Text, out int sResult) ? sResult : 0;
                        int holidays = int.TryParse(cbAddHolidays.Text, out int hResult) ? hResult : 0;
                        var parameters = new Dictionary<string, object>
                        {
                            { "@fname", tbAddFirstName.Text },
                            { "@lname", tbAddLastName.Text },
                            { "@taxNumber", "TX" + tbAddTaxNumber.Text.ToUpper() },
                            { "@holidays", holidays },
                            { "@address", tbAddAddress.Text },
                            { "@birthDate", dtpBirthdate.Value },
                            { "@hiring", DateTime.Now },
                            { "@role", cbAddJobTitle.Text },
                            { "@salary", salary },
                            { "@password_hash", "" },
                            { "@password_salt", "" },
                            { "@created_at", DateTime.Now },
                            { "@updated_at", DateTime.Now }
                        };

                        foreach (var param in parameters)
                        {
                            cmd.Parameters.AddWithValue(param.Key, param.Value ?? DBNull.Value);
                        }

                        cmd.ExecuteNonQuery();
                        MessageBox.Show($"Saved successfully!", "Succeeded", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Did not succeed: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                }

            bool ErrorHandling()
            {
                if(string.IsNullOrWhiteSpace(tbAddFirstName.Text))
                {
                    MessageBox.Show($"You can't leave empty spaces!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tbAddFirstName.Focus();
                    return false;
                }
                else if(string.IsNullOrWhiteSpace(tbAddLastName.Text))
                {
                    MessageBox.Show($"You can't leave empty spaces!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tbAddLastName.Focus();
                    return false;
                }
                else if (string.IsNullOrWhiteSpace(tbAddTaxNumber.Text))
                {
                    MessageBox.Show($"You can't leave empty spaces!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tbAddTaxNumber.Focus();
                    return false;
                }
                else if (string.IsNullOrWhiteSpace(cbAddHolidays.Text))
                {
                    MessageBox.Show($"You can't leave empty spaces!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cbAddHolidays.Focus();
                    return false;
                }
                else if (string.IsNullOrWhiteSpace(tbAddAddress.Text))
                {
                    MessageBox.Show($"You can't leave empty spaces!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tbAddAddress.Focus();
                    return false;
                }
                else if (string.IsNullOrWhiteSpace(cbAddJobTitle.Text))
                {
                    MessageBox.Show($"You can't leave empty spaces!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cbAddJobTitle.Focus();
                    return false;
                }
                else if (string.IsNullOrWhiteSpace(tbAddSalary.Text))
                {
                    MessageBox.Show($"You can't leave empty spaces!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tbAddSalary.Focus();
                    return false;
                }
                
                return true;
            }
        }
    }
}
