using App.Domain.Core.AppServices.Sellers.Queries;
using App.Domain.Core.DataAccess;
using App.Domain.Core.DtoModels.Auctions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.AppService.Sellers.Queries
{
    public class GetStoreAuctionsService : IGetStoreAuctionsService
    {
        private readonly IAuctionRepository _auctionRepository;

        public GetStoreAuctionsService(IAuctionRepository auctionRepository)
        {
            _auctionRepository = auctionRepository;
        }

        public async Task<List<AuctionOutputDto>> GetStoreAuctions(int storeId, CancellationToken cancellationToken)
        {
            var auctions = await _auctionRepository.GetStoreAuctions(storeId, cancellationToken);
            return auctions;
        }
    }
}
