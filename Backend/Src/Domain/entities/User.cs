using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.entities
{
    public class User
    {
        public int Id { get; set; }
        public string UserMail { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
        public virtual Address Address { get; set; }
        public virtual List<ShopCart> ShopCart { get; set; }

        public User()
        {
        }

        public User(int id, string userMail, string name, string lastName, string phone, string password, bool isAdmin)
        {
            Id = id;
            UserMail = userMail;
            Name = name;
            LastName = lastName;
            Phone = phone;
            Password = password;
            IsAdmin = isAdmin;
        }
    }
}
