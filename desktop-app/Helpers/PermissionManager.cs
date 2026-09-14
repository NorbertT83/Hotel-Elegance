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
            /* BOOKINGS */{ "btnBookings", new List<UserRole> { UserRole.Admin, UserRole.Manager, UserRole.Receptionist, UserRole.FrontOffMan } },
            /* GUESTS */{ "btnGuests", new List<UserRole> { UserRole.Admin, UserRole.Manager, UserRole.Receptionist, UserRole.FrontOffMan } },
            /* HOUSEKEEPING */{ "btnHousekeeping", new List<UserRole> { UserRole.Admin, UserRole.Manager, UserRole.HKManager, UserRole.Receptionist, UserRole.FrontOffMan } },
            /* SERVICES */{ "btnServices", new List<UserRole> { UserRole.Admin, UserRole.Manager, UserRole.HKManager, UserRole.Receptionist, UserRole.FrontOffMan } },
            /* ROOMS */{ "btnRooms", new List<UserRole> { UserRole.Admin, UserRole.Manager, UserRole.Receptionist, UserRole.FrontOffMan } },
            /* EMPLOYEES */{ "btnEmployees", new List<UserRole> { UserRole.Admin, UserRole.Manager} },
        };

        // ENABLED = FALSE / USER ROLE
        private static readonly Dictionary<string, List<UserRole>> Disables = new Dictionary<string, List<UserRole>>
        {
            { "pnlEditor", new List<UserRole> { UserRole.Receptionist, UserRole.HKManager, UserRole.Guest, UserRole.FrontOffMan } },
            { "btnMarkAllClean", new List<UserRole> { UserRole.Receptionist, UserRole.HKManager, UserRole.Guest, UserRole.FrontOffMan } },
            { "btnNewService", new List<UserRole> { UserRole.Receptionist, UserRole.HKManager, UserRole.Guest, UserRole.FrontOffMan } },
            { "btnUpdateService", new List<UserRole> { UserRole.Receptionist, UserRole.HKManager, UserRole.Guest, UserRole.FrontOffMan } },
            { "btnDeleteService", new List<UserRole> { UserRole.Receptionist, UserRole.HKManager, UserRole.Guest, UserRole.FrontOffMan } }
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
