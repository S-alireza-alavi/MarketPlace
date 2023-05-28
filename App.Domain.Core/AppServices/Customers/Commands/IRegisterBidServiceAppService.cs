using App.Domain.Core.DtoModels.Bids;
//using App.Domain.Core.Entities;

namespace App.Domain.Core.AppServices.Customers.Commands
{
    public interface IRegisterBidServiceAppService
    {
        Task<BidOutputDto> RegisterBidForAuctionProduct(AddBidInputDto bid, CancellationToken cancellationToken);
    }
}
