using App.Domain.Core.AppServices;
using App.Domain.Core.Configs;
using App.Domain.Core.DataAccess;
using App.Domain.Core.DtoModels.Orders;

namespace App.Domain.AppService
{
    public class PurchaseOrderService : IPurchaseOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IUserRepository _userRepository;
        private readonly AppConfigs _appConfigs;

        public PurchaseOrderService(IOrderRepository orderRepository, IUserRepository userRepository, AppConfigs appConfigs)
        {
            _orderRepository = orderRepository;
            _userRepository = userRepository;
            _appConfigs = appConfigs;
        }

        public async Task<int> PurchaseOrder(int orderId, CancellationToken cancellationToken)
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

                    order.IsPurchased = true;

                    await _orderRepository.UpdateOrder(new EditOrderInputDto
                    {
                        Id = order.Id,
                        SellerId = order.SellerId,
                        CustomerId = order.CustomerId,
                        TotalPrice = order.TotalPrice,
                        IsPurchased = order.IsPurchased,
                        CreatedAt = order.CreatedAt
                    }, cancellationToken);

                    int commissionAmount = (int)(order.TotalPrice * commissionRate / 100);
                    return commissionAmount;
                }
            }

            return 0;
        }
    }
}
