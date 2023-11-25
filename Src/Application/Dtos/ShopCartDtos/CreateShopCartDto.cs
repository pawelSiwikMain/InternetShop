﻿using Application.Mappings;
using AutoMapper;
using Domain.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.ShopCartDtos
{
    public class CreateShopCartDto : IMap
    {
        public string UserId { get; set; } = string.Empty;
        public string ProductId { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public float Price { get; set; } = default(float);
        public int QuqntityInCart { get; set; } = default(int);
        public string UrlToOffer { get; set; } = string.Empty;
        public CreateShopCartDto()
        {            
        }

        public CreateShopCartDto(string userId, string productId, string name, float price, int quqntityInCart, string urlToOffer)
        {
            UserId = userId;
            ProductId = productId;
            Name = name;
            Price = price;
            QuqntityInCart = quqntityInCart;
            UrlToOffer = urlToOffer;
        }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateShopCartDto, ShopCart>();
        }
    }
}
