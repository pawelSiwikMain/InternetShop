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
        public string Name { get; set; } 
        public string Description { get; set; }
        public string Category { get; set; }
        public float Price { get; set; } 
        public int QuqntityInStorage { get; set; }
        public string UrlToPicture { get; set; } 

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
