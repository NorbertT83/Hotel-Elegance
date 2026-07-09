using Hotel_erp_Winforms_App.Models;
using Hotel_erp_Winforms_App.Services;
using Hotel_erp_Winforms_App.UI.Controls;
using Hotel_erp_Winforms_App.UI.Forms.ServiceForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows.Forms;


namespace Hotel_erp_Winforms_App.UI.Controls.EmployeeControl
{
    public partial class EmployeeControl : UserControl
    {
        private List<Employee> _employees = new List<Employee>();
        private EmployeeService _employeeService = new EmployeeService();
        private System.Windows.Forms.Timer _dbRefreshTimer = new System.Windows.Forms.Timer();

        public EmployeeControl()
        {
            InitializeComponent();
        }

        private void EmployeeControl_Load(object sender, EventArgs e)
        {
            LoadData();
            cbJobTitle.SelectedIndex = 0;

            _dbRefreshTimer.Interval = 10000;
            _dbRefreshTimer.Tick += DbRefreshTimer_Tick;
            _dbRefreshTimer.Start();
        }

        private void DbRefreshTimer_Tick(object? sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbSearch.Text)) return;

            int selectedRowIndex = dgvEmployees.CurrentRow?.Index ?? -1;
            LoadData();

            if (selectedRowIndex >= 0 && selectedRowIndex < dgvEmployees.Rows.Count)
            {
                dgvEmployees.ClearSelection();
                dgvEmployees.Rows[selectedRowIndex].Selected = true;
            }
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FrmAddEmployee addEmployee = new FrmAddEmployee();
            addEmployee.ShowDialog();
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            if (dgvEmployees.CurrentRow != null)
            {
                Employee? selectedEmployee = dgvEmployees.CurrentRow.DataBoundItem as Employee;

                if (selectedEmployee != null)
                {
                    FrmEditEmployee editEmployee = new FrmEditEmployee(selectedEmployee);
                    editEmployee.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Please select an employee first!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("The table is empty or no row is selected!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvEmployees.CurrentRow != null)
            {
                Employee? selectedEmployee = dgvEmployees.CurrentRow.DataBoundItem as Employee;

                if (selectedEmployee != null)
                {
                    DialogResult result = MessageBox.Show("Are you sure you want to delete this employee?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        _employeeService.DeleteEmployee(selectedEmployee);
                    }
                }
                else
                {
                    MessageBox.Show("Please select an employee first!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("The table is empty or no row is selected!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void gbInfo_Enter(object sender, EventArgs e)
        {

        }
    }
}


