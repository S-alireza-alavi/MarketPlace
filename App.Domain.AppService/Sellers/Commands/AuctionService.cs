using App.Domain.Core.AppServices.Sellers.Commands;
using App.Domain.Core.DataAccess;
using App.Domain.Core.DtoModels.Auctions;
using App.Domain.Core.DtoModels.Bids;
using App.Domain.Core.DtoModels.Products;
using MarketPlace.Entities;
using System.Collections;
using System.Linq.Expressions;

namespace App.Domain.AppService.Sellers.Commands
{
    public class AuctionService : IAuctionService
    {
        private readonly IAuctionRepository _auctionRepository;
        private readonly IBidRepository _bidRepository;
        private readonly IProductRepository _productRepository;

        public AuctionService(IAuctionRepository auctionRepository, IBidRepository bidRepository, IProductRepository productRepository)
        {
            _auctionRepository = auctionRepository;
            _bidRepository = bidRepository;
            _productRepository = productRepository;
        }

        public async Task AssignWinningBidsToAuctions(CancellationToken cancellationToken)
        {
            var endedAuctions = await GetEndedAuctions(cancellationToken);

            foreach (var auction in endedAuctions)
            {
                var highestBid = await _bidRepository.GetHighestBidForAuction(auction.Id, cancellationToken);

                if (highestBid != null)
                {
                    highestBid.IsAcceptedFinally = true;
                    await _bidRepository.UpdateBid(new EditBidInputDto
                    {
                        Id = highestBid.Id,
                        AuctionId = highestBid.AuctionId,
                        BuyerId = highestBid.BuyerId,
                        BidAmount = highestBid.BidAmount,
                        IsAcceptedFinally = true
                    }, cancellationToken);
                }
            }
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
                else if (auction.EndTime < DateTime.Now && auction.IsRunning)
                {
                    await _auctionRepository.UpdateAuction(auction.Id, false, cancellationToken);
                }
            }
        }

        //todo: برای تمام مزایده‌ها نوشته شه
        public async Task DeactivateAuction(int auctionId, CancellationToken cancellationToken)
        {
            var auction = await _auctionRepository.GetAuctionBy(auctionId, cancellationToken);

            if (auction == null)
            {
                // Auction not found
                throw new Exception("مزایده‌ای یافت نشد.");
            }

            var product = await _productRepository.GetProductBy(auction.ProductId, cancellationToken);

            if (product != null)
            {
                product.IsActive = false;
                await _productRepository.UpdateProduct(new EditProductInputDto
                {
                    Id = product.Id,
                    Name = product.Name,
                    CategoryId = product.CategoryId,
                    BrandId = product.BrandId,
                    StoreId = product.StoreId,
                    Weight = product.Weight,
                    Description = product.Description,
                    Count = product.Count,
                    ModelId = product.Id,
                    Price = product.Price,
                    IsActive = product.IsActive
                }, cancellationToken);
            }
        }

        public async Task<List<AuctionOutputDto>> GetEndedAuctions(CancellationToken cancellationToken)
        {
            var endedAuctions = await _auctionRepository.GetEndedAuctions(cancellationToken);
            return endedAuctions;
        }

        public async Task UpdateRunningAuctionPrices(CancellationToken cancellationToken)
        {
            var runningAuctions = await _auctionRepository.GetAllRunningAuctions(cancellationToken);

            foreach (var auction in runningAuctions)
            {
                var highestBid = await _bidRepository.GetHighestBidForAuction(auction.Id, cancellationToken);

                if (highestBid != null)
                {
                    auction.Product.Price = highestBid.BidAmount;
                }
                else
                {
                    auction.Product.Price = auction.MinimumPrice;
                }


            }
        }
    }
}
