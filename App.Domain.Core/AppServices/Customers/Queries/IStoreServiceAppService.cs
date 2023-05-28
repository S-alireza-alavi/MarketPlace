using App.Domain.Core.DtoModels.Stores;
using MarketPlace.Entities;

namespace App.Domain.Core.AppServices.Customers.Queries;

public interface IStoreServiceAppService
{
    Task<List<StoreOutputDto>> GetAllStores(CancellationToken cancellationToken);
    Task<StoreOutputDto> GetStore(int id, CancellationToken cancellationToken);
    Task<List<Store>> GetCategoryStores(int categoryId, CancellationToken cancellationToken);

    List<Store> Test(int categoryId);
}