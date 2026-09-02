using Hotel_erp_Winforms_App.Models;
using Hotel_erp_Winforms_App.Services;
using Hotel_erp_Winforms_App.UI.Forms.ServiceForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Hotel_erp_Winforms_App.UI.Controls.EmployeeControl
{
    public partial class EmployeeControl : UserControl
    {
        private List<Employee> _employees = new List<Employee>();
        private readonly EmployeeService _employeeService = new EmployeeService();
        private Employee? _selectedEmployee;

        public EmployeeControl()
        {
            InitializeComponent();
        }

        private void EmployeeControl_Load(object sender, EventArgs e)
        {
            cbJobTitleFilter.SelectedIndex = 0;
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                _employees = _employeeService.LoadDgv("SELECT * FROM employees");
                dgvEmployees.AutoGenerateColumns = false;
                dgvEmployees.DataSource = _employees;

                UpdateKpis();

                if (dgvEmployees.Rows.Count > 0)
                {
                    RowSelection(0);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading employees: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void UpdateKpis()
        {
            lbKpiTotalValue.Text = _employees.Count.ToString();
            lbKpiManagersValue.Text = _employees.Count(e => (e.JobTitle ?? "").Contains("Manager", StringComparison.OrdinalIgnoreCase)).ToString();
            lbKpiStaffValue.Text = _employees.Count(e => (e.JobTitle ?? "").Contains("Receptionist", StringComparison.OrdinalIgnoreCase) || (e.JobTitle ?? "").Contains("Service", StringComparison.OrdinalIgnoreCase)).ToString();
            lbKpiCleanersValue.Text = _employees.Count(e => (e.JobTitle ?? "").Contains("Cleaner", StringComparison.OrdinalIgnoreCase)).ToString();
        }

        private void RowSelection(int index)
        {
            if (index < 0 || index >= dgvEmployees.Rows.Count) return;

            _selectedEmployee = dgvEmployees.Rows[index].DataBoundItem as Employee;
            if (_selectedEmployee == null) return;

            pbProfilePhoto.Image = Properties.Resources.person_icon;

            tbFirstName.Text = _selectedEmployee.FName;
            tbLastName.Text = _selectedEmployee.LName;
            cbJobTitle.Text = _selectedEmployee.JobTitle ?? "";
            tbTaxNumber.Text = _selectedEmployee.TaxNumber;
            dtpBirthdate.Value = _selectedEmployee.DateOfBirth > DateTime.MinValue ? _selectedEmployee.DateOfBirth : DateTime.Today;
            dtpHiringDate.Value = _selectedEmployee.DateOfHiring > DateTime.MinValue ? _selectedEmployee.DateOfHiring : DateTime.Today;
            tbAddress.Text = _selectedEmployee.Address ?? "";
            tbHolidays.Text = _selectedEmployee.PaidHolidaysLeft.ToString();
            tbSalary.Text = _selectedEmployee.Salary.ToString();
        }

        private void dgvEmployees_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                RowSelection(e.RowIndex);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string query = "SELECT * FROM employees WHERE 1=1 ";
            var parameters = new Dictionary<string, object>();

            if (!string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                query += "AND (fname LIKE @search OR lname LIKE @search OR tax_number LIKE @search) ";
                parameters.Add("@search", $"%{txtSearch.Text.Trim()}%");
            }

            if (cbJobTitleFilter.SelectedIndex > 0)
            {
                query += "AND role = @role ";
                parameters.Add("@role", cbJobTitleFilter.SelectedItem.ToString());
            }

            _employees = _employeeService.LoadDgv(query, parameters);
            dgvEmployees.DataSource = _employees;
            UpdateKpis();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            cbJobTitleFilter.SelectedIndex = 0;
            LoadData();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FrmAddEmployee addEmployee = new FrmAddEmployee();
            addEmployee.ShowDialog();
            LoadData();
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            if (_selectedEmployee != null)
            {
                FrmEditEmployee editEmployee = new FrmEditEmployee(_selectedEmployee);
                editEmployee.ShowDialog();
                LoadData();
            }
            else
            {
                MessageBox.Show("Please select an employee first!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_selectedEmployee != null)
            {
                DialogResult result = MessageBox.Show($"Are you sure you want to delete {_selectedEmployee.FName} {_selectedEmployee.LName}?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    _employeeService.DeleteEmployee(_selectedEmployee);
                    LoadData();
                }
            }
            else
            {
                MessageBox.Show("Please select an employee first!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSaveEmployee_Click(object sender, EventArgs e)
        {
            if (_selectedEmployee != null)
            {
                FrmEditEmployee editEmployee = new FrmEditEmployee(_selectedEmployee);
                editEmployee.ShowDialog();
                LoadData();
            }
            else
            {
                btnAdd_Click(sender, e);
            }
        }
    }
}