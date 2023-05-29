using App.Domain.Core.DtoModels.Stores;

namespace App.Domain.Core.AppServices.Admins.Queries
{
    public interface IStoresServiceAppService
    {
        Task<List<StoreOutputDto>> GetAllStores(string? search, CancellationToken cancellationToken);
        Task<StoreOutputDto> GetStoreBy(int id, CancellationToken cancellationToken);
        Task UpdateStore(EditStoreInputDto store, CancellationToken cancellationToken);
        Task DeleteStore(int id, CancellationToken cancellationToken);
        Task<int> GetStoresCount(CancellationToken cancellationToken);
    }
}
