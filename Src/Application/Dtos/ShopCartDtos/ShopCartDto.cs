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
    public class ShopCartDto : IMap
    {
        public int Id { get; set; } 
        public int UserId { get; set; } 
        public int ProductId { get; set; } 
        public string Name { get; set; } 
        public float Price { get; set; } 
        public int QuqntityInCart { get; set; } 
        public string UrlToOffer { get; set; } 

        public ShopCartDto()
        {            
        }

        public ShopCartDto(int id, int userId, int productId, string name, float price, int quqntityInCart, string urlToOffer)
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
            profile.CreateMap<ShopCart, ShopCartDto>();
        }
    }
}
