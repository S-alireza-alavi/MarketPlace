using App.Domain.Core.AppServices.Customers.Queries;
using App.Domain.Core.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.AppService.Customers.Queries
{
    public class CountOrderItemsService : ICountOrderItemsService
    {
        private readonly IOrderRepository _orderRepository;

        public CountOrderItemsService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public Task<int> CountOrderItems(int orderId, CancellationToken cancellationToken)
        {
            var result = _orderRepository.CountOrderItems(orderId, cancellationToken);
            return result;
        }
    }
}
