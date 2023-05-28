namespace App.Domain.Core.AppServices.Customers.Commands
{
    public interface IBuyProductServiceAppService
    {
        Task BuyProduct(int productId, CancellationToken cancellationToken);
    }
}
