using Domain.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.interfaces
{
    public interface IOrderItemRepository
    {
        IEnumerable<OrderItem> GetAllForOrder(int id);
        OrderItem GetById(int id);
        OrderItem Add(OrderItem item);
        void Update(OrderItem item);
        void Delete(OrderItem item);
    }
}
