using App.Domain.Core.DtoModels.Auctions;

namespace App.Domain.Core.AppServices.Sellers.Commands
{
    public interface IRegisterAuctionService
    {
        public Task<AuctionOutputDto> RegisterAuction(AddAuctionInputDto auction, CancellationToken cancellationToken);
    }
}
