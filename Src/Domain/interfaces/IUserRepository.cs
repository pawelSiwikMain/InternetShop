using Domain.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.interfaces
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAll();
        User Get(string id);
        User Add(User user);
        void Update(User user);
        void Delete(User user);
    }
}
