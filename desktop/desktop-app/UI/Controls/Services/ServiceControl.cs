using Hotel_erp_Winforms_App.Helpers;
using Hotel_erp_Winforms_App.Models;
using Hotel_erp_Winforms_App.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;

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
         * NEW SERVICE BOOKINGOT BEFEJEZNI
         * -> NEM FRISSUL AZ ÁR, NAGYON SOKSZOR VAN UGYANAZ A SZOBASZÁM A COMBOBOXBAN
        */

        #endregion

        #region variables

        ServiceService _serviceService = new ServiceService();
        List<Service> services = new List<Service>();
        List<Service> filteredServices = new List<Service>();
        List<RequestedService> serviceBookings;

        Service _selectedService;
        Service? _selectedServiceForServiceBooking;
        RequestedService _selectedRequestedService;

        CommonHelper _commonHelper = new CommonHelper();
        BookingService _bookingService = new BookingService();
        RoomService _roomService = new RoomService();

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

            dgvServices.AutoGenerateColumns = false;

            dgvServices.Columns["colPrice"].DisplayIndex = 10;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                services = await _serviceService.GetAllServicesFromDbAsync();
                dgvServices.DataSource = services;

                dgvServices.ClearSelection();
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

            RefreshActiveOrInactiveCountAsync();

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
            if (rbStatusActive.Checked)
            {
                bool includeHistory = chkShowHistory.Checked;
                serviceBookings = await _serviceService.GetServiceDataByServicebookingAsync(includeHistory);

                List<RequestedService> result = rbOrderBy.Checked
                    ? serviceBookings.OrderBy(s => s.RequestedAt).ToList()
                    : serviceBookings.OrderByDescending(s => s.RequestedAt).ToList();

                if (int.TryParse(cbRoomNumbers.Text.Trim(), out int searchedRoom))
                {
                    result = result.Where(s => s.RoomNumber == searchedRoom).ToList();
                }

                dgvServices.DataSource = null;
                dgvServices.DataSource = result;

                dgvServices.ClearSelection();
            }

            else
            {
                Cursor.Current = Cursors.WaitCursor;
                SetDgvVisibility(false);
                rbStatusAll.Checked = true;

                List<Service> filteredServices = await _serviceService.GetFilteredSerivicesAsync(cbTypeFilter.SelectedIndex, txtSearch.Text);

                dgvServices.DataSource = filteredServices;

                Cursor.Current = Cursors.Default;
            }
        }

        // 2.
        private async void rbStatusActive_CheckedChanged(object sender, EventArgs e)
        {
            DataGridViewTextBoxColumn roomNumberCol;

            if (rbStatusActive.Checked)
            {
                try
                {
                    cbRoomNumbers.Text = string.Empty;

                    Cursor.Current = Cursors.WaitCursor;

                    serviceBookings = await _serviceService.GetServiceDataByServicebookingAsync();
                    List<RequestedService> orderedSBList = serviceBookings.OrderByDescending(s => s.RequestedAt).ToList();

                    _commonHelper.EmptyListMessageBox(orderedSBList.Count(), "service bookings");

                    dgvServices.DataSource = orderedSBList;
                    colId.DataPropertyName = "Id";

                    pnlStatusEditor.Visible = true;
                    btnUpdateStatus.Enabled = false;

                    ClearEditorBoxes();
                    dgvServices.ClearSelection();

                    SetDgvVisibility(true);

                    cbRoomNumbers.Items.Clear();

                    foreach (RequestedService rs in serviceBookings)
                    {
                        cbRoomNumbers.Items.Add(rs.RoomNumber);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "An error occurred while trying to load the database: " + ex.Message,
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                    return;
                }
                finally
                {
                    Cursor.Current = Cursors.Default;
                }
            }
        }

        // 3.
        private async void rbStatusInactive_CheckedChanged(object sender, EventArgs e)
        {
            if (rbStatusInactive.Checked)
            {
                Cursor.Current = Cursors.WaitCursor;

                List<Service> inActiveServices = await _serviceService.GetActiveOrInactiveServicesAsync("notUsed");

                dgvServices.AutoGenerateColumns = false;
                dgvServices.DataSource = inActiveServices;

                _commonHelper.EmptyListMessageBox(inActiveServices.Count(), "services");

                ClearEditorBoxes();
                dgvServices.ClearSelection();

                SetDgvVisibility(false);

                Cursor.Current = Cursors.Default;

                pnlEditor.Visible = true;
                pnlNewServiceBooking.Visible = false;
                pnlStatusEditor.Visible = false;
                pnlDeleteEditor.Visible = false;
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

                _commonHelper.EmptyListMessageBox(services.Count(), "services");

                ClearEditorBoxes();
                dgvServices.ClearSelection();

                SetDgvVisibility(false);

                Cursor.Current = Cursors.Default;

                pnlEditor.Visible = true;
                pnlNewServiceBooking.Visible = false;
                pnlStatusEditor.Visible = false;
                pnlDeleteEditor.Visible = false;
            }
        }

        // 5.
        private async void chkShowHistory_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                await ApplyFiltersAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "An error occurred while applying filters: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        // 6.
        private async void rbOrderBy_CheckedChanged(object sender, EventArgs e)
        {
            ApplyFiltersAsync();
        }

        #endregion

        #region dgv
        // 5.
        private async void dgvServices_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (rbStatusActive.Checked)
            {
                if (e.RowIndex >= 0)
                {
                    _selectedRequestedService = dgvServices.Rows[e.RowIndex].DataBoundItem as RequestedService;

                    btnUpdateService.Enabled = _selectedRequestedService.CurrentServiceStatus == ServiceStatus.created ||
                        _selectedRequestedService.CurrentServiceStatus == ServiceStatus.pending;

                    cbNewStatus.Enabled = false;
                    btnUpdateStatus.Enabled = false;

                    if (!cbNewStatus.Items.Contains("Created") && !cbNewStatus.Items.Contains("Deleted"))
                    {
                        cbNewStatus.Items.Add("Created");
                        cbNewStatus.Items.Add("Deleted");
                    }

                    if (_selectedRequestedService != null)
                    {
                        // UPDATE SERVICE PANEL
                        lbServiceNameValue.Text = _selectedRequestedService.Name;
                        lbRoomNumberValue.Text = _selectedRequestedService.RoomNumber.ToString();

                        lbCurrentStatusValue.Text = _selectedRequestedService.CurrentServiceStatus switch
                        {
                            ServiceStatus.created => "CREATED",
                            ServiceStatus.pending => "PENDING",
                            ServiceStatus.deleted => "DELETED",
                            ServiceStatus.completed => "COMPLETED"
                        };

                        cbNewStatus.Text = _selectedRequestedService.CurrentServiceStatus switch
                        {
                            ServiceStatus.created => "Created",
                            ServiceStatus.pending => "Pending",
                            ServiceStatus.deleted => "Deleted",
                            ServiceStatus.completed => "Completed"
                        };

                        // DELETE SERVICE PANEL
                        lbDeleteServiceNameValue.Text = _selectedRequestedService.Name;
                        lbDeleteRoomNumberValue.Text = _selectedRequestedService.RoomNumber.ToString();
                        lbDeleteQuantityValue.Text = _selectedRequestedService.Quantity.ToString();
                        lbDeletePriceValue.Text = _selectedRequestedService.Price.ToString();
                        lbDeleteCurrentStatusValue.Text = _selectedRequestedService.CurrentServiceStatus switch
                        {
                            ServiceStatus.created => "Created",
                            ServiceStatus.pending => "Pending",
                            ServiceStatus.deleted => "Deleted",
                            ServiceStatus.completed => "Completed"
                        };
                        lbDeleteReqDateValue.Text = _selectedRequestedService.RequestedAt.ToString();
                    }
                }
            }

            else
            {
                List<Service> actives = await _serviceService.GetActiveOrInactiveServicesAsync("active");

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
        }

        #endregion

        #region Actions buttons
        // 6.
        private async void btnNewService_Click(object sender, EventArgs e)
        {
            if (rbStatusActive.Checked)
            {
                pnlEditor.Visible = false;
                pnlStatusEditor.Visible = false;
                pnlDeleteEditor.Visible = false;

                pnlNewServiceBooking.Visible = true;

                dgvServices.ClearSelection();

                _selectedRequestedService = null;

                cbSelectRoom.Items.Clear();

                List<Booking> bookings = await _bookingService.LoadDgvAsync();
                List<Room> rooms = await _roomService.GetAllRoomsAsync();

                List<Booking> currentBookings = bookings
                    .Where(b => b.Checkin != null && b.Checkout == null)
                    .ToList();

                List<int> currentRoomNumbers = currentBookings
                    .Select(c => c.RoomNumber)
                    .ToList();

                List<Room> currentRooms = rooms
                    .Where(r => currentRoomNumbers.Contains(r.Room_number))
                    .ToList();

                foreach (var c in currentRooms)
                {
                    cbSelectRoom.Items.Add(c.Room_number.ToString());
                }

                cbSelectService.Items.Clear();
                foreach (var s in services)
                {
                    cbSelectService.Items.Add(s.NameEn);
                }
            }

            else
            {
                pnlStatusEditor.Visible = false;
                pnlNewServiceBooking.Visible = false;

                pnlEditor.Visible = true;


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
            if (rbStatusActive.Checked)
            {
                MBSelectionRequired(_selectedRequestedService);

                if (_selectedRequestedService != null)
                {
                    pnlEditor.Visible = false;
                    pnlNewServiceBooking.Visible = false;
                    pnlDeleteEditor.Visible = false;
                    pnlStatusEditor.Visible = true;

                    btnUpdateStatus.Enabled = true;
                    cbNewStatus.Enabled = true;

                    cbNewStatus.Items.Remove("Created");
                    cbNewStatus.Items.Remove("Deleted");

                    cbNewStatus.Text = _selectedRequestedService.CurrentServiceStatus switch
                    {
                        ServiceStatus.created => "Pending",
                        ServiceStatus.pending => "Completed"
                    };
                }
            }

            else
            {
                pnlStatusEditor.Visible = false;
                pnlNewServiceBooking.Visible = false;

                pnlEditor.Visible = true;

                MBSelectionRequired(_selectedService);

                SetBoxesReadonlibility(false);

                tabControlLang.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

                if (!resized)
                {
                    tabControlLang.Height = tabControlLang.Height - 175;
                    resized = true;
                }

                pnlSideBottom.Visible = true;
            }
        }

        // 9.
        private async void btnDeleteService_Click(object sender, EventArgs e)
        {
            // AKTÍV SERVICE BOOKINGS
            if (rbStatusActive.Checked)
            {
                MBSelectionRequired(_selectedRequestedService);

                if (_selectedRequestedService != null)
                {
                    pnlEditor.Visible = false;
                    pnlNewServiceBooking.Visible = false;
                    pnlStatusEditor.Visible = false;
                    pnlDeleteEditor.Visible = true;

                    if (_selectedRequestedService.CurrentServiceStatus == ServiceStatus.completed
                    || _selectedRequestedService.CurrentServiceStatus == ServiceStatus.deleted)
                    {
                        MBCantDeleteService(_selectedRequestedService);
                    }
                }
            }

            // MINDEN SERVICE
            else
            {
                MBSelectionRequired(_selectedService);

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

                    MBSuccessfulDbAction();
                }
                catch (Exception ex)
                {
                    _commonHelper.MBErrorMessage(ex);
                }
                finally
                {
                    Cursor.Current = Cursors.Default;

                    services = await _serviceService.GetAllServicesFromDbAsync();
                    dgvServices.AutoGenerateColumns = false;
                    dgvServices.DataSource = services;

                    _selectedService = null;
                    dgvServices.ClearSelection();
                }
            }
        }

        // 10.
        private async void btnUpdateStatus_Click(object sender, EventArgs e)
        {
            if (cbNewStatus.Text.ToLower() == _selectedRequestedService.CurrentServiceStatus.ToString())
            {
                MessageBox.Show(
                    "No changes were made",
                    "No Changes Detected",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
            }

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (Enum.TryParse<ServiceStatus>(cbNewStatus.Text, true, out var serviceStatus))
                {
                    _selectedRequestedService.CurrentServiceStatus = serviceStatus;
                }

                await _serviceService.UpdateServiceBookingStatusAsync(_selectedRequestedService);

                MBSuccessfulDbAction(default, "updated");

                List<RequestedService> source = await _serviceService.GetServiceDataByServicebookingAsync(chkShowHistory.Checked);
                List<RequestedService> orderedSource = rbOrderBy.Checked
                    ? source.OrderBy(s => s.RequestedAt).ToList()
                    : source.OrderByDescending(s => s.RequestedAt).ToList();

                dgvServices.DataSource = null;
                dgvServices.DataSource = orderedSource;
                dgvServices.ClearSelection();

                RefreshActiveOrInactiveCountAsync();
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

        // 11.
        private async void btnAddBooking_Click(object sender, EventArgs e)
        {
            string name = cbSelectService.Text;

            Service? selectedService = services.Find(s =>
                string.Equals(s.NameEn, name, StringComparison.OrdinalIgnoreCase));

            if (selectedService == null)
            {
                MessageBox.Show(
                    "The selected service does not exist. Please choose a valid service from the list.",
                    "Service Not Found",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            if (!int.TryParse(cbSelectRoom.Text, out int roomNumber))
            {
                MessageBox.Show(
                    "Please select a room.",
                    "Room Required",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            DialogResult result = MessageBox.Show(
                "Are you sure all the details are correct?",
                "Confirmation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
                );

            if (result == DialogResult.No)
            {
                return;
            }

            else
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;

                    ServiceBooking sb = await MakeNewServiceBookingAsync(roomNumber, selectedService);

                    await _serviceService.SaveNewServiceBookingAsync(sb);

                    MBSuccessfulDbAction(default, "saved");

                    serviceBookings = await _serviceService.GetServiceDataByServicebookingAsync(chkShowHistory.Checked);

                    dgvServices.DataSource = null;
                    dgvServices.DataSource = serviceBookings;
                    dgvServices.ClearSelection();
                    RefreshActiveOrInactiveCountAsync();
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
        }

        // 12.
        private async void btnDeleteServiceBooking_Click(object sender, EventArgs e)
        {
            bool isPending = _selectedRequestedService?.CurrentServiceStatus == ServiceStatus.pending;

            string message = isPending
                ? "This service booking is currently pending. Are you sure you want to delete it?"
                : "Are you sure you want to delete this service booking?";

            string title = isPending
                ? "Delete Pending Service Booking"
                : "Delete Service Booking";

            DialogResult result = MessageBox.Show(
                message,
                title,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;

                    if(_selectedRequestedService != null)
                    {
                        await _serviceService.SetServiceBookingStatusToDeletedAsync(_selectedRequestedService.Id);

                        MBSuccessfulDbAction();

                        pnlDeleteEditor.Visible = false;
                        pnlStatusEditor.Visible = true;

                        await ReloadDbDataSourceAsync();
                        await RefreshActiveOrInactiveCountAsync();
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
        }
        #endregion

        #region Refresh buttons

        // 10.
        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            rbStatusAll.Checked = true;

            services = await _serviceService.GetAllServicesFromDbAsync();
            dgvServices.AutoGenerateColumns = false;
            dgvServices.DataSource = services;
            _selectedService = null;
            dgvServices.ClearSelection();

            SetDgvVisibility(false);
        }

        // 11.
        private void btnResetFilters_Click(object sender, EventArgs e)
        {
            rbStatusAll.Checked = true;

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

        // 10.
        private void cbSelectService_SelectedIndexChanged(object sender, EventArgs e)
        {
            _selectedServiceForServiceBooking = services.Find(s =>
                string.Equals(s.NameEn, cbSelectService.Text, StringComparison.OrdinalIgnoreCase));

            if (_selectedServiceForServiceBooking != null)
            {
                RefreshNewServiceBookingPrice(_selectedServiceForServiceBooking);
            }
        }

        // 11.
        private void numQuantity_ValueChanged(object sender, EventArgs e)
        {
            if (cbSelectService.SelectedItem != null)
            {
                RefreshNewServiceBookingPrice(_selectedServiceForServiceBooking);
            }
        }

        // 12.
        private void btnNewServiceClear_Click(object sender, EventArgs e)
        {
            cbSelectRoom.SelectedIndex = -1;
            cbSelectService.Text = "";
            numQuantity.Value = 1;
            lbTotalPriceValue.Text = "0 HUF";
        }

        #endregion

        // -----------------------
        #endregion

        #region Foolproofing

        private void cbRoomNumbers_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (rbStatusActive.Checked)
            {
                CommonHelper.InputValidationService.BlockLetters(e);
            }
        }

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

                dgvServices.ClearSelection();
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

        private void SetDgvVisibility(bool isActivesFiltered)
        {
            if (isActivesFiltered)
            {
                colRoomNumber.Visible = true;
                colStatus.Visible = true;
                colRequestDate.Visible = true;
                colQuantity.Visible = true;

                colNameHu.Visible = false;
                colTypeHu.Visible = false;
                colDescHu.Visible = false;
                colDescEn.Visible = false;

                dgvServices.Columns["colNameEn"].DisplayIndex = 4;
                dgvServices.Columns["colTypeEn"].DisplayIndex = 5;
                dgvServices.Columns["colQuantity"].DisplayIndex = 6;
                dgvServices.Columns["colPrice"].DisplayIndex = 7;

                colNameEn.DataPropertyName = "Name";
                colTypeEn.DataPropertyName = "SelectedServiceType";

                colNameEn.FillWeight = 100;
                colTypeEn.FillWeight = 80;
                colPrice.FillWeight = 60;
                colQuantity.FillWeight = 50;

                lbRoomNumber.Visible = true;
                cbRoomNumbers.Visible = true;

                lbSearch.Visible = false;
                txtSearch.Visible = false;
                cbTypeFilter.Visible = false;
                lbTypeFilter.Visible = false;

                lbHistory.Visible = true;
                chkShowHistory.Visible = true;
                pnlRbHolder.Visible = true;

                pnlEditor.Visible = false;

                btnSearch.Location = new Point(btnSearch.Location.X - 205, btnSearch.Location.Y);

                _selectedRequestedService = null;
            }

            else
            {
                colRoomNumber.Visible = false;
                colStatus.Visible = false;
                colRequestDate.Visible = false;
                colQuantity.Visible = false;

                colNameHu.Visible = true;
                colTypeHu.Visible = true;
                colDescHu.Visible = true;
                colDescEn.Visible = true;

                dgvServices.Columns["colNameEn"].DisplayIndex = 5;
                dgvServices.Columns["colTypeEn"].DisplayIndex = 6;
                dgvServices.Columns["colPrice"].DisplayIndex = 10;

                colNameEn.DataPropertyName = "NameEn";
                colTypeEn.DataPropertyName = "SelectedServiceTypeEn";

                colNameEn.FillWeight = 20;
                colTypeEn.FillWeight = 12;
                colPrice.FillWeight = 10;

                lbRoomNumber.Visible = false;
                cbRoomNumbers.Visible = false;

                lbSearch.Visible = true;
                txtSearch.Visible = true;
                cbTypeFilter.Visible = true;
                lbTypeFilter.Visible = true;

                lbHistory.Visible = false;
                chkShowHistory.Visible = false;
                pnlRbHolder.Visible = false;

                pnlEditor.Visible = true;

                if (btnSearch.Location.X < 435)
                {
                    btnSearch.Location = new Point(btnSearch.Location.X + 205, btnSearch.Location.Y);
                }
            }
        }

        private async Task ApplyFiltersAsync()
        {
            bool includeHistory = chkShowHistory.Checked;
            serviceBookings = await _serviceService.GetServiceDataByServicebookingAsync(includeHistory);

            IEnumerable<RequestedService> filtered = serviceBookings;

            if (!string.IsNullOrWhiteSpace(cbRoomNumbers.Text) &&
                int.TryParse(cbRoomNumbers.Text.Trim(), out int selectedRoom))
            {
                filtered = filtered.Where(s => s.RoomNumber == selectedRoom);
            }

            List<RequestedService> result = rbOrderBy.Checked
                ? filtered.OrderBy(s => s.RequestedAt).ToList()
                : filtered.OrderByDescending(s => s.RequestedAt).ToList();

            dgvServices.DataSource = null;
            dgvServices.DataSource = result;

            dgvServices.ClearSelection();
        }

        private void ClearEditorBoxes()
        {
            tbNameHu.Clear();
            tbNameEn.Clear();
            cbTypeHu.SelectedIndex = 0;
            cbTypeEn.SelectedIndex = 0;
            tbDescHu.Clear();
            tbDescEn.Clear();
            numPrice.Value = 0;
            chkIsActive.Checked = false;
        }

        private void RefreshNewServiceBookingPrice(Service selectedService)
        {
            if (selectedService != null)
            {
                int price = (int)selectedService.Price * (int)numQuantity.Value;

                lbTotalPriceValue.Text = $"{price} HUF";
            }
        }

        private async Task RefreshActiveOrInactiveCountAsync()
        {
            List<RequestedService> activesList = await _serviceService.GetServiceDataByServicebookingAsync(false);

            lbTotalServices.Text = "Total services: " + services.Count();
            lbActiveServices.Text = "In progress: " + activesList.Count();
        }

        private void MBSelectionRequired(object obj)
        {
            if (obj == null)
            {
                MessageBox.Show(
                    "You must select a service first!",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                return;
            }
        }

        private void MBCantDeleteService(RequestedService service)
        {
            string mbStatus = service.CurrentServiceStatus switch
            {
                ServiceStatus.completed => "completed",
                ServiceStatus.deleted => "deleted",
                _ => "unknown"
            };

            MessageBox.Show(
                $"Cannot delete this service booking because it is already {mbStatus}.",
                "Cannot Delete Booking",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            return;
        }

        private void MBSuccessfulDbAction(Status status = Status.deleted, string statusString = "")
        {
            if (statusString != "")
            {
                MessageBox.Show(
                    $"Service booking {statusString.ToString()} successfully.",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }

            else
            {
                MessageBox.Show(
                    $"Service booking {status.ToString()} successfully.",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        private async Task<ServiceBooking> MakeNewServiceBookingAsync(int roomNumber, Service selectedService)
        {
            List<Booking> bookings = await _bookingService.LoadDgvAsync();
            Booking? selectedBooking = bookings.Find(b =>
                b.RoomNumber == roomNumber &&
                b.Checkin.HasValue &&
                !b.Checkout.HasValue
            );

            int price = (int)selectedService.Price * (int)numQuantity.Value;

            ServiceBooking sb = new ServiceBooking(
                0,
                selectedBooking.Id,
                selectedService.Id,
                DateTime.Now,
                DateTime.Now,
                (int)numQuantity.Value,
                Status.created,
                price
            );

            return sb;
        }

        private async Task ReloadDbDataSourceAsync()
        {
            List<RequestedService> source = await _serviceService.GetServiceDataByServicebookingAsync(chkShowHistory.Checked);
            List<RequestedService> orderedSource = rbOrderBy.Checked
                ? source.OrderBy(s => s.RequestedAt).ToList()
                : source.OrderByDescending(s => s.RequestedAt).ToList();

            dgvServices.DataSource = null;
            dgvServices.DataSource = orderedSource;

            _selectedRequestedService = null;

            dgvServices.ClearSelection();
        }
        #endregion
    }
}
