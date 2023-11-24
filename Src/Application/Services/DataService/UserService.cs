using Application.Dtos.User;
using Application.Interfaces.DataService;
using Domain.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.DataService
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public UserDto AddUser(CreateUserDto user)
        {
            throw new NotImplementedException();
        }

        public void DeleteUser(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserDto> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public UserDto GetByIdUser(string id)
        {
            throw new NotImplementedException();
        }

        public void UpdateUser(UserDto user)
        {
            throw new NotImplementedException();
        }
    }
}
