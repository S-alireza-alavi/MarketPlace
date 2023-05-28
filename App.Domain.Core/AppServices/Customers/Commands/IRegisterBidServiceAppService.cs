using App.Domain.Core.DtoModels.Bids;
//using App.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.AppServices.Customers.Commands
{
    public interface IRegisterBidServiceAppService
    {
        Task<BidOutputDto> RegisterBidForAuctionProduct(AddBidInputDto bid, CancellationToken cancellationToken);
    }
}
