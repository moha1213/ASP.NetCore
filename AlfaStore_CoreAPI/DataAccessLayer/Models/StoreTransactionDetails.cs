using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Models
{
    public class StoreTransactionDetails : IModel
    {
        public virtual StoreTransaction StoreTransaction { get; set; }
        public string StoreTransactionID { get; set; }
        public string Template { get; set; }
        public decimal UnitSalePrice { get; set; }
     
        public decimal UnitBuyPrice { get; set; }      
       
        public decimal Quantity { get; set; }

        /// <summary>
        /// We use it to keep the return quantity limit, to prevent the user to return a quantity more than saled quantity
        /// </summary>
        [NotMapped]
        public decimal Orignal_Quantity { get; set; }

        public string WarehouseID { get; set; }
        public string ItemID { get; set; }
        public string SupplierID { get; set; }

        public decimal DiscountPercentage { get; set; }       

        public decimal DiscountAmount { get; set; }

        /// <summary>
        /// read only for user
        /// </summary>
        public decimal TotalAmount { get; set; }

        /// <summary>
        /// read only for user
        /// </summary>
        public decimal TotalAmountAfterDiscont { get; set; }

        [NotMapped]
        public List<WarehouseItems> ItemWarehouses_List { get; set; }
       
        private WarehouseItems defaultSelectedWarehouse;
        [NotMapped]
        public WarehouseItems DefaultSelectedWarehouse {
            get => defaultSelectedWarehouse;
            set {
                defaultSelectedWarehouse = value;
                if (value != null)
                    WarehouseID = ((WarehouseItems)value).WarehouseID;
            } 
        }
        [NotMapped]
        public List<ItemSuppliers> ItemSuppliers_List { get; set; }
        private ItemSuppliers defaultSelectedSupplier;
        [NotMapped]
        public ItemSuppliers DefaultSelectedSupplier { get => defaultSelectedSupplier; set
            {
                defaultSelectedSupplier = value;
                if (value != null)
                    SupplierID = ((ItemSuppliers)value).SupplierID;
            } }



    }


}
