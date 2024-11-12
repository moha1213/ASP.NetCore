using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Models
{
    public class AssetDeprecationDetails : IModel
    {
        public virtual AssetDeprecation AssetDeprecation { get; set; }
        public string AssetDeprecationID { get; set; }
        public decimal DueAmount { get; set; }
        public decimal PaidAmount { get; set; }
        /// <summary>
        /// The defrence between due amoun and paid amound (DueAmount - PaidAmount)
        /// </summary>
        public decimal RemainingAmount { get; set; }
        public DateTime DueDate { get; set; }

        /// <summary>
        /// Auto calculate the installment if the due date is exceeded(it mean copy the dueAmount to PaidAmount)
        /// set dueAmount to PaidAmount 
        /// </summary>
        public bool AutoCalc { get; set; }

        public bool IsPaid { get; set; }
    }
}
