namespace App.Domain.Core.AppServices.Sellers.Commands
{
    public interface ICalculateSellersTotalSaleServiceAppService
    {
        Task<int> CalculateSellersTotalSale(int sellerId, CancellationToken cancellationToken);
    }
}
