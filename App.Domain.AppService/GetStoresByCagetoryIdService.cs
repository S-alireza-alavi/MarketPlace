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
    public class GetStoresByCagetoryIdService : IGetStoresByCagetoryIdService
    {
        private readonly IStoreRepository _storeRepository;

        public GetStoresByCagetoryIdService(IStoreRepository storeRepository)
        {
            _storeRepository = storeRepository;
        }

        public async Task<List<StoreOutputDto>> GetStoresByCagetoryId(int categoryId, CancellationToken cancellationToken)
        {
            var stores = await _storeRepository.GetStoresByCategoryId(categoryId, cancellationToken);
            return stores;
        }
    }
}
