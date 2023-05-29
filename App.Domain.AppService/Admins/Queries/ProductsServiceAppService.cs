using App.Domain.Core.AppServices.Admins.Queries;
using App.Domain.Core.DataAccess;
using App.Domain.Core.DtoModels.Products;

namespace App.Domain.AppService.Admins.Queries
{
    public class ProductsServiceAppService : IProductsServiceAppService
    {
        private readonly IProductRepository _productRepository;

        public ProductsServiceAppService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task DeleteProduct(int id, CancellationToken cancellationToken)
        {
            await _productRepository.DeleteProduct(id, cancellationToken);
        }

        public Task<List<ProductOutputDto>> GetAllProducts(string? search, CancellationToken cancellationToken)
        {
            var products = _productRepository.GetAllProducts(search, cancellationToken);
            return products;
        }

        public Task<ProductOutputDto> GetProductBy(int id, CancellationToken cancellationToken)
        {
            var product = _productRepository.GetProductBy(id, cancellationToken);
            return product;
        }

        public async Task<int> GetProductsCount(CancellationToken cancellationToken)
        {
            var productsCount = await _productRepository.ProductsCount(cancellationToken);

            return productsCount;
        }

        public async Task UpdateProduct(EditProductInputDto store, CancellationToken cancellationToken)
        {
            await _productRepository.UpdateProduct(store, cancellationToken);
        }
    }
}
