using Application.Dtos.UserDtos;
using Application.Interfaces.DataService;
using AutoMapper;
using Domain.entities;
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
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public UserDto AddUser(CreateUserDto user)
        {
            var newUser = _mapper.Map<User>(user);
            _userRepository.Add(newUser);
            return _mapper.Map<UserDto>(newUser);
        }

        public void DeleteUser(string id)
        {
            var user = _userRepository.Get(id);
            _userRepository.Delete(user);
        }

        public IEnumerable<UserDto> GetAllUsers()
        {
            var users = _userRepository.GetAll();
            return _mapper.Map<IEnumerable<UserDto>>(users);
        }

        public UserDto GetByIdUser(string id)
        {
            var user = _userRepository.Get(id);
            return _mapper.Map<UserDto>(user);
        }

        public void UpdateUser(UpdateUserDto user)
        {
            var existingUser = _userRepository.Get(user.Id);
            var newUser = _mapper.Map(user, existingUser);
            _userRepository.Update(newUser);
        }
    }
}
