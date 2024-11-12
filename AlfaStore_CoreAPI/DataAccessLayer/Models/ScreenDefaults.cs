using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Models
{
    public class ScreenDefaults : IModel
    {
        public string RoleScreenID { get; set; }
        public string RoleScreenDetailID { get; set; }

        public string CostCenterID { get; set; }
        public bool CC_IsDisabled { get; set; }
        public string CC_Visibility { get; set; } = "Visible";

        public string CustomerID { get; set; }
        public bool Cust_IsDisabled { get; set; }
        public string Cust_Visibility { get; set; } = "Visible";

        public string SupplierID { get; set; }
        public bool Supp_IsDisabled { get; set; }
        public string Supp_Visibility { get; set; } = "Visible";

        public string TaxID { get; set; }
        public bool TX_IsDisabled { get; set; }
        public string TX_Visibility { get; set; } = "Visible";

        public int? EntryStatusID { get; set; }
        public bool ES_IsDisabled { get; set; }
        public string ES_Visibility { get; set; } = "Visible";

        public bool InvIsOpen { get; set; }
        public bool InvIsOpen_IsDisabled { get; set; }
        public string InvIsOpen_Visibility { get; set; } = "Visible";

       
    }
}