using App.Domain.Core.DtoModels.OrderItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.DataAccess
{
    public interface IOrderItemRepository
    {
        Task<List<OrderItemOutputDto>> GetAllOrderItems(CancellationToken cancellationToken);
        Task<OrderItemOutputDto>? GetOrderItemBy(int id, CancellationToken cancellationToken);
        Task CreateOrderItem(AddOrderItemInputDto orderItem, CancellationToken cancellationToken);
        Task UpdateOrderItem(EditOrderItemInputDto orderItem, CancellationToken cancellationToken);
        Task DeleteOrderItem(int id, CancellationToken cancellationToken);
    }
}
