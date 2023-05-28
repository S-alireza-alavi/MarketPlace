using App.Domain.Core.AppServices.Admins.Commands;
using App.Domain.Core.DataAccess;
using App.Domain.Core.DtoModels.Products;

namespace App.Domain.AppService.Admins.Commands
{
    public class ProductsControlServiceAppService : IProductsControlServiceAppService
    {
        private readonly IProductRepository _productRepository;

        public ProductsControlServiceAppService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task DeleteProduct(int productId, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetProductBy(productId, cancellationToken);

            if (product != null)
            {
                await _productRepository.DeleteProduct(product.Id, cancellationToken);
            }
        }

        public async Task<ProductOutputDto> EditProduct(EditProductInputDto product, CancellationToken cancellationToken)
        {
            var productToUpdate = await _productRepository.GetProductBy(product.Id, cancellationToken);

            if (productToUpdate != null)
            {
                productToUpdate.Name = product.Name;
                productToUpdate.Weight = product.Weight;
                productToUpdate.Description = product.Description;
                productToUpdate.Count = product.Count;
                productToUpdate.Price = product.Price;
                productToUpdate.IsActive = product.IsActive;
            }

            return productToUpdate;
        }

        public async Task<ProductOutputDto> GetProduct(int productId, CancellationToken cancellationToken)
        {
            try
            {
                var product = await _productRepository.GetProductBy(productId, cancellationToken);

                return product;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
