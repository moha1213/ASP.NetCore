using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models
{
    /// <summary>
    /// not used for now 
    /// </summary>
    public class ItemPrice : IModel
    {
        public string ItemID { get; set; }
        public string PriceListID { get; set; }

    }
}
