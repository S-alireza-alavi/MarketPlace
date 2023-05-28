using App.Domain.Core.DtoModels.Auctions;
using App.Domain.Core.DtoModels.Bids;

namespace App.Domain.Core.AppServices.Sellers.Commands
{
    public interface IAuctionServiceAppService
    {
        public Task<bool> CheckIfAuctionTimeHasPassed(int auctionId, CancellationToken cancellationToken);
        public Task<AuctionOutputDto> DeactivateAuction(int auctionId, CancellationToken cancellationToken);
        public Task<BidOutputDto> CalculateHighestBidAmount(int auctionId, CancellationToken cancellationToken);
        public Task<AuctionOutputDto> SellToHighestBidAmount(int auctionId, CancellationToken cancellationToken);
    }
}
