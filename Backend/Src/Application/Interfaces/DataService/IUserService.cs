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
        UserDto GetUser(int id);
        void Delete(int id); 
    }
}
