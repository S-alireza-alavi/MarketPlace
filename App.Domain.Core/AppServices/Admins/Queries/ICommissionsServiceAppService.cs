using App.Domain.Core.DtoModels.Commisions;

namespace App.Domain.Core.AppServices.Admins.Queries
{
    public interface ICommissionsServiceAppService
    {
        Task<List<CommissionOutputDto>> GetCommissions(CancellationToken cancellationToken);
    }
}
