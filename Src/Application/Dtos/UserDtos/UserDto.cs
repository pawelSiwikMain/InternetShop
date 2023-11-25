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
    public class UserDto : IMap
    {
        public string Id { get; set; } = string.Empty;
        public string UserMail { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public bool IsAdmin { get; set; } = default(bool);

        public UserDto()
        {            
        }

        public UserDto(string id, string userMail, string name, string lastName, string phone, string password, bool isAdmin)
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
            profile.CreateMap<User,  UserDto>();
        }
    }
}
