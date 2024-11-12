using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Models
{
    public class UserProfile : IModel
    {
        public string Email { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
        public string TokenId { get; set; }
        public bool EmailVerified { get; set; }
        public Contact? ContactDetails { get; set; }
        public Guid? ContactId { get; set; }
    }
}
