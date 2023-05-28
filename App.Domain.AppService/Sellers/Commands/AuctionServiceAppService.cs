using App.Domain.Core.AppServices.Sellers.Commands;
using App.Domain.Core.DtoModels.Auctions;
using App.Domain.Core.DtoModels.Bids;

namespace App.Domain.AppService.Sellers.Commands
{
    public class AuctionServiceAppService : IAuctionServiceAppService
    {
        public Task<BidOutputDto> CalculateHighestBidAmount(int auctionId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CheckIfAuctionTimeHasPassed(int auctionId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<AuctionOutputDto> DeactivateAuction(int auctionId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<AuctionOutputDto> SellToHighestBidAmount(int auctionId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
