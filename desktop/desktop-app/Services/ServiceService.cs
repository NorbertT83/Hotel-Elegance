using System.Data.Common;
using System.Text;
using Hotel_erp_Winforms_App.Models;
using MySql.Data.MySqlClient;

namespace Hotel_erp_Winforms_App.Services
{
    internal class ServiceService
    {
        #region variables

        private readonly string _connectionString = DbConfig.ConnectionString;

        #endregion

        #region Database Actions

        // 1. Get all services
        public async Task<List<Service>> GetAllServicesFromDbAsync()
        {
            List<Service> services = new List<Service>();
            string query = "SELECT * FROM services;";

            await using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                await conn.OpenAsync();
                await using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    await using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            services.Add(MakeNewService(reader));
                        }
                    }
                }
            }

            return services;
        }

        // 2. Get filtered services
        public async Task<List<Service>> GetFilteredSerivicesAsync(int type, string search)
        {
            List<Service> filteredServices = new List<Service>();
            StringBuilder queryBuilder = new StringBuilder("SELECT * FROM services WHERE 1 = 1 ");
            var parameters = new Dictionary<string, object>();

            // Type filter
            switch (type)
            {
                case 1:
                    queryBuilder.Append("AND service_type_en = 'Wellness' ");
                    break;
                case 2:
                    queryBuilder.Append("AND service_type_en = 'Extras' ");
                    break;
                case 3:
                    queryBuilder.Append("AND service_type_en = 'Logistics' ");
                    break;
            }

            // Search filter
            if (!string.IsNullOrWhiteSpace(search))
            {
                queryBuilder.Append(@"AND (name_hu LIKE @search 
                                        OR description_hu LIKE @search 
                                        OR price LIKE @search 
                                        OR service_type_hu LIKE @search 
                                        OR name_en LIKE @search 
                                        OR description_en LIKE @search 
                                        OR service_type_en LIKE @search) ");
                parameters.Add("@search", $"%{search}%");
            }

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
                            filteredServices.Add(MakeNewService(reader));
                        }
                    }
                }
            }

            return filteredServices;
        }

        // 3. Get active or inactive services
        public async Task<List<Service>> GetActiveOrInactiveServicesAsync(string active)
        {
            List<Service> services = new List<Service>();

            string activeQuery = @"
                SELECT *
                FROM services s
                WHERE s.id IN (SELECT service_id 
                               FROM servicebookings
                               WHERE status = 'created' OR status = 'pending');";

            string inactiveQuery = @"
                SELECT *
                FROM services s
                WHERE s.id IN (SELECT service_id 
                               FROM servicebookings);";

            string notUsedQuery = @"
                SELECT *
                FROM services
                WHERE id NOT IN (SELECT service_id
                                 FROM servicebookings);";

            string query = active switch
            {
                "active" => activeQuery,
                "inactive" => inactiveQuery,
                "notUsed" => notUsedQuery,
                _ => string.Empty
            };

            if (string.IsNullOrEmpty(query))
            {
                return services;
            }

            await using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                await conn.OpenAsync();
                await using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    await using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            services.Add(MakeNewService(reader));
                        }
                    }
                }
            }

            return services;
        }

        // 4. Save new service
        public async Task SaveNewServiceToDbAsync(Service service)
        {
            string query = @"
                INSERT INTO services 
                    (name_hu, description_hu, price, service_type_hu, name_en, description_en, service_type_en) 
                VALUES 
                    (@nameHu, @descriptionHu, @price, @serviceTypeHu, @nameEn, @descriptionEn, @serviceTypeEn);";

            await using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                await conn.OpenAsync();
                await using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@nameHu", service.NameHu);
                    cmd.Parameters.AddWithValue("@descriptionHu", string.IsNullOrWhiteSpace(service.DescriptionHu) ? DBNull.Value : service.DescriptionHu);
                    cmd.Parameters.AddWithValue("@price", service.Price);
                    cmd.Parameters.AddWithValue("@serviceTypeHu", service.SelectedServiceTypeHu.ToString());
                    cmd.Parameters.AddWithValue("@nameEn", string.IsNullOrWhiteSpace(service.NameEn) ? DBNull.Value : service.NameEn);
                    cmd.Parameters.AddWithValue("@descriptionEn", string.IsNullOrWhiteSpace(service.DescriptionEn) ? DBNull.Value : service.DescriptionEn);
                    cmd.Parameters.AddWithValue("@serviceTypeEn", service.SelectedServiceTypeEn.ToString());

                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        // 5. Update existing service
        public async Task UpdateSelectedServiceAsync(Service service)
        {
            string query = @"
                UPDATE services 
                SET name_hu = @nameHu, 
                    description_hu = @descriptionHu, 
                    price = @price, 
                    service_type_hu = @serviceTypeHu, 
                    name_en = @nameEn, 
                    description_en = @descriptionEn, 
                    service_type_en = @serviceTypeEn 
                WHERE id = @id;";

            await using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                await conn.OpenAsync();
                await using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", service.Id);
                    cmd.Parameters.AddWithValue("@nameHu", service.NameHu);
                    cmd.Parameters.AddWithValue("@descriptionHu", string.IsNullOrWhiteSpace(service.DescriptionHu) ? DBNull.Value : service.DescriptionHu);
                    cmd.Parameters.AddWithValue("@price", service.Price);
                    cmd.Parameters.AddWithValue("@serviceTypeHu", service.SelectedServiceTypeHu.ToString());
                    cmd.Parameters.AddWithValue("@nameEn", string.IsNullOrWhiteSpace(service.NameEn) ? DBNull.Value : service.NameEn);
                    cmd.Parameters.AddWithValue("@descriptionEn", string.IsNullOrWhiteSpace(service.DescriptionEn) ? DBNull.Value : service.DescriptionEn);
                    cmd.Parameters.AddWithValue("@serviceTypeEn", service.SelectedServiceTypeEn.ToString());

                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        // 6. Delete service
        public async Task DeleteSelectedServiceFromDbAsync(Service service)
        {
            string query = "DELETE FROM services WHERE id = @id;";

            await using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                await conn.OpenAsync();
                await using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", service.Id);
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        // 7. Get service bookings
        public async Task<List<RequestedService>> GetServiceDataByServicebookingAsync(bool all = false)
        {
            List<RequestedService> reqServices = new List<RequestedService>();

            string query = @"
                SELECT sb.id AS id, b.room_number AS room_number, sb.status AS status, sb.requested_at, s.name_en AS name, s.service_type_en AS service_type, sb.quantity AS quantity, sb.price_at_booking AS price
                FROM servicebookings sb
                INNER JOIN bookings b ON sb.booking_id = b.id
                INNER JOIN services s ON sb.service_id = s.id ";

            if (!all)
            {
                query += "WHERE sb.status IN ('created', 'pending') ";
            }

            query += "ORDER BY sb.requested_at DESC;";

            await using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                await conn.OpenAsync();
                await using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    await using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            reqServices.Add(MakeNewRequestedService(reader));
                        }
                    }
                }
            }

            return reqServices;
        }

        // 8. Update service booking status
        public async Task UpdateServiceBookingStatusAsync(RequestedService serviceBooking)
        {
            string query = @"
                UPDATE servicebookings
                SET updated_at = NOW(), status = @status
                WHERE id = @id;";

            await using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                await conn.OpenAsync();
                await using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", serviceBooking.Id);
                    cmd.Parameters.AddWithValue("@status", serviceBooking.CurrentServiceStatus.ToString().ToLower());

                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        // 9. Save new service booking
        public async Task SaveNewServiceBookingAsync(ServiceBooking sb)
        {
            string query = @"
                INSERT INTO servicebookings
                    (booking_id, service_id, requested_at, updated_at, quantity, status, price_at_booking)
                VALUES
                    (@bookingId, @serviceId, @requested, @updated, @quan, @state, @price);";

            await using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                await conn.OpenAsync();
                await using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@bookingId", sb.BookingId);
                    cmd.Parameters.AddWithValue("@serviceId", sb.ServiceId);
                    cmd.Parameters.AddWithValue("@requested", sb.RequestedAt);
                    cmd.Parameters.AddWithValue("@updated", sb.UpdatedAt);
                    cmd.Parameters.AddWithValue("@quan", sb.Quantity);
                    cmd.Parameters.AddWithValue("@state", sb.CurrentStatus.ToString().ToLower());
                    cmd.Parameters.AddWithValue("@price", sb.Price);

                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        // 10. Delete service booking (soft delete)
        public async Task SetServiceBookingStatusToDeletedAsync(int id)
        {
            string query = @"
                UPDATE servicebookings
                SET status = 'deleted', updated_at = NOW()
                WHERE id = @id;";

            await using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                await conn.OpenAsync();
                await using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        #endregion

        #region Helpers

        private Service MakeNewService(DbDataReader reader)
        {
            return new Service(
                Convert.ToInt32(reader["id"]),
                reader["name_hu"]?.ToString() ?? string.Empty,
                reader["description_hu"] is DBNull or null ? string.Empty : reader["description_hu"].ToString()!,
                Enum.TryParse<ServiceTypeHu>(reader["service_type_hu"]?.ToString(), true, out var serviceTypeHu) ? serviceTypeHu : ServiceTypeHu.Wellness,
                Convert.ToDecimal(reader["price"]),
                reader["name_en"]?.ToString() ?? string.Empty,
                reader["description_en"] is DBNull or null ? string.Empty : reader["description_en"].ToString()!,
                Enum.TryParse<ServiceTypeEn>(reader["service_type_en"]?.ToString(), true, out var serviceTypeEn) ? serviceTypeEn : ServiceTypeEn.Wellness
            );
        }

        private RequestedService MakeNewRequestedService(DbDataReader reader)
        {
            string statusRaw = reader["status"] != DBNull.Value ? reader["status"].ToString()! : string.Empty;
            if (!Enum.TryParse(statusRaw, ignoreCase: true, out ServiceStatus status))
            {
                status = ServiceStatus.created;
            }

            string typeRaw = reader["service_type"] != DBNull.Value ? reader["service_type"].ToString()! : string.Empty;
            if (!Enum.TryParse(typeRaw, ignoreCase: true, out ServiceType serviceType))
            {
                serviceType = ServiceType.Extras;
            }

            return new RequestedService(
                Convert.ToInt32(reader["id"]),
                reader["room_number"] != DBNull.Value ? Convert.ToInt32(reader["room_number"]) : 0,
                status,
                Convert.ToDateTime(reader["requested_at"]),
                reader["name"] != DBNull.Value ? reader["name"].ToString()! : string.Empty,
                serviceType,
                Convert.ToInt32(reader["quantity"]),
                Convert.ToInt32(reader["price"])
            );
        }

        #endregion
    }
}