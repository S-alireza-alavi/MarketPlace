using App.Domain.Core.AppServices.Customers.Queries;
using App.Domain.Core.DataAccess;
using App.Domain.Core.DtoModels.ProductComments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.AppService.Customers.Queries
{
    public class ProductCommentService : IProductCommentService
    {
        private readonly IProductCommentRepository _productCommentRepository;

        public ProductCommentService(IProductCommentRepository productCommentRepository)
        {
            _productCommentRepository = productCommentRepository;
        }

        public async Task<List<ProductCommentOutputDto>> GetConfirmedCommentsForProduct(int productId, CancellationToken cancellationToken)
        {
            var productComments = await _productCommentRepository.GetConfirmedCommentsForProduct(productId, cancellationToken);
            return productComments;
        }
    }
}
