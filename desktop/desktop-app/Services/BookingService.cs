using Hotel_erp_Winforms_App.Models;
using Hotel_erp_Winforms_App.UI.Controls.GuestsDataSumControl;
using Hotel_erp_Winforms_App.UI.Controls.RoomCardControl;
using MySql.Data.MySqlClient;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Text;
using NanoidDotNet;
using System.Drawing.Text;

namespace Hotel_erp_Winforms_App.Services
{
    public class BookingService
    {
        #region TODO:
        /*
            - a confirm new booking-nál ha már létezik a vendég az adatbázisban akkor azt mentse
            - a confirm checkin-nél ha már létezik a vendég az adatbázisban, akkor ne mentse újra
        */
        #endregion

        #region variables

        private readonly string connectionString = "Server=localhost;Database=hotelelegancedb;uid=root;pwd=";

        #endregion

        #region INFO
        /*
            1.: makes list of all of the bookings
            2.: filters bookings by the parameters
            3.: confirms the check-in, updates database
            4.: confirms the new booking, updates database
        */ 
        #endregion
        #region Database actions
        // 1.
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

                        System.Enum.TryParse<Hotel_erp_Winforms_App.Models.RoomType>(
                            reader["room_type"]?.ToString(), true, out var roomTypeEnum);

                        System.Enum.TryParse<CateringLevel>
                            (reader["catering_level"]?.ToString(), true, out var cateringEnum);

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
        // 2.
        public List<Booking> SearchBookings(int fieldIndex, string searchText, int statusIndex, int tabIndex, int spanIndex, DateTime fromDate, DateTime toDate)
        {
            string joins = "";
            string whereClause = " WHERE 1=1 ";
            var parameters = new Dictionary<string, object>();

            if(tabIndex == 0)
            {
                // MEZŐ KIVÁLASZTÁS
                if (!string.IsNullOrEmpty(searchText))
                {
                    switch (fieldIndex)
                    {
                        case -1:
                        case 0: break;

                        case 1:
                            joins += " INNER JOIN guests ON bookings.guest1_id = guests.id ";
                            whereClause += " AND guests.fname LIKE @fname ";
                            parameters.Add("@fname", $"%{searchText}%");
                            break;

                        case 2:
                            whereClause += " AND bookings.id LIKE @searchBar ";
                            parameters.Add("@searchBar", $"%{searchText}%");
                            break;

                        case 3:
                            whereClause += " AND bookings.room_number LIKE @searchBar ";
                            parameters.Add("@searchBar", $"%{searchText}%");
                            break;

                        case 4:
                            whereClause += " AND bookings.room_type LIKE @searchBar ";
                            parameters.Add("@searchBar", $"%{searchText}%");
                            break;

                        case 5:
                            whereClause += " AND bookings.beginning_of_stay LIKE @searchBar ";
                            parameters.Add("@searchBar", $"%{searchText}%");
                            break;

                        case 6:
                            whereClause += " AND bookings.end_of_stay LIKE @searchBar ";
                            parameters.Add("@searchBar", $"%{searchText}%");
                            break;

                        case 7:
                            whereClause += " AND bookings.checkin LIKE @searchBar ";
                            parameters.Add("@searchBar", $"%{searchText}%");
                            break;

                        case 8:
                            whereClause += " AND bookings.checkout LIKE @searchBar ";
                            parameters.Add("@searchBar", $"%{searchText}%");
                            break;

                        case 9:
                            whereClause += " AND bookings.catering_level LIKE @searchBar ";
                            parameters.Add("@searchBar", $"%{searchText}%");
                            break;
                    }
                }

                // STÁTUSZ KIVÁLASZTÁS
                switch (statusIndex)
                {
                    case 1:
                        whereClause += " AND checkin IS NULL";
                        break;

                    case 2:
                        whereClause += " AND checkin IS NOT NULL AND checkout IS NULL";
                        break;

                    case 3:
                        whereClause += " AND checkout IS NOT NULL";
                        break;
                }
            }

            // IDŐSZAK KIVÁLASZTÁS
            if(tabIndex == 1)
            {
                switch (spanIndex)
                {
                    case 0: 
                        whereClause += " AND beginning_of_stay BETWEEN @from AND @to";
                        parameters.Add("@from", fromDate);
                        parameters.Add("@to", toDate);
                        break;
                    case 1:
                        whereClause += " AND end_of_stay BETWEEN @from AND @to";
                        parameters.Add("@from", fromDate);
                        parameters.Add("@to", toDate);
                        break;
                    case 2:
                        whereClause += " AND beginning_of_stay >= @from AND end_of_stay <= @to";
                        parameters.Add("@from", fromDate);
                        parameters.Add("@to", toDate);
                        break;
                }
            }

            string query = $"SELECT bookings.* FROM bookings{joins}{whereClause};";

            return LoadDgv(query, parameters);
        }
        // 3.
        public void ConfirmCheckin(Booking booking, List<Guest> guestList, List<Service> serviceItems)
        {
            // 1.: SAVE GUESTS
            string saveGuestQuery = @"
                INSERT INTO guests (id, email, id_card_number, fname, lname, date_of_birth, country, zip_code, city, street, car_plate_number, total_nights, loyalty_level)
                VALUES (@id, @email, @idNumber, @fname, @lname, @dateOfBirth, @country, @zip, @city, @street, @carPlate, @totalNights, @loyalty)
                ON DUPLICATE KEY UPDATE
                    id = LAST_INSERT_ID(id),
                    email = VALUES(email),
                    id_card_number = VALUES(id_card_number),
                    fname = VALUES(fname),
                    lname = VALUES(lname),
                    date_of_birth = VALUES(date_of_birth),
                    country = VALUES(country),
                    zip_code = VALUES(zip_code),
                    city = VALUES(city),
                    street = VALUES(street),
                    car_plate_number = VALUES(car_plate_number),
                    total_nights = VALUES(total_nights),
                    loyalty_level = VALUES(loyalty_level);
                SELECT LAST_INSERT_ID();";

            // 2.: UPDATE BOOKING
            string updateBookingQuery = @"
                UPDATE bookings
                SET room_number = @roomNumber,
                    room_type = @roomType,
                    guest1_id = @guestId1,
                    guest2_id = @guestId2,
                    guest3_id = @guestId3,
                    guest4_id = @guestId4,
                    catering_level = @cateringLevel,
                    checkin = NOW()
                WHERE id = @bookingId;";

            // 3.: UPDATE ROOM
            string updateRoomQuery = @"
                UPDATE rooms
                SET status = 'unavailable'
                WHERE room_number = @roomNumber;";

            // 4.: SAVE SERVICES
            string updateServicesQuery = @"
                INSERT INTO servicebookings (service_id, booking_id, requested_at, updated_at, quantity, status, price_at_booking)
                VALUES (@serviceId, @bookingId, @requested, @updated, @quantity, @status, @price);";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                using (MySqlTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        List<int> savedGuestsIds = new List<int>();

                        foreach (Guest guest in guestList)
                        {
                            // VENDÉGEK MENTÉSE
                            using (MySqlCommand cmd = new MySqlCommand(saveGuestQuery, conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@id", guest.Id == 0 ? (object)DBNull.Value : guest.Id);
                                cmd.Parameters.AddWithValue("@email", guest.Email ?? (object)DBNull.Value);
                                cmd.Parameters.AddWithValue("@idNumber", guest.IdCardNumber);
                                cmd.Parameters.AddWithValue("@fname", guest.FName);
                                cmd.Parameters.AddWithValue("@lname", guest.LName);
                                cmd.Parameters.AddWithValue("@dateOfBirth", guest.DateOfBirth);
                                cmd.Parameters.AddWithValue("@country", guest.Country);
                                cmd.Parameters.AddWithValue("@zip", guest.ZipCode);
                                cmd.Parameters.AddWithValue("@city", guest.City);
                                cmd.Parameters.AddWithValue("@street", guest.Street);
                                cmd.Parameters.AddWithValue("@carPlate", (object)guest.CarPlateNumber ?? DBNull.Value);
                                cmd.Parameters.AddWithValue("@totalNights", guest.TotalNights);
                                cmd.Parameters.AddWithValue("@loyalty", guest.LoyaltyLevel);

                                object result = cmd.ExecuteScalar();
                                int currentGuestId = 0;

                                if (result != null && result != DBNull.Value && Convert.ToInt32(result) != 0)
                                {
                                    currentGuestId = Convert.ToInt32(result);
                                }
                                else { currentGuestId = guest.Id ?? 0; }


                                savedGuestsIds.Add(currentGuestId);
                            }
                        }

                        // BOOKING UPDATE
                        using (MySqlCommand cmd = new MySqlCommand(updateBookingQuery, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@bookingId", booking.Id);
                            cmd.Parameters.AddWithValue("@roomNumber", booking.RoomNumber);
                            cmd.Parameters.AddWithValue("@roomType", booking.SelectedRoomType);
                            cmd.Parameters.AddWithValue("@cateringLevel", booking.SelectedCateringLevel);

                            cmd.Parameters.AddWithValue("@guestId1", savedGuestsIds.Count > 0 ? savedGuestsIds[0] : (object)DBNull.Value);
                            cmd.Parameters.AddWithValue("@guestId2", savedGuestsIds.Count > 1 ? savedGuestsIds[1] : (object)DBNull.Value);
                            cmd.Parameters.AddWithValue("@guestId3", savedGuestsIds.Count > 2 ? savedGuestsIds[2] : (object)DBNull.Value);
                            cmd.Parameters.AddWithValue("@guestId4", savedGuestsIds.Count > 3 ? savedGuestsIds[3] : (object)DBNull.Value);

                            cmd.ExecuteNonQuery();
                        }

                        // ROOM UPDATE
                        using (MySqlCommand cmd = new MySqlCommand(updateRoomQuery, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@roomNumber", booking.RoomNumber);
                            cmd.ExecuteNonQuery();
                        }

                        // SZOLGÁLTATLÁSOK
                        foreach (var item in serviceItems)
                        {
                            int days = (booking.EndOfStay - booking.BeginningOfStay).Days;

                            using (MySqlCommand cmd = new MySqlCommand(updateServicesQuery, conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@serviceId", item.Id);
                                cmd.Parameters.AddWithValue("@bookingId", booking.Id);
                                cmd.Parameters.AddWithValue("@requested", DateTime.Now);
                                cmd.Parameters.AddWithValue("@updated", DateTime.Now);
                                if (item.NameHu == "Parkolás")
                                {
                                    cmd.Parameters.AddWithValue("@quantity", days);
                                    cmd.Parameters.AddWithValue("@price", item.Price);
                                }
                                else if (item.NameHu == "Félpanzió" || item.NameHu == "Teljes ellátás")
                                {
                                    cmd.Parameters.AddWithValue("@quantity", days);
                                    cmd.Parameters.AddWithValue("@price", item.Price * days);
                                }
                                else
                                {
                                    cmd.Parameters.AddWithValue("@quantity", 1);
                                    cmd.Parameters.AddWithValue("@price", item.Price);
                                }
                                cmd.Parameters.AddWithValue("@status", "created");

                                cmd.ExecuteNonQuery();
                            }
                        }

                        transaction.Commit();
                    }

                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }
        // 4.
        public async Task ConfirmNewBookingAsync(Room room, List<Guest> guestList, List<Service> services, DateTime endDate, CateringLevel catering, int nights)
        {
            // booking mentése
            string saveBookingQuery = @"
                INSERT INTO bookings (id, room_number, room_type,guest1_id, beginning_of_stay, end_of_stay,
                    checkin, checkout, guest2_id, guest3_id, guest4_id, created_at, catering_level)
                VALUES (@id, @roomNumber, @roomType,@guestId1, @startDate, @endDate, @checkin, @checkout, @guestId2, @guestId3, @guestId4, 
                    @createdAt, @cateringLevel);
            ";

            // szoba frissítése
            string updateRoomQuery = @"
                UPDATE rooms
                SET status = 'unavailable'
                WHERE room_number = @roomNumber;
            ";

            // vendégek mentése
            string saveGuestQuery = @"
                INSERT INTO guests (email, id_card_number, fname, lname, date_of_birth, country, zip_code, city, street,
                    car_plate_number, total_nights)
                VALUES (@email, @id_card_number, @fname, @lname, @date_of_birth, @country, @zip_code, @city, @street,
                    @carPlate, @totalNights)
                ON DUPLICATE KEY UPDATE
                    total_nights = total_nights + VALUES(total_nights),
                    car_plate_number = VALUES(car_plate_number);
            ";

            // serviceBookingok létrehozása
            string saveServiceQuery = @"
                INSERT INTO servicebookings (booking_id, service_id, requested_at, updated_at, quantity, status, price_at_booking)
                VALUES (@booking_id, @service_id, @requested_at, @updated_at, @quantity, @status, @price);
            ";

            Cursor.Current = Cursors.WaitCursor;

            try
            {
                await using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    await conn.OpenAsync();

                    await using (MySqlTransaction transaction = await conn.BeginTransactionAsync())
                    {
                        try
                        {
                            List<long> guestDbIds = new List<long>();
                            string bookingId = GenerateBookingId();

                            // save Guests
                            await using (MySqlCommand cmd = new MySqlCommand(saveGuestQuery, conn, transaction))
                            {
                                foreach (Guest g in guestList)
                                {
                                    cmd.Parameters.Clear();

                                    cmd.Parameters.AddWithValue("@email", g.Email);
                                    cmd.Parameters.AddWithValue("@id_card_number", g.IdCardNumber);
                                    cmd.Parameters.AddWithValue("@fname", g.FName);
                                    cmd.Parameters.AddWithValue("@lname", g.LName);
                                    cmd.Parameters.AddWithValue("@date_of_birth", g.DateOfBirth);
                                    cmd.Parameters.AddWithValue("@country", g.Country);
                                    cmd.Parameters.AddWithValue("@zip_code", g.ZipCode);
                                    cmd.Parameters.AddWithValue("@city", g.City);
                                    cmd.Parameters.AddWithValue("@street", g.Street);
                                    cmd.Parameters.AddWithValue("@carPlate", string.IsNullOrEmpty(g.CarPlateNumber) ? DBNull.Value : g.CarPlateNumber);
                                    cmd.Parameters.AddWithValue("@totalNights", nights);

                                    await cmd.ExecuteNonQueryAsync();

                                    using (MySqlCommand idCmd = new MySqlCommand("SELECT id FROM guests WHERE id_card_number = @idCard", conn, transaction))
                                    {
                                        idCmd.Parameters.AddWithValue("@idCard", g.IdCardNumber);
                                        object result = await idCmd.ExecuteScalarAsync();
                                        guestDbIds.Add(Convert.ToInt64(result));
                                    }
                                }
                            }

                            // save Booking
                            await using (MySqlCommand cmd = new MySqlCommand(saveBookingQuery, conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@id", bookingId);
                                cmd.Parameters.AddWithValue("@roomNumber", room.Room_number);
                                cmd.Parameters.AddWithValue("@roomType", room.RoomsRoomtype.ToString().ToLower());

                                cmd.Parameters.AddWithValue("@guestId1", guestDbIds[0]);
                                cmd.Parameters.AddWithValue("@guestId2", guestDbIds.Count() > 1 ? (object)guestDbIds[1] : DBNull.Value);
                                cmd.Parameters.AddWithValue("@guestId3", guestDbIds.Count() > 2 ? (object)guestDbIds[2] : DBNull.Value);
                                cmd.Parameters.AddWithValue("@guestId4", guestDbIds.Count() > 3 ? (object)guestDbIds[3] : DBNull.Value);

                                cmd.Parameters.AddWithValue("@startDate", DateTime.Today);
                                cmd.Parameters.AddWithValue("@endDate", endDate);
                                cmd.Parameters.AddWithValue("@checkin", DateTime.Now);
                                cmd.Parameters.AddWithValue("@checkout", DBNull.Value);

                                string cateringValue = catering switch
                                {
                                    CateringLevel.halfboard => "halfboard",
                                    CateringLevel.fullboard => "fullboard",
                                    _ => "breakfast"
                                };

                                cmd.Parameters.AddWithValue("@cateringLevel", cateringValue);
                                cmd.Parameters.AddWithValue("@createdAt", DateTime.Now);

                                await cmd.ExecuteNonQueryAsync();
                            }

                            // update Room
                            await using (MySqlCommand cmd = new MySqlCommand(updateRoomQuery, conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@roomNumber", room.Room_number);

                                await cmd.ExecuteNonQueryAsync();
                            }

                            // save Services
                            await using (MySqlCommand cmd = new MySqlCommand(saveServiceQuery, conn, transaction))
                            {
                                foreach (Service s in services)
                                {
                                    if (s.Id <= 0 || s.NameHu == "Pezsgő bekészítés" || s.NameHu == "Késői kijelentkezés" || s.NameHu == "Korai távozás") continue;

                                    cmd.Parameters.Clear();

                                    cmd.Parameters.AddWithValue("@booking_id", bookingId);
                                    cmd.Parameters.AddWithValue("@service_id", s.Id);
                                    cmd.Parameters.AddWithValue("@requested_at", DateTime.Now);
                                    cmd.Parameters.AddWithValue("@updated_at", DateTime.Now);
                                    cmd.Parameters.AddWithValue("@quantity", s.NameHu == "Teljes ellátás" || s.NameHu == "Félpanzió" ? nights : 1);
                                    cmd.Parameters.AddWithValue("@status", "created");
                                    cmd.Parameters.AddWithValue("@price", s.Price);

                                    await cmd.ExecuteNonQueryAsync();
                                }
                            }

                            await transaction.CommitAsync();

                            MessageBox.Show("Booking saved successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        catch (Exception ex)
                        {
                            await transaction.RollbackAsync();
                            MessageBox.Show(
                                "An error occured while trying to save the booking: " + ex.Message,
                                "Database Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error
                            );
                        }
                    }
                }
            }

            finally
            {
                Cursor.Current = Cursors.Default;
            }

            string GenerateBookingId()
            {
                string prefix = "HE";
                string year = DateTime.Now.Year.ToString();

                string customAlphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

                string randomSuffix = Nanoid.Generate(customAlphabet, 4);

                return $"{prefix}-{year}-{randomSuffix}";
            }
        }
        #endregion

        #region INFO
        /*
            1.: Returns number of current days arrivals
            2.: Returns number of current days departures
            3.: Returns percentage of unavailable / available rooms
        */
        #endregion
        #region Occupancy
        public int GetTodaysArrivalsCount()
        {
            string query = "SELECT COUNT(*) FROM bookings WHERE beginning_of_stay = CURRENT_DATE AND checkin = NULL ;";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    conn.Open();
                    return (int)(long)cmd.ExecuteScalar();
                }
            }
        }

        public int GetTodaysDeparturesCount()
        {
            string query = "SELECT COUNT(*) FROM bookings WHERE end_of_stay = CURRENT_DATE();";
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    conn.Open();
                    return (int)(long)cmd.ExecuteScalar();
                }
            }
        }

        public int GetOccupancyRate()
        {
            string query = "SELECT " +
                "ROUND( " +
                "(COUNT(CASE WHEN status NOT IN('available', 'under_maintenance') THEN 1 END) * 100.0) " +
                "/ COUNT(*), " +
                "2 " +
                ") AS occupied_percentage " +
                "FROM rooms;";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }

        }
        #endregion

        #region INFO
        /*
            1.: returns a booking by the parameter booking ID
            2.: returns a room by the parameter booking ID
            3.: returns a guest associated to the parameter booking
            4.: returns a list of the available rooms with the parameters of the booking
            5.: returns a list of billingItems out of the parameter service list
            6.: returns true if the serviceName parameter is associated to the parameter booking
            7.: returns true if the champage service is associated to the parameter booking
            8.: returns the car plate number associated to the parameter booking
            9.: returns the number of guests associated to the parameter booking
            10.: returns the net total of the items in the parameter list
            11.: returns the tax total of the items in the parameter list
            12.: returns the total of the items in the parameter list
            13.: returns the id card number associated to the parameter booking
            14.: fills the parameter dgv with the items of the parameter list
            15.: loads the parameter desciption into the parameter dgv
        */
        #endregion
        #region Check-in
        // 1.
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
                            System.Enum.TryParse<Hotel_erp_Winforms_App.Models.RoomType>
                                (reader["room_type"]?.ToString(), true, out var roomType);

                            System.Enum.TryParse<CateringLevel>
                                (reader["catering_level"]?.ToString(), true, out var cateringLevel);

                            return new Booking(
                                reader["id"].ToString(),
                                Convert.ToInt32(reader["room_number"]),
                                roomType,
                                Convert.ToInt32(reader["guest1_id"]),
                                Convert.ToDateTime(reader["beginning_of_stay"]),
                                Convert.ToDateTime(reader["end_of_stay"]),
                                reader["checkin"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["checkin"]),
                                reader["checkout"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["checkout"]),
                                reader["guest2_id"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["guest2_id"]),
                                reader["guest3_id"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["guest3_id"]),
                                reader["guest4_id"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["guest4_id"]),
                                cateringLevel,
                                Convert.ToDateTime(reader["created_at"])
                            );
                        }
                    }
                }
            }
            return null;
        }
        // 2.
        public Room GetRoomByBookingId(Booking booking)
        {
            string query = "SELECT rooms.room_number, rooms.room_type, floorspace, bed_type, has_balcony, has_view, " +
                "max_adults, extras, status, price_per_night, door_locked, needs_cleaning, dont_disturb, is_cleaning, ac_temp " +
                "FROM rooms " +
                "INNER JOIN bookings ON rooms.room_number = bookings.room_number " +
                "WHERE bookings.id = @bookingID;";

            using(MySqlConnection conn = new MySqlConnection(connectionString))
            {
                using(MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    conn.Open();
                    cmd.Parameters.AddWithValue("@bookingID", booking.Id); // ------------------- booking was null

                    using(MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Room
                            (
                                Convert.ToInt32(reader["room_number"]),
                                (Room.RoomType)System.Enum.Parse(typeof(Room.RoomType), reader["room_type"].ToString()),
                                Convert.ToInt32(reader["floorspace"]),
                                (Room.BedType)System.Enum.Parse(typeof(Room.BedType), reader["bed_type"].ToString()),
                                Convert.ToInt32(reader["has_balcony"]),
                                (Room.HasView)System.Enum.Parse(typeof(Room.HasView), reader["has_view"].ToString()),
                                Convert.ToInt32(reader["max_adults"]),
                                reader["extras"] == DBNull.Value ? "" : reader["extras"].ToString(),
                                (Room.Status)System.Enum.Parse(typeof(Room.Status), reader["status"].ToString()),
                                Convert.ToInt32(reader["price_per_night"]),
                                Convert.ToInt32(reader["door_locked"]),
                                Convert.ToInt32(reader["needs_cleaning"]),
                                Convert.ToInt32(reader["dont_disturb"]),
                                Convert.ToInt32(reader["is_cleaning"]),
                                Convert.ToInt32(reader["ac_temp"])
                            );
                        }
                    }
                }
            }

            return null;
        }
        // 3.
        public Guest? FillPersonalData(Booking selectedBooking)
        {
            string query = "SELECT guests.id, fname, lname, email, date_of_birth, country, zip_code, city, street, id_card_number, car_plate_number, total_nights, loyalty_level " +
                "FROM guests " +
                "INNER JOIN bookings ON guests.id = bookings.guest1_id " +
                "WHERE bookings.id = @bookingId";

            using(MySqlConnection conn = new MySqlConnection(connectionString))
            {
                using(MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    conn.Open();
                    cmd.Parameters.AddWithValue("@bookingId", selectedBooking.Id);

                    using(MySqlDataReader reader  = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Guest
                            (
                                Convert.ToInt32(reader["id"]),
                                (reader["email"] as string) ?? "",
                                (reader["id_card_number"] as string) ?? "",
                                (reader["fname"] as string) ?? "",
                                (reader["lname"] as string) ?? "",
                                reader["date_of_birth"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["date_of_birth"]),
                                (reader["country"] as string) ?? "",
                                (reader["zip_code"] as string) ?? "",
                                (reader["city"] as string) ?? "",
                                (reader["street"] as string) ?? "",
                                (reader["car_plate_number"] as string) ?? "",
                                reader["total_nights"] == DBNull.Value ? 0 : Convert.ToInt32(reader["total_nights"]),
                                reader["loyalty_level"] == DBNull.Value ? 0 : Convert.ToInt32(reader["loyalty_level"])
                            );
                        }
                    }
                }
            }

            return null;
        }
        // 4.
        public List<Room> SelectedRoomsByBooking(Booking booking, string request = "")
        {
            List<Room> rooms = new List<Room>();
            string query = "SELECT * " +
                           "FROM rooms " +
                           "WHERE rooms.status = 'available' " +
                               "AND rooms.needs_cleaning = 0 " +
                               "AND rooms.is_cleaning = 0 " +
                               "AND rooms.room_type = @roomType " +
                               "AND room_number NOT IN(SELECT bookings.room_number " +
                                                      "FROM bookings) ";
            query += request;
            query += ";";

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
        // 5.
        public async Task<List<BillingItem>> MakeListOfBillsAsync(List<Service> servicesList, Booking? selectedBooking = null, int days = 1, int guestCount = 1)
        {
            List<BillingItem> billingItems = new List<BillingItem>();

            days = selectedBooking != null
                ? (selectedBooking.EndOfStay - selectedBooking.BeginningOfStay).Days
                : days;

            guestCount = selectedBooking != null
                ? GetNumberOfGuests(selectedBooking)
                : guestCount;

            // SZOLGÁLTATÁS ÁRAK KISZÁMÍTÁSA
            foreach (Service service in servicesList)
            {
                decimal netPrice = service.Price / 1.27m;

                if (service.NameHu == "Parkolás")
                {
                    BillingItem parking = new BillingItem
                    (
                        service.Id,
                        DateTime.Now,
                        service.NameHu,
                        netPrice,
                        days,
                        0.27m,
                        service.Price
                    );
                    billingItems.Add(parking);
                }

                else if(service.NameHu == "Teljes ellátás")
                {
                    BillingItem fullBoard = new BillingItem
                    (
                        service.Id,
                        DateTime.Now,
                        service.NameHu,
                        28000 / 1.05m * guestCount,
                        days,
                        0.05m,
                        service.Price * days * guestCount
                    );
                    billingItems.Add(fullBoard);
                }

                else if (service.NameHu == "Félpanzió")
                {
                    BillingItem halfBoard = new BillingItem
                    (
                        service.Id,
                        DateTime.Now,
                        service.NameHu,
                        17000 / 1.05m * guestCount,
                        days,
                        0.05m,
                        service.Price * days * guestCount
                    );
                    billingItems.Add(halfBoard);
                }

                else
                {
                    BillingItem item = new BillingItem
                    (
                        service.Id,
                        DateTime.Now,
                        service.NameHu,
                        netPrice,
                        1,
                        0.27m,
                        service.Price
                    );
                    billingItems.Add(item);
                }
            }

            // SZOBA ÁRÁNAK KISZÁMÍTÁSA
            if(selectedBooking != null)
            {
                string getRoomQuery = "SELECT rooms.price_per_night, bookings.beginning_of_stay, bookings.end_of_stay, bookings.created_at " +
                                "FROM bookings " +
                                "INNER JOIN rooms ON bookings.room_number = rooms.room_number " +
                                "WHERE bookings.id = @bookingId;";

                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    await conn.OpenAsync();

                    using (MySqlCommand cmd = new MySqlCommand(getRoomQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@bookingId", selectedBooking.Id);

                        using (var reader = await cmd.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                DateTime end = Convert.ToDateTime(reader["end_of_stay"]);
                                DateTime beginning = Convert.ToDateTime(reader["beginning_of_stay"]);
                                int nights = Convert.ToInt32((end - beginning).Days);

                                decimal pricePerNight = Convert.ToDecimal(reader["price_per_night"]);
                                decimal netPricePerNight = Convert.ToDecimal(pricePerNight / 1.05m);
                                decimal grossPrice = pricePerNight * nights;

                                BillingItem roomItem = new BillingItem
                                (
                                    0,
                                    Convert.ToDateTime(reader["created_at"]),
                                    "Szoba ár",
                                    netPricePerNight,
                                    nights,
                                    0.05m,
                                    grossPrice
                                );
                                billingItems.Add(roomItem);
                            }
                        }
                    }
                }
            }
            return billingItems;
        }
        // 6.
        public bool GetSpecialRequestsFromDb(Booking selectedBooking, string serviceNameHu)
        {
            string query = "SELECT EXISTS " +
                " (SELECT 1 " +
                " FROM services " +
                " JOIN servicebookings ON services.id = servicebookings.service_id " +
                " JOIN bookings ON bookings.id = servicebookings.booking_id " +
                " WHERE bookings.id = @bookingId " +
                "   AND services.name_hu = @serviceName);";

            using(MySqlConnection conn = new MySqlConnection(connectionString))
            {
                using(MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@bookingId", selectedBooking.Id);
                    cmd.Parameters.AddWithValue("@serviceName", serviceNameHu);

                    conn.Open();

                    return Convert.ToBoolean(cmd.ExecuteScalar());
                }
            }
        }
        // 7.
        public bool IsChampagneOrdered(Booking selectedBooking)
        {
            string query = "SELECT EXISTS " +
                " (SELECT 1 " +
                " FROM servicebookings " +
                " JOIN bookings ON bookings.id = servicebookings.booking_id " +
                " WHERE bookings.id = @bookingId " +
                "   AND servicebookings.price_at_booking = 37000);";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@bookingId", selectedBooking.Id);

                    conn.Open();

                    return Convert.ToBoolean(cmd.ExecuteScalar());
                }
            }
        }
        // 8.
        public string GetCarPlateNumberByBooking(Booking selectedBooking)
        {
            string query = "SELECT car_plate_number FROM guests INNER JOIN bookings ON bookings.guest1_id = guests.id WHERE bookings.id = @bookingId;";

            using(MySqlConnection conn = new MySqlConnection(connectionString))
            {
                using(MySqlCommand cmd =  new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@bookingId", selectedBooking.Id);
                    conn.Open();

                    return cmd.ExecuteScalar()?.ToString() ?? "";
                }
            }
        }
        // 9.
        public int GetNumberOfGuests(Booking selectedBooking)
        {
            string query = "SELECT (" +
                                "(guest1_id IS NOT NULL) + " +
                                "(guest2_id IS NOT NULL) + " +
                                "(guest3_id IS NOT NULL) + " +
                                "(guest4_id IS NOT NULL)) as vendegek_szama " +
                           "FROM bookings " +
                           "WHERE bookings.id = @bookingId";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                using(MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@bookingId", selectedBooking.Id);
                    conn.Open();

                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }
        // 10.
        public int CalculateNetAmount(List<BillingItem> billingItems)
        {
            int netAmount = 0;

            foreach (BillingItem item in billingItems)
            {
                if (item.Description == "Szoba ár")
                {
                    netAmount += Convert.ToInt32(item.Total / 1.05m);
                }

                else
                {
                    netAmount += Convert.ToInt32(item.Total / 1.27m);
                }
            }

            return netAmount;
        }
        // 11.
        public int CalculateTaxAmount(List<BillingItem> billingItems)
        {
            int tax = 0;
            foreach (BillingItem billingItem in billingItems)
            {
                if (billingItem.Description == "Szoba ár")
                {
                    tax += Convert.ToInt32(billingItem.Total / 105m * 5m);
                }

                else
                {
                    tax += Convert.ToInt32(billingItem.Total / 127m * 27m);
                }
            }

            return tax;
        }
        // 12.
        public int CalculateGrossAmount(List<BillingItem> billingItems)
        {
            int grossAmount = 0;
            foreach (BillingItem billingItem in billingItems)
            {
                if (billingItem.Description == "Szoba ár")
                {
                    grossAmount += Convert.ToInt32(billingItem.Total);
                }

                else
                {
                    grossAmount += Convert.ToInt32(billingItem.Total);
                }
            }

            return grossAmount;
        }
        // 13.
        public async Task<string> GetIdCardNumberAsync(Booking booking)
        {
            string query = "SELECT guests.id_card_number " +
                "FROM guests " +
                "INNER JOIN bookings ON bookings.guest1_id = guests.id " +
                "WHERE bookings.id = @bookingId";

            await using(MySqlConnection conn = new MySqlConnection(connectionString))
            {
                await using(MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@bookingId", booking.Id);
                    await conn.OpenAsync();

                    object? result = await cmd.ExecuteScalarAsync();
                    return result != DBNull.Value && result != null ? result.ToString() : string.Empty;
                }
            }
        }
        // 14.
        public async Task LoadBillItemsAsync(DataGridView dgvPaymentSum, List<Service> services, Booking? selectedBooking = null, int days = 1, int guestCount = 1)
        {
            List<BillingItem> billingItems = await MakeListOfBillsAsync(services, selectedBooking, days, guestCount);

            billingItems = billingItems.OrderByDescending(e => e.Total).ToList();

            var bindingList = new BindingList<BillingItem>(billingItems);

            dgvPaymentSum.AutoGenerateColumns = false;
            dgvPaymentSum.Columns.Clear();

            LoadBillingitemToDgv("Date", dgvPaymentSum);
            LoadBillingitemToDgv("Description", dgvPaymentSum);
            LoadBillingitemToDgv("UnitPrice", dgvPaymentSum);
            LoadBillingitemToDgv("Quantity", dgvPaymentSum);
            LoadBillingitemToDgv("Tax", dgvPaymentSum);
            LoadBillingitemToDgv("Total", dgvPaymentSum);

            dgvPaymentSum.Columns[3].HeaderText = "Qty";

            dgvPaymentSum.DataSource = bindingList;

            // DATAGRIDVIEW STYLE
            dgvPaymentSum.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvPaymentSum.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvPaymentSum.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvPaymentSum.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvPaymentSum.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvPaymentSum.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvPaymentSum.Columns[0].DefaultCellStyle.Format = "yyyy.MM.dd";

            dgvPaymentSum.Columns[2].DefaultCellStyle.Format = "C0";
            dgvPaymentSum.Columns[5].DefaultCellStyle.Format = "C0";

            dgvPaymentSum.Columns[4].DefaultCellStyle.Format = "P0";
        }
        // 15.
        private void LoadBillingitemToDgv(string description, DataGridView dgvPaymentSum)
        {
            dgvPaymentSum.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = description,
                HeaderText = description
            });
        }
        #endregion

        #region INFO
        /*
            1.: returns a list rooms filtered by the parameters
            2.: fills the parameter flowLayoutPanel by the parameter list of rooms, with the parameter RoomCards
        */
        #endregion
        #region Add Booking

        public async Task<List<Room>> FilterAvailableRoomsAsync(DateTime arrival, DateTime departure, int numberOfGuests, string suite)
        {
            List<Room> selectedRooms = new List<Room>();
            string query =
                "SELECT r.* " +
                "FROM rooms r " +
                "WHERE r.max_adults >= @guests " +
                    "AND r.room_type = @suite " +
                    "AND NOT EXISTS (" +
                        "SELECT 1 " +
                        "FROM bookings b " +
                        "WHERE b.room_number = r.room_number " +
                            "AND b.beginning_of_stay < @departure " +
                            "AND b.end_of_stay > @arrival);";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@guests", numberOfGuests);
                    cmd.Parameters.AddWithValue("@arrival", arrival.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@departure", departure.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@suite", suite);

                    await conn.OpenAsync();

                    using (DbDataReader rd = await cmd.ExecuteReaderAsync())
                    {
                        while (await rd.ReadAsync())
                        {
                            Room room = new Room
                            (
                                Convert.ToInt32(rd["room_number"]),
                                (Room.RoomType)System.Enum.Parse(typeof(Room.RoomType), rd["room_type"].ToString(), true),
                                Convert.ToInt32(rd["floorspace"]),
                                (Room.BedType)System.Enum.Parse(typeof(Room.BedType), rd["bed_type"].ToString(), true),
                                Convert.ToInt32(rd["has_balcony"]),
                                (Room.HasView)System.Enum.Parse(typeof(Room.HasView), rd["has_view"].ToString(), true),
                                Convert.ToInt32(rd["max_adults"]),
                                rd["extras"].ToString(),
                                (Room.Status)System.Enum.Parse(typeof(Room.Status), rd["status"].ToString(), true),
                                Convert.ToInt32(rd["price_per_night"]),
                                Convert.ToInt32(rd["door_locked"]),
                                Convert.ToInt32(rd["needs_cleaning"]),
                                Convert.ToInt32(rd["dont_disturb"]),
                                Convert.ToInt32(rd["is_cleaning"]),
                                Convert.ToInt32(rd["ac_temp"])
                            );

                            selectedRooms.Add(room);
                        }
                    }
                }
            }

            return selectedRooms;
        }

        public void FillAvailableRooms(List<Room> rooms, FlowLayoutPanel flp, Action<RoomCardUserControl> OnCardSelected)
        {
            flp.Controls.Clear();

            foreach (var room in rooms)
            {
                RoomCardUserControl roomCard = new RoomCardUserControl();
                roomCard.LoadCardData(room);

                roomCard.CardSelected += (sender, e) =>
                {
                    OnCardSelected(roomCard);
                };

                flp.Controls.Add(roomCard);
            }
        }

        #endregion

        #region INFO
        /*
            1.: Next Button
            2.: Back Button
            3.: Sets the button visibility true or false
        */
        #endregion
        #region Buttons

        public void NextButtonClick(TabControl tc, System.Windows.Forms.Button next, System.Windows.Forms.Button back, System.Windows.Forms.Button confirm)
        {
            if (tc.SelectedIndex < 4)
            {
                tc.SelectedIndex += 1;
            }

            ButtonVisibility(tc, next, back, confirm);
        }

        public void BackButtonClick(TabControl tc, System.Windows.Forms.Button next, System.Windows.Forms.Button back, System.Windows.Forms.Button confirm)
        {
            if (tc.SelectedIndex > 0)
            {
                tc.SelectedIndex -= 1;
            }

            ButtonVisibility(tc, next, back, confirm);
        }

        private void ButtonVisibility(TabControl tc, System.Windows.Forms.Button next, System.Windows.Forms.Button back, System.Windows.Forms.Button confirm)
        {
            back.Visible = (tc.SelectedIndex > 0);
            next.Visible = (tc.SelectedIndex < 4);
            confirm.Visible = (tc.SelectedIndex == 4);
        }

        #endregion

        #region INFO
        /*
            1.: Refreshes the page count on the bottom of the page
        */
        #endregion
        #region UI refreshing

        public void RefreshPageCount(TabControl tc,System.Windows.Forms.Label lb)
        {
            switch (tc.SelectedIndex)
            {
                case 0: lb.Text = "1/5"; return;
                case 1: lb.Text = "2/5"; return;
                case 2: lb.Text = "3/5"; return;
                case 3: lb.Text = "4/5"; return;
                case 4: lb.Text = "5/5"; return;
            }
        }

        #endregion

        #region INFO
        /*
            1.: Keypress Handlers
            2.: returns true if the parameter textbox remains blank
            3.: creates a service of the parameter serviceName, adds to the parameter list
            4.: replaces the parameter label with the names of the items in the parameter list
            5.: adds the parameter guest as a control to the parameter tabControl
            6.: returns a string of the parameter rooms details
        */
        #endregion
        #region Common
        // 1.
        public static class InputValidationService
        {
            public static void BlockDigits(KeyPressEventArgs e)
            {
                if (char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }

            public static void BlockLetters(KeyPressEventArgs e)
            {
                if (char.IsLetter(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        }
        // 2.
        public bool HasValidationError(System.Windows.Forms.TextBox tb, ErrorProvider ep)
        {
            if (string.IsNullOrEmpty(tb.Text.Trim()))
            {
                ep.SetError(tb, "You can't leave empty spaces!");
                return true;
            }
            else { ep.SetError(tb, ""); return false; }
        }
        // 3.
        public void CreateNewService(string serviceName, List<Service> serviceList, int days = 1, Room? room = null)
        {
            var service = serviceName switch
            {
                
                "Szoba" when room != null => new Service(0, "Szoba", "Szoba ára éjszakánként", ServiceTypeHu.Logisztika, room.Price * days, "Room", "Price of room per night", ServiceTypeEn.Logistics),
                "Halfboard" => new Service(19, "Félpanzió", "Félpanziós ellátás reggelivel és vacsorával", ServiceTypeHu.Logisztika, 17000, "Half board", "Half-board service including breakfast and dinner.", ServiceTypeEn.Logistics),
                "Fullboard" => new Service(20, "Teljes ellátás", "Teljes ellátás reggelivel, ebéddel és vacsorával.", ServiceTypeHu.Logisztika, 28000, "Full board", "Full-board service including breakfast, lunch and dinner.", ServiceTypeEn.Logistics),
                "Transzfer" => new Service(3, "Transzfer", "Reptéri transzfer egy irányba", ServiceTypeHu.Logisztika, 10000, "Transfer", "Airport transfer one way", ServiceTypeEn.Logistics),
                "Parkolás" => new Service(2, "Parkolás", "Zárt parkoló napidíj", ServiceTypeHu.Logisztika, 3000 * days, "Parking", "Gated parking daily fee", ServiceTypeEn.Logistics),
                "Pótágy" => new Service(9, "Pótágy", "Extra ágy biztosítása", ServiceTypeHu.Extrák, 7000, "Extra bed", "Provision of an extra bed", ServiceTypeEn.Extras),
                "Kiságy" => new Service(10, "Kiságy", "Babaágy biztosítása", ServiceTypeHu.Extrák, 3000, "Baby cot", "Provision of a baby cot", ServiceTypeEn.Extras),
                "Késői kijelentkezés" => new Service(22, "Késői kijelentkezés", "Fizetős szobahosszabbítás a távozás napján.", ServiceTypeHu.Logisztika, 20000, "Late check-out", "Paid room extension upon departure.", ServiceTypeEn.Logistics),
                "Korai távozás" => new Service(23, "Korai távozás", "Tervezettnél korábbi elutazás a szállodából.", ServiceTypeHu.Logisztika, 30000, "Early departure", "Leaving the hotel before schedule.", ServiceTypeEn.Logistics),
                "Pezsgő bekészítés" => new Service(21, "Pezsgő bekészítés", "A világ legikonikusabb champagne-ja...", ServiceTypeHu.Extrák, 37000, "Champagne", "The world's most iconic champagne...", ServiceTypeEn.Extras),
                _ => null
            };

            if(service != null)
            {
                serviceList.Add(service);
            }
        }
        // 4.
        public void FillSumSpecialRequests(List<Service> services, System.Windows.Forms.Label lbSumExtras)
        {
            string sumRequests = string.Join(" | ", services.Where(s => s.NameHu != "Szoba").Select(s => s.NameHu));

            lbSumExtras.Text = services.Count() > 1
                ? sumRequests
                : "No special requests";
        }
        // 5.
        public void AddGuestTabToSummary(Guest g, List<Guest> guests, TabControl tcGuests)
        {
            int index = guests.IndexOf(g);

            GuestDataSumControl guestTab = new GuestDataSumControl();
            TabPage tp = new TabPage($"tpGuest{index}");

            tp.Text = $"Guest {index + 1}";
            tp.Controls.Add(guestTab);

            guestTab.FillGuestTabData(g);

            tcGuests.TabPages.Add(tp);
        }
        // 6.
        public string BuildSelectedRoomDetailsString(Room room)
        {
            StringBuilder sb = new StringBuilder();

            sb.Clear();
            string hasBalcony = room.HasBalcony == 1 ? "Balcony" : "No Balcony";
            sb.Append($"{room.Room_number.ToString()}  |  ");
            sb.Append($"{room.RoomsRoomtype.ToString()}  |  ");
            sb.Append($"{room.RoomsBedType.ToString()}  |  ");
            sb.Append($"{hasBalcony}  |  ");
            sb.Append($"{room.RoomsView.ToString()}");

            return sb.ToString();
        }
        #endregion
    }
}