using App.Domain.Core.AppServices;
using App.Domain.Core.Configs;
using App.Domain.Core.DataAccess;
using App.Domain.Core.DtoModels.Orders;

namespace App.Domain.AppService
{
    public class CalculateCommissionAmountService : ICalculateCommissionAmountService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IUserRepository _userRepository;
        private readonly AppConfigs _appConfigs;

        public CalculateCommissionAmountService(IOrderRepository orderRepository, IUserRepository userRepository, AppConfigs appConfigs)
        {
            _orderRepository = orderRepository;
            _userRepository = userRepository;
            _appConfigs = appConfigs;
        }

        public async Task<int> CalculateCommissionAmount(int orderId, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetOrderBy(orderId, cancellationToken);

            if (order != null && !order.IsPurchased)
            {
                var seller = await _userRepository.GetUserBy(order.SellerId);

                if (seller != null)
                {
                    int commissionRate = _appConfigs.CommissionSettings.NormalCommissionRate;

                    if (seller.Medal != null) 
                    {
                        commissionRate = _appConfigs.CommissionSettings.ReducedCommissionRate;
                    }

                    int commissionAmount = (order.TotalPrice * commissionRate / 100);
                    return commissionAmount;
                }
            }

            return 0;
        }
    }
}
