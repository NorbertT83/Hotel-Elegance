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
using static Hotel_erp_Winforms_App.Helpers.CommonHelper;

namespace Hotel_erp_Winforms_App.UI.Controls
{
    public partial class HousekeepingControl : UserControl
    {
        /* TODO:
         * side panel comboboxon szoba státusz állítása és mentése
         * reset all buttonnel kezdeni valamit
         * floor és status cb-knek legyen defaultja
        */

        public HousekeepingControl()
        {
            InitializeComponent();
        }

        #region variables

        private HousekeepingService _hkService = new HousekeepingService();

        private List<Room> rooms = new List<Room>();
        private List<Room> highPrioRooms = new List<Room>();
        private List<string> cleaners = new List<string>();

        private Dictionary<int, string> assignedCleaners = new Dictionary<int, string>();

        private Room _selectedRoom;

        #endregion

        #region onLoad events

        private async void HousekeepingControl_Load(object sender, EventArgs e)
        {
            #region data

            try
            {
                Cursor.Current = Cursors.WaitCursor;
                rooms = await _hkService.GetAllRoomsFromDbAsync();
                cleaners = await _hkService.GetAllCleanersAsync();
                highPrioRooms = await _hkService.GetHighPriorityRooms();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occured while trying to load database: {ex.Message}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }

            FillDictionary(assignedCleaners, rooms);

            #endregion

            #region UI defaults

            lbPrioTitle.Visible = false;
            lbPrioColor.Visible = false;
            lbNeedsCleaningTitle.Visible = false;
            lbNeedsCleaningColor.Visible = false;
            lbUnderMaintenanceTitle.Visible = false;
            lbUnderMaintenanceColor.Visible = false;
            lbCleanTitle.Visible = false;
            lbCleanColor.Visible = false;

            btnSaveRoomStatus.Visible = false;

            lbKpiDirtyValue.Text = rooms.Count(r => r.NeedsCleaning == 1).ToString();
            lbKpiProgressValue.Text = rooms.Count(r => r.IsCleaning == 1).ToString();
            lbKpiCleanValue.Text = rooms.Count(r => r.NeedsCleaning == 0).ToString();
            lbKpiStaffValue.Text = cleaners.Count().ToString();

            cbAssignCleaner.SelectedIndex = 0;

            foreach (string c in cleaners) cbAssignCleaner.Items.Add(c);

            #endregion

            #region datagridview

            dgvRooms.AutoGenerateColumns = false;
            dgvRooms.DataSource = rooms;
            dgvRooms.CellFormatting += _hkService.FormatRoomCell;

            #endregion
        }

        #endregion

        #region INFO
        /*
         * 1.: search button
         * 2.: refresh button
         * 3.: dgv cellclick
         * 4.: update and save button
         * 5.: setting color codes
        */
        #endregion
        #region buttons
        // 1.
        private async void btnSearch_Click(object sender, EventArgs e)
        {
            int cleanStatus = cbStatusFilter.SelectedIndex;
            int floor = cbFloorFilter.SelectedIndex;

            rooms = await _hkService.GetFilteredRoomsAsync(txtRoomSearch.Text, cleanStatus, floor);

            dgvRooms.DataSource = rooms;
        }

        // 2.
        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            rooms = await _hkService.GetAllRoomsFromDbAsync();
            dgvRooms.DataSource = rooms;
        }

        // 3.
        private void dgvRooms_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnSaveRoomStatus.Visible = true;

            if (dgvRooms.Rows.Count > 0)
            {
                if (e.RowIndex < 0) return;

                _selectedRoom = (Room)dgvRooms.Rows[e.RowIndex].DataBoundItem;
            }

            lbSelectedRoomValue.Text = _selectedRoom.Room_number.ToString();
            cbSetStatus.Text = _selectedRoom.IsCleaning == 1 ? "In Progress" : _selectedRoom.NeedsCleaning switch
            {
                0 => "Clean",
                1 => "Dirty"
            };

            cbAssignCleaner.Text = assignedCleaners[_selectedRoom.Room_number] == null ? "Unassigned" : assignedCleaners[_selectedRoom.Room_number];
        }

        // 4.
        private void btnSaveRoomStatus_Click(object sender, EventArgs e)
        {
            if (cbAssignCleaner.SelectedIndex < 1)
            {
                MessageBox.Show(
                    "You must assign a Cleaner first!",
                    "Error",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Error);

                return;
            }

            assignedCleaners[_selectedRoom.Room_number] = cbAssignCleaner.Text;

            MessageBox.Show(
                    "Cleaner assigned successfully",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
        }

        // 5.
        private void cbColorCodes_CheckedChanged(object sender, EventArgs e)
        {
            List<Room> needsCleaning = rooms.Where(r => r.NeedsCleaning == 1).ToList();
            List<Room> isCleaning = rooms.Where(r => r.IsCleaning == 1).ToList();
            List<Room> cleans = rooms.Where(r => r.NeedsCleaning == 0).ToList();

            if (cbColorCodes.Checked)
            {
                _hkService.ColorCoding(dgvRooms, needsCleaning, isCleaning, cleans);

                lbPrioTitle.Visible = true;
                lbPrioColor.Visible = true;
                lbNeedsCleaningTitle.Visible = true;
                lbNeedsCleaningColor.Visible = true;
                lbUnderMaintenanceTitle.Visible = true;
                lbUnderMaintenanceColor.Visible = true;
                lbCleanTitle.Visible = true;
                lbCleanColor.Visible = true;
            }

            else if (!cbColorCodes.Checked)
            {
                _hkService.ResetDataGridViewRowColors(dgvRooms);

                lbPrioTitle.Visible = false;
                lbPrioColor.Visible = false;
                lbNeedsCleaningTitle.Visible = false;
                lbNeedsCleaningColor.Visible = false;
                lbUnderMaintenanceTitle.Visible = false;
                lbUnderMaintenanceColor.Visible = false;
                lbCleanTitle.Visible = false;
                lbCleanColor.Visible = false;
            }
        }

        #endregion

        #region INFO
        /*
         * textbox keypress handler
        */
        #endregion
        #region Foolproofing
        private void txtRoomSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputValidationService.BlockLetters(e);
        }
        #endregion

        #region INFO
        /*
         * 1.: dgv cells formatting
        */
        #endregion
        #region helpers

        private void FillDictionary(Dictionary<int, string> dic, List<Room> list)
        {
            foreach (var room in list)
            {
                dic.Add(room.Room_number, "Unassigned");
            }
        }

        #endregion
    }
}
