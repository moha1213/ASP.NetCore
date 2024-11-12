using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Models
{
    public class StoreTransfereDetails : IModel
    {
        public virtual StoreTransfere StoreTransaction { get; set; }
        public string StoreTransfereID { get; set; }

        public string ItemID { get; set; }
        public decimal Quantity { get; set; }

        [NotMapped]
        public decimal AvailForSale { get; set; }



    }


}
