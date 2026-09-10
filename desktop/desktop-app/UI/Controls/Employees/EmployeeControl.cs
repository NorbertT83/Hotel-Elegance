using Hotel_erp_Winforms_App.Helpers;
using Hotel_erp_Winforms_App.Models;
using Hotel_erp_Winforms_App.Services;
using Hotel_erp_Winforms_App.UI.Forms.ServiceForms;
using Hotel_erp_Winforms_App.UI.Forms.ServiceForms.AddBackOfficeProf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Hotel_erp_Winforms_App.UI.Controls.EmployeeControl
{
    public partial class EmployeeControl : UserControl
    {
        public EmployeeControl()
        {
            InitializeComponent();
        }

        #region variables

        private readonly EmployeeService _employeeService = new EmployeeService();
        private readonly CommonHelper _commonHelper = new CommonHelper();

        private List<Employee> _employees = new List<Employee>();

        private Employee? _selectedEmployee;
        private ErrorProvider _errorProvider = new ErrorProvider();

        #endregion

        #region onLoad events

        private void EmployeeControl_Load(object sender, EventArgs e)
        {
            cbJobTitleFilter.SelectedIndex = 0;

            dtpBirthdate.MaxDate = DateTime.Today.AddYears(-18);

            LoadData();
        }

        #endregion

        #region INFO
        /*
         * 1.: search button
         * 2.: refresh button
         * 3.: dgv cellclick
         * 4.: add, modify, delete buttons
         * 5.: save employee and add profile buttons
        */
        #endregion
        #region buttons

        // 1.
        private async void btnSearch_Click(object sender, EventArgs e)
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

            _employees = await _employeeService.LoadDgvAsync(query, parameters);

            dgvEmployees.DataSource = null;
            dgvEmployees.DataSource = _employees;
            dgvEmployees.ClearSelection();

            lbNoData.BringToFront();
            lbNoData.Visible = _employees.Count == 0;

            UpdateKpis();
        }

        // 2.
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            cbJobTitleFilter.SelectedIndex = 0;
            LoadData();
        }

        // 3.
        private void dgvEmployees_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                RowSelection(e.RowIndex);
            }

            SetBoxesReadability(true);
        }

        // 4.
        private void btnAdd_Click(object sender, EventArgs e)
        {
            _selectedEmployee = null;
            dgvEmployees.ClearSelection();

            ClearBoxes();
            SetBoxesReadability(false);
        }

        // 5.
        private void btnModify_Click(object sender, EventArgs e)
        {
            if (_selectedEmployee != null)
            {
                SetBoxesReadability(false);


            }
            else
            {
                MessageBox.Show("Please select an employee first!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // 6.
        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (_selectedEmployee != null)
            {
                DialogResult result = MessageBox.Show($"Are you sure you want to delete {_selectedEmployee.FName} {_selectedEmployee.LName}?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        Cursor.Current = Cursors.WaitCursor;

                        await _employeeService.DeleteEmployeeAsync(_selectedEmployee);

                        MessageBox.Show("Employee deleted successfully.",
                            "Success",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

                        LoadData();
                    }
                    catch (Exception ex)
                    {
                        var ch = new CommonHelper();
                        ch.MBErrorMessage(ex);
                    }
                    finally
                    {
                        Cursor.Current = Cursors.Default;
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select an employee first!", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // 7.
        private async void btnSaveEmployee_Click(object sender, EventArgs e)
        {
            if (_selectedEmployee != null) // UPDATE EMPLYOEE
            {
                var emp = new Employee(
                    _selectedEmployee.Id,
                    tbFirstName.Text.Trim(),
                    tbLastName.Text.Trim(),
                    tbTaxNumber.Text.Trim(),
                    Convert.ToInt32(numHolidays.Value),
                    tbAddress.Text,
                    dtpBirthdate.Value,
                    dtpHiringDate.Value,
                    cbJobTitle.Text.ToString(),
                    Convert.ToInt32(numSalary.Value),
                    _selectedEmployee.CreatedAt,
                    DateTime.Now,
                    tbEmail.Text.Trim(),
                    _selectedEmployee.Password
                );

                if (numHolidays.Value == 0)
                {
                    DialogResult result = MessageBox.Show(
                        "The value for 'Holidays' is currently set to 0. Please confirm if this is correct.",
                        "Confirmation",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning
                    );

                    if (result == DialogResult.No) return;
                }

                if (numSalary.Value == 0)
                {
                    DialogResult result = MessageBox.Show(
                        "The value for 'Salary' is currently set to 0. Please confirm if this is correct.",
                        "Confirmation",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning
                    );

                    if (result == DialogResult.No)
                    {
                        return;
                    }
                }

                bool isUnchanged = tbFirstName.Text.Trim() == _selectedEmployee.FName &&
                   tbLastName.Text.Trim() == _selectedEmployee.LName &&
                   tbTaxNumber.Text.Trim() == _selectedEmployee.TaxNumber &&
                   Convert.ToInt32(numHolidays.Value) == _selectedEmployee.PaidHolidaysLeft &&
                   tbAddress.Text == _selectedEmployee.Address &&
                   dtpBirthdate.Value.Date == _selectedEmployee.DateOfBirth.Date &&
                   dtpHiringDate.Value.Date == _selectedEmployee.DateOfHiring.Date &&
                   cbJobTitle.Text == _selectedEmployee.JobTitle &&
                   Convert.ToInt32(numSalary.Value) == _selectedEmployee.Salary &&
                   tbEmail.Text.Trim() == _selectedEmployee.Email;

                if (isUnchanged)
                {
                    MessageBox.Show("No data were changed.", "No Data Changes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                else
                {
                    try
                    {
                        Cursor.Current = Cursors.WaitCursor;

                        await _employeeService.SaveEmployeeToDbAsync(emp, SaveOrUpdate.Update);

                        MessageBox.Show("Employee data updated successfully!",
                            "Success",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

                        LoadData();
                        RowSelection(_selectedEmployee.Id);
                    }

                    catch (Exception ex)
                    {
                        var ch = new CommonHelper();
                        ch.MBErrorMessage(ex);
                    }

                    finally
                    {
                        Cursor.Current = Cursors.Default;
                    }
                }
            }

            else // SAVE NEW EMPLOYEE
            {
                if (!PersonalDataValidationConfirm()) return;

                if (numHolidays.Value == 0)
                {
                    DialogResult result = MessageBox.Show(
                        "The value for 'Holidays' is currently set to 0. Please confirm if this is correct.",
                        "Confirmation",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning
                    );

                    if (result == DialogResult.No) return;
                }

                if (numSalary.Value == 0)
                {
                    DialogResult result = MessageBox.Show(
                        "The value for 'Salary' is currently set to 0. Please confirm if this is correct.",
                        "Confirmation",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning
                    );

                    if (result == DialogResult.No)
                    {
                        return;
                    }
                }

                var emp = new Employee(
                    0,
                    tbFirstName.Text.Trim(),
                    tbLastName.Text.Trim(),
                    tbTaxNumber.Text.Trim(),
                    Convert.ToInt32(numHolidays.Value),
                    tbAddress.Text,
                    dtpBirthdate.Value,
                    dtpHiringDate.Value,
                    cbJobTitle.Text.ToString(),
                    Convert.ToInt32(numSalary.Value),
                    DateTime.Now,
                    DateTime.Now,
                    tbEmail.Text.Trim(),
                    string.Empty
                );

                try
                {
                    Cursor.Current = Cursors.WaitCursor;

                    await _employeeService.SaveEmployeeToDbAsync(emp, SaveOrUpdate.Save);

                    MessageBox.Show("Employee data saved successfully!",
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    LoadData();

                    RowSelection(dgvEmployees.Rows.Count - 1);
                    int lastIndex = dgvEmployees.Rows.Count - 1;
                    dgvEmployees.Rows[lastIndex].Selected = true;
                }

                catch (Exception ex)
                {
                    var ch = new CommonHelper();
                    ch.MBErrorMessage(ex);
                }

                finally
                {
                    Cursor.Current = Cursors.Default;
                }
            }
        }

        // 8.
        private void btnAddProfile_Click(object sender, EventArgs e)
        {
            if (_selectedEmployee != null)
            {
                AddBackOfficeProfileForm addProfile = new AddBackOfficeProfileForm(_selectedEmployee);
                var result =  addProfile.ShowDialog();

                if(result == DialogResult.OK)
                {
                    LoadData();
                }
            }
        }

        // 9.
        private async void btnDeleteBackOffProfile_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
                "Are you sure you want to delete this BackOffice profile?",
                "Confirm Deletion",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.No) return;

            try
            {
                if(_selectedEmployee != null)
                {
                    Cursor.Current = Cursors.WaitCursor;

                    await _employeeService.DeleteBackOfficeProfileAsync(_selectedEmployee);

                    MessageBox.Show(
                        "This profile is deleted successfully.",
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    var list = await _employeeService.LoadDgvAsync("SELECT * FROM employees");

                    dgvEmployees.DataSource = null;
                    dgvEmployees.DataSource = list;
                    dgvEmployees.ClearSelection();
                }
            }
            catch (Exception ex)
            {
                _commonHelper.MBErrorMessage(ex);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        #endregion

        #region INFO
        /*
         * 1.: data loading and grid population
         * 2.: kpi value setting
         * 3.: row selection helper
        */
        #endregion
        #region helpers

        // 1.
        private async void LoadData()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                _employees = await _employeeService.LoadDgvAsync("SELECT * FROM employees");
                dgvEmployees.AutoGenerateColumns = false;

                dgvEmployees.DataSource = null;
                dgvEmployees.DataSource = _employees;
                dgvEmployees.ClearSelection();

                lbNoData.BringToFront();
                lbNoData.Visible = _employees.Count == 0;

                UpdateKpis();

                if (dgvEmployees.Rows.Count > 0)
                {
                    RowSelection(0);
                }

                SetBoxesReadability(true);
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

        // 2.
        private void UpdateKpis()
        {
            lbKpiTotalValue.Text = _employees.Count.ToString();
            lbKpiManagersValue.Text = _employees.Count(e => (e.JobTitle ?? "").Contains("Manager", StringComparison.OrdinalIgnoreCase)).ToString();
            lbKpiStaffValue.Text = _employees.Count(e => (e.JobTitle ?? "").Contains("Receptionist", StringComparison.OrdinalIgnoreCase) || (e.JobTitle ?? "").Contains("Service", StringComparison.OrdinalIgnoreCase)).ToString();
            lbKpiCleanersValue.Text = _employees.Count(e => (e.JobTitle ?? "").Contains("Cleaner", StringComparison.OrdinalIgnoreCase)).ToString();
        }

        // 3.
        private void RowSelection(int index)
        {
            if (index < 0 || index >= dgvEmployees.Rows.Count) return;

            _selectedEmployee = dgvEmployees.Rows[index].DataBoundItem as Employee;

            if (_selectedEmployee == null) return;

            pbProfilePhoto.Image = Properties.Resources.person_icon;

            tbFirstName.Text = _selectedEmployee.FName;
            tbLastName.Text = _selectedEmployee.LName;
            tbEmail.Text = _selectedEmployee.Email ?? "";
            cbJobTitle.Text = _selectedEmployee.JobTitle ?? "";
            tbTaxNumber.Text = _selectedEmployee.TaxNumber;
            dtpBirthdate.Value = _selectedEmployee.DateOfBirth > DateTime.MinValue ? _selectedEmployee.DateOfBirth : DateTime.Today;
            dtpHiringDate.Value = _selectedEmployee.DateOfHiring > DateTime.MinValue ? _selectedEmployee.DateOfHiring : DateTime.Today;
            tbAddress.Text = _selectedEmployee.Address ?? "";
            numHolidays.Value = _selectedEmployee.PaidHolidaysLeft;
            numSalary.Value = _selectedEmployee.Salary;

            btnDeleteBackOffProfile.Visible = !string.IsNullOrEmpty(_selectedEmployee.Password) && (_selectedEmployee.Id != CurrentUser.Id);
            btnAddProfile.Visible = _selectedEmployee.Id != CurrentUser.Id;

            if (_selectedEmployee.Id == CurrentUser.Id)
            {
            }

            SetBoxesReadability(false);
        }

        // 4.
        private void SetBoxesReadability(bool readOnly)
        {
            if (readOnly)
            {
                tbFirstName.ReadOnly = true;
                tbLastName.ReadOnly = true;
                tbEmail.ReadOnly = true;
                cbJobTitle.Enabled = false;
                tbTaxNumber.ReadOnly = true;
                dtpBirthdate.Enabled = false;
                dtpHiringDate.Enabled = false;
                tbAddress.ReadOnly = true;
                numHolidays.ReadOnly = true;
                numSalary.ReadOnly = true;
                btnSaveEmployee.Visible = false;
            }

            else
            {
                tbFirstName.ReadOnly = false;
                tbLastName.ReadOnly = false;
                tbEmail.ReadOnly = false;
                cbJobTitle.Enabled = true;
                tbTaxNumber.ReadOnly = false;
                dtpBirthdate.Enabled = true;
                dtpHiringDate.Enabled = true;
                tbAddress.ReadOnly = false;
                numHolidays.ReadOnly = false;
                numSalary.ReadOnly = false;
                btnSaveEmployee.Visible = true;
            }
        }

        // 5.
        private void ClearBoxes()
        {
            tbFirstName.Clear();
            tbLastName.Clear();
            tbEmail.Clear();
            cbJobTitle.SelectedIndex = -1;
            tbTaxNumber.Clear();
            dtpBirthdate.Value = DateTime.Today.AddYears(-18);
            dtpHiringDate.Value = DateTime.Today;
            tbAddress.Clear();
            numHolidays.Value = 0;
            numSalary.Value = 0;
        }

        #endregion

        #region foolproofing

        // 1.
        private void tbLastName_KeyPress(object sender, KeyPressEventArgs e)
        {
            CommonHelper.InputValidationService.BlockDigits(e);
        }

        // 2.
        private void tbFirstName_KeyPress(object sender, KeyPressEventArgs e)
        {
            CommonHelper.InputValidationService.BlockDigits(e);
        }

        // 3.
        private bool PersonalDataValidationConfirm()
        {
            bool isFirstNameValid = !_commonHelper.HasValidationError(tbFirstName, _errorProvider);
            bool isLastNameValid = !_commonHelper.HasValidationError(tbLastName, _errorProvider);
            bool isEmailValid = !_commonHelper.HasValidationError(tbEmail, _errorProvider);
            bool isAddressValid = !_commonHelper.HasValidationError(tbAddress, _errorProvider);
            bool isTaxValid = !_commonHelper.HasValidationError(tbTaxNumber, _errorProvider);

            bool isTitleSelected = cbJobTitle.SelectedIndex != -1;

            return isFirstNameValid && isLastNameValid && isEmailValid && isAddressValid && isTaxValid && isTitleSelected;
        }
        #endregion
    }
}