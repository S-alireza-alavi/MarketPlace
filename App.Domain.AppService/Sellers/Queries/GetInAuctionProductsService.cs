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
    public class GetInAuctionProductsService : IGetInAuctionProductsService
    {
        private readonly IProductRepository _productRepository;

        public GetInAuctionProductsService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Task<List<ProductOutputDto>> GetInAuctionProducts(CancellationToken cancellationToken)
        {
            var products = _productRepository.GetAllInAuctionProducts(cancellationToken);
            return products;
        }
    }
}
