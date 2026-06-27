using Hotel_erp_Winforms_App.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel_erp_Winforms_App.Helpers
{
    public static class SessionManager
    {
        public static Employee? CurrentUser { get; set; }
    }
}
