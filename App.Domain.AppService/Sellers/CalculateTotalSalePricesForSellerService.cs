using App.Domain.Core.AppServices.Sellers;
using App.Domain.Core.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.AppService.Sellers
{
    public class CalculateTotalSalePricesForSellerService : ICalculateTotalSalePricesForSellerService
    {
        private readonly IOrderRepository _orderRepository;

        public CalculateTotalSalePricesForSellerService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<int> CalculateTotalSalePricesForSeller(int sellerId, CancellationToken cancellationToken)
        {
            var totalSalePrice = await _orderRepository.CalculateTotalSalePricesForSeller(sellerId, cancellationToken);
            return totalSalePrice;
        }
    }
}
