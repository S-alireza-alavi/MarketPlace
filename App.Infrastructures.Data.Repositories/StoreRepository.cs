using App.Domain.Core.DataAccess;
using App.Domain.Core.DtoModels.Stores;
using App.Domain.Core.DtoModels.Users;
using MarketPlace.Database;
using MarketPlace.Entities;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace App.Infrastructures.Data.Repositories
{
    public class StoreRepository : IStoreRepository
    {
        private readonly AppDbContext _context;

        public StoreRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreateStore(AddStoreInputDto store)
        {
            await _context.Stores.AddAsync(new Store
            {
                Name = store.Name,
                SellerId = store.SellerId,
                Description = store.Description,
                AddressId = store.AddressId,
                CreatedAt = DateTime.Now
            });

            await _context.SaveChangesAsync();
        }

        public async Task DeleteStore(int id)
        {
            try
            {
                Store? store = await _context.Stores.FindAsync(id);

                store.IsDeleted = true;
            }
            catch (Exception ex)
            {
                throw new Exception("Something went wrong", ex.InnerException);
            }

            //todo: سوال: این باید اینجا باشه یا توی کد try
            await _context.SaveChangesAsync();
        }

        public async Task<int> StoresCount()
        {
            var count = await _context.Stores.AsNoTracking().CountAsync();

            return count;
        }

        public Task<List<StoreOutputDto>> GetAllStores()
        {
            var stores = _context.Stores.Select(s => new StoreOutputDto
            {
                Id = s.Id,
                Name = s.Name,
                Description = s.Description,
                AddressId = s.AddressId,
                CreatedAt = s.CreatedAt
            }).ToListAsync();

            return stores;
        }

        public async Task<List<StoreOutputDto>> GetAllStores(string? search)
        {
            var stores = await _context.Stores.Select(s => new StoreOutputDto
            {
                Name = s.Name,
                SellerId = s.SellerId,
                Description = s.Description,
                AddressId = s.AddressId,
                CreatedAt = s.CreatedAt

            }).ToListAsync();

            //foreach (var item in stores)
            //{

            //}

            if (string.IsNullOrEmpty(search))
            {
                return stores;
            }
            else
            {
                stores = stores.Where(s => s.Name.Contains(search) || s.Seller.UserName.Contains(search)).ToList();

                return stores;
            }
        }

        public async Task<StoreOutputDto> GetStoreBy(int id)
        {
            var store = await _context.Stores.FindAsync(id);

            StoreOutputDto storeDto = new()
            {
                Name = store.Name,
                SellerId = store.SellerId,
                Description = store.Description,
                AddressId = store.AddressId,
                CreatedAt = store.CreatedAt,
                Seller = store.Seller
            };

            return storeDto;
        }

        public async Task UpdateStore(EditStoreInputDto store)
        {
            var storeToUpdate = await _context.Stores.Where(s => s.Id == store.Id)
                .FirstOrDefaultAsync();

            storeToUpdate.Name = store.Name;
            storeToUpdate.SellerId = store.SellerId;
            storeToUpdate.Description = store.Description;
            storeToUpdate.AddressId = store.AddressId;
            storeToUpdate.CreatedAt = store.CreatedAt;

            await _context.SaveChangesAsync();
        }
    }
}
