using App.Domain.Core.AppServices.Sellers.Commands;
using App.Domain.Core.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.AppService.Sellers.Commands
{
    public class SetMedalForSellerService : ISetMedalForSellerService
    {
        private readonly IMedalRepository _medalRepository;

        public SetMedalForSellerService(IMedalRepository medalRepository)
        {
            _medalRepository = medalRepository;
        }

        public async Task SetMedalForSeller(int sellerId, CancellationToken cancellationToken)
        {
            await _medalRepository.SetMedalForSeller(sellerId, cancellationToken);
        }
    }
}
