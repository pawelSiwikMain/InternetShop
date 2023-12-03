using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.AuthorizationService
{
    public class SignInRequest
    {
        public string UserEmail { get; set; }
        public string Password { get; set; }

        public SignInRequest()
        {            
        }
    }
}
