using Application.Dtos.OrderDtos;

namespace ShopWebApi.Controllers.ModelApi
{
    public class CreateOrderRequest
    {
        public CreateOrderDto OrderDto { get; set; }
        public IEnumerable<CreateOrderItemDto> Items { get; set; }
    }
}
