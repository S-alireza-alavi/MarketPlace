using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.AppServices.Customers.Queries
{
    public interface IHasOrderService
    {
        Task<bool> HasOrder(int customerId, CancellationToken cancellationToken);
    }
}
