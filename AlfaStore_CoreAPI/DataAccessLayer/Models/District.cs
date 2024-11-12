using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace DataAccessLayer.Models
{
    public class District : IModel
    {
        public City? City { get; set; }
        public Guid? CityId { get; set; }

        public ICollection<Address> Addresses { get; } = new List<Address>(); // Collection navigation containing dependents
    }
}