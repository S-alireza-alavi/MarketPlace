using App.Domain.Core.AppServices.Sellers.Commands;
using App.Domain.Core.DataAccess;
using App.Domain.Core.DtoModels.StoreAddresses;
using App.Domain.Core.DtoModels.Stores;
using MarketPlace.Entities;

namespace App.Domain.AppService.Sellers.Commands
{
    public class AddNewStoreService : IAddNewStoreService
    {
        private readonly IStoreRepository _storeRepository;

        public AddNewStoreService(IStoreRepository storeRepository)
        {
            _storeRepository = storeRepository;
        }

        public async Task<int> AddNewStore(AddStoreInputDto inputDto, CancellationToken cancellationToken)
        {
            var result = await _storeRepository.CreateStore(inputDto, cancellationToken);
            return result;
        }
    }
}
