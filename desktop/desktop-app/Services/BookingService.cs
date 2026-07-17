using Google.Protobuf.WellKnownTypes;
using Hotel_erp_Winforms_App.Models;
using Hotel_erp_Winforms_App.Models;
using Hotel_erp_Winforms_App.UI.Controls.RoomCardControl;
using Hotel_erp_Winforms_App.UI.Forms.ServiceForms;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.BC;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Metrics;
using System.Reflection.Emit;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Xml.Linq;
using static Hotel_erp_Winforms_App.Models.Room;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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

                        Hotel_erp_Winforms_App.Models.RoomType roomTypeEnum = System.Enum.Parse<Hotel_erp_Winforms_App.Models.RoomType>(Convert.ToString(reader["room_type"]) ?? "", true);
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

        public Guest? FillPersonalData(Booking selectedBooking)
        {
            string query = "SELECT fname, lname, email, date_of_birth, country, zip_code, city, street, id_card_number, car_plate_number, total_nights, loyalty_level " +
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

        public List<BillingItem> MakeListOfBills(List<Service> servicesList, Booking selectedBooking)
        {
            List<BillingItem> billingItems = new List<BillingItem>();

            // SZOLGÁLTATÁS ÁRAK KISZÁMÍTÁSA
            foreach(Service service in servicesList)
            {
                decimal netPrice = service.Price / 1.27m;

                if (service.NameHu == "Parkolás")
                {
                    int days = (selectedBooking.EndOfStay - selectedBooking.BeginningOfStay).Days;

                    BillingItem parking = new BillingItem
                    (
                        DateTime.Now,
                        service.NameHu,
                        netPrice,
                        days,
                        0.27m,
                        service.Price
                    );
                    billingItems.Add(parking);
                }

                else
                {
                    BillingItem item = new BillingItem
                    (
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
            string getRoomQuery = "SELECT rooms.price_per_night, bookings.beginning_of_stay, bookings.end_of_stay, bookings.created_at " +
                                "FROM bookings " +
                                "INNER JOIN rooms ON bookings.room_number = rooms.room_number " +
                                "WHERE bookings.id = @bookingId;";

            using(MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(getRoomQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@bookingId", selectedBooking.Id);

                    using(MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DateTime end = Convert.ToDateTime(reader["end_of_stay"]);
                            DateTime beginning = Convert.ToDateTime(reader["beginning_of_stay"]);
                            int nights = Convert.ToInt32((end - beginning).Days);

                            decimal pricePerNight = Convert.ToDecimal(reader["price_per_night"]);
                            decimal netPricePerNight = Convert.ToDecimal(pricePerNight / 1.05m);
                            decimal grossPrice = pricePerNight * nights;

                            BillingItem roomItem = new BillingItem
                            (
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
            return billingItems;
        }

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
    }
}
