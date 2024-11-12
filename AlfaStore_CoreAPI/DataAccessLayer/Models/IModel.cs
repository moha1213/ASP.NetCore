using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace DataAccessLayer
{
    public abstract class IModel
    {       
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int BranchID { get; set; }
        public bool IsDeleted { get; set; } = false;

        #region metaData
        public DateTime? Created { get; set; }
        public string Created_by { get; set; }
        public DateTime? Modified { get; set; }
        public string Modified_by { get; set; }
        /// <summary>
        /// Appear to developer only
        /// </summary>
        public string DevMessage { get; set; }
        /// <summary>
        /// Appear to User
        /// </summary>
        public string UsrMessage { get; set; }
        #endregion

    }
}
