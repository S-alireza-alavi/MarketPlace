using App.Domain.Core.AppServices.Sellers.Commands;
using App.Domain.Core.Configs;
using App.Domain.Core.DataAccess;
using App.Domain.Core.DtoModels.Orders;
using MarketPlace.Database;
using MarketPlace.Entities;
using Microsoft.EntityFrameworkCore;

namespace App.Infrastructures.Data.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _context;
        private readonly AppConfigs _appConfigs;
        private readonly ISetMedalForSellerService _setMedalForSellerService;

        public OrderRepository(AppDbContext context, AppConfigs appConfigs, ISetMedalForSellerService setMedalForSellerService)
        {
            _context = context;
            _appConfigs = appConfigs;
            _setMedalForSellerService = setMedalForSellerService;
        }

        public async Task<int> CalculateTotalSalePricesForSeller(int sellerId, CancellationToken cancellationToken)
        {
            int totalSalePrice = await _context.Orders
                .Where(o => o.SellerId == sellerId && o.IsPurchased)
                .SumAsync(o => o.TotalPrice, cancellationToken);

            if (totalSalePrice >= _appConfigs.CommissionSettings.SaleAmountForMedal)
            {
                await _setMedalForSellerService.SetMedalForSeller(sellerId, cancellationToken);
            }

            return totalSalePrice;
        }

        public async Task CreateOrder(AddOrderInputDto order, CancellationToken cancellationToken)
        {
            await _context.Orders.AddAsync(new Order
            {
                SellerId = order.SellerId,
                CustomerId = order.CustomerId,
                TotalPrice = order.TotalPrice,
                IsPurchased = order.IsPurchased,
                CreatedAt = DateTime.Now
            });

            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteOrder(int id, CancellationToken cancellationToken)
        {
            Order? order = await _context.Orders.FindAsync(id);

            order.IsDeleted = true;

            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<List<OrderOutputDto>> GetAllOrders(CancellationToken cancellationToken)
        {
            var orders = await _context.Orders.Select(o => new OrderOutputDto
            {
                Id = o.Id,
                SellerId = o.SellerId,
                CustomerId = o.CustomerId,
                TotalPrice = o.TotalPrice,
                IsPurchased = o.IsPurchased

            }).ToListAsync(cancellationToken);

            return orders;
        }

        public async Task<OrderOutputDto>? GetOrderBy(int id, CancellationToken cancellationToken)
        {
            var order = await _context.Orders.Where(o => o.Id == id).Select(o => new OrderOutputDto
            {
                Id = o.Id,
                SellerId = o.SellerId,
                CustomerId = o.CustomerId,
                TotalPrice = o.TotalPrice,
                IsPurchased = o.IsPurchased
            }).FirstAsync(cancellationToken);

            return order;
        }

        public async Task UpdateOrder(EditOrderInputDto order, CancellationToken cancellationToken)
        {
            var orderToUpdate = await _context.Orders.Where(o => o.Id == order.Id).FirstOrDefaultAsync(cancellationToken);

            orderToUpdate.SellerId = order.SellerId;
            orderToUpdate.CustomerId = order.CustomerId;
            orderToUpdate.TotalPrice = order.TotalPrice;

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
