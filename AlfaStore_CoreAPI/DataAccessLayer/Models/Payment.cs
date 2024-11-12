using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Models
{
    public class Payment : IModel
    {
        /// <summary>
        /// the transaction who created the payment entry, it will be useful in reports
        /// </summary>
        public string RefrenceID { get; set; }

        public CostCentre? CostCentre { get; set; }
        public List<PaymentSchedule> Schedules { get; set; }

        /// <summary>
        /// Total amount include discount and tax, Calculated once
        /// </summary>
        public decimal GrandTotalAmount { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal TaxAmount { get; set; }

        /// <summary>
        /// Amount after tax and discount
        /// </summary>
        public decimal DueAmount { get; set; }

        /// <summary>
        /// the summition of all return invoices on main invoice, calculate only on payment controller
        /// </summary>
        public decimal ReturnedAmount { get; set; }

        /// <summary>
        /// Paid amount on invoice 
        /// </summary>
        public decimal InvoicePaid { get; set; }

        /// <summary>
        /// it filled from scedualing screen only
        /// </summary>
        public decimal ScedualePaid { get; set; }

        /// <summary>
        /// This contains the one pay entry, or advanced pay entry
        /// </summary>
        public decimal AdvancedPaid { get; set; }

        /// <summary>
        /// All Payments, The sum of (InvoicePaid, ScedualePaid, AdvancedPaid, - ReturnAmount)
        /// </summary>
        public decimal TotalPaid { get; set; }

        /// <summary>
        /// DueAmount - TotalPaid
        /// </summary>
        public decimal RemainingAmount { get; set; }
        public bool IsAsset { get; set; }

    }
}
