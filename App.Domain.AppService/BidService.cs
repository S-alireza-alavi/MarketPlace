using App.Domain.Core.AppServices;
using App.Domain.Core.DataAccess;
using App.Domain.Core.DtoModels.Bids;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.AppService
{
    public class BidService : IBidService
    {
        private readonly IBidRepository _bidRepository;

        public BidService(IBidRepository bidRepository)
        {
            _bidRepository = bidRepository;
        }

        public async Task CreateBid(AddBidInputDto bid, CancellationToken cancellationToken)
        {
           await _bidRepository.CreateBid(bid, cancellationToken);
        }
    }
}
