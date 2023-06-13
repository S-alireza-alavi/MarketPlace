using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.AppServices.Sellers
{
    public interface ICalculateTotalSalePricesForSellerService
    {
        Task<int> CalculateTotalSalePricesForSeller(int sellerId, CancellationToken cancellationToken);
    }
}
