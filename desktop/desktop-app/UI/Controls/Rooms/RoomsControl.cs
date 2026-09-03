using Hotel_erp_Winforms_App.Helpers;
using Hotel_erp_Winforms_App.Models;
using Hotel_erp_Winforms_App.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Hotel_erp_Winforms_App.UI.Controls.Rooms
{
    public partial class RoomsControl : UserControl
    {
        #region TODO
        /*
         * a többi functiont kidolgozni
        */
        #endregion

        #region variables

        private List<Room> _roomsList = new List<Room>();

        private RoomService _roomService = new RoomService();
        private CommonHelper _commonHelper = new CommonHelper();

        private Room? _selectedRoom;
        private bool _isAddingNew = false;

        #endregion

        #region constructor

        public RoomsControl()
        {
            InitializeComponent();
        }

        #endregion

        #region on load functions, UI defaults

        private void RoomsControl_Load(object sender, EventArgs e)
        {
            cbTypeFilter.SelectedIndex = 0;
            cbStatusFilter.SelectedIndex = 0;
            LoadRooms();
        }

        private async void LoadRooms()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                _roomsList = await _roomService.GetAllRoomsAsync();

                dgvRooms.AutoGenerateColumns = false;
                dgvRooms.DataSource = _roomsList;

                UpdateKpis();

                if (dgvRooms.Rows.Count > 0)
                {
                    RowSelection(0);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading rooms: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        #endregion

        #region INFO
        /*
            1.: Search / Filter
            2.: Refresh
            3.: Dgv cellclick
            4.: Add room
            5.: Save room
            6.: Delete room
        */
        #endregion
        #region buttons

        // 1.
        private async void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                _roomsList = await _roomService.GetFilteredRoomsAsync(
                    txtSearch.Text.Trim(),
                    cbTypeFilter.SelectedItem?.ToString() ?? "All Types",
                    cbStatusFilter.SelectedItem?.ToString() ?? "All Statuses"
                );

                _commonHelper.EmptyListMessageBox(_roomsList.Count(), "rooms");

                dgvRooms.DataSource = _roomsList;
                UpdateKpis();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Filter error: " + ex.Message);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        // 2.
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            cbTypeFilter.SelectedIndex = 0;
            cbStatusFilter.SelectedIndex = 0;
            LoadRooms();
        }

        // 3.
        private void dgvRooms_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                RowSelection(e.RowIndex);
            }
        }

        // 4.
        private void btnNewRoom_Click(object sender, EventArgs e)
        {
            _isAddingNew = true;
            dgvRooms.ClearSelection();
            _selectedRoom = null;

            tbRoomNumber.ReadOnly = false;
            tbRoomNumber.Clear();
            cbRoomType.SelectedIndex = 0;
            cbBedType.SelectedIndex = 0;
            tbFloorSpace.Text = "30";
            tbMaxAdults.Text = "2";
            tbPrice.Text = "20000";
            cbStatus.SelectedIndex = 0;
            cbView.SelectedIndex = 0;
            chkBalcony.Checked = false;
            tbExtras.Clear();
            tbAcTemp.Text = "22";

            tbRoomNumber.Focus();
        }

        // 5.
        private async void btnSaveRoom_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(tbRoomNumber.Text.Trim(), out int roomNumber) || roomNumber <= 0)
            {
                MessageBox.Show("Please enter a valid room number!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int floorSpace = int.TryParse(tbFloorSpace.Text, out int fs) ? fs : 25;
            int maxAdults = int.TryParse(tbMaxAdults.Text, out int ma) ? ma : 2;
            int price = int.TryParse(tbPrice.Text, out int pr) ? pr : 20000;
            int acTemp = int.TryParse(tbAcTemp.Text, out int ac) ? ac : 22;

            Room.RoomType roomType = Enum.TryParse<Room.RoomType>(cbRoomType.Text, true, out var rt) ? rt : Room.RoomType.standard;
            Room.BedType bedType = Enum.TryParse<Room.BedType>(cbBedType.Text, true, out var bt) ? bt : Room.BedType.single;
            Room.Status status = Enum.TryParse<Room.Status>(cbStatus.Text, true, out var st) ? st : Room.Status.available;
            Room.HasView view = Enum.TryParse<Room.HasView>(cbView.Text, true, out var vi) ? vi : Room.HasView.city;

            Room room = new Room(
                roomNumber,
                roomType,
                floorSpace,
                bedType,
                chkBalcony.Checked ? 1 : 0,
                view,
                maxAdults,
                tbExtras.Text.Trim(),
                status,
                price,
                0, 0, 0, 0,
                acTemp
            );

            //try
            //{
            //    Cursor.Current = Cursors.WaitCursor;
            //    await _roomService.SaveOrUpdateRoomAsync(room, _isAddingNew);

            //    MessageBox.Show("Room saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    LoadRooms();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Database error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            //finally
            //{
            //    Cursor.Current = Cursors.Default;
            //}
        }

        // 6.
        private async void btnDeleteRoom_Click(object sender, EventArgs e)
        {
            //if (_selectedRoom != null)
            //{
            //    DialogResult res = MessageBox.Show($"Are you sure you want to delete Room #{_selectedRoom.Room_number}?", "Delete Room", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            //    if (res == DialogResult.Yes)
            //    {
            //        try
            //        {
            //            Cursor.Current = Cursors.WaitCursor;
            //            await _roomService.DeleteRoomAsync(_selectedRoom.Room_number);
            //            MessageBox.Show("Room deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //            LoadRooms();
            //        }
            //        catch (Exception ex)
            //        {
            //            MessageBox.Show("Error deleting room: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        }
            //        finally
            //        {
            //            Cursor.Current = Cursors.Default;
            //        }
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("Please select a room to delete first!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
        }

        #endregion

        #region INFO
        /*
            1.: update KPI counters
            2.: fill textboxes, selectors and controls from selected room
        */
        #endregion
        #region Helpers

        // 1.
        private void UpdateKpis()
        {
            lbKpiTotalValue.Text = _roomsList.Count.ToString();
            lbKpiAvailableValue.Text = _roomsList.Count(r => r.CurrentStatus == Room.Status.available).ToString();
            lbKpiOccupiedValue.Text = _roomsList.Count(r => r.CurrentStatus == Room.Status.occupied || r.CurrentStatus == Room.Status.unavailable).ToString();
            lbKpiMaintenanceValue.Text = _roomsList.Count(r => r.CurrentStatus == Room.Status.under_maintenance).ToString();
        }

        // 2.
        private void RowSelection(int index)
        {
            if (index < 0 || index >= dgvRooms.Rows.Count) return;

            _selectedRoom = dgvRooms.Rows[index].DataBoundItem as Room;
            if (_selectedRoom == null) return;

            _isAddingNew = false;
            tbRoomNumber.ReadOnly = true;

            tbRoomNumber.Text = _selectedRoom.Room_number.ToString();
            cbRoomType.Text = _selectedRoom.RoomsRoomtype.ToString().ToLower();
            cbBedType.Text = _selectedRoom.RoomsBedType.ToString().ToLower();
            tbFloorSpace.Text = _selectedRoom.FloorSpace.ToString();
            tbMaxAdults.Text = _selectedRoom.MaxAdults.ToString();
            tbPrice.Text = _selectedRoom.Price.ToString();
            cbStatus.Text = _selectedRoom.CurrentStatus.ToString().ToLower();
            cbView.Text = _selectedRoom.RoomsView.ToString().ToLower();
            chkBalcony.Checked = _selectedRoom.HasBalcony == 1;
            tbExtras.Text = _selectedRoom.Extras ?? "";
            tbAcTemp.Text = _selectedRoom.AcTemp.ToString();
        }

        #endregion
    }
}