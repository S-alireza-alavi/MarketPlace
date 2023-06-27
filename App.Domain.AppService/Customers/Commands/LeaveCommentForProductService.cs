using App.Domain.Core.AppServices.Customers.Commands;
using App.Domain.Core.DataAccess;
using App.Domain.Core.DtoModels.ProductComments;

namespace App.Domain.AppService.Customers.Commands
{
    public class LeaveCommentForProductService : ILeaveCommentForProductService
    {
        private readonly IProductCommentRepository _productCommentRepository;

        public LeaveCommentForProductService(IProductCommentRepository productCommentRepository)
        {
            _productCommentRepository = productCommentRepository;
        }

        public async Task LeaveCommentForProduct(AddProductCommentInputDto comment, CancellationToken cancellationToken)
        {
           await _productCommentRepository.CreateProductComment(comment, cancellationToken);
        }
    }
}
