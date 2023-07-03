using App.Domain.Core.AppServices.Customers.Commands;
using App.Domain.Core.DataAccess;
using App.Domain.Core.DtoModels.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.AppService.Customers.Commands
{
    public class CreateOrderService : ICreateOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public CreateOrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public Task<int> CreateOrder(AddOrderInputDto inputDto, CancellationToken cancellationToken)
        {
            var orderId = _orderRepository.CreateOrder(inputDto, cancellationToken);
            return orderId;
        }
    }
}
