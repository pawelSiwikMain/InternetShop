using Application.Mappings;
using AutoMapper;
using Domain.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.OrderDtos
{
    public class CreateOrderItemDto : IMap
    {
        public string Name { get; set; }
        public int Quqntity { get; set; }
        public CreateOrderItemDto()
        {           
        }
        public CreateOrderItemDto(string name, int quqntity)
        {
            Name = name;
            Quqntity = quqntity;
        }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateOrderItemDto, OrderItem>();
        }
    }
}
