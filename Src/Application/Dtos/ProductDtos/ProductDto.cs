using Application.Mappings;
using AutoMapper;
using Domain.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.ProductDtos
{
    public class ProductDto : IMap
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public float Price { get; set; }
        public int QuqntityInStorage { get; set; }
        public string UrlToPicture { get; set; }

        public ProductDto()
        {
        }

        public ProductDto(string id, string name, string description, string category, float price, int quqntityInStorage, string urlToPicture)
        {
            Id = id;
            Name = name;
            Description = description;
            Category = category;
            Price = price;
            QuqntityInStorage = quqntityInStorage;
            UrlToPicture = urlToPicture;
        }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Product,  ProductDto>();
        }
    }
}
