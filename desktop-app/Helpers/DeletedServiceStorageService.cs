using Hotel_erp_Winforms_App.Models;
using System.Reflection;
using System.Text.Json;

namespace Hotel_erp_Winforms_App.Services
{
    internal class DeletedServiceStorageService
    {
        private readonly string _filePath;

        public DeletedServiceStorageService()
        {
            string appName = Assembly.GetExecutingAssembly().GetName().Name ?? "HotelElegance";

            string appDataFolder = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                appName
            );

            Directory.CreateDirectory(appDataFolder);
            _filePath = Path.Combine(appDataFolder, "deleted_services.json");
        }

        public async Task SaveDeletedServiceAsync(Service service)
        {
            var deletedServices = await LoadDeletedServicesAsync();
            deletedServices.Add(service);

            var options = new JsonSerializerOptions { WriteIndented = true };
            string json = JsonSerializer.Serialize(deletedServices, options);
            await File.WriteAllTextAsync(_filePath, json);
        }

        public async Task<List<Service>> LoadDeletedServicesAsync()
        {
            if (!File.Exists(_filePath))
            {
                return new List<Service>();
            }

            string json = await File.ReadAllTextAsync(_filePath);
            if (string.IsNullOrWhiteSpace(json))
            {
                return new List<Service>();
            }

            return JsonSerializer.Deserialize<List<Service>>(json) ?? new List<Service>();
        }

        public async Task ClearAllDeletedServicesAsync()
        {
            if (File.Exists(_filePath))
            {
                var emptyList = new List<Service>();
                var options = new JsonSerializerOptions { WriteIndented = true };
                string json = JsonSerializer.Serialize(emptyList, options);
                await File.WriteAllTextAsync(_filePath, json);
            }
        }
    }
}