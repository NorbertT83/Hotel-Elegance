using Hotel_erp_Winforms_App.Models;
using Microsoft.Data.SqlClient;
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
    public partial class FrmAddEmployee : Form
    {
        public FrmAddEmployee()
        {
            InitializeComponent();
        }

        private void FrmAddEmployee_Load(object sender, EventArgs e)
        {
            tbAddFirstName.Focus();
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

                        int existingCount = Convert.ToInt32(checkCmd.ExecuteScalar());

                        if (existingCount > 0)
                        {
                            MessageBox.Show("This tax number already exists in the database! Try another one!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    
                        MySqlCommand cmd = new MySqlCommand(query, connection);

                        int holidays = int.TryParse(cbAddHolidays.Text, out int hResult) ? hResult : 0;
                        int salary = int.TryParse(tbAddSalary.Text, out int sResult) ? sResult : 0;
                        var parameters = new Dictionary<string, object>
                        {
                            { "@fname", tbAddFirstName.Text },
                            { "@lname", tbAddLastName.Text },
                            { "@taxNumber", "TX" + tbAddTaxNumber.Text.ToUpper() },
                            { "@holidays",  holidays },
                            { "@address", tbAddAddress.Text },
                            { "@birthDate", dtpBirthdate.Value },
                            { "@hiring", DateTime.Now },
                            { "@role", cbAddJobTitle.Text },
                            { "@salary", salary },
                            { "@created_at", DateTime.Now },
                            { "@updated_at", DateTime.Now }
                        };

                        foreach (var param in parameters)
                        {
                            cmd.Parameters.AddWithValue(param.Key, param.Value ?? DBNull.Value);
                        }

                        if (ErrorHandling())
                        {
                            cmd.ExecuteNonQuery();
                            MessageBox.Show($"Saved successfully!", "Succeeded", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Did not succeed: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                }

            bool ErrorHandling()
            {
                if(tbAddFirstName.Text.Length < 1)
                {
                    MessageBox.Show($"You can't leave empty spaces!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tbAddFirstName.Focus();
                    return false;
                }
                else if(tbAddLastName.Text.Length < 1)
                {
                    MessageBox.Show($"You can't leave empty spaces!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tbAddLastName.Focus();
                    return false;
                }
                else if (tbAddTaxNumber.Text.Length < 1)
                {
                    MessageBox.Show($"You can't leave empty spaces!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tbAddTaxNumber.Focus();
                    return false;
                }
                else if (cbAddHolidays.Text.Length < 1)
                {
                    MessageBox.Show($"You can't leave empty spaces!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cbAddHolidays.Focus();
                    return false;
                }
                else if (tbAddAddress.Text.Length < 1)
                {
                    MessageBox.Show($"You can't leave empty spaces!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tbAddAddress.Focus();
                    return false;
                }
                else if (cbAddJobTitle.Text.Length < 1)
                {
                    MessageBox.Show($"You can't leave empty spaces!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cbAddJobTitle.Focus();
                    return false;
                }
                else if (tbAddSalary.Text.Length < 1)
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
