using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.entities
{
    public class Order
    {
        public int Id { get; set; }
        public virtual User User { get; set; }
        public int UserId { get; set; }
        public virtual Address Address { get; set; }
        public int AddressId { get; set; }
        public virtual List<OrderItem> OrderItems { get; set;}
        public Order()
        {         
        }

        public Order(int id, int userId, int addressId)
        {
            Id = id;            
            UserId = userId;            
            AddressId = addressId;          
        }
    }
}
