using Application.Models.PaymentService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.PaymentService
{
    public interface IPaymentService
    {
        PayResponse Pay(PayRequest request);
    }
}
