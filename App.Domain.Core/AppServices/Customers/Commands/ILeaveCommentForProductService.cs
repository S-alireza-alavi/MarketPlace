using App.Domain.Core.DtoModels.ProductComments;

namespace App.Domain.Core.AppServices.Customers.Commands
{
    public interface ILeaveCommentForProductService
    {
        Task LeaveCommentForProduct(AddProductCommentInputDto comment, CancellationToken cancellationToken);
    }
}
