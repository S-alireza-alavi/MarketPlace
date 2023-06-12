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
    public class ProductDetailService : IProductDetailService
    {
        private readonly IProductRepository _productRepository;

        public ProductDetailService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ProductOutputDto> GetProductDetail(int productId, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetProductDetails(productId, cancellationToken);
            return product;
        }
    }
}
