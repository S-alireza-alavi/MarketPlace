using App.Domain.Core.DtoModels.Auctions;

namespace App.Domain.Core.DataAccess
{
    public interface IAuctionRepository
    {
        Task<List<AuctionOutputDto>> GetAllAuctions(CancellationToken cancellationToken);
        Task<AuctionOutputDto>? GetAuctionBy(int id, CancellationToken cancellationToken);
        Task CreateAuction(AddAuctionInputDto auction, CancellationToken cancellationToken);
        Task UpdateAuction(EditAuctionInputDto auction, CancellationToken cancellationToken);
        Task DeleteAuction(int id, CancellationToken cancellationToken);
    }
}
