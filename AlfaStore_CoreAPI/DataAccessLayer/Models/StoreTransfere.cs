using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;

namespace DataAccessLayer.Models
{
    public class StoreTransfere : IModel
    {
        public virtual List<StoreTransfereDetails> Items { get; set; }
        public string WarehouseFromID { get; set; }
        public string WarehouseToID { get; set; }

        public int RowsCount { get; set; }
        public decimal QuantityCount { get; set; }

       
    }
}
