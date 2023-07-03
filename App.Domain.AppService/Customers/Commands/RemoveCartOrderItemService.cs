using App.Domain.Core.AppServices.Customers.Commands;
using App.Domain.Core.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.AppService.Customers.Commands
{
    public class RemoveCartOrderItemService : IRemoveCartOrderItemService
    {
        private readonly IOrderItemRepository _orderItemRepository;

        public RemoveCartOrderItemService(IOrderItemRepository orderItemRepository)
        {
            _orderItemRepository = orderItemRepository;
        }

        public async Task<int> RemoveCartOrderItem(int orderItemId, CancellationToken cancellationToken)
        {
            var orderId = await _orderItemRepository.DeleteOrderItem(orderItemId, cancellationToken);
            return orderId;
        }
    }
}
