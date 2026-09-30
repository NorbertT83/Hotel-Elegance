using Hotel_erp_Winforms_App.Models;
using Hotel_erp_Winforms_App.UI.Controls.GuestsDataSumControl;
using Hotel_erp_Winforms_App.UI.Controls.RoomCardControl;
using MySql.Data.MySqlClient;
using NanoidDotNet;
using System.ComponentModel;
using System.Data;
using System.Data.Common;

namespace Hotel_erp_Winforms_App.Services
{
    public class BookingService
    {
        #region TODO:

        #endregion

        #region variables

        private readonly string connectionString = DbConfig.ConnectionString;

        #endregion

        #region INFO
        /*
            1.: makes list of all of the bookings
            2.: filters bookings by the parameters
            3.: confirms the check-in, updates database
            4.: confirms the new booking, updates database
        */
        #endregion
        #region Common database actions

        // 1.
        public async Task<List<Booking>> LoadDgvAsync(string query = "SELECT * FROM bookings", Dictionary<string, object>? parameters = null)
        {
            List<Booking> bookings = new List<Booking>();

            await using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                await connection.OpenAsync();

                await using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    if (parameters != null)
                    {
                        foreach (var param in parameters)
                        {
                            cmd.Parameters.AddWithValue(param.Key, param.Value ?? DBNull.Value);
                        }
                    }

                    await using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            DateTime? checkinValue = reader["checkin"] == DBNull.Value ? null : Convert.ToDateTime(reader["checkin"]);
                            DateTime? checkoutValue = reader["checkout"] == DBNull.Value ? null : Convert.ToDateTime(reader["checkout"]);
                            DateTime? createdAtValue = reader["created_at"] == DBNull.Value ? null : Convert.ToDateTime(reader["created_at"]);

                            int? guest2 = reader["guest2_id"] == DBNull.Value ? null : Convert.ToInt32(reader["guest2_id"]);
                            int? guest3 = reader["guest3_id"] == DBNull.Value ? null : Convert.ToInt32(reader["guest3_id"]);
                            int? guest4 = reader["guest4_id"] == DBNull.Value ? null : Convert.ToInt32(reader["guest4_id"]);

                            Enum.TryParse<Hotel_erp_Winforms_App.Models.RoomType>(
                                reader["room_type"]?.ToString(), true, out var roomTypeEnum);

                            Enum.TryParse<CateringLevel>(
                                reader["catering_level"]?.ToString(), true, out var cateringEnum);

                            Booking booking = new Booking
                            (
                                reader["id"].ToString() ?? string.Empty,
                                reader["room_number"] == DBNull.Value ? 0 : Convert.ToInt32(reader["room_number"]),
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
            }
            return bookings;
        }

        // 2.
        public async Task<List<Booking>> SearchBookings(int fieldIndex, string searchText, int statusIndex, int spanIndex, DateTime fromDate, DateTime toDate)
        {
            if (statusIndex == 4)
            {
                var deletedStorage = new DeletedBookingStorageService();
                List<Booking> deletedBookings = await deletedStorage.LoadDeletedBookingsAsync();

                if (!string.IsNullOrEmpty(searchText))
                {
                    string search = searchText.Trim().ToLower();

                    var gs = new GuestService();
                    var allGuests = await gs.GetAllGuestsFromDbAsync();

                    deletedBookings = deletedBookings.Where(b =>
                    {
                        var guestIds = new List<int>();
                        if (b.GuestId > 0) guestIds.Add(b.GuestId);
                        if (b.GuestId2 > 0) guestIds.Add(b.GuestId2.Value);
                        if (b.GuestId3 > 0) guestIds.Add(b.GuestId3.Value);
                        if (b.GuestId4 > 0) guestIds.Add(b.GuestId4.Value);

                        var matchingGuests = allGuests.Where(g => guestIds.Contains(g.Id ?? 0)).ToList();

                        bool nameMatches = matchingGuests.Any(g =>
                            (!string.IsNullOrEmpty(g.FName) && g.FName.ToLower().Contains(search)) ||
                            (!string.IsNullOrEmpty(g.LName) && g.LName.ToLower().Contains(search))
                        );

                        return (fieldIndex == 1 && nameMatches) ||
                               (fieldIndex == 2 && b.Id.ToString().Contains(search)) ||
                               (fieldIndex == 3 && b.RoomNumber.ToString().Contains(search)) ||
                               (fieldIndex == 4 && b.SelectedRoomType.ToString().ToLower().Contains(search)) ||
                               (fieldIndex == 9 && b.SelectedCateringLevel.ToString().ToLower().Contains(search)) ||
                               (fieldIndex <= 0 && (nameMatches || b.Id.ToString().Contains(search)));
                    }).ToList();
                }

                DateTime deletedStartRange = fromDate.Date;
                DateTime deletedEndRange = toDate.Date.AddDays(1).AddSeconds(-1);

                switch (spanIndex)
                {
                    case 1: // Kezdés alapján
                        deletedBookings = deletedBookings
                            .Where(b => b.BeginningOfStay >= deletedStartRange && b.BeginningOfStay <= deletedEndRange)
                            .ToList();
                        break;
                    case 2: // Távozás alapján
                        deletedBookings = deletedBookings
                            .Where(b => b.EndOfStay >= deletedStartRange && b.EndOfStay <= deletedEndRange)
                            .ToList();
                        break;
                    case 3: // Teljes tartomány
                        deletedBookings = deletedBookings
                            .Where(b => b.BeginningOfStay >= deletedStartRange && b.EndOfStay <= deletedEndRange)
                            .ToList();
                        break;
                }

                return deletedBookings;
            }

            string joins = "";
            string whereClause = " WHERE 1=1 ";
            var parameters = new Dictionary<string, object>();

            var deletedService = new DeletedBookingStorageService();
            List<Booking> deletedList = await deletedService.LoadDeletedBookingsAsync();

            if (deletedList.Count > 0)
            {
                var validDeletedIds = deletedList
                    .Where(b => !string.IsNullOrWhiteSpace(b.Id))
                    .Select(b => $"'{b.Id.Replace("'", "''")}'")
                    .ToList();

                if (validDeletedIds.Count > 0)
                {
                    whereClause += $" AND bookings.id NOT IN ({string.Join(",", validDeletedIds)}) ";
                }
            }

            // 1. MEZŐ KIVÁLASZTÁS
            if (!string.IsNullOrEmpty(searchText))
            {
                switch (fieldIndex)
                {
                    case -1:
                    case 0:
                        break;

                    case 1:
                        joins += " INNER JOIN guests ON bookings.guest1_id = guests.id ";
                        whereClause += " AND (guests.fname LIKE @fname OR guests.lname LIKE @fname) ";
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
                        whereClause += " AND DATE_FORMAT(bookings.beginning_of_stay, '%Y-%m-%d') LIKE @searchBar ";
                        parameters.Add("@searchBar", $"%{searchText}%");
                        break;

                    case 6:
                        whereClause += " AND DATE_FORMAT(bookings.end_of_stay, '%Y-%m-%d') LIKE @searchBar ";
                        parameters.Add("@searchBar", $"%{searchText}%");
                        break;

                    case 7:
                        whereClause += " AND DATE_FORMAT(bookings.checkin, '%Y-%m-%d') LIKE @searchBar ";
                        parameters.Add("@searchBar", $"%{searchText}%");
                        break;

                    case 8:
                        whereClause += " AND DATE_FORMAT(bookings.checkout, '%Y-%m-%d') LIKE @searchBar ";
                        parameters.Add("@searchBar", $"%{searchText}%");
                        break;

                    case 9:
                        whereClause += " AND bookings.catering_level LIKE @searchBar ";
                        parameters.Add("@searchBar", $"%{searchText}%");
                        break;
                }
            }

            // 2. STÁTUSZ KIVÁLASZTÁS
            switch (statusIndex)
            {
                case 0:
                    break;
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

            // 3. IDŐSZAK KIVÁLASZTÁS
            DateTime startRange = fromDate.Date;
            DateTime endRange = toDate.Date.AddDays(1).AddSeconds(-1);

            switch (spanIndex)
            {
                case 0:
                    break;
                case 1:
                    whereClause += " AND beginning_of_stay BETWEEN @from AND @to";
                    parameters.Add("@from", startRange);
                    parameters.Add("@to", endRange);
                    break;
                case 2:
                    whereClause += " AND end_of_stay BETWEEN @from AND @to";
                    parameters.Add("@from", startRange);
                    parameters.Add("@to", endRange);
                    break;
                case 3:
                    whereClause += " AND beginning_of_stay >= @from AND end_of_stay <= @to";
                    parameters.Add("@from", startRange);
                    parameters.Add("@to", endRange);
                    break;
            }

            string query = $"SELECT bookings.* FROM bookings{joins}{whereClause};";

            return await LoadDgvAsync(query, parameters);
        }

        // 3.
        public async Task ConfirmCheckinAsync(Booking booking, List<Guest> guestList, List<Service> serviceItems)
        {
            // 1.: SAVE GUESTS
            string saveGuestQuery = @"
                INSERT INTO guests (id, email, id_card_number, fname, lname, date_of_birth, country, zip_code, city, street, car_plate_number, total_nights)
                VALUES (@id, @email, @idNumber, @fname, @lname, @dateOfBirth, @country, @zip, @city, @street, @carPlate, @totalNights)
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
                    total_nights = VALUES(total_nights);
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

            await using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                await conn.OpenAsync();
                await using (MySqlTransaction transaction = await conn.BeginTransactionAsync())
                {
                    try
                    {
                        List<int> savedGuestsIds = new List<int>();

                        for (int i = 0; i < guestList.Count; i++)
                        {
                            Guest guest = guestList[i];

                            string guestEmail = (i == 0 && !string.IsNullOrEmpty(guest.Email))
                                ? guest.Email
                                : (!string.IsNullOrEmpty(guest.Email) ? guest.Email : $"no-email-{Guid.NewGuid()}@placeholder.local");

                            // VENDÉGEK MENTÉSE
                            await using (MySqlCommand cmd = new MySqlCommand(saveGuestQuery, conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@id", guest.Id == 0 ? (object)DBNull.Value : guest.Id);
                                cmd.Parameters.AddWithValue("@email", guestEmail);
                                cmd.Parameters.AddWithValue("@idNumber", string.IsNullOrEmpty(guest.IdCardNumber) ? (object)DBNull.Value : guest.IdCardNumber);
                                cmd.Parameters.AddWithValue("@fname", guest.FName);
                                cmd.Parameters.AddWithValue("@lname", guest.LName);
                                cmd.Parameters.AddWithValue("@dateOfBirth", guest.DateOfBirth);
                                cmd.Parameters.AddWithValue("@country", guest.Country);
                                cmd.Parameters.AddWithValue("@zip", guest.ZipCode);
                                cmd.Parameters.AddWithValue("@city", guest.City);
                                cmd.Parameters.AddWithValue("@street", guest.Street);
                                cmd.Parameters.AddWithValue("@carPlate", string.IsNullOrEmpty(guest.CarPlateNumber) ? (object)DBNull.Value : guest.CarPlateNumber);
                                cmd.Parameters.AddWithValue("@totalNights", guest.TotalNights);

                                object? result = await cmd.ExecuteScalarAsync();
                                int currentGuestId = 0;

                                if (result != null && result != DBNull.Value && Convert.ToInt32(result) != 0)
                                {
                                    currentGuestId = Convert.ToInt32(result);
                                }
                                else
                                {
                                    currentGuestId = guest.Id ?? 0;
                                }

                                savedGuestsIds.Add(currentGuestId);
                            }
                        }

                        // BOOKING UPDATE
                        await using (MySqlCommand cmd = new MySqlCommand(updateBookingQuery, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@bookingId", booking.Id);
                            cmd.Parameters.AddWithValue("@roomNumber", booking.RoomNumber);
                            cmd.Parameters.AddWithValue("@roomType", booking.SelectedRoomType.ToString().ToLower());
                            cmd.Parameters.AddWithValue("@cateringLevel", booking.SelectedCateringLevel.ToString().ToLower());

                            cmd.Parameters.AddWithValue("@guestId1", savedGuestsIds.Count > 0 ? savedGuestsIds[0] : (object)DBNull.Value);
                            cmd.Parameters.AddWithValue("@guestId2", savedGuestsIds.Count > 1 ? savedGuestsIds[1] : (object)DBNull.Value);
                            cmd.Parameters.AddWithValue("@guestId3", savedGuestsIds.Count > 2 ? savedGuestsIds[2] : (object)DBNull.Value);
                            cmd.Parameters.AddWithValue("@guestId4", savedGuestsIds.Count > 3 ? savedGuestsIds[3] : (object)DBNull.Value);

                            await cmd.ExecuteNonQueryAsync();
                        }

                        // ROOM UPDATE
                        await using (MySqlCommand cmd = new MySqlCommand(updateRoomQuery, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@roomNumber", booking.RoomNumber);
                            await cmd.ExecuteNonQueryAsync();
                        }

                        // SZOLGÁLTATÁSOK
                        foreach (var item in serviceItems)
                        {
                            int days = (booking.EndOfStay - booking.BeginningOfStay).Days;

                            await using (MySqlCommand cmd = new MySqlCommand(updateServicesQuery, conn, transaction))
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

                                await cmd.ExecuteNonQueryAsync();
                            }
                        }

                        await transaction.CommitAsync();
                    }
                    catch (Exception)
                    {
                        await transaction.RollbackAsync();
                        throw;
                    }
                }
            }
        }

        // 4.
        public async Task ConfirmNewBookingAsync(Room room, List<Guest> guestList, List<Service> services, DateTime endDate, CateringLevel catering, int nights)
        {
            string saveBookingQuery = @"
                INSERT INTO bookings (id, room_number, room_type, guest1_id, beginning_of_stay, end_of_stay,
                    checkin, checkout, guest2_id, guest3_id, guest4_id, created_at, catering_level)
                VALUES (@id, @roomNumber, @roomType, @guestId1, @startDate, @endDate, @checkin, @checkout, @guestId2, @guestId3, @guestId4, 
                    @createdAt, @cateringLevel);
            ";

            string updateRoomQuery = @"
                UPDATE rooms
                SET status = 'unavailable'
                WHERE room_number = @roomNumber;
            ";

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

                            for (int i = 0; i < guestList.Count; i++)
                            {
                                Guest g = guestList[i];
                                long guestId = 0;

                                string guestEmail = (i == 0 && !string.IsNullOrEmpty(g.Email))
                                    ? g.Email
                                    : $"no-email-{Guid.NewGuid()}@placeholder.local";

                                string checkGuestQuery = @"
                                    SELECT id FROM guests 
                                    WHERE id_card_number = @idCard 
                                       OR email = @email
                                    LIMIT 1;";

                                using (MySqlCommand checkCmd = new MySqlCommand(checkGuestQuery, conn, transaction))
                                {
                                    checkCmd.Parameters.AddWithValue("@idCard", string.IsNullOrEmpty(g.IdCardNumber) ? DBNull.Value : g.IdCardNumber);
                                    checkCmd.Parameters.AddWithValue("@email", guestEmail);

                                    object? result = await checkCmd.ExecuteScalarAsync();

                                    if (result != null && result != DBNull.Value)
                                    {
                                        guestId = Convert.ToInt64(result);
                                    }
                                }

                                if (guestId > 0)
                                {
                                    string updateGuestQuery = @"
                                        UPDATE guests 
                                        SET total_nights = total_nights + @totalNights,
                                            car_plate_number = COALESCE(@carPlate, car_plate_number),
                                            id_card_number = COALESCE(@idCard, id_card_number)
                                        WHERE id = @id;";

                                    using (MySqlCommand updateCmd = new MySqlCommand(updateGuestQuery, conn, transaction))
                                    {
                                        updateCmd.Parameters.AddWithValue("@id", guestId);
                                        updateCmd.Parameters.AddWithValue("@totalNights", nights);
                                        updateCmd.Parameters.AddWithValue("@carPlate", string.IsNullOrEmpty(g.CarPlateNumber) ? DBNull.Value : g.CarPlateNumber);
                                        updateCmd.Parameters.AddWithValue("@idCard", string.IsNullOrEmpty(g.IdCardNumber) ? DBNull.Value : g.IdCardNumber);

                                        await updateCmd.ExecuteNonQueryAsync();
                                    }
                                }
                                else
                                {
                                    string insertGuestQuery = @"
                                        INSERT INTO guests (email, id_card_number, fname, lname, date_of_birth, country, zip_code, city, street, car_plate_number, total_nights)
                                        VALUES (@email, @id_card_number, @fname, @lname, @date_of_birth, @country, @zip_code, @city, @street, @carPlate, @totalNights);
                                        SELECT LAST_INSERT_ID();";

                                    using (MySqlCommand insertCmd = new MySqlCommand(insertGuestQuery, conn, transaction))
                                    {
                                        insertCmd.Parameters.AddWithValue("@email", guestEmail);
                                        insertCmd.Parameters.AddWithValue("@id_card_number", string.IsNullOrEmpty(g.IdCardNumber) ? DBNull.Value : g.IdCardNumber);
                                        insertCmd.Parameters.AddWithValue("@fname", g.FName);
                                        insertCmd.Parameters.AddWithValue("@lname", g.LName);
                                        insertCmd.Parameters.AddWithValue("@date_of_birth", g.DateOfBirth);
                                        insertCmd.Parameters.AddWithValue("@country", g.Country);
                                        insertCmd.Parameters.AddWithValue("@zip_code", g.ZipCode);
                                        insertCmd.Parameters.AddWithValue("@city", g.City);
                                        insertCmd.Parameters.AddWithValue("@street", g.Street);
                                        insertCmd.Parameters.AddWithValue("@carPlate", string.IsNullOrEmpty(g.CarPlateNumber) ? DBNull.Value : g.CarPlateNumber);
                                        insertCmd.Parameters.AddWithValue("@totalNights", nights);

                                        object? newId = await insertCmd.ExecuteScalarAsync();
                                        if (newId != null && newId != DBNull.Value)
                                        {
                                            guestId = Convert.ToInt64(newId);
                                        }
                                    }
                                }

                                if (guestId > 0)
                                {
                                    guestDbIds.Add(guestId);
                                }
                                else
                                {
                                    throw new Exception($"Guest not found: {g.FName} {g.LName} ({g.IdCardNumber})");
                                }
                            }

                            await using (MySqlCommand cmd = new MySqlCommand(saveBookingQuery, conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@id", bookingId);
                                cmd.Parameters.AddWithValue("@roomNumber", room.Room_number);
                                cmd.Parameters.AddWithValue("@roomType", room.RoomsRoomtype.ToString().ToLower());

                                cmd.Parameters.AddWithValue("@guestId1", guestDbIds[0]);

                                cmd.Parameters.AddWithValue("@guestId2", guestDbIds.Count > 1 ? (object)guestDbIds[1] : DBNull.Value);
                                cmd.Parameters.AddWithValue("@guestId3", guestDbIds.Count > 2 ? (object)guestDbIds[2] : DBNull.Value);
                                cmd.Parameters.AddWithValue("@guestId4", guestDbIds.Count > 3 ? (object)guestDbIds[3] : DBNull.Value);

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

                            await using (MySqlCommand cmd = new MySqlCommand(updateRoomQuery, conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@roomNumber", room.Room_number);

                                await cmd.ExecuteNonQueryAsync();
                            }

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

        // 1.
        public int GetTodaysArrivalsCount()
        {
            string query = "SELECT COUNT(*) FROM bookings WHERE beginning_of_stay = CURRENT_DATE AND checkin IS NULL ;";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    conn.Open();
                    return (int)(long)cmd.ExecuteScalar();
                }
            }
        }

        // 2.
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

        // 3.
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

        // ====================
        #region INFO
        // 1. Foglaláshoz tartozó vendég adatainak lekérése
        // 2. Foglaláshoz tartozó személyi igazolvány szám lekérése
        // 3. Foglaláshoz tartozó autó rendszámának lekérése
        // 4. Foglalásban szereplő vendégek számának meghatározása
        // 5. Elérhető szobák listázása a foglalási feltételek alapján
        // 6. Egyedi kérés / szolgáltatás létezésének ellenőrzése a foglaláshoz
        // 7. Pezsgő rendelés létezésének ellenőrzése a foglaláshoz
        // 8. Számlatételek (BillingItem) listájának összeállítása szolgáltatásokból
        // 9. Számlatételek nettó összegének kiszámítása
        // 10. Számlatételek adótartalmának (ÁFA) kiszámítása
        // 11. Számlatételek bruttó összegének kiszámítása
        // 12. Számlatételek betöltése és megjelenítése a DataGridView felületén
        #endregion
        #region Vendég és Foglalási Adatok (SQL)

        // 1.
        public async Task<Guest?> FillPersonalDataAsync(Booking selectedBooking)
        {
            string query = "SELECT guests.id, fname, lname, email, date_of_birth, country, zip_code, city, street, id_card_number, car_plate_number, total_nights, loyalty_level " +
                "FROM guests " +
                "INNER JOIN bookings ON guests.id = bookings.guest1_id " +
                "WHERE bookings.id = @bookingId";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    await conn.OpenAsync();
                    cmd.Parameters.AddWithValue("@bookingId", selectedBooking.Id);

                    using (DbDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
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

        // 2.
        public async Task<string> GetIdCardNumberAsync(Booking? booking)
        {
            if (booking is null)
            {
                return string.Empty;
            }

            string query = "SELECT guests.id_card_number " +
                "FROM guests " +
                "INNER JOIN bookings ON bookings.guest1_id = guests.id " +
                "WHERE bookings.id = @bookingId";

            await using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                await using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@bookingId", booking.Id);
                    await conn.OpenAsync();

                    object? result = await cmd.ExecuteScalarAsync();
                    return result is not null and not DBNull ? result.ToString()! : string.Empty;
                }
            }
        }

        // 3.
        public async Task<string> GetCarPlateNumberByBookingAsync(Booking selectedBooking)
        {
            string query = "SELECT car_plate_number FROM guests INNER JOIN bookings ON bookings.guest1_id = guests.id WHERE bookings.id = @bookingId;";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@bookingId", selectedBooking.Id);

                    await conn.OpenAsync();

                    object? result = await cmd.ExecuteScalarAsync();
                    return result?.ToString() ?? "";
                }
            }
        }

        // 4.
        public async Task<int> GetNumberOfGuestsAsync(Booking selectedBooking)
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
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@bookingId", selectedBooking.Id);

                    await conn.OpenAsync();

                    object? result = await cmd.ExecuteScalarAsync();
                    return result != null ? Convert.ToInt32(result) : 0;
                }
            }
        }

        // 5.
        public async Task<List<Room>> SelectedRoomsByBookingAsync(Booking booking, string additionalWhereClause = "")
        {
            List<Room> rooms = new List<Room>();

            string query = "SELECT * " +
                           "FROM rooms " +
                           "WHERE rooms.status = 'available' " +
                               "AND rooms.needs_cleaning = 0 " +
                               "AND rooms.is_cleaning = 0 " +
                               "AND rooms.room_type = @roomType " +
                               "AND room_number NOT IN (SELECT bookings.room_number FROM bookings) " +
                           additionalWhereClause + ";";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@roomType", booking.SelectedRoomType.ToString());
                    await conn.OpenAsync();

                    using (DbDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            Room room = new Room
                            (
                                Convert.ToInt32(reader["room_number"]),
                                Enum.TryParse<Room.RoomType>(reader["room_type"]?.ToString(), true, out var roomType) ? roomType : default,
                                Convert.ToInt32(reader["floorspace"]),
                                Enum.TryParse<Room.BedType>(reader["bed_type"]?.ToString(), true, out var bedType) ? bedType : default,
                                Convert.ToInt32(reader["has_balcony"]),
                                Enum.TryParse<Room.HasView>(reader["has_view"]?.ToString(), true, out var hasView) ? hasView : default,
                                Convert.ToInt32(reader["max_adults"]),
                                reader["extras"] is DBNull or null ? string.Empty : reader["extras"].ToString()!,
                                Enum.TryParse<Room.Status>(reader["status"]?.ToString(), true, out var status) ? status : default,
                                Convert.ToInt32(reader["price_per_night"]),
                                Convert.ToInt32(reader["door_locked"]),
                                Convert.ToInt32(reader["needs_cleaning"]),
                                Convert.ToInt32(reader["dont_disturb"]),
                                Convert.ToInt32(reader["is_cleaning"]),
                                Convert.ToInt32(reader["ac_temp"])
                            );

                            rooms.Add(room);
                        }
                    }
                }
            }

            return rooms;
        }

        #endregion

        #region Szolgáltatások és Kérések (SQL)

        // 6.
        public async Task<bool> GetSpecialRequestsFromDbAsync(Booking selectedBooking, string serviceNameHu)
        {
            string query = "SELECT EXISTS " +
                " (SELECT 1 " +
                " FROM services " +
                " JOIN servicebookings ON services.id = servicebookings.service_id " +
                " JOIN bookings ON bookings.id = servicebookings.booking_id " +
                " WHERE bookings.id = @bookingId " +
                "   AND services.name_hu = @serviceName);";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@bookingId", selectedBooking.Id);
                    cmd.Parameters.AddWithValue("@serviceName", serviceNameHu);

                    await conn.OpenAsync();

                    object? result = await cmd.ExecuteScalarAsync();
                    return result != null && Convert.ToBoolean(result);
                }
            }
        }

        // 7.
        public async Task<bool> IsChampagneOrderedAsync(Booking selectedBooking)
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

                    await conn.OpenAsync();

                    object? result = await cmd.ExecuteScalarAsync();
                    return result != null && Convert.ToBoolean(result);
                }
            }
        }

        #endregion

        #region Számlázás és Számítások

        // 8.
        public async Task<List<BillingItem>> MakeListOfBillsAsync(List<Service> servicesList, Booking? selectedBooking = null, int days = 1, int guestCount = 1)
        {
            List<BillingItem> billingItems = new List<BillingItem>();

            days = selectedBooking != null
                ? (selectedBooking.EndOfStay - selectedBooking.BeginningOfStay).Days
                : days;

            guestCount = selectedBooking != null
                ? await GetNumberOfGuestsAsync(selectedBooking)
                : guestCount;

            // SZOLGÁLTATÁS ÁRAK KISZÁMÍTÁSA
            foreach (Service service in servicesList)
            {
                decimal netPrice = service.Price / 1.27m;

                if (service.NameHu == "Szoba")
                {
                    decimal unitNetPrice = (service.Price / (days > 0 ? days : 1)) / 1.05m;
                    decimal calculatedTotal = (service.Price / (days > 0 ? days : 1)) * days;

                    BillingItem roomItem = new BillingItem
                    (
                        service.Id,
                        DateTime.Now,
                        service.NameHu,
                        unitNetPrice,
                        days,
                        0.05m,
                        calculatedTotal
                    );
                    billingItems.Add(roomItem);
                }
                else if (service.NameHu == "Parkolás")
                {
                    BillingItem parking = new BillingItem
                    (
                        service.Id,
                        DateTime.Now,
                        service.NameHu,
                        netPrice,
                        1,
                        0.27m,
                        service.Price
                    );
                    billingItems.Add(parking);
                }
                else if (service.NameHu == "Teljes ellátás")
                {
                    BillingItem fullBoard = new BillingItem
                    (
                        service.Id,
                        DateTime.Now,
                        service.NameHu,
                        (28000 / 1.05m),
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
                        (17000 / 1.05m),
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
            if (selectedBooking != null && !servicesList.Any(s => s.NameHu == "Szoba"))
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
                                decimal netPricePerNight = pricePerNight / 1.05m;
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

        // 9.
        public async Task<int> CalculateNetAmountAsync(List<BillingItem> billingItems)
        {
            decimal netAmount = 0m;

            foreach (BillingItem item in billingItems)
            {
                decimal rate = 1m + item.Tax;
                netAmount += item.Total / rate;
            }

            int result = Convert.ToInt32(Math.Round(netAmount, MidpointRounding.AwayFromZero));

            return await Task.FromResult(result);
        }

        // 10.
        public async Task<int> CalculateTaxAmountAsync(List<BillingItem> billingItems)
        {
            decimal tax = 0m;
            foreach (BillingItem billingItem in billingItems)
            {
                decimal rate = 1m + billingItem.Tax;
                tax += billingItem.Total - (billingItem.Total / rate);
            }

            int result = Convert.ToInt32(Math.Round(tax, MidpointRounding.AwayFromZero));
            return await Task.FromResult(result);
        }

        // 11.
        public async Task<int> CalculateGrossAmountAsync(List<BillingItem> billingItems)
        {
            int grossAmount = 0;
            foreach (BillingItem billingItem in billingItems)
            {
                grossAmount += Convert.ToInt32(billingItem.Total);
            }

            return await Task.FromResult(grossAmount);
        }

        #endregion

        #region Felületi (UI) Műveletek

        // 12.
        public async Task LoadBillItemsAsync(DataGridView dgvPaymentSum, List<Service> services, Booking? selectedBooking = null, int days = 1, int guestCount = 1)
        {
            List<BillingItem> billingItems = await MakeListOfBillsAsync(services, selectedBooking, days, guestCount);

            billingItems = billingItems.OrderByDescending(e => e.Total).ToList();

            var bindingList = new BindingList<BillingItem>(billingItems);

            dgvPaymentSum.AutoGenerateColumns = false;
            dgvPaymentSum.DataSource = null;
            dgvPaymentSum.DataSource = bindingList;
        }

        #endregion
        // =====================

        #region Add Booking

        // 1. Szobák szűrése és aszinkron lekérése
        public async Task<List<Room>> FilterAvailableRoomsAsync(DateTime arrival, DateTime departure, int numberOfGuests, string suite, CancellationToken cancellationToken = default)
        {
            var selectedRooms = new List<Room>();

            const string query = @"
        SELECT r.* 
        FROM rooms r 
        WHERE r.max_adults >= @guests 
          AND r.room_type = @suite 
          AND NOT EXISTS (
              SELECT 1 
              FROM bookings b 
              WHERE b.room_number = r.room_number 
                AND b.beginning_of_stay < @departure 
                AND b.end_of_stay > @arrival
          );";

            await using var conn = new MySqlConnection(connectionString);
            await using var cmd = new MySqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@guests", numberOfGuests);
            cmd.Parameters.AddWithValue("@arrival", arrival.ToString("yyyy-MM-dd"));
            cmd.Parameters.AddWithValue("@departure", departure.ToString("yyyy-MM-dd"));
            cmd.Parameters.AddWithValue("@suite", suite);

            await conn.OpenAsync(cancellationToken);

            await using var rd = await cmd.ExecuteReaderAsync(cancellationToken);
            while (await rd.ReadAsync(cancellationToken))
            {
                var room = MapRoomFromDataReader(rd);
                selectedRooms.Add(room);
            }

            return selectedRooms;
        }

        // Segédmetódus az adatkiolvasás tisztább kezeléséhez
        private static Room MapRoomFromDataReader(DbDataReader rd)
        {
            return new Room
            (
                Convert.ToInt32(rd["room_number"]),
                Enum.TryParse<Room.RoomType>(rd["room_type"]?.ToString(), true, out var roomType) ? roomType : default,
                Convert.ToInt32(rd["floorspace"]),
                Enum.TryParse<Room.BedType>(rd["bed_type"]?.ToString(), true, out var bedType) ? bedType : default,
                Convert.ToInt32(rd["has_balcony"]),
                Enum.TryParse<Room.HasView>(rd["has_view"]?.ToString(), true, out var hasView) ? hasView : default,
                Convert.ToInt32(rd["max_adults"]),
                rd["extras"] is DBNull or null ? string.Empty : rd["extras"].ToString()!,
                Enum.TryParse<Room.Status>(rd["status"]?.ToString(), true, out var status) ? status : default,
                Convert.ToInt32(rd["price_per_night"]),
                Convert.ToInt32(rd["door_locked"]),
                Convert.ToInt32(rd["needs_cleaning"]),
                Convert.ToInt32(rd["dont_disturb"]),
                Convert.ToInt32(rd["is_cleaning"]),
                Convert.ToInt32(rd["ac_temp"])
            );
        }

        // 2. Szobakártyák aszinkron feltöltése a felületre (UI freeze elkerülése)
        public async Task FillAvailableRoomsAsync(List<Room> rooms, FlowLayoutPanel flp, Action<RoomCardUserControl> onCardSelected)
        {
            flp.SuspendLayout();
            try
            {
                // Korábbi elemek törlése és felszabadítása
                foreach (Control control in flp.Controls)
                {
                    control.Dispose();
                }
                flp.Controls.Clear();

                foreach (var room in rooms)
                {
                    var roomCard = new RoomCardUserControl();
                    roomCard.LoadCardData(room);

                    roomCard.CardSelected += (sender, e) => onCardSelected(roomCard);

                    flp.Controls.Add(roomCard);

                    // Rövid várakozás a UI szál folyamatosságáért nagy adatmennyiségnél
                    await Task.Yield();
                }
            }
            finally
            {
                flp.ResumeLayout(true);
            }
        }

        #endregion

        #region UI Navigation

        public void NextButtonClick(TabControl tc, System.Windows.Forms.Button next, System.Windows.Forms.Button back, System.Windows.Forms.Button confirm)
        {
            if (tc.SelectedIndex < tc.TabCount - 1)
            {
                tc.SelectedIndex++;
            }

            UpdateButtonVisibility(tc, next, back, confirm);
        }

        public void BackButtonClick(TabControl tc, System.Windows.Forms.Button next, System.Windows.Forms.Button back, System.Windows.Forms.Button confirm)
        {
            if (tc.SelectedIndex > 0)
            {
                tc.SelectedIndex--;
            }

            UpdateButtonVisibility(tc, next, back, confirm);
        }

        private void UpdateButtonVisibility(TabControl tc, System.Windows.Forms.Button next, System.Windows.Forms.Button back, System.Windows.Forms.Button confirm)
        {
            int lastIndex = tc.TabCount - 1;
            back.Visible = tc.SelectedIndex > 0;
            next.Visible = tc.SelectedIndex < lastIndex;
            confirm.Visible = tc.SelectedIndex == lastIndex;
        }

        public void RefreshPageCount(TabControl tc, System.Windows.Forms.Label lb)
        {
            lb.Text = $"{tc.SelectedIndex + 1}/{tc.TabCount}";
        }

        #endregion

        #region Common

        // 3. Szolgáltatások dinamikus kezelése szótár (Dictionary) alapú gyárral
        private static readonly Dictionary<string, Func<int, Service>> ServiceRegistry = new()
        {
            ["Halfboard"] = _ => new Service(19, "Félpanzió", "Félpanziós ellátás reggelivel és vacsorával", ServiceTypeHu.Logisztika, 17000, "Half board", "Half-board service including breakfast and dinner.", ServiceTypeEn.Logistics),
            ["Fullboard"] = _ => new Service(20, "Teljes ellátás", "Teljes ellátás reggelivel, ebéddel és vacsorával.", ServiceTypeHu.Logisztika, 28000, "Full board", "Full-board service including breakfast, lunch and dinner.", ServiceTypeEn.Logistics),
            ["Transzfer"] = _ => new Service(3, "Transzfer", "Reptéri transzfer egy irányba", ServiceTypeHu.Logisztika, 10000, "Transfer", "Airport transfer one way", ServiceTypeEn.Logistics),
            ["Parkolás"] = days => new Service(2, "Parkolás", "Zárt parkoló napidíj", ServiceTypeHu.Logisztika, 3000 * days, "Parking", "Gated parking daily fee", ServiceTypeEn.Logistics),
            ["Pótágy"] = _ => new Service(9, "Pótágy", "Extra ágy biztosítása", ServiceTypeHu.Extrák, 7000, "Extra bed", "Provision of an extra bed", ServiceTypeEn.Extras),
            ["Kiságy"] = _ => new Service(10, "Kiságy", "Babaágy biztosítása", ServiceTypeHu.Extrák, 3000, "Baby cot", "Provision of a baby cot", ServiceTypeEn.Extras),
            ["Késői kijelentkezés"] = _ => new Service(22, "Késői kijelentkezés", "Fizetős szobahosszabbítás a távozás napján.", ServiceTypeHu.Logisztika, 20000, "Late check-out", "Paid room extension upon departure.", ServiceTypeEn.Logistics),
            ["Korai távozás"] = _ => new Service(23, "Korai távozás", "Tervezettnél korábbi elutazás a szállodából.", ServiceTypeHu.Logisztika, 30000, "Early departure", "Leaving the hotel before schedule.", ServiceTypeEn.Logistics),
            ["Pezsgő bekészítés"] = _ => new Service(21, "Pezsgő bekészítés", "A világ legikonikusabb champagne-ja...", ServiceTypeHu.Extrák, 37000, "Champagne", "The world's most iconic champagne...", ServiceTypeEn.Extras)
        };

        public void CreateNewService(string serviceName, List<Service> serviceList, int days = 1, Room? room = null)
        {
            if (serviceList == null) return;

            if (serviceName == "Szoba")
            {
                serviceList.RemoveAll(s => s.NameHu == "Szoba" || s.NameEn == "Room" || s.Id == 0);

                if (room != null)
                {
                    int calculatedDays = days > 0 ? days : 1;
                    var roomSvc = new Service(
                        0,
                        "Szoba",
                        "Szoba ára éjszakánként",
                        ServiceTypeHu.Logisztika,
                        room.Price * calculatedDays,
                        "Room",
                        "Price of room per night",
                        ServiceTypeEn.Logistics
                    );
                    serviceList.Add(roomSvc);
                }
                return;
            }

            if (ServiceRegistry.TryGetValue(serviceName, out var serviceFactory))
            {
                serviceList.Add(serviceFactory(days));
            }
        }

        // 4. Kérések összefűzése
        public void FillSumSpecialRequests(List<Service> services, System.Windows.Forms.Label lbSumExtras)
        {
            var extraServices = services.Where(s => s.NameHu != "Szoba").Select(s => s.NameHu).ToList();

            lbSumExtras.Text = extraServices.Count > 0
                ? string.Join(" | ", extraServices)
                : "No special requests";
        }

        // 5. Vendég fülek hozzáadása aszinkron módon
        public async Task AddGuestTabToSummaryAsync(Guest g, List<Guest> guests, TabControl tcGuests)
        {
            int index = guests.IndexOf(g);

            var guestTab = new GuestDataSumControl();
            var tp = new TabPage($"tpGuest{index}")
            {
                Text = $"Guest {index + 1}"
            };

            tp.Controls.Add(guestTab);
            guestTab.FillGuestTabData(g);

            tcGuests.TabPages.Add(tp);

            await Task.Yield();
        }

        // 6. Szobainformációs szöveg összeállítása
        public string BuildSelectedRoomDetailsString(Room? room)
        {
            if (room == null) return "No room selected";

            string hasBalcony = room.HasBalcony == 1 ? "Balcony" : "No Balcony";
            return $"{room.Room_number}  |  {room.RoomsRoomtype}  |  {room.RoomsBedType}  |  {hasBalcony}  |  {room.RoomsView}";
        }

        #endregion
    }
}