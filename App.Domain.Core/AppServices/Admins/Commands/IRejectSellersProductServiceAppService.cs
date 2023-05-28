namespace App.Domain.Core.AppServices.Admins.Commands
{
    public interface IRejectSellersProductServiceAppService
    {
        Task<bool> RejectSellersProductAsync(int productId, CancellationToken cancellationToken);
    }
}
