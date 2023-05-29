using App.Domain.Core.AppServices;
using App.Domain.Core.DataAccess;
using App.Domain.Core.DtoModels.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.AppService
{
    public class StoreAppService : IStoreAppService
    {
        private readonly IStoreRepository _storeRepository;

        public StoreAppService(IStoreRepository storeRepository)
        {
            _storeRepository = storeRepository;
        }

        public async Task DeleteStore(int id)
        {
            await _storeRepository.DeleteStore(id);
        }

        public async Task<List<StoreOutputDto>> GetAllStores()
        {
            var stores = await _storeRepository.GetAllStores();
            return stores;
        }

        public async Task<StoreOutputDto> GetStoreBy(int id)
        {
            var store = await _storeRepository.GetStoreBy(id);
            return store;
        }

        public async Task UpdateStore(EditStoreInputDto store)
        {
            await _storeRepository.UpdateStore(store);
        }
    }
}
