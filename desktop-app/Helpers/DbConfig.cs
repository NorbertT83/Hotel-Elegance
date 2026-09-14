using Microsoft.Extensions.Configuration;

namespace Hotel_erp_Winforms_App
{
    public static class DbConfig
    {
        public static string ConnectionString
        {
            get
            {
                try
                {
                    var config = new ConfigurationBuilder()
                        .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                        .Build();

                    return config.GetConnectionString("DefaultConnection")
                        ?? "Server=localhost;Database=hotelelegancedb;Uid=root;Pwd=;";
                }
                catch
                {
                    return "Server=localhost;Database=hotelelegancedb;Uid=root;Pwd=;";
                }
            }
        }
    }
}