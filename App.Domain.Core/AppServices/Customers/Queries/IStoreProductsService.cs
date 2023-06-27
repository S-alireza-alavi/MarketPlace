using App.Domain.Core.DtoModels.Products;
using MarketPlace.Entities;

namespace App.Domain.Core.AppServices.Customers.Queries;

public interface IStoreProductsService
{
    Task<List<ProductOutputDto>> GetStoreProducts(int storeId, CancellationToken cancellationToken);

    List<Product> Test(int storeId);
}