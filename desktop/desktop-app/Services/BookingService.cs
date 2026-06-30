using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Hotel_erp_Winforms_App.Models;
using Org.BouncyCastle.Asn1.BC;
using MySql.Data.MySqlClient;

namespace Hotel_erp_Winforms_App.Services
{
    public class BookingService
    {
        private readonly string connectionString = "Server=localhost;Database=hotelelegancedb;uid=root;pwd=";

        public List<Booking> LoadDgv(string query)
        {
            List<Booking> bookings = new List<Booking>();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
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

                        RoomType roomTypeEnum = (RoomType)Enum.Parse(typeof(RoomType), reader["room_type"].ToString(), true);
                        CateringLevel cateringEnum = (CateringLevel)Enum.Parse(typeof(CateringLevel), reader["catering_level"].ToString(), true);

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

        //public void AddBooking(Booking booking)
        //{
        //    string connectionString = "Server=localhost;Database=hotelelegancedb;uid=root;pwd=";
        //    string query = "INSERT INTO bookings (room_number, guest_id1, beginning_of_stay, end_of_stay, level_of_service)" +
        //                   "VALUES (@room, @guest, @start, @end, @level)";

        //    using (MySqlConnection connection = new MySqlConnection(connectionString))
        //    {
        //        MySqlCommand cmd = new MySqlCommand(query, connection);
        //        cmd.Parameters.AddWithValue("@room", booking.RoomNumber);
        //        cmd.Parameters.AddWithValue("@guest", booking.GuestId);
        //        cmd.Parameters.AddWithValue("@start", booking.BeginningOfStay);
        //        cmd.Parameters.AddWithValue("@end", booking.EndOfStay);
        //        cmd.Parameters.AddWithValue("@level", booking.CateringLevel);

        //        connection.Open();
        //        cmd.ExecuteNonQuery();
        //    }
        //}
    }
}
