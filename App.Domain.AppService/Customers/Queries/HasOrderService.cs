using App.Domain.Core.AppServices.Customers.Queries;
using App.Domain.Core.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.AppService.Customers.Queries
{
    public class HasOrderService : IHasOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public HasOrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<bool> HasOrder(int customerId, CancellationToken cancellationToken)
        {
            var result = await _orderRepository.HasOrder(customerId, cancellationToken);
            return result;
        }
    }
}
