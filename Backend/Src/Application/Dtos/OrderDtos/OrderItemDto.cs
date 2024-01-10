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
    public class OrderItemDto : IMap
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quqntity { get; set; }
        public OrderItemDto()
        {
        }
        public OrderItemDto(int id, string name, int quqntity)
        {
            Id = id;
            Name = name;
            Quqntity = quqntity;
        }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<OrderItem, OrderItemDto>();
        }
    }
}
