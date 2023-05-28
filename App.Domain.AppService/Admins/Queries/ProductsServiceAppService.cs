using App.Domain.Core.AppServices.Admins.Queries;
using App.Domain.Core.DataAccess;

namespace App.Domain.AppService.Admins.Queries
{
    public class ProductsServiceAppService : IProductsServiceAppService
    {
        private readonly IProductRepository _productRepository;

        public ProductsServiceAppService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<int> GetProductsCount(CancellationToken cancellationToken)
        {
            var productsCount = await _productRepository.ProductsCount(cancellationToken);

            return productsCount;
        }
    }
}
