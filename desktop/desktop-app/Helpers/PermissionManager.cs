namespace Hotel_erp_Winforms_App.Helpers
{
    public enum UserRole
    {
        HKManager,
        Receptionist,
        Admin,
        FrontOffMan,
        Manager,
        Guest
    }

    public static class PermissionManager
    {
        // MENÜ GOMBOK
        private static readonly Dictionary<string, List<UserRole>> Rules = new Dictionary<string, List<UserRole>>
        {
            { "btnBookings", new List<UserRole> { UserRole.Admin, UserRole.Manager, UserRole.Receptionist, UserRole.FrontOffMan } },
            { "btnGuests", new List<UserRole> { UserRole.Admin, UserRole.Manager, UserRole.Receptionist, UserRole.FrontOffMan } },
            { "btnHousekeeping", new List<UserRole> { UserRole.Admin, UserRole.Manager, UserRole.HKManager, UserRole.Receptionist, UserRole.FrontOffMan } },
            { "btnServices", new List<UserRole> { UserRole.Admin, UserRole.Manager, UserRole.HKManager, UserRole.Receptionist, UserRole.FrontOffMan } },
            { "btnBilling", new List<UserRole> { UserRole.Admin, UserRole.Manager, UserRole.Receptionist, UserRole.FrontOffMan } },
            { "btnRooms", new List<UserRole> { UserRole.Admin, UserRole.Manager, UserRole.Receptionist, UserRole.FrontOffMan } },
            { "btnEmployees", new List<UserRole> { UserRole.Admin, UserRole.Manager, } },
            { "btnStatistics", new List<UserRole> { UserRole.Admin, UserRole.Manager } },
            { "btnSettings", new List<UserRole> { UserRole.Admin, UserRole.Manager, UserRole.HKManager, UserRole.Receptionist, UserRole.FrontOffMan } }
        };

        // ENABLED = FALSE / USER ROLE
        private static readonly Dictionary<string, List<UserRole>> Disables = new Dictionary<string, List<UserRole>>
        {
            { "pnlEditor", new List<UserRole> { UserRole.Receptionist } },
            { "btnMarkAllClean", new List<UserRole> { UserRole.Receptionist } },
            { "btnNewService", new List<UserRole> { UserRole.Receptionist } },
            { "btnUpdateService", new List<UserRole> { UserRole.Receptionist } },
            { "btnDeleteService", new List<UserRole> { UserRole.Receptionist } }
        };

        public static void ApplyPermissions(Control parent)
        {
            foreach(Control control in parent.Controls)
            {
                if(Rules.ContainsKey(control.Name))
                {
                    control.Visible = Rules[control.Name].Contains(CurrentUser.Role);
                }

                if (Disables.ContainsKey(control.Name))
                {
                    control.Enabled = !Disables[control.Name].Contains(CurrentUser.Role);
                }

                if (control.HasChildren)
                {
                    ApplyPermissions(control);
                }
            }
        }
    }
}
