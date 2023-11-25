using Application.Dtos.UserDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.DataService
{
    public interface IUserService
    {
        UserDto AddUser(CreateUserDto user);
        UserDto GetByIdUser (string id);
        IEnumerable<UserDto> GetAllUsers();
        void UpdateUser(UserDto user);
        void DeleteUser(string id);
    }
}
