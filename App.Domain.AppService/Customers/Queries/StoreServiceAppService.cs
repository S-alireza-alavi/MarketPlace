using App.Domain.Core.AppServices.Customers.Queries;
using App.Domain.Core.DataAccess;
using App.Domain.Core.DtoModels.Stores;
using MarketPlace.Database;
using MarketPlace.Entities;
using Microsoft.EntityFrameworkCore;

namespace App.Domain.AppService.Customers.Queries;

public class StoreServiceAppService : IStoreServiceAppService
{
    private protected IStoreRepository _storeRepository;
    private protected AppDbContext _context;

    public StoreServiceAppService(IStoreRepository storeRepository, AppDbContext context)
    {
        _storeRepository = storeRepository;
        _context = context;
    }

    public async Task<List<StoreOutputDto>> GetAllStores(string? search, CancellationToken cancellationToken)
    {
        try
        {
            var stores = await _storeRepository.GetAllStores(search);

            return stores;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<StoreOutputDto> GetStore(int id, CancellationToken cancellationToken)
    {
        try
        {
            var store = await _storeRepository.GetStoreBy(id);

            return store;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<List<Store>> GetCategoryStores(int categoryId, CancellationToken cancellationToken)
    {
        try
        {
            var stores = await _context.Stores.Where(s => s.Products.Any(p => p.CategoryId == categoryId)).ToListAsync(cancellationToken);

            return stores;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public List<Store> Test(int categoryId)
    {
        try
        {
            var stores = _context.Stores.Where(s => s.Products.Any(p => p.CategoryId == categoryId)).ToList();

            return stores;
        }
        catch (Exception)
        {

            throw;
        }
    }
}