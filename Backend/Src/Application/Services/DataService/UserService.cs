using Application.Dtos.UserDtos;
using Application.Interfaces.DataService;
using AutoMapper;
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

        public void Delete(int id)
        {
            var user = _userRepository.Get(id);
            _userRepository.Delete(user);
        }

        public UserDto GetUser(int id)
        {
            var user = _userRepository.Get(id);
            return _mapper.Map<UserDto>(user);
        }
    }
}
