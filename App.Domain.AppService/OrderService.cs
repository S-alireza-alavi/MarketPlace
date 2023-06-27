using App.Domain.Core.AppServices;
using App.Domain.Core.DataAccess;
using App.Domain.Core.DtoModels.OrderItems;
using App.Domain.Core.DtoModels.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.AppService
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderItemRepository _orderItemRepository;

        public OrderService(IOrderRepository orderRepository, IOrderItemRepository orderItemRepository)
        {
            _orderRepository = orderRepository;
            _orderItemRepository = orderItemRepository;
        }

        public async Task<int> CreateOrder(AddOrderInputDto order, CancellationToken cancellationToken)
        {
            var orderId = await _orderRepository.CreateOrder(order, cancellationToken);
            return orderId;
        }

        public async Task CreateOrderItem(AddOrderItemInputDto orderItem, CancellationToken cancellationToken)
        {
            await _orderItemRepository.CreateOrderItem(orderItem, cancellationToken);
        }

        public async Task SetOrderAsPurchased(int orderId, CancellationToken cancellationToken)
        {
            await _orderRepository.SetOrderAsPurchased(orderId, cancellationToken);
        }
    }
}
