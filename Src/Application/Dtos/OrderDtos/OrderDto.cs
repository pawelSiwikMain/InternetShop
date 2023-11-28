using Domain.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.OrderDtos
{
    public class OrderDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int AddressId { get; set; }
        public IEnumerable<OrderItem> OrderItemDtos { get; set; }
        public OrderDto()
        {
        }

        public OrderDto(int id, int userId, int addressId, IEnumerable<OrderItem> orderItemDtos)
        {
            Id = id;
            UserId = userId;
            AddressId = addressId;
            OrderItemDtos = orderItemDtos;
        }
    }
}
