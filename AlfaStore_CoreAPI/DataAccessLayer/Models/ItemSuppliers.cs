using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models
{
    /// <summary>
    /// not used for now 
    /// </summary>
    public class ItemSuppliers : IModel
    {
        public string ItemID { get; set; }
        public string SupplierID { get; set; }
        public bool IsDefaultSupplier { get; set; }

       
    }
}
