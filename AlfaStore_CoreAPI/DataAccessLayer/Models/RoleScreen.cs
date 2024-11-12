using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Models
{
    public class RoleScreen : IModel
    {
        public string RoleID { get; set; }
        public virtual Role Role { get; set; }
        public virtual List<RoleScreenDetails> Screens { get; set; }

       
    }
}
