using App.Domain.Core.AppServices.Customers.Queries;
using App.Domain.Core.DataAccess;
using App.Domain.Core.DtoModels.Products;
using App.Domain.Core.DtoModels.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.AppService.Customers.Queries
{
    public class GetProductsByCategoriesService : IGetProductsByCategoriesService
    {
        private readonly IProductRepository _productRepository;

        public GetProductsByCategoriesService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<List<ProductOutputDto>> GetProductsByCategories(int categoryId, CancellationToken cancellationToken)
        {
            var products = await _productRepository.GetProductsByCategory(categoryId, cancellationToken);
            return products;
        }
    }
}
