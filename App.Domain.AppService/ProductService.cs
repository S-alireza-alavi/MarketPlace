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
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ProductOutputDto> GetProductBy(int productId, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetProductBy(productId, cancellationToken);
            return product;
        }

        public async Task<List<ProductOutputDto>> GetRandomProducts(CancellationToken cancellationToken)
        {
            var randomProducts = await _productRepository.GetRandomProducts(cancellationToken);
            return randomProducts;
        }
    }
}
