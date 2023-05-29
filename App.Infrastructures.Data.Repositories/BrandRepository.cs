using App.Domain.Core.DataAccess;
using App.Domain.Core.DtoModels.Brands;
using MarketPlace.Database;
using MarketPlace.Entities;
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

        public async Task CreateBrand(AddBrandInputDto brand)
        {
            await _context.Brands.AddAsync(new Brand
            {
                Name = brand.Name
            });

            await _context.SaveChangesAsync();
        }

        public async Task DeleteBrand(int id)
        {
            Brand? brand = await _context.Brands.FindAsync(id);

            brand.IsDeleted = true;

            await _context.SaveChangesAsync();
        }

        public async Task<List<BrandOutputDto>> GetAllBrands()
        {
            var brands = await _context.Brands.Select(b => new BrandOutputDto
            {
                Id = b.Id,
                Name = b.Name
            }).ToListAsync();

            return brands;
        }

        public async Task<BrandOutputDto> GetBrandBy(int id)
        {
            var brand = await _context.Brands.Where(b => b.Id == id).Select(b => new BrandOutputDto
            {
                Id = b.Id,
                Name = b.Name
            }).FirstAsync();

            return brand;
        }

        public async Task UpdateBrand(EditBrandInputDto brand)
        {
            var brandToUpdate = await _context.Brands.Where(b => b.Id == brand.Id).FirstOrDefaultAsync();

            brandToUpdate.Name = brand.Name;

            await _context.SaveChangesAsync();
        }
    }
}
