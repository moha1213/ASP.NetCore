using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Models
{
    /// <summary>
    /// not used for now 
    /// </summary>
    public class CostCentre : IModel
    {
        /// <summary>
        /// 0-> MainCostCenter(has credit and depit childs), 1-> Credit , 2-> Depit
        /// </summary>
        public int CostCenterType { get; set; }
        public string ParentId { get; set; }
        [NotMapped]
        public string ParentTree { get; set; }

    }
}
