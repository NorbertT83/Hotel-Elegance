using Google.Protobuf.WellKnownTypes;
using Hotel_erp_Winforms_App.Models;
using Hotel_erp_Winforms_App.UI.Controls.RoomCardControl;
using Hotel_erp_Winforms_App.UI.Forms.ServiceForms;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.BC;
using System;
using System.Collections.Generic;
using System.Data;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Hotel_erp_Winforms_App.UI.Controls.RoomCardControl;

namespace Hotel_erp_Winforms_App.Services
{
    public class BookingService
    {
        private readonly string connectionString = "Server=localhost;Database=hotelelegancedb;uid=root;pwd=";

        public List<Booking> LoadDgv(string query, Dictionary<string, object> parameters = null)
        {
            List<Booking> bookings = new List<Booking>();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);

                if(parameters != null)
                {
                    foreach(var param in parameters)
                    {
                        cmd.Parameters.AddWithValue(param.Key, param.Value);
                    }
                }

                connection.Open();
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DateTime? checkinValue = reader["checkin"] == DBNull.Value ? null : (DateTime?)Convert.ToDateTime(reader["checkin"]);
                        DateTime? checkoutValue = reader["checkout"] == DBNull.Value ? null : (DateTime?)Convert.ToDateTime(reader["checkout"]);
                        DateTime? createdAtValue = reader["created_at"] == DBNull.Value ? null : (DateTime?)Convert.ToDateTime(reader["created_at"]);

                        int? guest2 = reader["guest2_id"] == DBNull.Value ? null : (int?)Convert.ToInt32(reader["guest2_id"]);
                        int? guest3 = reader["guest3_id"] == DBNull.Value ? null : (int?)Convert.ToInt32(reader["guest3_id"]);
                        int? guest4 = reader["guest4_id"] == DBNull.Value ? null : (int?)Convert.ToInt32(reader["guest4_id"]);

                        RoomType roomTypeEnum = (Hotel_erp_Winforms_App.Models.RoomType)System.Enum.Parse(typeof(RoomType), reader["room_type"].ToString(), true);
                        CateringLevel cateringEnum = (Hotel_erp_Winforms_App.Models.CateringLevel)System.Enum.Parse(typeof(CateringLevel), reader["catering_level"].ToString(), true);

                        Booking booking = new Booking
                        (
                            reader["id"].ToString() ?? string.Empty,
                            Convert.ToInt32(reader["room_number"]),
                            roomTypeEnum,
                            Convert.ToInt32(reader["guest1_id"]),
                            Convert.ToDateTime(reader["beginning_of_stay"]),
                            Convert.ToDateTime(reader["end_of_stay"]),
                            checkinValue,
                            checkoutValue,
                            guest2,
                            guest3,
                            guest4,
                            cateringEnum,
                            createdAtValue
                        );
                        bookings.Add(booking);
                    }
                }
            }
            return bookings;
        }

        public List<Booking> SearchBookings(int fieldIndex, string searchText, int statusIndex, int tabIndex, int spanIndex, DateTime fromDate, DateTime toDate)
        {
            string query = "SELECT * FROM bookings WHERE 1=1";
            var parameters = new Dictionary<string, object>();

            if(tabIndex == 0)
            {
                // MEZŐ KIVÁLASZTÁS
                if (!string.IsNullOrEmpty(searchText))
                {
                    switch (fieldIndex)
                    {
                        case -1: query += " "; break;
                        case 0: query += " "; break;
                        case 1: query += " AND id LIKE @searchBar "; break;
                        case 2: query += " AND room_number LIKE @searchBar "; break;
                        case 3: query += " AND room_type LIKE @searchBar "; break;
                        case 4: query += " AND beginning_of_stay LIKE @searchBar "; break;
                        case 5: query += " AND end_of_stay LIKE @searchBar "; break;
                        case 6: query += " AND checkin LIKE @searchBar "; break;
                        case 7: query += " AND checkout LIKE @searchBar "; break;
                        case 8: query += " AND catering_level LIKE @searchBar "; break;
                    }
                    parameters.Add("@searchBar", $"%{searchText}%");
                }

                // STÁTUSZ KIVÁLASZTÁS
                switch (statusIndex)
                {
                    case 1: query += " AND checkin IS NULL"; break;
                    case 2: query += " AND checkin IS NOT NULL AND checkout IS NULL"; break;
                    case 3: query += " AND checkout IS NOT NULL"; break;
                }
            }

            // IDŐSZAK KIVÁLASZTÁS
            if(tabIndex == 1)
            {
                switch (spanIndex)
                {
                    case 0: 
                        query += " AND beginning_of_stay BETWEEN @from AND @to";
                        break;
                    case 1:
                        query += " AND end_of_stay BETWEEN @from AND @to";
                        break;
                    case 2:
                        query += " AND beginning_of_stay >= @from AND end_of_stay <= @to";
                        break;
                }
                parameters.Add("@from", fromDate.Date);
                parameters.Add("@to", toDate.Date);
            }

            query += ";";

            return LoadDgv(query, parameters);
        }

        public Booking GetBookingById(string id)
        {
            using(MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT * FROM bookings WHERE @id = id";

                using(MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    connection.Open();

                    using(MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Booking(
                                reader["id"].ToString(),
                                Convert.ToInt32(reader["room_number"]),
                                (Hotel_erp_Winforms_App.Models.RoomType)System.Enum.Parse(typeof(Hotel_erp_Winforms_App.Models.RoomType), reader["room_type"].ToString()),
                                Convert.ToInt32(reader["guest1_id"]),
                                Convert.ToDateTime(reader["beginning_of_stay"]),
                                Convert.ToDateTime(reader["end_of_stay"]),
                                reader["checkin"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["checkin"]),
                                reader["checkout"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["checkout"]),
                                reader["guest2_id"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["guest2_id"]),
                                reader["guest3_id"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["guest3_id"]),
                                reader["guest4_id"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["guest4_id"]),
                                (Hotel_erp_Winforms_App.Models.CateringLevel)System.Enum.Parse(typeof(Hotel_erp_Winforms_App.Models.CateringLevel), reader["catering_level"].ToString()),
                                Convert.ToDateTime(reader["created_at"])
                            );
                        }
                    }
                }
            }
            return null;
        }

        public int GetTodaysArrivalsCount()
        {
            string query = "SELECT COUNT(*) FROM bookings WHERE beginning_of_stay = CURRENT_DATE;";

            using(MySqlConnection conn = new MySqlConnection(connectionString))
            {
                using(MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    conn.Open();
                    return (int)(long)cmd.ExecuteScalar();
                }
            }
        }

        public int GetTodaysDeparturesCount()
        {
            string query = "SELECT COUNT(*) FROM bookings WHERE end_of_stay = CURRENT_DATE();";
            using(MySqlConnection conn = new MySqlConnection(connectionString))
            {
                using(MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    conn.Open();
                    return (int)(long)cmd.ExecuteScalar();
                }
            }
        }

        public void SaveGuest(Guest guest)
        {
            string query = "INSERT INTO guests " +
                "(email, id_card_number, fname, lname, date_of_birth, country, zip_code, city, street, car_plate_number, total_nights) " +
                "VALUES (@email, @idNumber, @fname, @lname, @birthDate, @country, @zipCode, @city, @street, @carPlateNUmber, @totalNights, @loyaltyLevel);";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                using( MySqlCommand cmd = new MySqlCommand( query, conn))
                {
                    cmd.Parameters.AddWithValue("@email", guest.Email);
                    cmd.Parameters.AddWithValue("@idNumber", guest.IdCardNumber);
                    cmd.Parameters.AddWithValue("@fname", guest.FName);
                    cmd.Parameters.AddWithValue("@lname", guest.LName);
                    cmd.Parameters.AddWithValue("@birtDate", guest.DateOfBirth);
                    cmd.Parameters.AddWithValue("@county", guest.Country);
                    cmd.Parameters.AddWithValue("@zipCode", guest.ZipCode);
                    cmd.Parameters.AddWithValue("@city", guest.City);
                    cmd.Parameters.AddWithValue("@street", guest.Street);
                    cmd.Parameters.AddWithValue("@carPlateNumber", guest.CarPlateNumber);
                    cmd.Parameters.AddWithValue("@totalNights", guest.TotalNights);
                    cmd.Parameters.AddWithValue("@loyaltyLevel", guest.LoyaltyLevel);

                    conn.Open();

                    int rowsAffected = cmd.ExecuteNonQuery();
                }
            }
        }

        public List<Room> SelectedRoomsByBooking(Booking booking)
        {
            List<Room> rooms = new List<Room>();
            string query = "SELECT * " +
                "FROM rooms " +
                "WHERE status = 'available' " +
                "AND needs_cleaning = 0 " +
                "AND is_cleaning = 0 " +
                "AND room_type = @roomType;";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@roomType", booking.SelectedRoomType.ToString());
                    conn.Open();

                    using(MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Room room = new Room
                            (
                                Convert.ToInt32(reader["room_number"]),
                                (Room.RoomType)System.Enum.Parse(typeof(Room.RoomType), reader["room_type"].ToString()),
                                Convert.ToInt32(reader["floorspace"]),
                                (Room.BedType)System.Enum.Parse(typeof(Room.BedType), reader["bed_type"].ToString()),
                                Convert.ToInt32(reader["has_balcony"]),
                                (Room.HasView)System.Enum.Parse(typeof(Room.HasView), reader["has_view"].ToString()),
                                Convert.ToInt32(reader["max_adults"]),
                                reader["extras"].ToString(),
                                (Room.Status)System.Enum.Parse(typeof(Room.Status), reader["status"].ToString()),
                                Convert.ToInt32(reader["price_per_night"]),
                                Convert.ToInt32(reader["door_locked"]),
                                Convert.ToInt32(reader["needs_cleaning"]),
                                Convert.ToInt32(reader["dont_disturb"]),
                                Convert.ToInt32(reader["is_cleaning"]),
                                Convert.ToInt32(reader["ac_temp"])
                            );

                            rooms.Add(room);
                        }
                        conn.Close();
                    }
                }
            }

            return rooms;
        }
    }
}
