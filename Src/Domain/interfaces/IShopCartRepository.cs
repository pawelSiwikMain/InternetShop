using Domain.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.interfaces
{
    public interface IShopCartRepository
    {
        IEnumerable<ShopCart> GetAll();
        ShopCart Get(int id);
        ShopCart Add(ShopCart shopCart);
        void Update(ShopCart shopCart);
        void Delete(ShopCart shopCart);
    }
}
