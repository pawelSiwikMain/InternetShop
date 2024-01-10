using Domain.interfaces;
using Application.Dtos.OrderDtos;
using Application.Interfaces.DataService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Domain.entities;

namespace Application.Services.DataService
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderItemRepository _itemRepository;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepository orderRepository, IOrderItemRepository itemRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _itemRepository = itemRepository;
            _mapper = mapper;
        }

        public OrderDto CreateOrder(CreateOrderDto order, IEnumerable<CreateOrderItemDto> items)
        {
            var newOrder = _mapper.Map<Order>(order);
            _orderRepository.Add(newOrder);
            var itemsList = _mapper.Map<IEnumerable<OrderItem>>(items).ToList();
            foreach (var item in itemsList)
            {
                item.OrderId = newOrder.Id;
                _itemRepository.Add(item);
            }
            var response = new OrderDto()
            {
                Id = newOrder.Id,
                AddressId = newOrder.AddressId,
                UserId = newOrder.UserId,
                OrderItemDtos = _mapper.Map<IEnumerable<OrderItemDto>>(itemsList).ToList()
            };
            return response;
        }

        public void DeleteOrder(int id)
        {
            var items = _itemRepository.GetAllForOrder(id);
            foreach (var item in items)
            {
                _itemRepository.Delete(item);
            }
            var order = _orderRepository.Get(id);
            _orderRepository.Delete(order);
        }

        public IEnumerable<OrderDto> GetAllOrders()
        {
            var orders = _orderRepository.GetAll().ToList();
            var listOfOrders = new List<OrderDto>();
            foreach (var item in orders)
            {
                var orderDto = new OrderDto()
                {
                    Id = item.Id,
                    AddressId = item.AddressId,
                    UserId = item.UserId,
                    OrderItemDtos = _mapper.Map<IEnumerable<OrderItemDto>>(_itemRepository.GetAllForOrder(item.Id)).ToList()
                };
                listOfOrders.Add(orderDto);
            }
            return listOfOrders;
        }

        public OrderDto GetOrder(int id)
        {
            var order = _orderRepository.Get(id);
            var orderDto = new OrderDto()
            {
                Id = order.Id,
                AddressId = order.AddressId,
                UserId = order.UserId,
                OrderItemDtos = _mapper.Map<IEnumerable<OrderItemDto>>(_itemRepository.GetAllForOrder(id)).ToList()
            };
            return orderDto;
        }
    }
}
