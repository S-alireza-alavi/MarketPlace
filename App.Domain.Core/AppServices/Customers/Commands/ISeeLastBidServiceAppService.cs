using App.Domain.Core.DtoModels.Bids;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.AppServices.Customers.Commands;

public interface ISeeLastBidServiceAppService
{
    Task<BidOutputDto> SeeLastBid(int auctionId, CancellationToken cancellationToken);
}
