using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.AuthorizationService
{
    public class SignUpResponse
    {
        public bool UserAlreadyEgzist { get; set; } = true;
        public bool AcountCreated { get; set; } = false;
        public int UserId { get; set; } = -1;
        public SignUpResponse()
        {
            UserAlreadyEgzist = true;
            AcountCreated = false;
            UserId = -1;
        }
    }
}
