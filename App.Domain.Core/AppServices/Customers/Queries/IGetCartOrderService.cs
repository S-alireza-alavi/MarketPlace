using App.Domain.Core.DtoModels.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.AppServices.Customers.Queries
{
    public interface IGetCartOrderService
    {
        Task<OrderOutputDto> GetCartOrder(int customerId, CancellationToken cancellationToken);
    }
}
