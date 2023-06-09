using App.Domain.Core.AppServices.Sellers.Commands;
using App.Domain.Core.DataAccess;
using App.Domain.Core.DtoModels.StoreAddresses;

namespace App.Domain.AppService.Sellers.Commands
{
    public class AddNewStoreAddressService : IAddNewStoreAddressService
    {
        private readonly IStoreAddressRepository _storeAddressRepository;

        public AddNewStoreAddressService(IStoreAddressRepository storeAddressRepository)
        {
            _storeAddressRepository = storeAddressRepository;
        }

        public async Task CreateStoreAddress(AddStoreAddressInputDto storeAddress, CancellationToken cancellationToken)
        {
            await _storeAddressRepository.CreateStoreAddress(storeAddress, cancellationToken);
        }
    }
}
