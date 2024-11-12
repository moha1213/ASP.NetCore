using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Models
{
    public class WarehouseItems : IModel
    {
        public string ItemID { get; set; }
        /// <summary>
        /// Display warehouse name concatenated with item quantity
        /// </summary>
        [NotMapped]
        public string DisplayName { get; set; }
        public string WarehouseID { get; set; }
        public bool IsDefaultWarehouse { get; set; }

        /// <summary>
        /// is set once on create the row
        /// </summary>
        public decimal OpenningBalance { get; set; }
        //change every transaction
        public decimal AvailableForSale { get; set; }

        /// <summary>
        /// change on sale or return to supplier only
        /// </summary>
        public decimal OutQnty { get; set; }
        /// <summary>
        /// change on purchase or return from customer only
        /// </summary>
        public decimal InQnty { get; set; }
        public decimal HoldQnty { get; set; }
       
    }
}