using Hotel_erp_Winforms_App.Helpers;
using Hotel_erp_Winforms_App.Models;
using Hotel_erp_Winforms_App.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hotel_erp_Winforms_App.UI.Controls
{
    public partial class ProductContol : UserControl
    {
        public ProductContol()
        {
            InitializeComponent();
        }

        #region TODO:

        /*
         * 1.: order by-okat csinálni
        */

        #endregion

        #region variables

        ServiceService _serviceService = new ServiceService();
        List<Service> services = new List<Service>();
        List<Service> filteredServices = new List<Service>();

        Service _selectedService;
        CommonHelper _commonHelper = new CommonHelper();

        ErrorProvider _errorProvider = new ErrorProvider();
        bool resized = false;

        private enum UpdateOrSave
        {
            Update,
            Save
        }

        #endregion

        #region INFO
        /*
         * 1.: UI items default values
         * 2.: Load datagridview
        */
        #endregion
        #region onLoad events

        private async void ProductContol_Load(object sender, EventArgs e)
        {
            #region UI defaults before await

            SetBoxesReadonlibility(true);
            pnlSideBottom.Visible = false;
            cbTypeFilter.SelectedIndex = 0;
            chkIsActive.Checked = false;

            #endregion

            #region datagridview

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                services = await _serviceService.GetAllServicesFromDbAsync();
                dgvServices.AutoGenerateColumns = false;
                dgvServices.DataSource = services;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "An error occured while trying to load the database" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                    );
            }
            finally { Cursor.Current = Cursors.Default; }


            #endregion

            #region UI defaults
            List<Service> actives = await _serviceService.GetActiveOrInactiveServicesAsync(true);

            lbTotalServices.Text = "Total services: " + services.Count().ToString();
            lbActiveServices.Text = "Active: " + actives.Count();

            #endregion
        }

        #endregion

        #region INFO
        /*
         * 1.: Search button
         * 2.: Active radio button
         * 3.: Inactive radio button
         * 4.: All statuses radio button
         * 5.: Dgv cell click
         * 6.: New service button
         * 7.: Save new service button
         * 8.: Update service button
         * 9.: Delete button
         * 10.: Reloads the dgv / database
         * 11.: Sets all filters to default
         * 8.: Type Hu selected index = Type En selected index
         * 9.: Type En selected index = Type Hu selected index
        */
        #endregion
        #region buttons
        // -----------------------

        #region filter buttons

        // 1.
        private async void btnSearch_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            List<Service> filteredServices = await _serviceService.GetFilteredSerivicesAsync(cbTypeFilter.SelectedIndex, txtSearch.Text);

            dgvServices.AutoGenerateColumns = false;
            dgvServices.DataSource = filteredServices;

            Cursor.Current = Cursors.Default;
        }

        // 2.
        private async void rbStatusActive_CheckedChanged(object sender, EventArgs e)
        {
            if (rbStatusActive.Checked)
            {
                Cursor.Current = Cursors.WaitCursor;

                filteredServices = await _serviceService.GetActiveOrInactiveServicesAsync(true);

                dgvServices.AutoGenerateColumns = false;
                dgvServices.DataSource = filteredServices;

                Cursor.Current = Cursors.Default;
            }
        }

        // 3.
        private async void rbStatusInactive_CheckedChanged(object sender, EventArgs e)
        {
            if (rbStatusInactive.Checked)
            {
                Cursor.Current = Cursors.WaitCursor;

                filteredServices = await _serviceService.GetActiveOrInactiveServicesAsync(false);

                dgvServices.AutoGenerateColumns = false;
                dgvServices.DataSource = filteredServices;

                Cursor.Current = Cursors.Default;
            }
        }

        // 4.
        private async void rbStatusAll_CheckedChanged(object sender, EventArgs e)
        {
            if (rbStatusAll.Checked)
            {
                Cursor.Current = Cursors.WaitCursor;

                services = await _serviceService.GetAllServicesFromDbAsync();

                dgvServices.AutoGenerateColumns = false;
                dgvServices.DataSource = services;

                Cursor.Current = Cursors.Default;
            }
        }

        #endregion

        #region dgv
        // 5.
        private async void dgvServices_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            List<Service> actives = await _serviceService.GetActiveOrInactiveServicesAsync(true);

            if (e.RowIndex >= 0)
            {
                pnlSideBottom.Visible = false;

                chkIsActive.Visible = true;

                _selectedService = dgvServices.Rows[e.RowIndex].DataBoundItem as Service;

                numPrice.Value = _selectedService.Price;
                cbTypeHu.Text = _selectedService.SelectedServiceTypeHu.ToString();
                tbNameHu.Text = _selectedService.NameHu;
                tbDescHu.Text = _selectedService.DescriptionHu;

                cbTypeEn.Text = _selectedService.SelectedServiceTypeEn.ToString();
                tbNameEn.Text = _selectedService.NameEn;
                tbDescEn.Text = _selectedService.DescriptionEn;

                chkIsActive.Checked = actives.Any(s => s.Id == _selectedService.Id);

                SetBoxesReadonlibility(true);

                if (resized)
                {
                    tabControlLang.Height = tabControlLang.Height + 175;
                    resized = false;
                }
            }
        }

        #endregion

        #region Actions buttons
        // 6.
        private void btnNewService_Click(object sender, EventArgs e)
        {
            _selectedService = null;

            pnlSideBottom.Visible = true;

            dgvServices.ClearSelection();

            chkIsActive.Visible = false;
            SetBoxesReadonlibility(false);

            numPrice.Value = 0;
            cbTypeHu.SelectedIndex = 0;
            tbNameHu.Clear();
            tbDescHu.Clear();

            cbTypeEn.SelectedIndex = 0;
            tbNameEn.Clear();
            tbDescEn.Clear();

            tabControlLang.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            if (!resized)
            {
                tabControlLang.Height = tabControlLang.Height - 175;
                resized = true;
            }
        }

        // 7.
        private async void btnSaveService_Click(object sender, EventArgs e)
        {
            if (_selectedService == null)
            {
                SaveService(UpdateOrSave.Save);
            }

            else
            {
                SaveService(UpdateOrSave.Update);
            }
        }

        // 8.
        private async void btnUpdateService_Click(object sender, EventArgs e)
        {
            if (_selectedService == null)
            {
                MessageBox.Show(
                    "You must select a service first!",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                return;
            }

            SetBoxesReadonlibility(false);

            tabControlLang.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            if (!resized)
            {
                tabControlLang.Height = tabControlLang.Height - 175;
                resized = true;
            }

            pnlSideBottom.Visible = true;
        }

        // 9.
        private async void btnDeleteService_Click(object sender, EventArgs e)
        {
            if (_selectedService == null)
            {
                MessageBox.Show(
                    "You must select a service first!",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                return;
            }

            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete this service?",
                "Confirmation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.No) return;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                await _serviceService.DeleteSelectedServiceFromDbAsync(_selectedService);

                MessageBox.Show(
                    "Service deleted successfully",
                    "Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "An error occurred while trying to delete this service: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            finally
            {
                Cursor.Current = Cursors.Default;

                services = await _serviceService.GetAllServicesFromDbAsync();
                dgvServices.AutoGenerateColumns = false;
                dgvServices.DataSource = services;

                _selectedService = null;
            }
        }

        #endregion

        #region Refresh buttons

        // 10.
        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            services = await _serviceService.GetAllServicesFromDbAsync();
            dgvServices.AutoGenerateColumns = false;
            dgvServices.DataSource = services;
            _selectedService = null;
        }

        // 11.
        private void btnResetFilters_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            cbTypeFilter.SelectedIndex = 0;
            rbStatusAll.Checked = true;
        }

        #endregion

        #region Side panel buttons

        // 8.
        private void cbTypeHu_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbTypeEn.SelectedIndex = cbTypeHu.SelectedIndex;
        }

        // 9.
        private void cbTypeEn_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbTypeHu.SelectedIndex = cbTypeEn.SelectedIndex;
        }

        #endregion

        // -----------------------
        #endregion

        #region Foolproofing

        private void tbNameHu_KeyPress(object sender, KeyPressEventArgs e)
        {
            CommonHelper.InputValidationService.BlockDigits(e);
        }

        private void tbNameEn_KeyPress(object sender, KeyPressEventArgs e)
        {
            CommonHelper.InputValidationService.BlockDigits(e);
        }

        private bool PersonalDataValidationConfirm()
        {
            bool isNameHuValid = !_commonHelper.HasValidationError(tbNameHu, _errorProvider);
            bool isNameEnValid = !_commonHelper.HasValidationError(tbNameEn, _errorProvider);
            bool isDescHuValid = !_commonHelper.HasValidationError(tbDescHu, _errorProvider);
            bool isDescEnValid = !_commonHelper.HasValidationError(tbDescEn, _errorProvider);

            return isNameHuValid && isNameEnValid && isDescHuValid && isDescEnValid;
        }

        #endregion

        #region helpers

        private void SetBoxesReadonlibility(bool isReadOnly)
        {
            if (isReadOnly)
            {
                numPrice.ReadOnly = true;
                cbTypeHu.Enabled = false;
                tbNameHu.ReadOnly = true;
                tbDescHu.ReadOnly = true;

                cbTypeEn.Enabled = false;
                tbNameEn.ReadOnly = true;
                tbDescEn.ReadOnly = true;
            }

            else
            {
                numPrice.ReadOnly = false;
                cbTypeHu.Enabled = true;
                tbNameHu.ReadOnly = false;
                tbDescHu.ReadOnly = false;

                cbTypeEn.Enabled = true;
                tbNameEn.ReadOnly = false;
                tbDescEn.ReadOnly = false;
            }
        }

        private Service MakeNewService(int id = 0)
        {
            Service service = new Service(
                id,
                tbNameHu.Text,
                tbDescHu.Text,
                (ServiceTypeHu)Enum.Parse(typeof(ServiceTypeHu), cbTypeHu.SelectedItem.ToString()),
                numPrice.Value,
                tbNameEn.Text,
                tbDescEn.Text,
                (ServiceTypeEn)Enum.Parse(typeof(ServiceTypeEn), cbTypeEn.SelectedItem.ToString())
            );

            return service;
        }

        private async void SaveService(UpdateOrSave updateOrSave)
        {
            if (!PersonalDataValidationConfirm()) return;

            if (updateOrSave == UpdateOrSave.Save)
            {
                if (cbTypeHu.SelectedIndex == 0 || cbTypeEn.SelectedIndex == 0)
                {
                    MessageBox.Show("You must select a service type first!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            if (updateOrSave == UpdateOrSave.Update)
            {
                bool changed = false;

                if (numPrice.Value != _selectedService.Price
                    || cbTypeHu.Text != _selectedService.SelectedServiceTypeHu.ToString()
                    || tbNameHu.Text != _selectedService.NameHu
                    || tbDescHu.Text != _selectedService.DescriptionHu
                    || tbNameEn.Text != _selectedService.NameEn
                    || tbDescEn.Text != _selectedService.DescriptionEn)
                {
                    changed = true;
                }

                if (!changed)
                {
                    MessageBox.Show(
                        "No data is changed",
                        "No Changes",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );

                    return;
                }
            }

            DialogResult result = MessageBox.Show(
                "Are you sure all the details are correct?",
                "Confirmation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
                );

            if (result == DialogResult.No) return;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (updateOrSave == UpdateOrSave.Save)
                {
                    Service service = MakeNewService(0);
                    await _serviceService.SaveNewServiceToDbAsync(service);

                    MessageBox.Show(
                        "New service saved successfully",
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }

                else
                {
                    Service service = MakeNewService(_selectedService.Id);
                    await _serviceService.UpdateSelectedServiceAsync(service);

                    MessageBox.Show(
                        "Service updated successfully",
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );

                    SetBoxesReadonlibility(true);
                    pnlSideBottom.Visible = false;
                    tabControlLang.Height = tabControlLang.Height + 175;
                }

                services = await _serviceService.GetAllServicesFromDbAsync();
                dgvServices.AutoGenerateColumns = false;
                dgvServices.DataSource = services;
            }
            catch (Exception ex)
            {
                if (updateOrSave == UpdateOrSave.Save)
                {
                    MessageBox.Show(
                        "An error occurred while trying to save the new service: " + ex.Message,
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }

                else
                {
                    MessageBox.Show(
                        "An error occurred while trying to update the service: " + ex.Message,
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }
            finally { Cursor.Current = Cursors.Default; }
        }

        #endregion
    }
}
