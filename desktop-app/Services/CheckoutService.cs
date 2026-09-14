using Hotel_erp_Winforms_App.Models;
using MySql.Data.MySqlClient;

namespace Hotel_erp_Winforms_App.Services
{
    internal class CheckoutService
    {
        private readonly string _connectionString = DbConfig.ConnectionString;

        public async Task<List<CheckoutSumHelper>> GetServiceItemsAsync(string bookingId)
        {
            var serviceItems = new List<CheckoutSumHelper>();

            const string query = @"
                SELECT s.name_en AS name, sb.quantity AS qty, s.price AS price, sb.price_at_booking AS priceAtB
                FROM servicebookings sb
                INNER JOIN services s ON s.id = sb.service_id
                INNER JOIN bookings b ON sb.booking_id = b.id
                WHERE b.id = @id;";

            await using (var conn = new MySqlConnection(_connectionString))
            {
                await conn.OpenAsync();

                await using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", bookingId);

                    await using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var item = new CheckoutSumHelper(
                                reader["name"]?.ToString() ?? string.Empty,
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

        public async Task CheckoutBookingAsync(Booking booking, int nights)
        {
            const string query = @"
                UPDATE bookings b
                JOIN rooms r ON b.room_number = r.room_number
                SET b.checkout = NOW(), 
                    r.status = 'under_maintenance', 
                    r.needs_cleaning = 1
                WHERE b.id = @id;

                UPDATE guests g
                JOIN bookings b ON (g.id = b.guest1_id OR g.id = b.guest2_id OR g.id = b.guest3_id OR g.id = b.guest4_id)
                SET g.total_nights = g.total_nights + @nights
                WHERE b.id = @id;";

            await using (var conn = new MySqlConnection(_connectionString))
            {
                await conn.OpenAsync();
                await using (var transaction = await conn.BeginTransactionAsync())
                {
                    try
                    {
                        await using (var cmd = new MySqlCommand(query, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@id", booking.Id);
                            cmd.Parameters.AddWithValue("@nights", nights);

                            await cmd.ExecuteNonQueryAsync();
                        }

                        await transaction.CommitAsync();
                    }
                    catch
                    {
                        await transaction.RollbackAsync();
                        throw;
                    }
                }
            }
        }
    }
}