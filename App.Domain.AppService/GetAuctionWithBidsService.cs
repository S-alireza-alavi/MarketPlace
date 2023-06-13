using App.Domain.Core.AppServices.Sellers;
using App.Domain.Core.DataAccess;
using App.Domain.Core.DtoModels.Auctions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.AppService
{
    public class GetAuctionWithBidsService : IGetAuctionWithBidsService
    {
        private readonly IAuctionRepository _auctionRepository;

        public GetAuctionWithBidsService(IAuctionRepository auctionRepository)
        {
            _auctionRepository = auctionRepository;
        }

        public async Task<AuctionOutputDto> GetAuctionWithBids(int auctionId, CancellationToken cancellationToken)
        {
            var auction = await _auctionRepository.GetAuctionWithBids(auctionId, cancellationToken);
            return auction;
        }
    }
}
