using System;
using System.Collections.Generic;
using System.Reflection.Metadata;

namespace DataAccessLayer.Models
{
    public class City : IModel
    {
        public Country? Country { get; set; }// Optional reference navigation to principal
        public Guid? CountryId { get; set; }// Optional foreign key property

        public ICollection<District> Districts { get; } = new List<District>(); // Collection navigation containing dependents

    }

}