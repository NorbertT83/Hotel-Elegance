using Hotel_erp_Winforms_App.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Reflection;
using System.Text;

namespace Hotel_erp_Winforms_App.Services
{
    public class RoomService
    {
        #region variables

        private readonly string _connectionString = DbConfig.ConnectionString;

        #endregion

        #region INFO
        /*
         * 1.: returns a list of all rooms in database
        */
        #endregion
        #region database actions

        // 1.
        public async Task<List<Room>> GetAllRoomsAsync()
        {
            var rooms = new List<Room>();

            string query = "SELECT * FROM rooms";

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

        // 2.
        public async Task<List<Room>> GetFilteredRoomsAsync(string search, string type, string status)
        {
            var rooms = new List<Room>();
            Dictionary<string, string> parameters = new Dictionary<string, string>();

            string selectQuery = "SELECT * FROM rooms WHERE 1=1 ";
            string whereClauses = "";

            if (!string.IsNullOrWhiteSpace(search))
            {
                whereClauses += " AND CAST(room_number AS CHAR) LIKE @search";

                parameters.Add("@search", $"%{search.Trim()}%");
            }

            // típus szűrő
            whereClauses += type switch
            {
                "All Types" => "",
                "Standard" => " AND room_type = 'standard' ",
                "Deluxe" => " AND room_type = 'deluxe' ",
                "Suite" => " AND room_type = 'suite' ",
                _ => ""
            };

            // státusz szűrő
            whereClauses += status switch
            {
                "All Statuses" => "",
                "Available" => " AND rooms.status = 'available' ",
                "Occupied" => " AND rooms.status = 'occupied' ",
                "Under Maintenance" => " AND rooms.status = 'under_maintenance' ",
                "Unavailable" => " AND rooms.status = 'unavailable' ",
                _ => ""
            };

            string query = selectQuery + whereClauses + ';';

            await using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                await conn.OpenAsync();

                await using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    foreach (var param in parameters)
                    {
                        cmd.Parameters.AddWithValue(param.Key, param.Value);
                    }

                    await using(var reader = await cmd.ExecuteReaderAsync())
                    {
                        while(await reader.ReadAsync())
                        {
                            Room room = MakeNewRoom(reader);

                            rooms.Add(room);
                        }
                    }
                }
            }

            return rooms;
        }

        #endregion

        #region helpers

        public Room MakeNewRoom(DbDataReader reader)
        {
            int roomNumber = Convert.ToInt32(reader["room_number"]);

            Enum.TryParse<Room.RoomType>(reader["room_type"]?.ToString(), true, out var roomType);
            Enum.TryParse<Room.BedType>(reader["bed_type"]?.ToString(), true, out var bedType);
            Enum.TryParse<Room.Status>(reader["status"]?.ToString(), true, out var status);
            Enum.TryParse<Room.HasView>(reader["has_view"]?.ToString(), true, out var view);

            int floorSpace = Convert.ToInt32(reader["floorspace"]);
            int hasBalcony = Convert.ToInt32(reader["has_balcony"]);
            int maxAdults = Convert.ToInt32(reader["max_adults"]);
            string extras = reader["extras"] != DBNull.Value ? reader["extras"].ToString() ?? "" : "";
            int price = reader["price_per_night"] != DBNull.Value ? Convert.ToInt32(reader["price_per_night"]) : 0;

            int doorLocked = Convert.ToInt32(reader["door_locked"]);
            int needsCleaning = Convert.ToInt32(reader["needs_cleaning"]);
            int dontDisturb = Convert.ToInt32(reader["dont_disturb"]);
            int isCleaning = Convert.ToInt32(reader["is_cleaning"]);
            int acTemp = Convert.ToInt32(reader["ac_temp"]);

            return new Room(
                roomNumber,
                roomType,
                floorSpace,
                bedType,
                hasBalcony,
                view,
                maxAdults,
                extras,
                status,
                price,
                doorLocked,
                needsCleaning,
                dontDisturb,
                isCleaning,
                acTemp
            );
        }

        #endregion

        //_roomsList = await _roomService.GetFilteredRoomsAsync(
        //            txtSearch.Text.Trim(),
        //            cbTypeFilter.SelectedItem?.ToString() ?? "All Types",
        //            cbStatusFilter.SelectedItem?.ToString() ?? "All Statuses"
        //        );

        //GetFilteredRoomsAsync();

        //SaveOrUpdateRoomAsync(room, _isAddingNew);

        //DeleteRoomAsync(_selectedRoom.Room_number);

    }
}
