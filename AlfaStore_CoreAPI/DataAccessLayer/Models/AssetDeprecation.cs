using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Models
{
    public class AssetDeprecation : IModel
    {
        public string CostCentreID { get; set; }
        public virtual CostCentre CostCentre { get; set; }
        public string AssetID { get; set; }
        public virtual Asset Asset { get; set; }
        public virtual ICollection<AssetDeprecationDetails> Deprecations { get; set; } = new List<AssetDeprecationDetails>();

        public decimal TotalDeprecatedAmount { get; set; }

        public bool IsFullyDerecated { get; set; }
    }
}
