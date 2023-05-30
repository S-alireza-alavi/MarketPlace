using App.Domain.Core.AppServices.Admins.Commands;
using App.Domain.Core.DataAccess;
using App.Domain.Core.DtoModels.Products;

namespace App.Domain.AppService.Admins.Commands
{
    public class ConfirmSellersProductServiceAppService : IConfirmSellersProductServiceAppService
    {
        private readonly IProductRepository _productRepository;

        public ConfirmSellersProductServiceAppService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<bool> ConfirmSellersProductAsync(int productId, CancellationToken cancellationToken)
        {
            bool isDone;

            var product = await _productRepository.GetProductBy(productId, cancellationToken);

            if (product != null)
            {
                await _productRepository.UpdateProduct(new EditProductInputDto
                {
                    Id = product.Id,
                    Name = product.Name,
                    CategoryId = product.CategoryId,
                    BrandId = product.BrandId,
                    StoreId = product.StoreId,
                    Weight = product.Weight,
                    Description = product.Description,
                    Count = product.Count,
                    ModelId = product.Id,
                    Price = product.Price,
                    IsActive = product.IsActive = true
                }, cancellationToken);

                isDone = true;
            }
            else
            {
                isDone = false;
            }

            return isDone;
        }

        public Task<List<ProductOutputDto>> GetAllInActiveProducts(CancellationToken cancellationToken)
        {
            var inActiveProducts = _productRepository.GetAllInActiveProducts(cancellationToken);
            return inActiveProducts;
        }
    }
}
