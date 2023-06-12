using App.Domain.Core.AppServices.Sellers.Commands;
using App.Domain.Core.DataAccess;
using App.Domain.Core.DtoModels.Auctions;
using App.Domain.Core.DtoModels.Bids;
using MarketPlace.Entities;
using System.Collections;

namespace App.Domain.AppService.Sellers.Commands
{
    public class AuctionService : IAuctionService
    {
        private readonly IAuctionRepository _auctionRepository;

        public AuctionService(IAuctionRepository auctionRepository)
        {
            _auctionRepository = auctionRepository;
        }

        public Task<BidOutputDto> CalculateHighestBidAmount(int auctionId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task CheckAndUpdateIsRunning(int? storeId, CancellationToken cancellationToken)
        {
            IEnumerable<AuctionOutputDto> auctions;

            if (storeId.HasValue)
            {
                auctions = await _auctionRepository.GetStoreAuctions(storeId.Value, cancellationToken);
            }
            else
            {
                auctions = await _auctionRepository.GetAllAuctions(cancellationToken);
            }

            foreach (var auction in auctions)
            {
                if (auction.StartTime < DateTime.Now && auction.EndTime > DateTime.Now && !auction.IsRunning)
                {
                    await _auctionRepository.UpdateAuction(auction.Id, true, cancellationToken);
                }
                else if (auction.EndTime < DateTime.Now && !auction.IsRunning)
                {
                    await _auctionRepository.UpdateAuction(auction.Id, false, cancellationToken);
                }
            }

            //var auctions = await _auctionRepository.GetStoreAuctions(storeId.Value, cancellationToken);

            //foreach (var auction in auctions)
            //{
            //    if (auction.StartTime < DateTime.Now && auction.EndTime > DateTime.Now && !auction.IsRunning)
            //    {
            //        await _auctionRepository.UpdateAuction(auction.Id, true, cancellationToken);
            //    }
            //    else if (auction.EndTime < DateTime.Now && !auction.IsRunning)
            //    {
            //        await _auctionRepository.UpdateAuction(auction.Id, false, cancellationToken);
            //    }
            //}
        }

        public Task<AuctionOutputDto> DeactivateAuction(int auctionId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<AuctionOutputDto> SellToHighestBidAmount(int auctionId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
