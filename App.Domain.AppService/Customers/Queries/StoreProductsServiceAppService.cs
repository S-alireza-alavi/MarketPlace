using App.Domain.Core.AppServices.Customers.Queries;
using App.Domain.Core.DtoModels.Products;
using App.Domain.Core.Entities;
using App.Infrastructures.Database.SqlServer.Data;

namespace App.Domain.AppService.Customers.Queries;

public class StoreProductsServiceAppService : IStoreProductsServiceAppService
{
    private readonly AppDbContext _context;
    private readonly IStoreServiceAppService _storeService;

    public StoreProductsServiceAppService(AppDbContext context, IStoreServiceAppService storeService)
    {
        _context = context;
        _storeService = storeService;
    }

    public async Task<List<ProductOutputDto>> GetStoreProducts(int storeId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
        //Get the store first
        //var store = await _storeService.GetStore(storeId, cancellationToken);

        //query to return store products
        //var products = await _context.Products.Include(p => p.Store).ThenInclude(s => s.Products)
        //    .Where(p => p.StoreId == storeId).ToListAsync(cancellationToken);

        //return products;
    }

    public List<Product> Test(int storeId)
    {
        throw new NotImplementedException();
        //var products = _context.Products.Include(p => p.Store).ThenInclude(s => s.Products)
        //    .Where(p => p.StoreId == storeId).ToList();

        //return products;
    }
}