using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.AuthorizationService
{
    public class SignInResponse
    {
        public bool UserEgzist { get; set; } = false;
        public bool PasswordCorect { get; set; } = false;
        public bool UserIsAdmin { get; set; } = false;
        public int UserId { get; set; } = -1;

        public SignInResponse()
        {
            UserEgzist = false;
            PasswordCorect = false;
            UserIsAdmin = false;
            UserId = -1;
        }
    }
}
