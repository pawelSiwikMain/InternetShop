using Application.Mappings;
using Domain.entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.AddressDtos
{
    public class AddressDto : IMap
    {
        public string Id { get; set; } = string.Empty;
        public string UserId { get; set; } = string.Empty;
        public string PostCode { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Street { get; set; } = string.Empty;
        public string LocalNumber { get; set; } = string.Empty;

        public AddressDto()
        {
        }

        public AddressDto(string id, string userId, string postCode, string city, string street, string localNumber)
        {
            Id = id;
            UserId = userId;
            PostCode = postCode;
            City = city;
            Street = street;
            LocalNumber = localNumber;
        }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Address, AddressDto>();
        }
    }
}
