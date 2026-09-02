using System;
using System.Collections.Generic;
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

        #region INFO
        /*
         * 1.: get all services from database
         * 2.: returns a list of services filtered by the paramteres
         * 3.: returns a list of active or inactive services
         * 4.: saves a new service to db
         * 5.: updates the parameter service in db
         * 6.: deletes the parameter service from db
         * 7.: gets all service bookings from db
        */
        #endregion
        #region database actions
        // 1.
        public async Task<List<Service>> GetAllServicesFromDbAsync()
        {
            List<Service> services = new List<Service>();

            string query = @"
                SELECT *
                FROM services;";

            await using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                await conn.OpenAsync();

                await using(MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    await using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            Service service = MakeNewService(reader);

                            services.Add(service);
                        }
                    }
                }
            }

            return services;
        }

        // 2.
        public async Task<List<Service>> GetFilteredSerivicesAsync(int type, string search)
        {
            List<Service> filteredServices = new List<Service>();

            StringBuilder queryBuilder = new StringBuilder("SELECT * FROM services WHERE 1 = 1 ");

            // Típus
            switch (type)
            {
                case 0: queryBuilder.Append(""); break;
                case 1: queryBuilder.Append("AND service_type_en = 'Wellness' "); break;
                case 2: queryBuilder.Append("AND service_type_en = 'Extras' "); break;
                case 3: queryBuilder.Append("AND service_type_en = 'Logistics' "); break;
            }

            // Search box
            if (!string.IsNullOrEmpty(search))
            {
                queryBuilder.Append($"AND (name_hu LIKE @search " +
                                        $"OR description_hu LIKE @search " +
                                        $"OR price LIKE @search " +
                                        $"OR service_type_hu LIKE @search " +
                                        $"OR name_en LIKE @search " +
                                        $"OR description_en LIKE @search " +
                                        $"OR service_type_en LIKE @search);");

            }

            await using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                await conn.OpenAsync();

                await using (MySqlCommand cmd = new MySqlCommand(queryBuilder.ToString(), conn))
                {
                    cmd.Parameters.AddWithValue("@search", search + "%");

                    await using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            Service s = MakeNewService(reader);
                            filteredServices.Add(s);
                        }
                    }
                }
            }

            return filteredServices;
        }

        // 3.
        public async Task<List<Service>> GetActiveOrInactiveServicesAsync(bool active)
        {
            List<Service> services = new List<Service>();

            string activeQuery = @"
                SELECT *
                FROM services s
                WHERE s.id IN (SELECT service_id 
                               FROM servicebookings
                               WHERE status = 'created'
                                   OR status = 'pending');";

            string inactiveQuery = @"
                SELECT *
                FROM services s
                WHERE s.id IN (SELECT service_id 
                               FROM servicebookings);";

            await using(MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                await conn.OpenAsync();

                await using(MySqlCommand cmd = new MySqlCommand(active ? activeQuery : inactiveQuery, conn))
                {
                    await using(var reader = await cmd.ExecuteReaderAsync())
                    {
                        while(await reader.ReadAsync())
                        {
                            Service s = MakeNewService(reader);
                            services.Add(s);
                        }
                    }
                }
            }

            return services;
        }

        // 4.
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
                    cmd.Parameters.AddWithValue("@descriptionHu", (object)service.DescriptionHu ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@price", service.Price);
                    cmd.Parameters.AddWithValue("@serviceTypeHu", service.SelectedServiceTypeHu.ToString());

                    cmd.Parameters.AddWithValue("@nameEn", (object)service.NameEn ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@descriptionEn", (object)service.DescriptionEn ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@serviceTypeEn", service.SelectedServiceTypeEn.ToString());

                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        // 5.
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

            await using(MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                await conn.OpenAsync();

                await using(MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", service.Id);
                    cmd.Parameters.AddWithValue("@nameHu", service.NameHu);
                    cmd.Parameters.AddWithValue("@descriptionHu", string.IsNullOrWhiteSpace(service.DescriptionHu) ? DBNull.Value : service.DescriptionHu);
                    cmd.Parameters.AddWithValue("@price", service.Price);
                    cmd.Parameters.AddWithValue("@serviceTypeHu", service.SelectedServiceTypeHu.ToString());
                    cmd.Parameters.AddWithValue("@nameEn", string.IsNullOrWhiteSpace(service.NameEn) ? DBNull.Value : service.NameEn);
                    cmd.Parameters.AddWithValue("@descriptionEn", string.IsNullOrWhiteSpace(service.DescriptionEn) ? DBNull.Value : service.DescriptionEn);
                    cmd.Parameters.AddWithValue("@serviceTypeEn", service.SelectedServiceTypeEn != null ? service.SelectedServiceTypeEn.ToString() : DBNull.Value);

                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        // 6.
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

        // 7.
        public async Task<List<RequestedService>> GetServiceDataByServicebookingAsync(bool all = false)
        {
            List<RequestedService> reqServices = new List<RequestedService>();

            string query = @"
                SELECT b.room_number AS room_number, sb.status AS status, sb.requested_at, s.name_en AS name, s.service_type_en AS service_type, sb.price_at_booking AS price
                FROM servicebookings sb
                INNER JOIN bookings b ON sb.booking_id = b.id
                INNER JOIN services s ON sb.service_id = s.id ";

            if (!all)
            {
                query += "WHERE status IN('created', 'pending')";
            }

            query += ';';

            await using(MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                await conn.OpenAsync();

                await using(MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    await using(var reader = await cmd.ExecuteReaderAsync())
                    {
                        while(await reader.ReadAsync())
                        {
                            RequestedService service = MakeNewRequestedService(reader);

                            reqServices.Add(service);
                        }
                    }
                }
            }

            return reqServices;
        }

        #endregion

        #region INFO
        /*
         * 1.: creates a service from database reader
        */
        #endregion
        #region helpers
        // 1.
        private Service MakeNewService(System.Data.Common.DbDataReader reader)
        {
            Service service = new Service(
                Convert.ToInt32(reader["id"]),
                reader["name_hu"].ToString(),
                reader["description_hu"] != DBNull.Value ? reader["description_hu"].ToString() : null,

                (ServiceTypeHu)Enum.Parse(
                    typeof(ServiceTypeHu),
                    reader["service_type_hu"] != DBNull.Value ? reader["service_type_hu"].ToString() : "Wellness",
                    ignoreCase: true
                ),

                Convert.ToDecimal(reader["price"]),
                reader["name_en"] != DBNull.Value ? reader["name_en"].ToString() : null,
                reader["description_en"] != DBNull.Value ? reader["description_en"].ToString() : null,

                (ServiceTypeEn)Enum.Parse(
                    typeof(ServiceTypeEn),
                    reader["service_type_en"] != DBNull.Value ? reader["service_type_en"].ToString() : "Wellness",
                    ignoreCase: true
                )
            );

            return service;
        }

        // 2.
        private ServiceBooking MakeNewServiceBooking(System.Data.Common.DbDataReader reader)
        {
            ServiceBooking serviceBooking = new ServiceBooking(
                Convert.ToInt32(reader["id"]),
                reader["booking_id"].ToString(),
                Convert.ToInt32(reader["service_id"]),
                Convert.ToDateTime(reader["requested_at"]),
                reader["updated_at"] != DBNull.Value ? Convert.ToDateTime(reader["updated_at"]) : DateTime.MinValue,
                Convert.ToInt32(reader["quantity"]),
                (Status)Enum.Parse(
                    typeof(Status),
                    reader["status"] != DBNull.Value ? reader["status"].ToString() : "created",
                    ignoreCase: true
                ),
                Convert.ToInt32(reader["price_at_booking"])
            );

            return serviceBooking;
        }

        // 3.
        private RequestedService MakeNewRequestedService(System.Data.Common.DbDataReader reader)
        {
            return new RequestedService(
                reader["room_number"] != DBNull.Value ? Convert.ToInt32(reader["room_number"]) : 0,
                (ServiceStatus)Enum.Parse(
                    typeof(ServiceStatus),
                    reader["status"] != DBNull.Value ? reader["status"].ToString() : "created",
                    ignoreCase: true
                ),
                Convert.ToDateTime(reader["requested_at"]),
                reader["name"] != DBNull.Value ? reader["name"].ToString() : string.Empty,
                (ServiceType)Enum.Parse(
                    typeof(ServiceType),
                    reader["service_type"] != DBNull.Value ? reader["service_type"].ToString() : "Extras",
                    ignoreCase: true
                ),
                Convert.ToInt32(reader["price"])
            );
        }

        #endregion
    }
}
