using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Models
{
    public class Company
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Owner { get; set; }
        public string Data { get; set; }
        public bool IsTrialVersion { get; set; }
        public bool IsValidLicense { get; set; }
        public DateTime? LicenseStart { get; set; }
        public DateTime? LicenseEnd { get; set; }
       
    }
}
