using App.Domain.Core.DtoModels.StoreComments;

namespace App.Domain.Core.AppServices.Customers.Commands
{
    public interface ICommentForStoreServiceAppService
    {
        Task<StoreCommentOutputDto> LeaveCommentForStore(int storeId, AddStoreCommentInputDto comment, CancellationToken cancellationToken);
    }
}
