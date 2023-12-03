using Application.Dtos.OrderDtos;
using Application.Interfaces.DataService;
using Microsoft.AspNetCore.Mvc;
using ShopWebApi.Controllers.ModelApi;

namespace ShopWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public IActionResult Ger()
        {
            var orders = _orderService.GetAllOrders();
            return Ok(orders);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id) 
        {
            var order = _orderService.GetOrder(id);
            return Ok(order);
        }
        [HttpPost]
        public IActionResult Create(CreateOrderRequest request)
        {
            var order = _orderService.CreateOrder(request.OrderDto, request.Items);
            return Created($"api/orders/{order.Id}", order);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id) 
        {
            _orderService.DeleteOrder(id);
            return NoContent();
        }
    }
}
