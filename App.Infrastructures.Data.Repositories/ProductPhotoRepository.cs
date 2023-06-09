using App.Domain.Core.DataAccess;
using App.Domain.Core.DtoModels.ProductPhotos;
using MarketPlace.Database;
using MarketPlace.Entities;
using Microsoft.EntityFrameworkCore;

namespace App.Infrastructures.Data.Repositories
{
    public class ProductPhotoRepository : IProductPhotoRepository
    {
        private readonly AppDbContext _context;

        public ProductPhotoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreateProductPhoto(AddProductPhotoInputDto productPhoto, CancellationToken cancellationToken)
        {
            await _context.ProductPhotos.AddAsync(new ProductPhoto
            {
                FileName = productPhoto.FileName,
                FilePath = productPhoto.FilePath,
                ProductId = productPhoto.ProductId
            });

            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteProductPhoto(int id, CancellationToken cancellationToken)
        {
            ProductPhoto? productPhoto = await _context.ProductPhotos.FindAsync(id);

            productPhoto.IsDeleted = true;

            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<List<ProductPhotoOutputDto>> GetAllProductPhotos(CancellationToken cancellationToken)
        {
            var productPhotos = await _context.ProductPhotos.Select(pp => new ProductPhotoOutputDto
            {
                FileName = pp.FileName,
                FilePath = pp.FilePath,
                ProductId = pp.ProductId
            }).ToListAsync(cancellationToken);

            return productPhotos;
        }

        public async Task<ProductPhotoOutputDto>? GetProductPhotoBy(int id, CancellationToken cancellationToken)
        {
            var productPhoto = await _context.ProductPhotos.Where(pp => pp.Id == id).Select(pp =>
                new ProductPhotoOutputDto
                {
                    FileName = pp.FileName,
                    FilePath = pp.FilePath,
                    ProductId = pp.ProductId
                }).FirstAsync(cancellationToken);

            return productPhoto;
        }

        public async Task UpdateProductPhoto(EditProductPhotoInputDto productPhoto, CancellationToken cancellationToken)
        {
            var productPhotoToUpdate = await _context.ProductPhotos.Where(pp => pp.Id == productPhoto.Id)
                .FirstOrDefaultAsync(cancellationToken);

            productPhotoToUpdate.FileName = productPhoto.FileName;
            productPhotoToUpdate.FilePath = productPhoto.FilePath;
            productPhotoToUpdate.ProductId = productPhoto.ProductId;

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
