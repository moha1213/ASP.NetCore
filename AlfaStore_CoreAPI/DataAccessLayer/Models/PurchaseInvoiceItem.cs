using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models
{
    public class PurchaseInvoiceItem: IModel
    {
        public virtual Item Item { get; set; }
        public string ItemID { get; set; }

        public decimal ItemQnty { get; set; }
        public string PriceListID { get; set; }
        public decimal ItemDiscountPercentage { get; set; }
        public decimal ItemDiscountAmount { get; set; }
        public decimal ItemTotalPricBeforeDiscount { get; set; }
        public decimal ItemTotalPriceAfterDiscount { get; set; }


    }
}
