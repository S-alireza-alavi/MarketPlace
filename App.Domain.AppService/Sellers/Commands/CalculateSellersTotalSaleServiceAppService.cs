using App.Domain.Core.AppServices.Sellers.Commands;

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
