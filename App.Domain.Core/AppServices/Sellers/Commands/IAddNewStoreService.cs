using App.Domain.Core.DtoModels.StoreAddresses;
using App.Domain.Core.DtoModels.Stores;

namespace App.Domain.Core.AppServices.Sellers.Commands
{
    public interface IAddNewStoreService
    {
        Task<int> AddNewStore(AddStoreInputDto inputDto, CancellationToken cancellationToken);
    }
}
