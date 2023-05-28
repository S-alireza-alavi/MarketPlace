using App.Domain.Core.DataAccess;
using App.Domain.Core.DtoModels.ProductTags;
using App.Domain.Core.Entities;
using Microsoft.EntityFrameworkCore;
using App.Infrastructures.Database.SqlServer.Data;

namespace App.Infrastructures.Data.Repositories
{
    public class ProductTagRepository : IProductTagRepository
    {
        private readonly AppDbContext _context;

        public ProductTagRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreateProductTag(AddProductTagInputDto productTag, CancellationToken cancellationToken)
        {
            await _context.ProductTags.AddAsync(new ProductTag
            {
                ProductId = productTag.ProductId,
                TagId = productTag.TagId,
            });

            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteProductTag(int id, CancellationToken cancellationToken)
        {
            ProductTag? productTag = await _context.ProductTags.FindAsync(id);

            productTag.IsDeleted = true;

            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<List<ProductTagOutputDto>> GetAllProductTags(CancellationToken cancellationToken)
        {
            var productTags = await _context.ProductTags.Select(pt => new ProductTagOutputDto
            {
                ProductId = pt.ProductId,
                TagId = pt.TagId
            }).ToListAsync(cancellationToken);

            return productTags;
        }

        public async Task<ProductTagOutputDto>? GetProductTagBy(int id, CancellationToken cancellationToken)
        {
            var productTag = await _context.ProductTags.Where(pt => pt.Id == id).Select(pt =>
                new ProductTagOutputDto
                {
                    ProductId = pt.ProductId,
                    TagId = pt.TagId
                }).FirstAsync(cancellationToken);

            return productTag;
        }

        public async Task UpdateProductTag(EditProductTagInputDto productTag, CancellationToken cancellationToken)
        {
            var productTagToUpdate = await _context.ProductTags.Where(pt => pt.Id == productTag.Id)
                .FirstOrDefaultAsync(cancellationToken);

            productTagToUpdate.ProductId = productTag.ProductId;
            productTagToUpdate.TagId = productTag.TagId;

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
