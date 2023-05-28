using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.AppServices.Admins.Commands
{
    public interface IRejectCustomersCommentServiceAppService
    {
        Task<bool> RejectCustomersProductComment(int productCommentId, CancellationToken cancellationToken);
        Task<bool> RejectCustomersStoreComment(int storeCommentId, CancellationToken cancellationToken);
    }
}
