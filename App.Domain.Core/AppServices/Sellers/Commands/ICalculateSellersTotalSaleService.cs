namespace App.Domain.Core.AppServices.Sellers.Commands
{
    public interface ICalculateSellersTotalSaleService
    {
        Task<int> CalculateSellersTotalSale(int sellerId, CancellationToken cancellationToken);
    }
}
