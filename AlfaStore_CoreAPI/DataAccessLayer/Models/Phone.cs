using System;
using System.Collections.Generic;
using System.Reflection.Metadata;

namespace DataAccessLayer.Models
{
    public class Phone : IModel
    {
        public Guid? ContactId { get; set; } // Optional foreign key property
        public Contact? Contact { get; set; } // Optional reference navigation to pri
        public string MobileOne { get; set; }
        public string MobileTwo { get; set; }
        public string MobileThree { get; set; }
        public string MobileFour { get; set; }
        public string LandLineOne { get; set; }
        public string LandLineTwo { get; set; }
        public string LandLineThree { get; set; }
 
    }
}