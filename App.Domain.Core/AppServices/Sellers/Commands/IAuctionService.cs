using App.Domain.Core.DtoModels.Auctions;
using App.Domain.Core.DtoModels.Bids;

namespace App.Domain.Core.AppServices.Sellers.Commands
{
    public interface IAuctionService
    {
        Task CheckAndUpdateIsRunning(int? storeId,CancellationToken cancellationToken);
        Task<AuctionOutputDto> DeactivateAuction(int auctionId, CancellationToken cancellationToken);
        Task<BidOutputDto> CalculateHighestBidAmount(int auctionId, CancellationToken cancellationToken);
        Task<AuctionOutputDto> SellToHighestBidAmount(int auctionId, CancellationToken cancellationToken);
    }
}
