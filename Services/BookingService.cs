using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Hotel_erp_Winforms_App.Models;
using Microsoft.Data.SqlClient;

namespace Hotel_erp_Winforms_App.Services
{
    public class BookingService
    {
        public List<Booking> GetAllBookings()
        {
            List<Booking> bookings = new List<Booking>();

            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=HotelDB;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False;Command Timeout=30";
            string query = "SELECT * FROM bookings";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DateTime? checkinValue = reader["checkin"] == DBNull.Value ? null : (DateTime?)Convert.ToDateTime(reader["checkin"]);
                        DateTime? checkoutValue = reader["checkout"] == DBNull.Value ? null : (DateTime?)Convert.ToDateTime(reader["checkout"]);

                        Booking booking = new Booking
                        (
                            Convert.ToInt32(reader["id"]),
                            Convert.ToInt32(reader["room_number"]),
                            Convert.ToInt32(reader["guest_id1"]),
                            Convert.ToDateTime(reader["beginning_of_stay"]),
                            Convert.ToDateTime(reader["end_of_stay"]),
                            checkinValue,
                            checkoutValue,
                            Convert.ToInt32(reader["guest_id2"]),
                            Convert.ToInt32(reader["guest_id3"]),
                            Convert.ToInt32(reader["guest_id4"]),
                            reader["level_of_service"]?.ToString() ?? string.Empty
                        );
                        bookings.Add(booking);
                    }
                }
            }
            return bookings;
        }

        public void AddBooking(Booking booking)
        {
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=HotelDB;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False;Command Timeout=30";
            string query = "INSERT INTO bookings (room_number, guest_id1, beginning_of_stay, end_of_stay, level_of_service)" +
                           "VALUES (@room, @guest, @start, @end, @level)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@room", booking.RoomNumber);
                cmd.Parameters.AddWithValue("@guest", booking.GuestId);
                cmd.Parameters.AddWithValue("@start", booking.BeginningOfStay);
                cmd.Parameters.AddWithValue("@end", booking.EndOfStay);
                cmd.Parameters.AddWithValue("@level", booking.LevelOfService);

                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
