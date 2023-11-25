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
    public class CreateProductDto : IMap
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public float Price { get; set; } = default(float);
        public int QuqntityInStorage { get; set; } = default(int);
        public string UrlToPicture { get; set; } = string.Empty;

        public CreateProductDto()
        {           
        }

        public CreateProductDto(string name, string description, string category, float price, int quqntityInStorage, string urlToPicture)
        {
            Name = name;
            Description = description;
            Category = category;
            Price = price;
            QuqntityInStorage = quqntityInStorage;
            UrlToPicture = urlToPicture;
        }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateProductDto, Product>();
        }
    }
}
