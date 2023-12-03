using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.PaymentService
{
    public class PayRequest
    {
        public float Amount { get; set; }
        public string Cvv { get; set; }
        public string ExpirationDate { get; set; }
        public string CardNumber { get; set; }
        public string CardType { get; set; }
        public PayRequest() { }
    }
}
