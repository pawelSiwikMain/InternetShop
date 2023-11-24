using Application.Dtos.Product;
using Application.Dtos.ShopCart;
using Application.Interfaces.DataService;
using Domain.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.DataService
{
    public class ShopCarService : IShopCartService
    {
        private readonly IShopCartRepository _shopCartRepository;

        public ShopCarService(IShopCartRepository shopCartRepository)
        {
            _shopCartRepository = shopCartRepository;
        }

        public ShopCartDto AddShopCart(CreateShopCartDto shopCart)
        {
            throw new NotImplementedException();
        }

        public void DeleteShopCart(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ShopCartDto> GetAllShopCarts()
        {
            throw new NotImplementedException();
        }

        public ShopCartDto GetByIdShopCart(string id)
        {
            throw new NotImplementedException();
        }

        public void UpdateShopCart(ProductDto product)
        {
            throw new NotImplementedException();
        }
    }
}
