using App.Domain.Core.DtoModels.Auctions;
using App.Domain.Core.DtoModels.Bids;

namespace App.Domain.Core.AppServices.Sellers.Commands
{
    public interface IAuctionService
    {
        Task<List<AuctionOutputDto>> GetEndedAuctions(CancellationToken cancellationToken);
        Task CheckAndUpdateIsRunning(int? storeId, CancellationToken cancellationToken);
        Task<AuctionOutputDto> DeactivateAuction(int auctionId, CancellationToken cancellationToken);
        Task AssignWinningBidsToAuctions(CancellationToken cancellationToken);
        Task UpdateRunningAuctionPrices(CancellationToken cancellationToken);
    }
}
