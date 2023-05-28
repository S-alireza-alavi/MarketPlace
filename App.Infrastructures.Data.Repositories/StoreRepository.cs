using App.Domain.Core.DataAccess;
using App.Domain.Core.DtoModels.Stores;
using App.Domain.Core.Entities;
using Microsoft.EntityFrameworkCore;
using App.Infrastructures.Database.SqlServer.Data;

namespace App.Infrastructures.Data.Repositories
{
    public class StoreRepository : IStoreRepository
    {
        private readonly AppDbContext _context;

        public StoreRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreateStore(AddStoreInputDto store, CancellationToken cancellationToken)
        {
            await _context.Stores.AddAsync(new Store
            {
                Name = store.Name,
                SellerId = store.SellerId,
                Description = store.Description,
                AddressId = store.AddressId,
                CreatedAt = DateTime.Now
            });

            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteStore(int id, CancellationToken cancellationToken)
        {
            Store? store = await _context.Stores.FindAsync(id);

            store.IsDeleted = true;

            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<int> StoresCount(CancellationToken cancellationToken)
        {
            var count = await _context.Stores.AsNoTracking().CountAsync(cancellationToken);

            return count;
        }

        public async Task<List<StoreOutputDto>> GetAllStores(CancellationToken cancellationToken)
        {
            var stores = await _context.Stores.Select(s => new StoreOutputDto
            {
                Name = s.Name,
                SellerId = s.SellerId,
                Description = s.Description,
                AddressId = s.AddressId,
                CreatedAt = s.CreatedAt

            }).ToListAsync(cancellationToken);

            return stores;
        }

        public async Task<StoreOutputDto>? GetStoreBy(int id, CancellationToken cancellationToken)
        {
            var store = await _context.Stores.Where(s => s.Id == id).Select(s =>
                new StoreOutputDto
                {
                    Name = s.Name,
                    SellerId = s.SellerId,
                    Description = s.Description,
                    AddressId = s.AddressId,
                    CreatedAt = s.CreatedAt
                }).FirstAsync(cancellationToken);

            return store;
        }

        public async Task UpdateStore(EditStoreInputDto store, CancellationToken cancellationToken)
        {
            var storeToUpdate = await _context.Stores.Where(s => s.Id == store.Id)
                .FirstOrDefaultAsync(cancellationToken);

            storeToUpdate.Name = store.Name;
            storeToUpdate.SellerId = store.SellerId;
            storeToUpdate.Description = store.Description;
            storeToUpdate.AddressId = store.AddressId;
            storeToUpdate.CreatedAt = store.CreatedAt;

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
