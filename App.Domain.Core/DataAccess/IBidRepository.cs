using App.Domain.Core.DtoModels.Bids;

namespace App.Domain.Core.DataAccess
{
    public interface IBidRepository
    {
        Task<List<BidOutputDto>> GetAllBids(CancellationToken cancellationToken);
        Task<BidOutputDto>? GetBidBy(int id, CancellationToken cancellationToken);
        Task<BidOutputDto> GetHighestBidForAuction(int auctionId, CancellationToken cancellationToken);
        Task CreateBid(AddBidInputDto bid, CancellationToken cancellationToken);
        Task UpdateBid(EditBidInputDto bid, CancellationToken cancellationToken);
        Task DeleteBid(int id, CancellationToken cancellationToken);
    }
}
