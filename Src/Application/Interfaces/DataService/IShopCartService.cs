using Application.Dtos.ShopCartDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.DataService
{
    public interface IShopCartService
    {
        ShopCartDto AddShopCart(CreateShopCartDto shopCart);
        ShopCartDto GetByIdShopCart(int id);
        IEnumerable<ShopCartDto> GetAllShopCarts();
        void UpdateShopCart(UpdateShopCartDto product);
        void DeleteShopCart(int id);
    }
}
