using Application.Mappings;
using AutoMapper;
using Domain.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.AddressDtos
{
    public class CreateAddressDto : IMap
    {
        public int UserId { get; set; }
        public string PostCode { get; set; } 
        public string City { get; set; } 
        public string Street { get; set; } 
        public string LocalNumber { get; set; } 

        public CreateAddressDto()
        {
        }

        public CreateAddressDto(int userId, string postCode, string city, string street, string localNumber)
        {
            UserId = userId;
            PostCode = postCode;
            City = city;
            Street = street;
            LocalNumber = localNumber;
        }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateAddressDto, Address>();
        }
    }
}
