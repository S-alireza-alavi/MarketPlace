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
    public class GetOrderByIdService : IGetOrderByIdService
    {
        private readonly IOrderRepository _orderRepository;

        public GetOrderByIdService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<OrderOutputDto> GetOrderById(int id, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetOrderBy(id, cancellationToken);
            return order;
        }
    }
}
