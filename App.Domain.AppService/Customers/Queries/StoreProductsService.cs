using App.Domain.Core.AppServices.Customers.Queries;
using App.Domain.Core.DataAccess;
using App.Domain.Core.DtoModels.Products;
using MarketPlace.Database;
using MarketPlace.Entities;

namespace App.Domain.AppService.Customers.Queries;

public class StoreProductsService : IStoreProductsService
{
    private readonly AppDbContext _context;
    private readonly IStoreServiceAppService _storeService;
    private readonly IStoreRepository _storeRepository;

    public StoreProductsService(AppDbContext context, IStoreServiceAppService storeService, IStoreRepository storeRepository)
    {
        _context = context;
        _storeService = storeService;
        _storeRepository = storeRepository;
    }

    public async Task<List<ProductOutputDto>> GetStoreProducts(int storeId, CancellationToken cancellationToken)
    {
        var products = await _storeRepository.GetStoreProducts(storeId, cancellationToken);
        return products;
    }

    public List<Product> Test(int storeId)
    {
        throw new NotImplementedException();
        //var products = _context.Products.Include(p => p.Store).ThenInclude(s => s.Products)
        //    .Where(p => p.StoreId == storeId).ToList();

        //return products;
    }
}