using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models
{
    public class Tax : IModel
    {
        public string MTypeID { get; set; }
        public decimal TaxPercentageOne { get; set; }
        public decimal TaxPercentageTwo { get; set; }
        public decimal TaxPercentageThree { get; set; }
        public int TaxType { get; set; }

   
    }
}
