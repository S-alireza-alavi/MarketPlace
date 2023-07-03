using App.Domain.Core.DataAccess;
using App.Domain.Core.DtoModels.OrderItems;
using MarketPlace.Database;
using MarketPlace.Entities;
using Microsoft.EntityFrameworkCore;

namespace App.Infrastructures.Data.Repositories
{
    public class OrderItemRepository : IOrderItemRepository
    {
        private readonly AppDbContext _context;

        public OrderItemRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreateOrderItem(AddOrderItemInputDto orderItem, CancellationToken cancellationToken)
        {
            await _context.OrderItems.AddAsync(new OrderItem
            {
                OrderId = orderItem.OrderId,
                ProductId = orderItem.ProductId
            });

            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<int> DeleteOrderItem(int id, CancellationToken cancellationToken)
        {
            OrderItem? orderItem = await _context.OrderItems.FindAsync(id);

            if (orderItem != null)
            {
                int orderId = orderItem.OrderId;

                _context.OrderItems.Remove(orderItem);
                await _context.SaveChangesAsync(cancellationToken);

                return orderId;
            }

            return -1;
        }

            public async Task<OrderItemOutputDto>? GetOrderItemBy(int id, CancellationToken cancellationToken)
            {
                var orderItem = await _context.OrderItems.Where(oi => oi.Id == id).Select(oi => new OrderItemOutputDto
                {
                    Id = oi.Id,
                    OrderId = oi.OrderId,
                    ProductId = oi.ProductId
                }).FirstAsync(cancellationToken);

                return orderItem;
            }

            public async Task<List<OrderItemOutputDto>> GetAllOrderItems(CancellationToken cancellationToken)
            {
                var orderItems = await _context.OrderItems.Select(oi => new OrderItemOutputDto
                {
                    Id = oi.Id,
                    OrderId = oi.OrderId,
                    ProductId = oi.ProductId
                }).ToListAsync(cancellationToken);

                return orderItems;
            }

            public async Task UpdateOrderItem(EditOrderItemInputDto orderItem, CancellationToken cancellationToken)
            {
                var orderItemToUpdate = await _context.OrderItems.Where(oi => oi.Id == orderItem.Id).FirstOrDefaultAsync(cancellationToken);

                orderItemToUpdate.OrderId = orderItem.OrderId;
                orderItemToUpdate.ProductId = orderItem.ProductId;

                await _context.SaveChangesAsync(cancellationToken);
            }
        }
    }
