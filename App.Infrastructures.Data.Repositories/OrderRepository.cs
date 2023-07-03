﻿using App.Domain.Core.AppServices.Sellers.Commands;
using App.Domain.Core.Configs;
using App.Domain.Core.DataAccess;
using App.Domain.Core.DtoModels.OrderItems;
using App.Domain.Core.DtoModels.Orders;
using App.Domain.Core.DtoModels.Products;
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

            var sellerMedal = await _context.Medals.FirstOrDefaultAsync(m => m.SellerId == sellerId);

            if (totalSalePrice >= _appConfigs.CommissionSettings.SaleAmountForMedal && sellerMedal == null)
            {
                await _setMedalForSellerService.SetMedalForSeller(sellerId, cancellationToken);
            }

            return totalSalePrice;
        }

        public async Task<int> CountOrderItems(int orderId, CancellationToken cancellationToken)
        {
            var result = await _context.OrderItems.CountAsync(oi => oi.OrderId == orderId, cancellationToken);
            return result;
        }

        public async Task<int> CreateOrder(AddOrderInputDto inputDto, CancellationToken cancellationToken)
        {
            var order = new Order
            {
                SellerId = inputDto.SellerId,
                CustomerId = inputDto.CustomerId,
                TotalPrice = inputDto.TotalPrice,
                IsPurchased = false,
                CreatedAt = DateTime.Now
            };

            await _context.Orders.AddAsync(order, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return order.Id;
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

        public async Task<OrderOutputDto>? GetCartOrder(int customerId, CancellationToken cancellationToken)
        {
            var cartOrder = await _context.Orders
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Product)
                .ThenInclude(p => p.ProductPhotos)
                .FirstOrDefaultAsync(o => o.CustomerId == customerId && !o.IsPurchased && !o.IsDeleted, cancellationToken);

            var cartOrderDto = new OrderOutputDto
            {
                Id = cartOrder.Id,
                SellerId = cartOrder.SellerId,
                CustomerId = cartOrder.CustomerId,
                TotalPrice = cartOrder.TotalPrice,
                CreatedAt = cartOrder.CreatedAt,
                IsPurchased = cartOrder.IsPurchased,
                OrderItems = cartOrder.OrderItems.Select(oi => new OrderItemOutputDto
                {
                    Id = oi.Id,
                    OrderId = oi.OrderId,
                    ProductId = oi.ProductId,
                    Product = oi.Product,
                    ProductPhotos = oi.Product.ProductPhotos
                }).ToList()
            };

            return cartOrderDto;
        }

        public async Task<OrderOutputDto>? GetOrderBy(int id, CancellationToken cancellationToken)
        {
            var order = await _context.Orders
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Product)
                .ThenInclude(p => p.ProductPhotos)
                .Where(o => o.Id == id).Select(o => new OrderOutputDto
                {
                    Id = o.Id,
                    SellerId = o.SellerId,
                    CustomerId = o.CustomerId,
                    TotalPrice = o.TotalPrice,
                    CreatedAt = o.CreatedAt,
                    IsPurchased = o.IsPurchased,
                    OrderItems = o.OrderItems.Select(oi => new OrderItemOutputDto
                    {
                        Id = oi.Id,
                        OrderId = oi.OrderId,
                        Product = oi.Product
                    }).ToList()
                }).FirstAsync(cancellationToken);

            return order;
        }

        public async Task<List<OrderOutputDto>> GetOrdersByUserId(int userId, CancellationToken cancellationToken)
        {
            var userOrders = await _context.Orders
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Product)
                .ThenInclude(p => p.ProductPhotos)
                .Where(o => o.CustomerId == userId && o.IsPurchased)
                .Select(o => new OrderOutputDto
                {
                    Id = o.Id,
                    TotalPrice = o.TotalPrice,
                    CreatedAt = o.CreatedAt,
                    OrderItems = o.OrderItems.Select(oi => new OrderItemOutputDto
                    {
                        Id = oi.Id,
                        OrderId = oi.OrderId,
                        ProductId = oi.ProductId,
                        Product = oi.Product,
                        ProductPhotos = oi.Product.ProductPhotos
                    }).ToList()
                })
                .ToListAsync(cancellationToken);

            return userOrders;
        }

        public async Task<bool> HasOrder(int customerId, CancellationToken cancellationToken)
        {
            var order = await _context.Orders.FirstOrDefaultAsync(o => o.CustomerId == customerId && !o.IsPurchased && !o.IsDeleted, cancellationToken);

            if (order != null)
                return true;
            return false;
        }

        public async Task SetOrderAsPurchased(int orderId, CancellationToken cancellationToken)
        {
            var order = await GetOrderBy(orderId, cancellationToken);

            if (order != null)
            {
                await UpdateOrder(new EditOrderInputDto
                {
                    Id = order.Id,
                    SellerId = order.SellerId,
                    CustomerId = order.CustomerId,
                    TotalPrice = order.TotalPrice,
                    IsPurchased = true
                }, cancellationToken);
            }
        }

        public async Task UpdateOrder(EditOrderInputDto order, CancellationToken cancellationToken)
        {
            var orderToUpdate = await _context.Orders.Where(o => o.Id == order.Id).FirstOrDefaultAsync(cancellationToken);

            orderToUpdate.Id = order.Id;
            orderToUpdate.SellerId = order.SellerId;
            orderToUpdate.CustomerId = order.CustomerId;
            orderToUpdate.TotalPrice = order.TotalPrice;
            orderToUpdate.IsPurchased = order.IsPurchased;


            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateOrderTotalPrice(int orderId, CancellationToken cancellationToken)
        {
            var order = await _context.Orders
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Product)
                .FirstOrDefaultAsync(o => o.Id == orderId, cancellationToken);

            if (order != null && order.OrderItems != null)
            {
                int totalPrice = order.OrderItems.Sum(oi => oi.Product.Price);
                order.TotalPrice = totalPrice;

                await _context.SaveChangesAsync(cancellationToken);
            }
        }
    }
}
