using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class SearchModel : IModel
    {
        public string NameEn { get; set; }
        public string NameAr { get; set; }
        public bool ShowInSearch { get; set; }
        public bool ShowInReport { get; set; }

       
    }
}
