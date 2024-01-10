using Application.Dtos.OrderDtos;
using Application.Interfaces.DataService;
using Application.Services.DataService;

namespace OrderItemTest
{
    public class Tests
    {
        private IOrderService _service;

        [SetUp]
        public void Setup(IOrderService service)
        {
            _service = service;
        }

        [Test]
        public void Test1()
        {
            // Arrange
            var order = new CreateOrderDto { 
                UserId = 100,
                AddressId = 100,
            };
            var items = new List<CreateOrderItemDto> {new CreateOrderItemDto("string", 10)};

            // Act
            var result = _service.CreateOrder(order, items);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(order.AddressId, result.AddressId);
            Assert.AreEqual(order.UserId, result.UserId);

        }
    }
}