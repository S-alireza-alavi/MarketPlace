using App.Domain.Core.DataAccess;
using App.Domain.Core.DtoModels.StoreAddresses;
using MarketPlace.Database;
using MarketPlace.Entities;
using Microsoft.EntityFrameworkCore;

namespace App.Infrastructures.Data.Repositories
{
    public class StoreAddressRepository : IStoreAddressRepository
    {
        private readonly AppDbContext _context;

        public StoreAddressRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreateStoreAddress(AddStoreAddressInputDto storeAddress, CancellationToken cancellationToken)
        {
            var address = new StoreAddress
            {
                StoreId = storeAddress.StoreId,
                FullAddress = storeAddress.FullAddress,
                IsDeleted = false
            };

            await _context.StoreAddresses.AddAsync(address);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteStoreAddress(int id)
        {
            try
            {
                StoreAddress? storeAddress = await _context.StoreAddresses.FindAsync(id);

                storeAddress.IsDeleted = true;

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Something went wrong", ex.InnerException);
            }
        }

        public async Task<List<StoreAddressOutputDto>> GetAllStoreAddresses()
        {
            var storeAddresses = await _context.StoreAddresses.Select(sa => new StoreAddressOutputDto
            {
                Id = sa.Id,
                StoreId = sa.StoreId,
                FullAddress = sa.FullAddress,
                IsDeleted = sa.IsDeleted
            }).ToListAsync();

            return storeAddresses;
        }

        public async Task<StoreAddressOutputDto> GetStoreAddressBy(int id)
        {
            var storeAddress = await _context.StoreAddresses.FindAsync(id);

            StoreAddressOutputDto storeAddressDto = new()
            {
                Id = storeAddress.Id,
                StoreId = storeAddress.StoreId,
                FullAddress = storeAddress.FullAddress,
                IsDeleted = storeAddress.IsDeleted
            };

            return storeAddressDto;
        }

        public async Task UpdateStoreAddress(EditStoreAddressInputDto storeAddress)
        {
            var storeAddressToUpdate = await _context.StoreAddresses.Where(sa => sa.Id == storeAddress.Id)
                .FirstOrDefaultAsync();

            storeAddressToUpdate.FullAddress = storeAddress.FullAddress;

            await _context.SaveChangesAsync();
        }
    }
}
