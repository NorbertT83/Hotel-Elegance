using Hotel_erp_Winforms_App.Models;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.BC;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel_erp_Winforms_App.Services
{
    internal class HousekeepingService
    {
        #region variables

        private readonly string _connectionString = "server=localhost;port=3306;database=hotelelegancedb;uid=root;pwd=";

        public enum CleanStatus
        {
            Clean,
            Dirty,
            Pending
        }

        #endregion

        #region INFO
        /*
         * 1.: gets every room from database
         * 2.: returns a list of filtered rooms by parameters
         * 3.: returns the number of cleaners from employees
         * 4.: returns a list of rooms where an associated guests loyalty level = 2, or the associated booking has early check in
        */
        #endregion
        #region database actions

        // 1.
        public async Task<List<Room>> GetAllRoomsFromDbAsync()
        {
            List<Room> rooms = new List<Room>();

            string query = @"
                SELECT *
                FROM rooms;";

            await using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                await conn.OpenAsync();

                await using(MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    await using(var reader = await cmd.ExecuteReaderAsync())
                    {
                        while(await reader.ReadAsync())
                        {
                            rooms.Add(MakeNewRoom(reader));
                        }
                    }
                }
            }

            return rooms;
        }

        // 2.
        public async Task<List<Room>> GetFilteredRoomsAsync(string search = "", int cleanStatus = 0, int floor = 0)
        {
            List<Room> filteredRooms = new List<Room>();

            StringBuilder queryBuilder = new StringBuilder("SELECT * FROM rooms WHERE 1 = 1 ");

            // Emelet
            switch (floor)
            {
                case 1: queryBuilder.Append("AND room_number < 200 "); break;
                case 2: queryBuilder.Append("AND room_number >= 200 AND room_number < 300 "); break;
                case 3: queryBuilder.Append("AND room_number >= 300 AND room_number < 400 "); break;
                case 4: queryBuilder.Append("AND room_number >= 400 "); break;
            }

            // Tisztasági státusz
            switch (cleanStatus)
            {
                case 1: queryBuilder.Append("AND needs_cleaning = 1 "); break;
                case 2: queryBuilder.Append("AND is_cleaning = 1 "); break;
                case 3: queryBuilder.Append("AND needs_cleaning = 0 "); break;
            }

            // Szobaszám keresés
            bool isNumericSearch = int.TryParse(search, out int roomNumber);

            if (isNumericSearch)
            {
                queryBuilder.Append("AND room_number = @roomNumber ");
            }

            await using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                await conn.OpenAsync();

                await using (MySqlCommand cmd = new MySqlCommand(queryBuilder.ToString(), conn))
                {
                    if (isNumericSearch)
                    {
                        cmd.Parameters.AddWithValue("@roomNumber", roomNumber);
                    }

                    await using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            Room r = MakeNewRoom(reader);
                            filteredRooms.Add(r);
                        }
                    }
                }
            }

            return filteredRooms;
        }

        // 3.
        public async Task<List<string>> GetAllCleanersAsync()
        {
            List<string> employees = new List<string>();

            string query = "SELECT fname, lname FROM employees WHERE role = 'Cleaner'";

            await using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                await conn.OpenAsync();

                await using(MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    await using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            string employee = $"{reader["lname"]} {reader["fname"]}".Trim();

                            employees.Add(employee);
                        }
                    }

                    return employees;
                }
            }
        }

        // 4.
        public async Task<List<Room>> GetHighPriorityRooms()
        {
            List<Room> rooms = new List<Room>();

            string query = @"
                SELECT DISTINCT r.*
                FROM rooms r
                JOIN bookings b ON r.room_number = b.room_number
                LEFT JOIN servicebookings sb ON b.id = sb.booking_id
                LEFT JOIN services s ON sb.service_id = s.id
                LEFT JOIN guests g ON g.id_card_number IN (b.guest1_id, b.guest2_id, b.guest3_id, b.guest4_id)
                WHERE s.name_hu = 'Korai bejelentkezés'
                   OR g.loyalty_level = 2;";

            await using(MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                await conn.OpenAsync();

                await using(MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    await using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            Room room = MakeNewRoom(reader);

                            rooms.Add(room);
                        }
                    }
                }
            }

            return rooms;
        }

        // 5.
        public async Task UpdateCleanStatusInDbAsync(CleanStatus status, int roomNumber)
        {
            StringBuilder querySb = new StringBuilder("UPDATE rooms SET ");

            switch (status)
            {
                case CleanStatus.Clean: querySb.Append("needs_cleaning = 0, is_cleaning = 0 "); break;
                case CleanStatus.Dirty: querySb.Append("needs_cleaning = 1, is_cleaning = 0 "); break;
                case CleanStatus.Pending: querySb.Append("is_cleaning = 1, needs_cleaning = 1 "); break;
                default: throw new ArgumentOutOfRangeException(nameof(status), status, "Unknown CleanStatus value.");
            }

            querySb.Append("WHERE room_number = @roomNumber;");

            await using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                await conn.OpenAsync();

                await using (MySqlCommand cmd = new MySqlCommand(querySb.ToString(), conn))
                {
                    cmd.Parameters.AddWithValue("@roomNumber", roomNumber);

                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        #region helpers

        private Room MakeNewRoom(System.Data.Common.DbDataReader reader)
        {
            Room room = new Room(
                Convert.ToInt32(reader["room_number"]),
                Enum.Parse<Room.RoomType>(reader["room_type"].ToString(), true),
                Convert.ToInt32(reader["floorspace"]),
                Enum.Parse<Room.BedType>(reader["bed_type"].ToString(), true),
                Convert.ToInt32(reader["has_balcony"]),
                reader["has_view"] != DBNull.Value
                    ? Enum.Parse<Room.HasView>(reader["has_view"].ToString(), true)
                    : Room.HasView.city,
                Convert.ToInt32(reader["max_adults"]),
                reader["extras"] != DBNull.Value ? reader["extras"].ToString() : string.Empty,
                Enum.Parse<Room.Status>(reader["status"].ToString(), true),
                reader["price_per_night"] != DBNull.Value ? Convert.ToInt32(reader["price_per_night"]) : 0,
                Convert.ToInt32(reader["door_locked"]),
                Convert.ToInt32(reader["needs_cleaning"]),
                Convert.ToInt32(reader["dont_disturb"]),
                Convert.ToInt32(reader["is_cleaning"]),
                Convert.ToInt32(reader["ac_temp"])
            );

            return room;
        }

        private void ColorCodingHelper(DataGridView dgvRooms, List<Room> roomList, Color color)
        {
            for (int i = 0; i < dgvRooms.Rows.Count; i++)
            {
                if (dgvRooms.Rows[i].IsNewRow) continue;

                int roomNumber = Convert.ToInt32(dgvRooms.Rows[i].Cells["colRoomNumber"].Value);

                List<int> list = roomList.Select(r => r.Room_number).ToList();

                bool stateDefine = list.Contains(roomNumber);

                if (stateDefine)
                {
                    dgvRooms.Rows[i].DefaultCellStyle.BackColor = color;
                }
            }
        }

        #endregion

        #endregion

        #region INFO
        /*
         * 1.: formatting dgv cells
         * 2.: color code
         * 3.: setting dgv row colors to default
        */
        #endregion
        #region UI
        // 1.
        public void FormatRoomCell(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (sender is not DataGridView dgv || e.Value == null || e.Value == DBNull.Value)
                return;

            string columnName = dgv.Columns[e.ColumnIndex].Name;
            string valueStr = e.Value.ToString();

            if (columnName.Equals("colFloor", StringComparison.OrdinalIgnoreCase))
            {
                if (!string.IsNullOrEmpty(valueStr))
                {
                    char firstChar = valueStr[0];
                    e.Value = firstChar switch
                    {
                        '1' => "1.",
                        '2' => "2.",
                        '3' => "3.",
                        '4' => "4.",
                        _ => "Other"
                    };
                    e.FormattingApplied = true;
                }
            }
            else if (columnName.Equals("colCleaningStatus", StringComparison.OrdinalIgnoreCase))
            {
                if (int.TryParse(valueStr, out int needsCleaning))
                {
                    e.Value = (needsCleaning == 0) ? "Clean" : "Needs cleaning";
                    e.FormattingApplied = true;
                }
            }
            else if (columnName.Equals("colDisturb", StringComparison.OrdinalIgnoreCase))
            {
                if (int.TryParse(valueStr, out int disturb))
                {
                    e.Value = (disturb == 0) ? "Service allowed" : "Don't disturb";
                    e.FormattingApplied = true;
                }
            }
            else if (columnName.Equals("colIsCleaning", StringComparison.OrdinalIgnoreCase))
            {
                if (int.TryParse(valueStr, out int cleaning))
                {
                    e.Value = (cleaning == 0) ? "No" : "In Progress";
                    e.FormattingApplied = true;
                }
            }
        }

        // 2.
        public async void ColorCoding(DataGridView dgvRooms, List<Room> needsCleaning, List<Room> isCleaning, List<Room> cleans)
        {
            List<Room> highPrioRooms = await GetHighPriorityRooms();

            // Clean color
            ColorCodingHelper(dgvRooms, cleans, Color.Honeydew);

            // Needs Cleaning color
            ColorCodingHelper(dgvRooms, needsCleaning, Color.PapayaWhip);

            // Is Cleaning color
            ColorCodingHelper(dgvRooms, isCleaning, Color.PaleTurquoise);

            // High prio color
            ColorCodingHelper(dgvRooms, highPrioRooms, Color.FromArgb(236, 163, 163));
        }

        // 3.
        public void ResetDataGridViewRowColors(DataGridView dgvRooms)
        {
            DataGridViewCellStyle altStyle = new DataGridViewCellStyle();
            altStyle.BackColor = Color.FromArgb(245, 248, 253);
            altStyle.SelectionBackColor = SystemColors.Highlight;
            altStyle.SelectionForeColor = SystemColors.HighlightText;

            DataGridViewCellStyle defaultStyle = new DataGridViewCellStyle();
            defaultStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            defaultStyle.BackColor = SystemColors.Window;
            defaultStyle.Font = new Font("Segoe UI", 9.75F);
            defaultStyle.ForeColor = SystemColors.ControlText;
            defaultStyle.SelectionBackColor = SystemColors.Highlight;
            defaultStyle.SelectionForeColor = SystemColors.HighlightText;
            defaultStyle.WrapMode = DataGridViewTriState.False;

            dgvRooms.AlternatingRowsDefaultCellStyle = altStyle;
            dgvRooms.DefaultCellStyle = defaultStyle;

            foreach (DataGridViewRow row in dgvRooms.Rows)
            {
                row.DefaultCellStyle.BackColor = Color.Empty;
            }
        }
        #endregion
    }
}