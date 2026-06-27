using Hotel_erp_Winforms_App.Forms;
using Hotel_erp_Winforms_App.Models;
using Hotel_erp_Winforms_App.UI.Forms;

namespace Hotel_erp_Winforms_App
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            Employee employee = new Employee(
                1, "Dávid", "Csaba", "8505695667", 13, "a címem", new DateTime(2026, 5, 21),
                new DateTime(2026, 5, 21), "Manager", 130000, "", "", new DateTime(2026, 5, 21), new DateTime(2026, 5, 21)
            );

            Application.Run(new FrmLogin());
        }
    }
}
