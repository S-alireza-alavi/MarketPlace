using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.AppServices.Sellers.Commands
{
    public interface ISetMedalForSellerService
    {
        Task SetMedalForSeller(int sellerId, CancellationToken cancellationToken);
    }
}
