using App.Domain.Core.DtoModels.Bids;

namespace App.Domain.Core.AppServices.Customers.Commands;

public interface ISeeLastBidServiceAppService
{
    Task<BidOutputDto> SeeLastBid(int auctionId, CancellationToken cancellationToken);
}
