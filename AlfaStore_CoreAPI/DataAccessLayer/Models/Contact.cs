using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models
{
    public class Contact : IModel
    {
        public Address? Address { get; set; }
        public Guid? AddressId { get; set; }
        public Phone? Phone { get; set; }
        public string EmailAddress { get; set; }
        public string EmailAddressTwo { get; set; }
        public string EmailAddressThree { get; set; }
        public string FaceBookAccountLink { get; set; }

    }
}