using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.AppServices.Admins.Commands
{
    public interface IRejectSellersProductServiceAppService
    {
        Task<bool> RejectSellersProductAsync(int productId, CancellationToken cancellationToken);
    }
}
