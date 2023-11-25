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
    internal class ShopCartRepository : IShopCartRepository
    {
        private readonly ShopContext _context;

        public ShopCartRepository(ShopContext context)
        {
            this._context = context;
        }

        public ShopCart Add(ShopCart shopCart)
        {
            _context.ShopCarts.Add(shopCart);
            _context.SaveChanges();
            return shopCart;
        }

        public void Delete(ShopCart shopCart)
        {
            _context.ShopCarts.Remove(shopCart);
            _context.SaveChanges();
        }

        public ShopCart Get(int id)
        {
            return _context.ShopCarts.SingleOrDefault(s => s.Id == id);
        }

        public IEnumerable<ShopCart> GetAll()
        {
            return _context.ShopCarts;
        }

        public void Update(ShopCart shopCart)
        {
            _context.ShopCarts.Update(shopCart);
            _context.SaveChanges();
        }
    }
}
