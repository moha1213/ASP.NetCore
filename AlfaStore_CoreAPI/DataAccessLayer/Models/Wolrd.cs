using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models
{
    public class World : IModel
    {
        public virtual Country Country { get; set; }
        public string CountryID { get; set; }
       
    }
}