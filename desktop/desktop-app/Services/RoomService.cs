using Hotel_erp_Winforms_App.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_erp_Winforms_App.Services
{
    public class RoomService
    {
        private readonly string _connectionString = "server=localhost;port=3306;database=hotelelegancedb;uid=root;pwd=";

        public async Task<List<Room>> GetAllRoomsAsync()
        {
            List<Room> rooms = new List<Room>();
            string query = "SELECT * FROM rooms ORDER BY room_number ASC;";

            await using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                await conn.OpenAsync();
                await using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    await using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            rooms.Add(MapRoomFromReader(reader));
                        }
                    }
                }
            }

            return rooms;
        }

        public async Task<List<Room>> GetFilteredRoomsAsync(string search, string roomType, string status)
        {
            List<Room> rooms = new List<Room>();
            StringBuilder queryBuilder = new StringBuilder("SELECT * FROM rooms WHERE 1=1 ");
            var parameters = new Dictionary<string, object>();

            if (int.TryParse(search, out int roomNumber))
            {
                queryBuilder.Append("AND room_number = @roomNumber ");
                parameters.Add("@roomNumber", roomNumber);
            }

            if (!string.IsNullOrEmpty(roomType) && roomType != "All Types")
            {
                queryBuilder.Append("AND room_type = @roomType ");
                parameters.Add("@roomType", roomType.ToLower());
            }

            if (!string.IsNullOrEmpty(status) && status != "All Statuses")
            {
                queryBuilder.Append("AND status = @status ");
                parameters.Add("@status", status.ToLower());
            }

            queryBuilder.Append("ORDER BY room_number ASC;");

            await using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                await conn.OpenAsync();
                await using (MySqlCommand cmd = new MySqlCommand(queryBuilder.ToString(), conn))
                {
                    foreach (var p in parameters)
                    {
                        cmd.Parameters.AddWithValue(p.Key, p.Value);
                    }

                    await using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            rooms.Add(MapRoomFromReader(reader));
                        }
                    }
                }
            }

            return rooms;
        }

        public async Task SaveOrUpdateRoomAsync(Room room, bool isNew)
        {
            string query;
            if (isNew)
            {
                query = @"
                    INSERT INTO rooms (room_number, room_type, floorspace, bed_type, has_balcony, has_view, max_adults, extras, status, price_per_night, door_locked, needs_cleaning, dont_disturb, is_cleaning, ac_temp)
                    VALUES (@roomNumber, @roomType, @floorspace, @bedType, @hasBalcony, @hasView, @maxAdults, @extras, @status, @price, @doorLocked, @needsCleaning, @dontDisturb, @isCleaning, @acTemp);";
            }
            else
            {
                query = @"
                    UPDATE rooms 
                    SET room_type = @roomType,
                        floorspace = @floorspace,
                        bed_type = @bedType,
                        has_balcony = @hasBalcony,
                        has_view = @hasView,
                        max_adults = @maxAdults,
                        extras = @extras,
                        status = @status,
                        price_per_night = @price,
                        ac_temp = @acTemp
                    WHERE room_number = @roomNumber;";
            }

            await using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                await conn.OpenAsync();
                await using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@roomNumber", room.Room_number);
                    cmd.Parameters.AddWithValue("@roomType", room.RoomsRoomtype.ToString().ToLower());
                    cmd.Parameters.AddWithValue("@floorspace", room.FloorSpace);
                    cmd.Parameters.AddWithValue("@bedType", room.RoomsBedType.ToString().ToLower());
                    cmd.Parameters.AddWithValue("@hasBalcony", room.HasBalcony);
                    cmd.Parameters.AddWithValue("@hasView", room.RoomsView.ToString().ToLower());
                    cmd.Parameters.AddWithValue("@maxAdults", room.MaxAdults);
                    cmd.Parameters.AddWithValue("@extras", string.IsNullOrEmpty(room.Extras) ? (object)DBNull.Value : room.Extras);
                    cmd.Parameters.AddWithValue("@status", room.CurrentStatus.ToString().ToLower());
                    cmd.Parameters.AddWithValue("@price", room.Price);
                    cmd.Parameters.AddWithValue("@doorLocked", room.DoorLocked);
                    cmd.Parameters.AddWithValue("@needsCleaning", room.NeedsCleaning);
                    cmd.Parameters.AddWithValue("@dontDisturb", room.DontDisturb);
                    cmd.Parameters.AddWithValue("@isCleaning", room.IsCleaning);
                    cmd.Parameters.AddWithValue("@acTemp", room.AcTemp);

                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task DeleteRoomAsync(int roomNumber)
        {
            string query = "DELETE FROM rooms WHERE room_number = @roomNumber;";

            await using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                await conn.OpenAsync();
                await using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@roomNumber", roomNumber);
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        private Room MapRoomFromReader(DbDataReader reader)
        {
            return new Room(
                Convert.ToInt32(reader["room_number"]),
                Enum.Parse<Room.RoomType>(reader["room_type"].ToString(), true),
                Convert.ToInt32(reader["floorspace"]),
                Enum.Parse<Room.BedType>(reader["bed_type"].ToString(), true),
                Convert.ToInt32(reader["has_balcony"]),
                reader["has_view"] != DBNull.Value ? Enum.Parse<Room.HasView>(reader["has_view"].ToString(), true) : Room.HasView.city,
                Convert.ToInt32(reader["max_adults"]),
                reader["extras"] != DBNull.Value ? reader["extras"].ToString() : string.Empty,
                Enum.Parse<Room.Status>(reader["status"].ToString(), true),
                reader["price_per_night"] != DBNull.Value ? Convert.ToInt32(reader["price_per_night"]) : 0,
                reader["door_locked"] != DBNull.Value ? Convert.ToInt32(reader["door_locked"]) : 0,
                reader["needs_cleaning"] != DBNull.Value ? Convert.ToInt32(reader["needs_cleaning"]) : 0,
                reader["dont_disturb"] != DBNull.Value ? Convert.ToInt32(reader["dont_disturb"]) : 0,
                reader["is_cleaning"] != DBNull.Value ? Convert.ToInt32(reader["is_cleaning"]) : 0,
                reader["ac_temp"] != DBNull.Value ? Convert.ToInt32(reader["ac_temp"]) : 22
            );
        }
    }
}