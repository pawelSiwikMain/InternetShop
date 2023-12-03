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
    public class CreateOrderDto : IMap
    {
        public int UserId { get; set; }
        public int AddressId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateOrderDto, Order>();
        }
    }
}
