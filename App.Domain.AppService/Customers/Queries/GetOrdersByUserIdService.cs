using App.Domain.Core.AppServices.Customers.Queries;
using App.Domain.Core.DataAccess;
using App.Domain.Core.DtoModels.Orders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.AppService.Customers.Queries
{
    public class GetOrdersByUserIdService : IGetOrdersByUserIdService
    {
        private readonly IOrderRepository _orderRepository;

        public GetOrdersByUserIdService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<List<OrderOutputDto>> GetOrdersByUserId(int userId, CancellationToken cancellationToken)
        {
            var userOrders = await _orderRepository.GetOrdersByUserId(userId, cancellationToken);
            return userOrders;
        }
    }
}
