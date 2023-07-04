using App.Domain.Core.AppServices;
using App.Domain.Core.DataAccess;
using App.Domain.Core.DtoModels.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.AppService
{
    public class FilterProductsSearchService : IFilterProductsSearchService
    {
        private readonly IProductRepository _productRepository;

        public FilterProductsSearchService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<List<ProductOutputDto>> FilterProductsSearch(string searchPhrase, CancellationToken cancellationToken)
        {
            var filteredProducts = await _productRepository.FilterProductsSearch(searchPhrase, cancellationToken);
            return filteredProducts;
        }
    }
}
