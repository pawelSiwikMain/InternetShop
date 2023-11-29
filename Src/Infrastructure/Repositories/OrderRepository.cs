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
    public class OrderRepository : IOrderRepository
    {
        ShopContext _shopContext;

        public OrderRepository(ShopContext shopContext)
        {
            _shopContext = shopContext;
        }

        public Order Add(Order order)
        {
            _shopContext.Orders.Add(order);
            _shopContext.SaveChanges();
            return order;
        }

        public void Delete(Order order)
        {
            _shopContext.Orders.Remove(order);
            _shopContext.SaveChanges();
        }

        public Order Get(int id)
        {
            return _shopContext.Orders.SingleOrDefault(x => x.Id == id);
        }

        public IEnumerable<Order> GetAll()
        {
            return _shopContext.Orders;
        }

        public void Update(Order order)
        {
            _shopContext.Orders.Update(order);
            _shopContext.SaveChanges();
        }
    }
}
