using App.Domain.Core.DataAccess;
using App.Domain.Core.DtoModels.Brands;
using App.Domain.Core.Entities;
using App.Infrastructures.Database.SqlServer.Data;
using Microsoft.EntityFrameworkCore;

namespace App.Infrastructures.Data.Repositories
{
    public class BrandRepository : IBrandRepository
    {
        private readonly AppDbContext _context;

        public BrandRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreateBrand(AddBrandInputDto brand, CancellationToken cancellationToken)
        {
            await _context.Brands.AddAsync(new Brand
            {
                Name = brand.Name
            });

            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteBrand(int id, CancellationToken cancellationToken)
        {
            Brand? brand = await _context.Brands.FindAsync(id);

            brand.IsDeleted = true;

            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<List<BrandOutputDto>> GetAllBrands(CancellationToken cancellationToken)
        {
            var brands = await _context.Brands.Select(b => new BrandOutputDto
            {
                Id = b.Id,
                Name = b.Name
            }).ToListAsync(cancellationToken);

            return brands;
        }

        public async Task<BrandOutputDto>? GetBrandBy(int id, CancellationToken cancellationToken)
        {
            var brand = await _context.Brands.Where(b => b.Id == id).Select(b => new BrandOutputDto
            {
                Id = b.Id,
                Name = b.Name
            }).FirstAsync(cancellationToken);

            return brand;
        }

        public async Task UpdateBrand(EditBrandInputDto brand, CancellationToken cancellationToken)
        {
            var brandToUpdate = await _context.Brands.Where(b => b.Id == brand.Id).FirstOrDefaultAsync(cancellationToken);

            brandToUpdate.Name = brand.Name;

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
