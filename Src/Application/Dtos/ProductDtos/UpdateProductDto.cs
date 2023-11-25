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
    public class UpdateProductDto : IMap
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public float Price { get; set; } = default(float);
        public int QuqntityInStorage { get; set; } = default(int);
        public string UrlToPicture { get; set; } = string.Empty;

        public UpdateProductDto()
        {           
        }

        public UpdateProductDto(string id, string name, string description, string category, float price, int quqntityInStorage, string urlToPicture)
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
            profile.CreateMap<UpdateProductDto, Product>();
        }
    }
}
