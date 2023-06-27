using App.Domain.Core.DtoModels.OrderItems;
using App.Domain.Core.DtoModels.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.AppServices
{
    public interface IOrderService
    {
        Task<int> CreateOrder(AddOrderInputDto order, CancellationToken cancellationToken);
        Task CreateOrderItem(AddOrderItemInputDto orderItem, CancellationToken cancellationToken);
        Task SetOrderAsPurchased(int orderId, CancellationToken cancellationToken);
    }
}
