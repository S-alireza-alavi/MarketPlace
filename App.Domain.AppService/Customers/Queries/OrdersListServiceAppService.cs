using App.Domain.Core.AppServices.Customers.Queries;
using App.Domain.Core.DtoModels.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.AppService.Customers.Queries
{
    public class OrdersListServiceAppService : IOrdersListServiceAppService
    {
        public Task<List<OrderOutputDto>> GetListOfOrders(int customerID, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
