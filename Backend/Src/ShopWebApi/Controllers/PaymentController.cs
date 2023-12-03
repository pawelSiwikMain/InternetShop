using Application.Interfaces.PaymentService;
using Application.Models.PaymentService;
using Microsoft.AspNetCore.Mvc;

namespace ShopWebApi.Controllers
{
    [Route("api/[controller]")]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;
        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }
        [HttpPost]
        public IActionResult Pay(PayRequest request)
        {
            var response = _paymentService.Pay(request);
            return Ok(response);
        }
    }
}
