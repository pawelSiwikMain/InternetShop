using Application.Mappings;
using AutoMapper;
using Domain.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.ShopCartDtos
{
    public class UpdateShopCartDto : IMap
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string ProductId { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public int QuqntityInCart { get; set; }
        public string UrlToOffer { get; set; }
        public UpdateShopCartDto()
        {            
        }

        public UpdateShopCartDto(string id, string userId, string productId, string name, float price, int quqntityInCart, string urlToOffer)
        {
            Id = id;
            UserId = userId;
            ProductId = productId;
            Name = name;
            Price = price;
            QuqntityInCart = quqntityInCart;
            UrlToOffer = urlToOffer;
        }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateShopCartDto, ShopCart>();
        }
    }
}
