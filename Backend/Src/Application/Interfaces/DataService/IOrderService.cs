using Application.Dtos.OrderDtos;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.DataService
{
    public interface IOrderService
    {
        OrderDto CreateOrder(CreateOrderDto order, IEnumerable<CreateOrderItemDto> items);
        IEnumerable<OrderDto> GetAllOrders();
        OrderDto GetOrder(int id);
        void DeleteOrder(int id);
    }
}
