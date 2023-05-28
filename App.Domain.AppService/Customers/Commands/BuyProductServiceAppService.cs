using App.Domain.Core.AppServices.Customers.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
