namespace Hotel_erp_Winforms_App.Helpers
{
    public static class CurrentUser
    {
        public static int Id { get; set; }
        public static string Username { get; set; } = string.Empty;
        public static UserRole Role { get; set; }

        public static void Clear()
        {
            Id = 0;
            Username = string.Empty;
            Role = UserRole.Admin;
        }
    }
}