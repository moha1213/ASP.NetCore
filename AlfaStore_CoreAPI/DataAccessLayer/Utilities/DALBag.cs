using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Utilities
{
    public class DALBag
    {
        public static readonly string AdminKeyword = "AdminMG_89";
        public static bool IsInistantiatNewCompany = false;
        public static RoleScreen roleScreens { get; set; }

        public static UserProfile CurrentUser { get; set; }
        public static Role Role { get; set; }
        public static UserRole UserRole { get; set; }
        public static List<Screen> UserScreens { get; set; }

        public static Company Company { get; set; }
        public static Branch Branch { get; set; }
    }
}
