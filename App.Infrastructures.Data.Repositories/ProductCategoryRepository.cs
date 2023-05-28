using App.Domain.Core.DataAccess;
using App.Domain.Core.DtoModels.ProductCategories;
using App.Domain.Core.Entities;
using Microsoft.EntityFrameworkCore;
using App.Infrastructures.Database.SqlServer.Data;

namespace App.Infrastructures.Data.Repositories
{
    public class ProductCategoryRepository : IProductCategoryRepository
    {
        private readonly AppDbContext _context;

        public ProductCategoryRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreateProductCategory(AddProductCategoryInputDto productCategory, CancellationToken cancellationToken)
        {
            await _context.ProductCategories.AddAsync(new ProductCategory
            {
                Name = productCategory.Name,
                ParentCategoryId = productCategory.ParentCategoryId,
                IsActive = true
            });

            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteProductCategory(int id, CancellationToken cancellationToken)
        {
            ProductCategory? productCategory = await _context.ProductCategories.FindAsync(id);

            productCategory.IsDeleted = true;

            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<List<ProductCategoryOutputDto>> GetAllProductCategories(CancellationToken cancellationToken)
        {
            var tagCategories = await _context.ProductCategories.Select(pc => new ProductCategoryOutputDto
            {
                Id = pc.Id,
                Name = pc.Name,
                ParentCategoryId = pc.ParentCategoryId,
                IsActive = pc.IsActive

            }).ToListAsync(cancellationToken);

            return tagCategories;
        }

        public async Task<ProductCategoryOutputDto>? GetProductCategoryBy(int id, CancellationToken cancellationToken)
        {
            var productCategory = await _context.ProductCategories.Where(pc => pc.Id == id).Select(pc =>
                new ProductCategoryOutputDto
                {
                    Id = pc.Id,
                    Name = pc.Name,
                    ParentCategoryId = pc.ParentCategoryId,
                    IsActive = pc.IsActive
                }).FirstAsync(cancellationToken);

            return productCategory;
        }

        public async Task UpdateProductCategory(EditProductCategoryInputDto productCategory, CancellationToken cancellationToken)
        {
            var productCategoryToUpdate = await _context.ProductCategories.Where(pc => pc.Id == productCategory.Id)
                .FirstOrDefaultAsync(cancellationToken);

            productCategoryToUpdate.Name = productCategory.Name;
            productCategoryToUpdate.ParentCategoryId = productCategory.ParentCategoryId;
            productCategoryToUpdate.IsActive = productCategory.IsActive;

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
