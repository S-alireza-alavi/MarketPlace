using App.Domain.Core.DtoModels.Stores;
using MarketPlace.Entities;

namespace App.Domain.Core.DataAccess
{
    public interface IStoreRepository
    {
        Task<List<StoreOutputDto>> GetAllStores();
        Task<List<StoreOutputDto>> GetAllStores(string? search);
        Task<StoreOutputDto> GetStoreBy(int id);
        Task<List<StoreOutputDto>> GetAllStoresBySellerId(int sellerId, CancellationToken cancellationToken);
        Task<int> CreateStore(AddStoreInputDto inputDto, CancellationToken cancellationToken);
        Task UpdateStore(EditStoreInputDto store);
        Task DeleteStore(int id);
        Task<int> StoresCount();
    }
}
