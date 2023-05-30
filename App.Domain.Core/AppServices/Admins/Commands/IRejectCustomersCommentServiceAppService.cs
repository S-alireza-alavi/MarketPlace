namespace App.Domain.Core.AppServices.Admins.Commands
{
    //todo: همه byDefault confirm نشده هستن!
    public interface IRejectCustomersCommentServiceAppService
    {
        Task<bool> RejectCustomersProductComment(int productCommentId, CancellationToken cancellationToken);
        Task<bool> RejectCustomersStoreComment(int storeCommentId, CancellationToken cancellationToken);
    }
}
