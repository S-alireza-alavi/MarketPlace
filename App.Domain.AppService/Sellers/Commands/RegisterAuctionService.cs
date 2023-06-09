using App.Domain.Core.AppServices.Sellers.Commands;
using App.Domain.Core.DtoModels.Auctions;

namespace App.Domain.AppService.Sellers.Commands
{
    public class RegisterAuctionService : IRegisterAuctionService
    {
        public Task<AuctionOutputDto> RegisterAuction(AddAuctionInputDto auction, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
