using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.entities
{
    public class OrderItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quqntity {  get; set; }
        public virtual Order Order { get; set; }
        public int OrderId { get; set; }

        public OrderItem()
        {           
        }

        public OrderItem(int id, string name, int quqntity, int orderId)
        {
            Id = id;
            Name = name;
            Quqntity = quqntity;
            OrderId = orderId;
        }
    }
}
