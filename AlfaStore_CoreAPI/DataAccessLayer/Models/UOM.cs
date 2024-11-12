using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class UOM : IModel
    {
        public decimal Rate { get; set; }
        public string SaleUomId { get; set; }

       
    }
}
