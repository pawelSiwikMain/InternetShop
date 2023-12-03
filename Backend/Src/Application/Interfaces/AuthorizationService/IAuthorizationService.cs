using Application.Models.AuthorizationService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.AuthorizationService
{
    public interface IAuthorizationService
    {
        SignInResponse SingIn(SignInRequest request);
        SignUpResponse SignUp(SignUpRequst requst);
    }
}
