using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.entities
{
    public class Address
    {
        public string Id { get; set; }
        public virtual User User { get; set; }
        public string UserId { get; set; }
        public string PostCode { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string LocalNumber { get; set; }



        public Address()
        {
        }

        public Address(string id, string userId, string postCode, string city, string street, string localNumber)
        {
            Id = id;
            UserId = userId;
            PostCode = postCode;
            City = city;
            Street = street;
            LocalNumber = localNumber;
        }
    }
}
