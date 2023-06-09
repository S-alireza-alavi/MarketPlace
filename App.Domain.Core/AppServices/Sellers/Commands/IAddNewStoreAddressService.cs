using App.Domain.Core.DtoModels.StoreAddresses;

namespace App.Domain.Core.AppServices.Sellers.Commands
{
    public interface IAddNewStoreAddressService
    {
        Task CreateStoreAddress(AddStoreAddressInputDto storeAddress, CancellationToken cancellationToken);
    }
}
