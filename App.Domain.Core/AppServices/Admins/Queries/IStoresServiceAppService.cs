namespace App.Domain.Core.AppServices.Admins.Queries
{
    public interface IStoresServiceAppService
    {
        Task<int> GetStoresCount(CancellationToken cancellationToken);
    }
}
