using App.Domain.Core.AppServices.Customers.Commands;
using App.Domain.Core.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.AppService.Customers.Commands
{
    public class UpdateOrderTotalPriceService : IUpdateOrderTotalPriceService
    {
        private readonly IOrderRepository _orderRepository;

        public UpdateOrderTotalPriceService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task UpdateOrderTotalPrice(int orderId, CancellationToken cancellationToken)
        {
            await _orderRepository.UpdateOrderTotalPrice(orderId, cancellationToken);
        }
    }
}
