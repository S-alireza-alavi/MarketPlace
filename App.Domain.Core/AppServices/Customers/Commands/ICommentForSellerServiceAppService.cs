using App.Domain.Core.DtoModels.StoreComments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.AppServices.Customers.Commands
{
    public interface ICommentForStoreServiceAppService
    {
        Task<StoreCommentOutputDto> LeaveCommentForStore(int storeId, AddStoreCommentInputDto comment, CancellationToken cancellationToken);
    }
}
