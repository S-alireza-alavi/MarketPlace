using App.Domain.Core.AppServices.Customers.Commands;
using App.Domain.Core.DtoModels.StoreComments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
