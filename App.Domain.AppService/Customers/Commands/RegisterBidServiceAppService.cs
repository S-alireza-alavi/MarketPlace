using App.Domain.Core.AppServices.Customers.Commands;
using App.Domain.Core.DtoModels.Bids;

namespace App.Domain.AppService.Customers.Commands
{
    public class RegisterBidServiceAppService : IRegisterBidServiceAppService
    {
        public Task<BidOutputDto> RegisterBidForAuctionProduct(AddBidInputDto bid, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
