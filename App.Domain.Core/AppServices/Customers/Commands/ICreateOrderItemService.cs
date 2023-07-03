using App.Domain.Core.DtoModels.OrderItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.AppServices.Customers.Commands
{
    public interface ICreateOrderItemService
    {
        Task CreateOrderItem(AddOrderItemInputDto orderItem, CancellationToken cancellationToken);
    }
}
