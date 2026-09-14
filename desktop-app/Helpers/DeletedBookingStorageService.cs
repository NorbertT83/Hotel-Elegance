using Hotel_erp_Winforms_App.Models;
using System.Reflection;
using System.Text.Json;

namespace Hotel_erp_Winforms_App.Services
{
    internal class DeletedBookingStorageService
    {
        private readonly string _filePath;

        public DeletedBookingStorageService()
        {
            string appName = Assembly.GetExecutingAssembly().GetName().Name ?? "HotelElegance";

            string appDataFolder = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                appName
            );

            Directory.CreateDirectory(appDataFolder);
            _filePath = Path.Combine(appDataFolder, "deleted_bookings.json");
        }

        public async Task SaveDeletedBookingAsync(Booking booking)
        {
            var deletedBookings = await LoadDeletedBookingsAsync();
            deletedBookings.Add(booking);

            var options = new JsonSerializerOptions { WriteIndented = true };
            string json = JsonSerializer.Serialize(deletedBookings, options);
            await File.WriteAllTextAsync(_filePath, json);
        }

        public async Task<List<Booking>> LoadDeletedBookingsAsync()
        {
            if (!File.Exists(_filePath))
            {
                return new List<Booking>();
            }

            string json = await File.ReadAllTextAsync(_filePath);
            if (string.IsNullOrWhiteSpace(json))
            {
                return new List<Booking>();
            }

            return JsonSerializer.Deserialize<List<Booking>>(json) ?? new List<Booking>();
        }

        public async Task ClearAllDeletedBookingsAsync()
        {
            if (File.Exists(_filePath))
            {
                var emptyList = new List<Booking>();
                var options = new JsonSerializerOptions { WriteIndented = true };
                string json = JsonSerializer.Serialize(emptyList, options);
                await File.WriteAllTextAsync(_filePath, json);
            }
        }
    }
}
