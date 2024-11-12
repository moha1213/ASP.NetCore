using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models
{
    public class Address : IModel
    {       
        public District? District { get; set; }
        public Guid? DistrictId { get; set; }
        public string StreetName { get; set; }
        public string BuildingNo { get; set; }
        public string FloorNumber { get; set; }

        public ICollection<Contact> Contacts { get; } = new List<Contact>(); // Collection navigation containing dependents
    }
}