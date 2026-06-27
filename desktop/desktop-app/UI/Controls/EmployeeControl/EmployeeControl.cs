using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows.Forms;
using Hotel_erp_Winforms_App.Models;
using Hotel_erp_Winforms_App.Services;
using Microsoft.Data.SqlClient;
using Hotel_erp_Winforms_App.UI.Controls;


namespace Hotel_erp_Winforms_App.UI.Controls.EmployeeControl
{
    public partial class EmployeeControl : UserControl
    {
        private List<Employee> _employees = new List<Employee>();
        private EmployeeService _employeeService = new EmployeeService();
        public event EventHandler<Employee>? EmployeeSelected;
        public event EventHandler<Employee>? EmployeeRowSelected;

        public EmployeeControl()
        {
            InitializeComponent();
        }

        private void EmployeeControl_Load(object sender, EventArgs e)
        {
            LoadData();
            cbJobTitle.SelectedIndex = 0;
        }

        private void LoadData()
        {
            try
            {
                string query = "SELECT * FROM employees";

                _employees = _employeeService.LoadDgv(query);
                dgvEmployees.AutoGenerateColumns = false;
                dgvEmployees.DataSource = null;
                dgvEmployees.DataSource = _employees;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba az adatok betöltésekor: " + ex.Message);
            }
        }

        private void RadioButtonChanged()
        {
            string sortBy = "";
            if (rbName.Checked) sortBy = "Name";
            else if (rbJobTitle.Checked) sortBy = "JobTitle";

            var sortedList = _employeeService.GetSortedEmployees(_employees, sortBy);

            dgvEmployees.DataSource = null;
            dgvEmployees.DataSource = sortedList;
        }

        public void rbName_CheckedChanged(object sender, EventArgs e)
        {
            RadioButtonChanged();
        }

        public void rbJobTitle_CheckedChanged(object sender, EventArgs e)
        {
            RadioButtonChanged();
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            string query = "SELECT * FROM employees WHERE lname LIKE @search ";

            var parameters = new Dictionary<string, object>
            {
                { "@search", tbSearch.Text + "%" }
            };

            _employees = _employeeService.LoadDgv(query, parameters);
            dgvEmployees.DataSource = null;
            dgvEmployees.DataSource = _employees;

        }

        private void cbJobTitle_SelectedIndexChanged(object sender, EventArgs e)
        {
            string query = "";

            switch (cbJobTitle.SelectedIndex)
            {
                case 0: query = "SELECT * FROM employees"; break;
                case 1: query = "SELECT * FROM employees WHERE role = 'HK Manager'"; break;
                case 2: query = "SELECT * FROM employees WHERE role = 'Receptionist'"; break;
                case 3: query = "SELECT * FROM employees WHERE role = 'Room Service'"; break;
                case 4: query = "SELECT * FROM employees WHERE role = 'Front Office Manager'"; break;
                case 5: query = "SELECT * FROM employees WHERE role = 'F&B Manager'"; break;
                case 6: query = "SELECT * FROM employees WHERE role = 'Cleaner'"; break;
            }

            dgvEmployees.DataSource = null;
            dgvEmployees.DataSource = _employeeService.LoadDgv(query);
        }

        private void dgvEmployees_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                Employee selectedEmployee = dgvEmployees.Rows[e.RowIndex].DataBoundItem as Employee;

                if(selectedEmployee != null)
                {
                    EmployeeSelected?.Invoke(this, selectedEmployee);
                }
            }
        }

        private void dgvEmployees_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvEmployees.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvEmployees.SelectedRows[0];

                Employee selectedEmployee = new Employee
                {
                    Id = Convert.ToInt32(row.Cells["colId"].Value),
                    FName = row.Cells["colFname"].Value?.ToString() ?? "",
                    LName = row.Cells["colLname"].Value?.ToString() ?? "",
                    TaxNumber = row.Cells["colTaxNumber"].Value?.ToString() ?? "",
                    PaidHolidaysLeft = Convert.ToInt32(row.Cells["colHolidays"].Value),
                    Address = row.Cells["colAddress"].Value?.ToString() ?? "",
                    DateOfBirth = Convert.ToDateTime(row.Cells["colBirthDate"].Value),
                    DateOfHiring = Convert.ToDateTime(row.Cells["colHiringDate"].Value),
                    JobTitle = row.Cells["colJobTitle"].Value?.ToString() ?? "",
                    Salary = Convert.ToInt32(row.Cells["colSalary"].Value),
                    Password_hash = "",
                    Password_salt = "",
                    CreatedAt = Convert.ToDateTime(row.Cells["colCreatedAt"].Value),
                    UpdatedAt = Convert.ToDateTime(row.Cells["colUpdatedAt"].Value)
                };

                EmployeeRowSelected?.Invoke(this, selectedEmployee);
            }
        }
    }
}

