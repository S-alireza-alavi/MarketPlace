using App.Domain.Core.AppServices.Admins.Queries;
using App.Domain.Core.DtoModels.Commisions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
