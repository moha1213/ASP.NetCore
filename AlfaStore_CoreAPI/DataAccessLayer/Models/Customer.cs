using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models
{
    public class Customer : IModel
    {
        public string ContactID { get; set; }
        public string MTypeID { get; set; }
        public string TaxID { get; set; }
       
    }
}
