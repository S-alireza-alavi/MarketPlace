using App.Domain.Core.DtoModels.ProductComments;
using App.Domain.Core.DtoModels.StoreComments;

namespace App.Domain.Core.AppServices.Admins.Commands
{
    public interface IConfirmCustomersCommentServiceAppService
    {
        Task<List<ProductCommentOutputDto>> GetAllUnConfirmedProductComments(CancellationToken cancellationToken);
        Task<bool> ConfirmCustomersProductComment(int productCommentId, CancellationToken cancellationToken);
        Task<List<StoreCommentOutputDto>> GetAllUnConfirmedStoreComments(CancellationToken cancellationToken);
        Task<bool> ConfirmCustomersStoreComment(int storeCommentId, CancellationToken cancellationToken);
    }
}
