using App.Domain.Core.AppServices.Admins.Commands;
using App.Domain.Core.DtoModels.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Domain.Core.DataAccess;

namespace App.Domain.AppService.Admins.Commands
{
    public class StoresControlServiceAppService : IStoresControlServiceAppService
    {
        private readonly IStoreRepository _storeRepository;

        public StoresControlServiceAppService(IStoreRepository storeRepository)
        {
            _storeRepository = storeRepository;
        }

        public async Task DeleteStore(int storeId, CancellationToken cancellationToken)
        {
            var store = await _storeRepository.GetStoreBy(storeId, cancellationToken);

            if (store != null)
            {
                await _storeRepository.DeleteStore(store.Id, cancellationToken);
            }
        }

        public async Task<StoreOutputDto> EditStore(EditStoreInputDto store, CancellationToken cancellationToken)
        {
            var storeToUpdate = await _storeRepository.GetStoreBy(store.Id, cancellationToken);

            if (storeToUpdate != null)
            {
                storeToUpdate.Name = store.Name;
                storeToUpdate.Description = store.Description;
                storeToUpdate.Address.FullAddress = store.Address.FullAddress;
            }

            return storeToUpdate;
        }

        public async Task<StoreOutputDto> GetStore(int storeId, CancellationToken cancellationToken)
        {
            try
            {
                var store = await _storeRepository.GetStoreBy(storeId, cancellationToken);

                return store;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
