using App.Domain.Core.AppServices.Sellers.Commands;

namespace App.Domain.AppService.Sellers.Commands
{
    public class CalculateSellersTotalSaleService : ICalculateSellersTotalSaleService
    {
        public Task<int> CalculateSellersTotalSale(int sellerId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
