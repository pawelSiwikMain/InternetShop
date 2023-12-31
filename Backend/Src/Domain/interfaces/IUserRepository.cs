﻿using Domain.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.interfaces
{
    public interface IUserRepository
    {
        User GetByMail(string email);
        User Get(int id);
        User Add(User user);
        void Update(User user);
        void Delete(User user);
    }
}
