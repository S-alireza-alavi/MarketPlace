using App.Domain.Core.DtoModels.Orders;

namespace App.Domain.Core.DataAccess
{
    public interface IOrderRepository
    {
        Task<List<OrderOutputDto>> GetAllOrders(CancellationToken cancellationToken);
        Task<OrderOutputDto>? GetOrderBy(int id, CancellationToken cancellationToken);
        Task<int> CalculateTotalSalePricesForSeller(int sellerId, CancellationToken cancellationToken);
        Task CreateOrder(AddOrderInputDto order, CancellationToken cancellationToken);
        Task UpdateOrder(EditOrderInputDto order, CancellationToken cancellationToken);
        Task DeleteOrder(int id, CancellationToken cancellationToken);
    }
}
