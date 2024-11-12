using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class Branch
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Manager { get; set; }
        public string Data { get; set; }

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
