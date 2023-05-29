using App.Domain.Core.AppServices.Admins.Queries;
using App.Domain.Core.DataAccess;
using App.Domain.Core.DtoModels.Stores;

namespace App.Domain.AppService.Admins.Queries
{
    public class StoresServiceAppService : IStoresServiceAppService
    {
        private readonly IStoreRepository _storeRepository;

        public StoresServiceAppService(IStoreRepository storeRepository)
        {
            _storeRepository = storeRepository;
        }

        public async Task DeleteStore(int id, CancellationToken cancellationToken)
        {
            await _storeRepository.DeleteStore(id);
        }

        public Task<List<StoreOutputDto>> GetAllStores(string? search, CancellationToken cancellationToken)
        {
            var stores = _storeRepository.GetAllStores(search);
            return stores;
        }

        public async Task<StoreOutputDto> GetStoreBy(int id, CancellationToken cancellationToken)
        {
            var store = await _storeRepository.GetStoreBy(id);
            return store;
        }

        public Task<int> GetStoresCount(CancellationToken cancellationToken)
        {
            var count = _storeRepository.StoresCount();

            return count;
        }

        public async Task UpdateStore(EditStoreInputDto store, CancellationToken cancellationToken)
        {
            await _storeRepository.UpdateStore(store);
        }
    }
}
