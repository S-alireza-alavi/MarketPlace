using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.AppServices.Customers.Commands
{
    public interface IRemoveCartOrderItemService
    {
        Task<int> RemoveCartOrderItem(int orderItemId, CancellationToken cancellationToken);
    }
}
