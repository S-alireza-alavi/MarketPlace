using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.AppServices
{
    public interface ICalculateCommissionAmountService
    {
        Task<int> CalculateCommissionAmount(int orderId, CancellationToken cancellationToken);
    }
}
