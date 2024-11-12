using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class ErrorModel
    {
        public string name { get; set; }
        public string Action { get; set; }
        public string Message { get; set; }
    }
}
