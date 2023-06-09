using App.Domain.Core.AppServices.Sellers.Commands;
using App.Domain.Core.DataAccess;
using App.Domain.Core.DtoModels.ProductPhotos;
using App.Domain.Core.DtoModels.Products;

namespace App.Domain.AppService.Sellers.Commands
{
    public class AddNewProductService : IAddNewProductService
    {
        private readonly IProductRepository _productRepository;

        public AddNewProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Task<int> AddNewProduct(AddProductInputDto product, CancellationToken cancellationToken)
        {
            var result = _productRepository.CreateProduct(product, cancellationToken);
            return result;
        }
    }
}
