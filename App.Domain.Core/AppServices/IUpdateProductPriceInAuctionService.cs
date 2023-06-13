using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.AppServices
{
    public interface IUpdateProductPriceInAuctionService
    {
        Task UpdateProductPriceInAuction(int auctionId, CancellationToken cancellationToken);
    }
}
