namespace Hotel_erp_Winforms_App.Helpers
{
    public static class CurrentUser
    {
        public static int Id { get; set; }
        public static string Name { get; set; } = string.Empty;
        public static string Email { get; set; } = string.Empty;
        public static UserRole Role { get; set; }

        public static void Clear()
        {
            Id = 0;
            Name = string.Empty;
            Email = string.Empty;
            Role = UserRole.Guest;
        }
    }
}