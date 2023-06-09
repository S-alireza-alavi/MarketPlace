using App.Domain.Core.AppServices.Sellers.Queries;
using App.Domain.Core.DataAccess;
using App.Domain.Core.DtoModels.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.AppService.Sellers.Queries
{
    public class GetAllStoresBySellerId : IGetAllStoresBySellerId
    {
        private readonly IStoreRepository _storeRepository;

        public GetAllStoresBySellerId(IStoreRepository storeRepository)
        {
            _storeRepository = storeRepository;
        }

        async Task<List<StoreOutputDto>> IGetAllStoresBySellerId.GetAllStoresBySellerId(int sellerId, CancellationToken cancellationToken)
        {
            var sellerStores = await _storeRepository.GetAllStoresBySellerId(sellerId, cancellationToken);
            return sellerStores;
        }
    }
}
