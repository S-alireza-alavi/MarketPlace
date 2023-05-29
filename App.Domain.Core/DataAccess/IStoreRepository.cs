using App.Domain.Core.DtoModels.Stores;

namespace App.Domain.Core.DataAccess
{
    public interface IStoreRepository
    {
        Task<List<StoreOutputDto>> GetAllStores(string? search);
        Task<StoreOutputDto> GetStoreBy(int id);
        Task CreateStore(AddStoreInputDto store);
        Task UpdateStore(EditStoreInputDto store);
        Task DeleteStore(int id);
        Task<int> StoresCount();
    }
}
