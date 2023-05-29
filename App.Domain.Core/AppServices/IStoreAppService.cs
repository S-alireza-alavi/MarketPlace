using App.Domain.Core.DtoModels.Stores;

namespace App.Domain.Core.AppServices
{
    public interface IStoreAppService
    {
        Task<List<StoreOutputDto>> GetAllStores();
        Task<StoreOutputDto> GetStoreBy(int id);
        Task UpdateStore(EditStoreInputDto store);
        Task DeleteStore(int id);
    }
}
