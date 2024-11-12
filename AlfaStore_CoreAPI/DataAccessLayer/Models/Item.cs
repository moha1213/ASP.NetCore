using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace DataAccessLayer.Models
{
    public class Item : IModel
    {       
        public bool IsTemplate { get; set; }
        public string TemplateID { get; set; }
        public string Barcode { get; set; }
        public decimal Quantity { get; set; }
        public decimal UnitBuyPrice { get; set; }
        public decimal UnitSalePrice { get; set; }
        public string SupplierID { get; set; }

        /// <summary>
        /// Default warehouse
        /// </summary>
        public string WarehouseID { get; set; }

       
    }
}
