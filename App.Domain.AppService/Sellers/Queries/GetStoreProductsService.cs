using App.Domain.Core.AppServices.Sellers.Queries;
using App.Domain.Core.DataAccess;
using App.Domain.Core.DtoModels.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.AppService.Sellers.Queries
{
    public class GetStoreProductsService : IGetStoreProductsService
    {
        private readonly IStoreRepository _storeRepository;

        public GetStoreProductsService(IStoreRepository storeRepository)
        {
            _storeRepository = storeRepository;
        }

        public Task<List<ProductOutputDto>> GetStoreProducts(int storeId, CancellationToken cancellationToken)
        {
            var products = _storeRepository.GetStoreProducts(storeId, cancellationToken);
            return products;
        }
    }
}
