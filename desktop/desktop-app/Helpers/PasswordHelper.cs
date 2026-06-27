using System;
using System.Collections.Generic;
using System.Text;
using BCrypt.Net;

namespace Hotel_erp_Winforms_App.Security
{
    public static class PasswordHelper
    {
        public static string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.EnhancedHashPassword(password, workFactor: 12);
        }

        public static bool VerifyPassword(string password, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.EnhancedVerify(password, hashedPassword);
        }
    }
}
