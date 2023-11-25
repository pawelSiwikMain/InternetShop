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
        public string UserId { get; set; } = string.Empty;
        public string PostCode { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Street { get; set; } = string.Empty;
        public string LocalNumber { get; set; } = string.Empty;

        public CreateAddressDto()
        {
        }

        public CreateAddressDto(string userId, string postCode, string city, string street, string localNumber)
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
