using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models
{
    public class UserRole : IModel
    {
        public string RoleID { get; set; }
        public string UserProfileID { get; set; }

    }
}
