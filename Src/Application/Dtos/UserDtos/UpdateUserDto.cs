using Application.Mappings;
using AutoMapper;
using Domain.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.UserDtos
{
    public class UpdateUserDto : IMap
    {
        public int Id { get; set; } 
        public string UserMail { get; set; }
        public string Name { get; set; } 
        public string LastName { get; set; }
        public string Phone { get; set; } 
        public string Password { get; set; } 
        public bool IsAdmin { get; set; } 
        public UpdateUserDto()
        {            
        }

        public UpdateUserDto(int id, string userMail, string name, string lastName, string phone, string password, bool isAdmin)
        {
            Id = id;
            UserMail = userMail;
            Name = name;
            LastName = lastName;
            Phone = phone;
            Password = password;
            IsAdmin = isAdmin;
        }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateUserDto, User>();
        }
    }
}
