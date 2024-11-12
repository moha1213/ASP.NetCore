using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models
{
    public class Country : IModel
    {
        public ICollection<City> Cities { get; } = new List<City>(); // Collection navigation containing dependents
    }
}