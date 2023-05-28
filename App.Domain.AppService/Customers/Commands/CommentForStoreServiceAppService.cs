using App.Domain.Core.AppServices.Customers.Commands;
using App.Domain.Core.DtoModels.StoreComments;

namespace App.Domain.AppService.Customers.Commands
{
    public class CommentForStoreServiceAppService : ICommentForStoreServiceAppService
    {
        public Task<StoreCommentOutputDto> LeaveCommentForStore(int storeId, AddStoreCommentInputDto comment, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
