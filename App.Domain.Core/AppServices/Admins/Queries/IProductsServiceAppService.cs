namespace App.Domain.Core.AppServices.Admins.Queries
{
    public interface IProductsServiceAppService
    {
        Task<int> GetProductsCount(CancellationToken cancellationToken);
    }
}
