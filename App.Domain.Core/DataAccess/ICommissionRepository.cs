using App.Domain.Core.DtoModels.Commisions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.DataAccess
{
    public interface ICommissionRepository
    {
        Task<List<CommissionOutputDto>> GetAllCommissions(CancellationToken cancellationToken);
        Task<CommissionOutputDto>? GetCommissionBy(int id, CancellationToken cancellationToken);
        Task CreateCommission(AddCommissionInputDto commission, CancellationToken cancellationToken);
        Task UpdateCommission(EditCommissionInputDto commission, CancellationToken cancellationToken);
        Task DeleteCommission(int id, CancellationToken cancellationToken);
    }
}
