using App.Domain.Core.AppServices.Sellers.Commands;
using App.Domain.Core.DtoModels.Commisions;
using MarketPlace.Entities;

namespace App.Domain.AppService.Sellers.Commands
{
    public class CalculateCommissionServiceAppService : ICalculateCommissionServiceAppService
    {
        public Task<CommissionOutputDto> CalculateCommission(Order order, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CheckIfSellerHasMedal(int sellerId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
