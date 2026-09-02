using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace Hotel_erp_Winforms_App.Services
{
    public static class DbConfig
    {
        public static string ConnectionString { get; }

        static DbConfig()
        {
            try
            {
                var config = new ConfigurationBuilder()
                    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                    .Build();

                ConnectionString = config.GetConnectionString("DefaultConnection")
                    ?? "Server=localhost;Database=hotelelegancedb;uid=root;pwd=;";
            }
            catch
            {
                ConnectionString = "Server=localhost;Database=hotelelegancedb;uid=root;pwd=;";
            }
        }
    }
}