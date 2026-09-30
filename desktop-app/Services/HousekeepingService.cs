using Hotel_erp_Winforms_App.Models;
using MySql.Data.MySqlClient;
using System.Text;

namespace Hotel_erp_Winforms_App.Services
{
    internal class HousekeepingService
    {
        #region variables

        private readonly string _connectionString = DbConfig.ConnectionString;

        public enum CleanStatus
        {
            Clean,
            Dirty,
            Pending
        }

        #endregion

        #region Database Actions

        public async Task<List<Room>> GetAllRoomsFromDbAsync()
        {
            List<Room> rooms = new List<Room>();

            string query = @"
                SELECT *
                FROM rooms;";

            await using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                await conn.OpenAsync();

                await using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    await using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            rooms.Add(MakeNewRoom(reader));
                        }
                    }
                }
            }

            return rooms;
        }

        public async Task<List<Room>> GetFilteredRoomsAsync(string search = "", int cleanStatus = 0, int floor = 0)
        {
            List<Room> filteredRooms = new List<Room>();

            StringBuilder queryBuilder = new StringBuilder("SELECT * FROM rooms WHERE 1 = 1 ");

            switch (floor)
            {
                case 1: queryBuilder.Append("AND room_number < 200 "); break;
                case 2: queryBuilder.Append("AND room_number >= 200 AND room_number < 300 "); break;
                case 3: queryBuilder.Append("AND room_number >= 300 AND room_number < 400 "); break;
                case 4: queryBuilder.Append("AND room_number >= 400 "); break;
            }

            switch (cleanStatus)
            {
                case 1: queryBuilder.Append("AND needs_cleaning = 1 "); break;
                case 2: queryBuilder.Append("AND is_cleaning = 1 "); break;
                case 3: queryBuilder.Append("AND needs_cleaning = 0 "); break;
            }

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

        public async Task<List<string>> GetAllCleanersAsync()
        {
            List<string> employees = new List<string>();

            string query = "SELECT fname, lname FROM employees WHERE role = 'Cleaner'";

            await using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                await conn.OpenAsync();

                await using (MySqlCommand cmd = new MySqlCommand(query, conn))
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

            await using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                await conn.OpenAsync();

                await using (MySqlCommand cmd = new MySqlCommand(query, conn))
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

        #endregion

        #region Helpers

        private Room MakeNewRoom(System.Data.Common.DbDataReader reader)
        {
            Enum.TryParse<Room.RoomType>(reader["room_type"]?.ToString(), true, out var roomType);
            Enum.TryParse<Room.BedType>(reader["bed_type"]?.ToString(), true, out var bedType);
            Enum.TryParse<Room.HasView>(reader["has_view"]?.ToString(), true, out var hasView);
            Enum.TryParse<Room.Status>(reader["status"]?.ToString(), true, out var status);

            Room room = new Room(
                Convert.ToInt32(reader["room_number"]),
                roomType,
                Convert.ToInt32(reader["floorspace"]),
                bedType,
                Convert.ToInt32(reader["has_balcony"]),
                reader["has_view"] is DBNull or null ? Room.HasView.city : hasView,
                Convert.ToInt32(reader["max_adults"]),
                reader["extras"] is DBNull or null ? string.Empty : reader["extras"].ToString()!,
                status,
                reader["price_per_night"] is DBNull or null ? 0 : Convert.ToInt32(reader["price_per_night"]),
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

        #region UI

        public void FormatRoomCell(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (sender is not DataGridView dgv || e.Value == null || e.Value == DBNull.Value)
                return;

            string columnName = dgv.Columns[e.ColumnIndex].Name;
            string valueStr = e.Value?.ToString() ?? string.Empty;

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

        public async void ColorCoding(DataGridView dgvRooms, List<Room> needsCleaning, List<Room> isCleaning, List<Room> cleans)
        {
            List<Room> highPrioRooms = await GetHighPriorityRooms();

            ColorCodingHelper(dgvRooms, cleans, Color.Honeydew);
            ColorCodingHelper(dgvRooms, needsCleaning, Color.PapayaWhip);
            ColorCodingHelper(dgvRooms, isCleaning, Color.PaleTurquoise);
            ColorCodingHelper(dgvRooms, highPrioRooms, Color.FromArgb(236, 163, 163));
        }

        public void ResetDataGridViewRowColors(DataGridView dgvRooms)
        {
            DataGridViewCellStyle altStyle = new DataGridViewCellStyle
            {
                BackColor = Color.FromArgb(245, 248, 253),
                SelectionBackColor = SystemColors.Highlight,
                SelectionForeColor = SystemColors.HighlightText
            };

            DataGridViewCellStyle defaultStyle = new DataGridViewCellStyle
            {
                Alignment = DataGridViewContentAlignment.MiddleCenter,
                BackColor = SystemColors.Window,
                Font = new Font("Segoe UI", 9.75F),
                ForeColor = SystemColors.ControlText,
                SelectionBackColor = SystemColors.Highlight,
                SelectionForeColor = SystemColors.HighlightText,
                WrapMode = DataGridViewTriState.False
            };

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