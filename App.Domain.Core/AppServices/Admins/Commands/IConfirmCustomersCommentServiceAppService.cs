namespace App.Domain.Core.AppServices.Admins.Commands
{
    public interface IConfirmCustomersCommentServiceAppService
    {
        Task<bool> ConfirmCustomersProductComment(int productCommentId, CancellationToken cancellationToken);
        Task<bool> ConfirmCustomersStoreComment(int storeCommentId, CancellationToken cancellationToken);
    }
}
