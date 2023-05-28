namespace App.Domain.Core.AppServices.Admins.Commands
{
    public interface IConfirmSellersProductServiceAppService
    {
        Task<bool> ConfirmSellersProductAsync(int productId, CancellationToken cancellationToken);
    }
}
