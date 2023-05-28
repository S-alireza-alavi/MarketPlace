using App.Domain.Core.AppServices.Customers.Commands;

namespace App.Domain.AppService.Customers.Commands
{
    public class BuyProductServiceAppService : IBuyProductServiceAppService
    {
        public Task BuyProduct(int productId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
