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
        ShopCartDto GetByIdShopCart(string id);
        IEnumerable<ShopCartDto> GetAllShopCarts();
        void UpdateShopCart(ProductDto product);
        void DeleteShopCart(string id);
    }
}
