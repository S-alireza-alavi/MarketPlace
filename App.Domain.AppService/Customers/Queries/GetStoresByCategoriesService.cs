using App.Domain.Core.AppServices.Customers.Queries;
using App.Domain.Core.DataAccess;
using App.Domain.Core.DtoModels.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.AppService.Customers.Queries
{
    public class GetStoresByCategoriesService : IGetStoresByCategoriesService
    {
        private readonly IStoreRepository _storeRepository;

        public GetStoresByCategoriesService(IStoreRepository storeRepository)
        {
            _storeRepository = storeRepository;
        }

        public async Task<List<StoreOutputDto>> GetStoresByCategories(int categoryId, CancellationToken cancellationToken)
        {
            var stores = await _storeRepository.GetStoresByCategory(categoryId, cancellationToken);
            return stores;
        }
    }
}
