using App.Domain.Core.DtoModels.Commisions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.AppServices
{
    public interface ICommissionService
    {
        Task CreateCommission(AddCommissionInputDto commission, CancellationToken cancellationToken);
    }
}
