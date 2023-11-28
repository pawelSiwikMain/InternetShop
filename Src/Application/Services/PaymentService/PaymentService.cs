using Application.Interfaces.PaymentService;
using Application.Models.PaymentService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.PaymentService
{
    public class PaymentService : IPaymentService
    {
        public PayResponse Pay(PayRequest request)
        {
            var payResponse = new PayResponse();
            if(request.Cvv == "666") 
            {
                return payResponse;
            }
            payResponse.Success = true;
            return payResponse;
        }
    }
}
