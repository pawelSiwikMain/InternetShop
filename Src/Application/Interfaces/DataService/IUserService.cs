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
        UserDto GetByIdUser (int id);
        IEnumerable<UserDto> GetAllUsers();
        void UpdateUser(UpdateUserDto user);
        void DeleteUser(int id);
    }
}
