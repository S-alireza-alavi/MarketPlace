using App.Domain.Core.AppServices;
using App.Domain.Core.DataAccess;
using App.Domain.Core.DtoModels.Commisions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.AppService
{
    public class CommissionService : ICommissionService
    {
        private readonly ICommissionRepository _commissionRepository;

        public CommissionService(ICommissionRepository commissionRepository)
        {
            _commissionRepository = commissionRepository;
        }

        public async Task CreateCommission(AddCommissionInputDto commission, CancellationToken cancellationToken)
        {
            await _commissionRepository.CreateCommission(commission, cancellationToken);
        }
    }
}
