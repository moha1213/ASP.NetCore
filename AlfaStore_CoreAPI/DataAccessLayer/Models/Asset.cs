using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class Asset : IModel
    {
      
        public string PaymentID { get; set; }
        public virtual Payment Payment { get; set; } 
        
    }
}
