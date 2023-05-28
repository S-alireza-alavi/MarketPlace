using App.Domain.Core.AppServices.Sellers.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.AppService.Sellers.Commands
{
    public class CalculateSellersTotalSaleServiceAppService : ICalculateSellersTotalSaleServiceAppService
    {
        public Task<int> CalculateSellersTotalSale(int sellerId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
