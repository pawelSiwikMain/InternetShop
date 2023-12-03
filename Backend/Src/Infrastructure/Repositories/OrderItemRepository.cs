using Domain.entities;
using Domain.interfaces;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class OrderItemRepository : IOrderItemRepository
    {
        private readonly ShopContext _shopContext;

        public OrderItemRepository(ShopContext shopContext)
        {
            _shopContext = shopContext;
        }

        public OrderItem Add(OrderItem item)
        {
            _shopContext.OrderItems.Add(item);
            _shopContext.SaveChanges();
            return item;
        }

        public void Delete(OrderItem item)
        {
            _shopContext.OrderItems.Remove(item);
            _shopContext.SaveChanges();
        }

        public IEnumerable<OrderItem> GetAllForOrder(int id)
        {
            return _shopContext.OrderItems.Where(x => x.OrderId == id).ToList();
        }

        public OrderItem GetById(int id)
        {
            return _shopContext.OrderItems.SingleOrDefault(x => x.Id == id);
        }

        public void Update(OrderItem item)
        {
            _shopContext.OrderItems.Update(item);
            _shopContext.SaveChanges();
        }
    }
}
