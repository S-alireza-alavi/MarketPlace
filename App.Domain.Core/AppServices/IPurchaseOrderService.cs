using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.AppServices
{
    public interface IPurchaseOrderService
    {
        Task<int> PurchaseOrder(int orderId, CancellationToken cancellationToken);
    }
}
