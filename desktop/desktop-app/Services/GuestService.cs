using Hotel_erp_Winforms_App.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography;
using System.Security.Permissions;
using System.Text;

namespace Hotel_erp_Winforms_App.Services
{
    internal class GuestService
    {
        #region variables

        private readonly string _connectionString = DbConfig.ConnectionString;

        #endregion

        #region INFO
        /*
            1.: returns a list of all the guests in the database
            2.: returns a list of guests by the parameter name and loyalty category
            3.: uploads the parameter guest to database
        */
        #endregion
        #region database actions
        // 1.
        public async Task<List<Guest>> GetAllGuestsFromDbAsync()
        {
            string query = "SELECT * FROM guests;";
            List<Guest> guests = new List<Guest>();

            await using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                await conn.OpenAsync();

                await using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    await using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            Guest g = MakeNewGuest(reader);
                            guests.Add(g);
                        }
                    }
                }
            }

            return guests;
        }

        // 2.
        public async Task<List<Guest>> GetFilteredGuestListAsync(string search, string loyalty)
        {
            List<Guest> guests = new List<Guest>();
            int loyaltyLevel = GetLoyaltyLevelBySelectedCategory(loyalty);

            string query = @"
                SELECT * 
                FROM guests
                WHERE (email LIKE @search 
                    OR id_card_number LIKE @search
                    OR fname LIKE @search
                    OR lname LIKE @search
                    OR date_of_birth LIKE @search
                    OR country LIKE @search
                    OR zip_code LIKE @search
                    OR city LIKE @search
                    OR street LIKE @search
                    OR car_plate_number LIKE @search
                    OR total_nights LIKE @search)
                  AND (@loyalty = -1 OR loyalty_level = @loyalty);";

            await using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                await conn.OpenAsync();

                await using(MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@search", $"%{search}%");
                    cmd.Parameters.AddWithValue("@loyalty", loyaltyLevel);

                    await using(var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            Guest g = MakeNewGuest(reader);
                            guests.Add(g);
                        }
                    }
                }
            }

            return guests;
        }

        // 3.
        public async Task SaveGuestToDatabaseAsync(Guest g)
        {
            string query = @"
                INSERT INTO guests
                    (email, id_card_number, fname, lname, date_of_birth, country, zip_code, city, street, car_plate_number)
                VALUES
                    (@email, @id_card_number, @fname, @lname, @birthDate, @country, @zip, @city, @street, @carPlate)
            ";

            await using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                await conn.OpenAsync();

                await using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@email", g.Email);
                    cmd.Parameters.AddWithValue("@id_card_number", g.IdCardNumber ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@fname", g.FName);
                    cmd.Parameters.AddWithValue("@lname", g.LName);
                    cmd.Parameters.AddWithValue("@birthDate", g.DateOfBirth == null ? DBNull.Value : g.DateOfBirth);
                    cmd.Parameters.AddWithValue("@country", g.Country);
                    cmd.Parameters.AddWithValue("@zip", g.ZipCode);
                    cmd.Parameters.AddWithValue("@city", g.City);
                    cmd.Parameters.AddWithValue("@street", g.Street);
                    cmd.Parameters.AddWithValue("@carPlate", g.CarPlateNumber ?? (object)DBNull.Value);

                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        // 4.
        public async Task DeleteGuestFromDbAsync(Guest g)
        {
            string query = @"
                DELETE FROM guests
                WHERE id = @id;
            ";

            await using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                await conn.OpenAsync();

                await using(MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", g.Id);

                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        // ---- HELPERS ----
        private string? GetStringOrNull(object dbValue)
        {
            return dbValue is DBNull ? null : dbValue.ToString();
        }

        private Guest MakeNewGuest(System.Data.Common.DbDataReader reader)
        {
            Guest g = new Guest
            (
                Convert.ToInt32(reader["id"]),
                reader["email"].ToString(),
                GetStringOrNull(reader["id_card_number"]),
                reader["fname"].ToString(),
                reader["lname"].ToString(),
                reader["date_of_birth"] is DBNull ? null : Convert.ToDateTime(reader["date_of_birth"]),
                reader["country"].ToString(),
                reader["zip_code"].ToString(),
                reader["city"].ToString(),
                reader["street"].ToString(),
                GetStringOrNull(reader["car_plate_number"]),
                Convert.ToInt32(reader["total_nights"]),
                Convert.ToInt32(reader["loyalty_level"])
            );

            return g;
        }
        #endregion

        #region INFO
        /*
            1.: returns the number of guests with loyalty level: 2
            2.: returns the number of currently staying guests
            3.: returns the number of guests with more than one booking in the database
        */
        #endregion
        #region Counters

        // 1.
        public int GetNumberOfVipGuests(List<Guest> guests)
        {
            int count = guests.Count(g => g.LoyaltyLevel == 2);

            return count;
        }

        // 2.
        public int GetNumberOfCurrentlyStayers(List<Booking> bookings)
        {
            if (bookings == null) return 0;

            int count = bookings
                .Where(b => b.Checkin != null && b.Checkout == null)
                .Sum(b => (b.GuestId != null ? 1 : 0) +
                          (b.GuestId2 != null ? 1 : 0) +
                          (b.GuestId3 != null ? 1 : 0) +
                          (b.GuestId4 != null ? 1 : 0));

            return count;
        }

        // 3.
        public int GetNumberOfReturningGuests(List<Booking> bookings)
        {
            if (bookings == null) return 0;

            int returningCount = bookings
                .SelectMany(b => new[] { (int?)b.GuestId, b.GuestId2, b.GuestId3, b.GuestId4 })
                .Where(id => id.HasValue)
                .Select(id => id.Value)
                .GroupBy(id => id)
                .Count(g => g.Count() > 1);

            return returningCount;
        }

        #endregion

        #region INFO
        /*
            1.: returns the loyalty level number by the selected category
        */
        #endregion
        #region filtering methods
        // 1.
        public int GetLoyaltyLevelBySelectedCategory(string category)
        {
            if (string.IsNullOrWhiteSpace(category)) return 0;

            switch (category.Trim().ToLower())
            {
                case "all": return -1;
                case "standard": return 0;
                case "corporate": return 1;
                case "vip": return 2;
                default: return -1;
            }
        }

        #endregion
    }
}
