using App.Domain.Core.DtoModels.Orders;

namespace App.Domain.Core.DataAccess
{
    public interface IOrderRepository
    {
        Task<List<OrderOutputDto>> GetAllOrders(CancellationToken cancellationToken);
        Task<OrderOutputDto>? GetOrderBy(int id, CancellationToken cancellationToken);
        Task<List<OrderOutputDto>> GetOrdersByUserId(int userId, CancellationToken cancellationToken);
        Task<int> CalculateTotalSalePricesForSeller(int sellerId, CancellationToken cancellationToken);
        Task<int> CreateOrder(AddOrderInputDto inputDto, CancellationToken cancellationToken);
        Task UpdateOrder(EditOrderInputDto order, CancellationToken cancellationToken);
        Task SetOrderAsPurchased(int orderId, CancellationToken cancellationToken);
        Task DeleteOrder(int id, CancellationToken cancellationToken);
    }
}
