using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;

namespace DataAccessLayer.Models
{
    public class StoreTransaction : IModel
    {
        [NotMapped]
        public string DisplayedName { get; set; }
        public string CustomerID { get; set; }
        public string SupplierID { get; set; }
        public string ReturnID { get; set; }
        public virtual List<StoreTransactionDetails> Items { get; set; }

        public string PriceListID { get; set; }
        public string TaxID { get; set; }
        public string PaymentID { get; set; }
        public virtual Payment Payment { get; set; }
        /// <summary>
        /// Discount amount on invoice
        /// </summary>
        public decimal DiscountAmount { get; set; }
        /// <summary>
        /// Sales = 1, Purchase = 2, ReturnFromCustomer = 3, ReturnToSupplier = 4
        /// </summary>
        public int InvoiceType { get; set; }

        public int RowsCount { get; set; }
        public decimal QuantityCount { get; set; }
        public bool IsOpened { get; set; }


    }

}
