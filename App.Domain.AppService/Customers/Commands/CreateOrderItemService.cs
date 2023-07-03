using App.Domain.Core.AppServices.Customers.Commands;
using App.Domain.Core.DataAccess;
using App.Domain.Core.DtoModels.OrderItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.AppService.Customers.Commands
{
    public class CreateOrderItemService : ICreateOrderItemService
    {
        private readonly IOrderItemRepository _orderItemRepository;

        public CreateOrderItemService(IOrderItemRepository orderItemRepository)
        {
            _orderItemRepository = orderItemRepository;
        }

        public async Task CreateOrderItem(AddOrderItemInputDto orderItem, CancellationToken cancellationToken)
        {
            await _orderItemRepository.CreateOrderItem(orderItem, cancellationToken);
        }
    }
}
