using Application.Dtos.UserDtos;
using Application.Interfaces.AuthorizationService;
using Application.Interfaces.DataService;
using Application.Models.AuthorizationService;
using AutoMapper;
using Domain.entities;
using Domain.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.AuthorizationService
{
    public class AuthorizationService : IAuthorizationService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public AuthorizationService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public SignUpResponse SignUp(SignUpRequst requst)
        {
            var userEgzis = _userRepository.GetByMail(requst.Email);
            var response = new SignUpResponse();

            if (userEgzis != null)
            {
                return response;
            }

            response.UserAlreadyEgzist = false;

            var createUserDto = new CreateUserDto(requst.Email, requst.Name, requst.LastName, requst.Phone, requst.Password, false);
            var createUser = _mapper.Map<User>(createUserDto);
            var check = _userRepository.Add(createUser);
            if (check != null)
            {
                response.AcountCreated = true;
            }
            response.UserId = createUser.Id;
            return response;
        }

        public SignInResponse SingIn(SignInRequest request)
        {
            var user = _userRepository.GetByMail(request.UserEmail);
            var response = new SignInResponse();

            if (user == null)
            {
                return response;
            }

            response.UserEgzist = true;

            if (request.Password == user.Password)
            {
                response.PasswordCorect = true;
                response.UserId = user.Id;
                response.UserIsAdmin = user.IsAdmin;
            }
            return response;
        }
    }
}
