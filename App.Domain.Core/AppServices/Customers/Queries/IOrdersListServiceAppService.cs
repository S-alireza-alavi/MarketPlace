using App.Domain.Core.DtoModels.Orders;

namespace App.Domain.Core.AppServices.Customers.Queries
{
    public interface IOrdersListServiceAppService
    {
        Task<List<OrderOutputDto>> GetListOfOrders(int customerID, CancellationToken cancellationToken);
    }
}
