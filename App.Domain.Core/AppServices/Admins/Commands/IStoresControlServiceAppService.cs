using App.Domain.Core.DtoModels.Stores;

namespace App.Domain.Core.AppServices.Admins.Commands
{
    public interface IStoresControlServiceAppService
    {
        Task<StoreOutputDto> GetStore(int storeId, CancellationToken cancellationToken);
        Task<StoreOutputDto> EditStore(EditStoreInputDto store, CancellationToken cancellationToken);
        Task DeleteStore(int storeId, CancellationToken cancellationToken);
    }
}
