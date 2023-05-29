using App.Domain.Core.DataAccess;
using App.Domain.Core.DtoModels.ProductCategories;
using MarketPlace.Database;
using MarketPlace.Entities;
using Microsoft.EntityFrameworkCore;

namespace App.Infrastructures.Data.Repositories
{
    public class ProductCategoryRepository : IProductCategoryRepository
    {
        private readonly AppDbContext _context;

        public ProductCategoryRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreateProductCategory(AddProductCategoryInputDto productCategory)
        {
            await _context.ProductCategories.AddAsync(new ProductCategory
            {
                Name = productCategory.Name,
                ParentCategoryId = productCategory.ParentCategoryId,
                IsActive = true
            });

            await _context.SaveChangesAsync();
        }

        public async Task DeleteProductCategory(int id)
        {
            ProductCategory? productCategory = await _context.ProductCategories.FindAsync(id);

            productCategory.IsDeleted = true;

            await _context.SaveChangesAsync();
        }

        public async Task<List<ProductCategoryOutputDto>> GetAllProductCategories()
        {
            var tagCategories = await _context.ProductCategories.Select(pc => new ProductCategoryOutputDto
            {
                Id = pc.Id,
                Name = pc.Name,
                ParentCategoryId = pc.ParentCategoryId,
                IsActive = pc.IsActive

            }).ToListAsync();

            return tagCategories;
        }

        public async Task<ProductCategoryOutputDto> GetProductCategoryBy(int id)
        {
            var productCategory = await _context.ProductCategories.Where(pc => pc.Id == id).Select(pc =>
                new ProductCategoryOutputDto
                {
                    Id = pc.Id,
                    Name = pc.Name,
                    ParentCategoryId = pc.ParentCategoryId,
                    IsActive = pc.IsActive
                }).FirstAsync();

            return productCategory;
        }

        public async Task UpdateProductCategory(EditProductCategoryInputDto productCategory)
        {
            var productCategoryToUpdate = await _context.ProductCategories.Where(pc => pc.Id == productCategory.Id)
                .FirstOrDefaultAsync();

            productCategoryToUpdate.Name = productCategory.Name;
            productCategoryToUpdate.ParentCategoryId = productCategory.ParentCategoryId;
            productCategoryToUpdate.IsActive = productCategory.IsActive;

            await _context.SaveChangesAsync();
        }
    }
}
