using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.AppServices.Sellers.Commands
{
    public interface ICalculateSellersTotalSaleServiceAppService
    {
        Task<int> CalculateSellersTotalSale(int sellerId, CancellationToken cancellationToken);
    }
}
