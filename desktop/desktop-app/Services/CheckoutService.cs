using Hotel_erp_Winforms_App.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.IO.Packaging;
using System.Text;

namespace Hotel_erp_Winforms_App.Services
{
    internal class CheckoutService
    {
        #region variables

        string _connectionString = DbConfig.ConnectionString;

        #endregion

        #region INFO
        /*
         * 1.: gets all servicebookings from db
        */
        #endregion
        #region database actions

        // 1.
        public async Task<List<CheckoutSumHelper>> GetServiceItemsAsync(string bookingId)
        {
            List<CheckoutSumHelper> serviceItems = new List<CheckoutSumHelper>();

            string query = @"
                SELECT s.name_en as name, sb.quantity as qty, s.price as price, sb.price_at_booking as priceAtB
                FROM servicebookings sb
                INNER JOIN services s ON s.id = sb.service_id
                INNER JOIN bookings b ON sb.booking_id = b.id
                WHERE b.id = @id;";

            await using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                await conn.OpenAsync();

                await using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", bookingId);

                    await using(var reader = await cmd.ExecuteReaderAsync())
                    {
                        while(await reader.ReadAsync())
                        {
                            CheckoutSumHelper item = new CheckoutSumHelper(
                                reader["name"]?.ToString(),
                                Convert.ToInt32(reader["qty"]),
                                Convert.ToInt32(reader["price"]),
                                Convert.ToInt32(reader["priceAtB"])
                            );

                            serviceItems.Add(item);
                        }
                    }
                }
            }

            return serviceItems;
        }

        // 2.
        public async Task CheckoutBookingAsync(Booking booking)
        {
            string query = @"
                UPDATE bookings b
                JOIN rooms r ON b.room_number = r.room_number
                SET b.checkout = NOW(), 
                    r.status = 'under_maintenance', 
                    r.needs_cleaning = 1
                WHERE b.id = @id";

            await using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                await conn.OpenAsync();

                await using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", booking.Id);

                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }
        #endregion
    }
}
