using DataAccessLayer;
using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models
{
    public class UserRoleScreenDefaults : IModel
    {
        public string UserRoleID { get; set; }
        public virtual UserRole UserRole { get; set; }
        public string ScreenDefaultsID { get; set; }
        public virtual ScreenDefaults ScreenDefaults { get; set; }
       
      
    }
}