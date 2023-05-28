using App.Domain.Core.AppServices.Customers.Commands;
using App.Domain.Core.DtoModels.Bids;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.AppService.Customers.Commands
{
    public class SeeLastBidServiceAppService : ISeeLastBidServiceAppService
    {
        public Task<BidOutputDto> SeeLastBid(int auctionId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
