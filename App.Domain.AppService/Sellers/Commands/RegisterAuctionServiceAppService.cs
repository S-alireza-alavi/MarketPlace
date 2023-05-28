using App.Domain.Core.AppServices.Sellers.Commands;
using App.Domain.Core.DtoModels.Auctions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.AppService.Sellers.Commands
{
    public class RegisterAuctionServiceAppService : IRegisterAuctionServiceAppService
    {
        public Task<AuctionOutputDto> RegisterAuction(AddAuctionInputDto auction, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
