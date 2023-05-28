﻿using App.Domain.Core.DataAccess;
using App.Domain.Core.DtoModels.Products;
using App.Domain.Core.Entities;
using Microsoft.EntityFrameworkCore;
using App.Infrastructures.Database.SqlServer.Data;

namespace App.Infrastructures.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreateProduct(AddProductInputDto product, CancellationToken cancellationToken)
        {
            await _context.Products.AddAsync(new Product
            {
                Name = product.Name,
                CategoryId = product.CategoryId,
                BrandId = product.BrandId,
                StoreId = product.StoreId,
                Weight = product.Weight,
                Description = product.Description,
                Count = product.Count,
                ModelId = product.ModelId,
                Price = product.Price,
                IsActive = true
            });

            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteProduct(int id, CancellationToken cancellationToken)
        {
            Product? product = await _context.Products.FindAsync(id);

            product.IsDeleted = true;

            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<int> ProductsCount(CancellationToken cancellationToken)
        {
            var count = await _context.Products.AsNoTracking().CountAsync(cancellationToken);

            return count;
        }

        public async Task<List<ProductOutputDto>> GetAllProducts(CancellationToken cancellationToken)
        {
            var product = await _context.Products.Select(p => new ProductOutputDto
            {
                Name = p.Name,
                CategoryId = p.CategoryId,
                BrandId = p.BrandId,
                StoreId = p.StoreId,
                Weight = p.Weight,
                Description = p.Description,
                Count = p.Count,
                ModelId = p.ModelId,
                Price = p.Price,
                IsActive = p.IsActive
            }).ToListAsync(cancellationToken);

            return product;
        }

        public async Task<ProductOutputDto>? GetProductBy(int id, CancellationToken cancellationToken)
        {
            var product = await _context.Products.Where(p => p.Id == id).Select(p =>
                new ProductOutputDto
                {
                    Name = p.Name,
                    CategoryId = p.CategoryId,
                    BrandId = p.BrandId,
                    StoreId = p.StoreId,
                    Weight = p.Weight,
                    Description = p.Description,
                    Count = p.Count,
                    ModelId = p.ModelId,
                    Price = p.Price,
                    IsActive = p.IsActive
                }).FirstAsync(cancellationToken);

            return product;
        }

        public async Task UpdateProduct(EditProductInputDto product, CancellationToken cancellationToken)
        {
            var productToUpdate = await _context.Products.Where(p => p.Id == product.Id)
                .FirstOrDefaultAsync(cancellationToken);

            productToUpdate.Name = product.Name;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.BrandId = product.BrandId;
            productToUpdate.StoreId = product.StoreId;
            productToUpdate.Weight = product.Weight;
            productToUpdate.Description = product.Description;
            productToUpdate.Count = product.Count;
            productToUpdate.ModelId = product.ModelId;
            productToUpdate.Price = product.Price;
            productToUpdate.IsActive = product.IsActive;

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
