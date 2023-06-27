using App.Domain.Core.DtoModels.StoreComments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.AppServices.Customers.Commands
{
    public interface ILeaveCommentForStoreService
    {
        Task LeaveCommentForStore(AddStoreCommentInputDto comment, CancellationToken cancellationToken);
    }
}
