﻿using Application.Mappings;
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
        public int Id { get; set; } 
        public int UserId { get; set; }
        public string PostCode { get; set; }
        public string City { get; set; }
        public string Street { get; set; } 
        public string LocalNumber { get; set; }

        public AddressDto()
        {
        }

        public AddressDto(int id, int userId, string postCode, string city, string street, string localNumber)
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
