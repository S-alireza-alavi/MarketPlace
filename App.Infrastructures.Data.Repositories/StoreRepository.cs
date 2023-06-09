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

        public async Task<int> CreateStore(AddStoreInputDto inputDto, CancellationToken cancellationToken)
        {
            var store = new Store
            {
                Name = inputDto.Name,
                SellerId = inputDto.SellerId,
                Description = inputDto.Description,
                CreatedAt = DateTime.Now
            };

            await _context.Stores.AddAsync(store, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return store.Id;
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

        public async Task<List<StoreOutputDto>> GetAllStores()
        {
            var stores = await _context.Stores.Select(s => new StoreOutputDto
            {
                Id = s.Id,
                Name = s.Name,
                Description = s.Description,
                CreatedAt = s.CreatedAt
            }).ToListAsync();

            return stores;
        }

        public async Task<List<StoreOutputDto>> GetAllStores(string? search)
        {
            var stores = await _context.Stores.Include(s => s.Seller).Include(s => s.StoreAddresses).Where(s => s.IsDeleted == false).ToListAsync();

            var outputDto = stores.Select(s => new StoreOutputDto
            {
                Id = s.Id,
                Name = s.Name,
                SellerUserName = s.Seller.UserName,
                Description = s.Description,
                CreatedAt = s.CreatedAt
            }).ToList();

            //foreach (var item in stores)
            //{

            //}

            if (string.IsNullOrEmpty(search))
            {
                return outputDto;
            }
            else
            {
                stores = stores.Where(s => s.Name.Contains(search) || s.Seller.UserName.Contains(search)).ToList();

                return outputDto;
            }
        }

        public async Task<StoreOutputDto> GetStoreBy(int id)
        {
            var store = await _context.Stores.FindAsync(id);

            StoreOutputDto storeDto = new()
            {
                Id = id,
                Name = store.Name,
                SellerId = store.SellerId,
                Description = store.Description,
                CreatedAt = store.CreatedAt,
                Seller = store.Seller
            };

            return storeDto;
        }

        public async Task<List<StoreOutputDto>> GetAllStoresBySellerId(int sellerId, CancellationToken cancellationToken)
        {
            var sellerStores = await _context.Stores.Where(s => s.SellerId == sellerId).ToListAsync(cancellationToken);

            var outputDto = sellerStores.Select(s => new StoreOutputDto
            {
                Id = s.Id,
                Name = s.Name,
                Description = s.Description,
                CreatedAt = s.CreatedAt
            }).ToList();

            return outputDto;
        }

        public async Task UpdateStore(EditStoreInputDto store)
        {
            var storeToUpdate = await _context.Stores.Where(s => s.Id == store.Id)
                .FirstOrDefaultAsync();

            storeToUpdate.Name = store.Name;
            storeToUpdate.SellerId = store.SellerId;
            storeToUpdate.Description = store.Description;
            storeToUpdate.CreatedAt = store.CreatedAt;

            await _context.SaveChangesAsync();
        }
    }
}
