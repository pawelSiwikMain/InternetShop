using Application.Dtos.ShopCartDtos;
using Application.Interfaces.DataService;
using AutoMapper;
using Domain.entities;
using Domain.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.DataService
{
    public class ShopCartService : IShopCartService
    {
        private readonly IShopCartRepository _shopCartRepository;
        private readonly IMapper _mapper;

        public ShopCartService(IShopCartRepository shopCartRepository, IMapper mapper)
        {
            _shopCartRepository = shopCartRepository;
            _mapper = mapper;
        }

        public ShopCartDto AddShopCart(CreateShopCartDto shopCart)
        {
            var newShopCart = _mapper.Map<ShopCart>(shopCart);
            _shopCartRepository.Add(newShopCart);
            return _mapper.Map<ShopCartDto>(newShopCart);
        }

        public void DeleteShopCart(string id)
        {
            var shopCart = _shopCartRepository.Get(id);
            _shopCartRepository.Delete(shopCart);
        }

        public IEnumerable<ShopCartDto> GetAllShopCarts()
        {
            var shopCarts = _shopCartRepository.GetAll();
            return _mapper.Map<IEnumerable<ShopCartDto>>(shopCarts);
        }

        public ShopCartDto GetByIdShopCart(string id)
        {
            var shopCart = _shopCartRepository.Get(id);
            return _mapper.Map<ShopCartDto>(shopCart);
        }

        public void UpdateShopCart(UpdateShopCartDto product)
        {
            var existingProduct = _shopCartRepository.Get(product.Id);
            var newProduct = _mapper.Map(product, existingProduct);
            _shopCartRepository.Update(newProduct);
        }
    }
}
