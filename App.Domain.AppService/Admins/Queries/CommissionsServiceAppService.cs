using App.Domain.Core.DtoModels.Commisions;

namespace App.Domain.AppService.Admins.Queries
{
    public class CommissionsServiceAppService : Core.AppServices.Admins.Queries.ICommissionsServiceAppService
    {
        public Task<List<CommissionOutputDto>> GetCommissions(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
