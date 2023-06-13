using App.Domain.Core.AppServices;
using App.Domain.Core.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.AppService
{
    public class UpdateProductPriceInAuctionService : IUpdateProductPriceInAuctionService
    {
        private readonly IAuctionRepository _auctionRepository;
        private readonly IProductRepository _productRepository;

        public UpdateProductPriceInAuctionService(IAuctionRepository auctionRepository, IProductRepository productRepository)
        {
            _auctionRepository = auctionRepository;
            _productRepository = productRepository;
        }

        public async Task UpdateProductPriceInAuction(int auctionId, CancellationToken cancellationToken)
        {
            var auction = await _auctionRepository.GetAuctionWithBids(auctionId, cancellationToken);

            if (auction != null)
            {
                if (auction.Bids.Any())
                {
                    var maxBidAmount = auction.Bids.Max(b => b.BidAmount);

                    await _productRepository.UpdateProductPrice(auction.ProductId, maxBidAmount, cancellationToken);
                }
                else
                {
                    await _productRepository.UpdateProductPrice(auction.ProductId, auction.MinimumPrice, cancellationToken);
                }
            }
        }
    }
}
