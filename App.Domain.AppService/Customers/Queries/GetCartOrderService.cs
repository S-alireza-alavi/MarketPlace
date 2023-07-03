using App.Domain.Core.AppServices.Customers.Queries;
using App.Domain.Core.DataAccess;
using App.Domain.Core.DtoModels.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.AppService.Customers.Queries
{
    public class GetCartOrderService : IGetCartOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public GetCartOrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<OrderOutputDto> GetCartOrder(int customerId, CancellationToken cancellationToken)
        {
            var cartOrder = await _orderRepository.GetCartOrder(customerId, cancellationToken);
            return cartOrder;
        }
    }
}
