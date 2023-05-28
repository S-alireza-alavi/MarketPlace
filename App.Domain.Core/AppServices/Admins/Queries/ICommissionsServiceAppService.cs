using App.Domain.Core.DtoModels.Commisions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.AppServices.Admins.Queries
{
    public interface ICommissionsServiceAppService
    {
        Task<List<CommissionOutputDto>> GetCommissions(CancellationToken cancellationToken);
    }
}
