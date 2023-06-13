using App.Domain.Core.DataAccess;
using App.Domain.Core.DtoModels.Bids;
using MarketPlace.Database;
using MarketPlace.Entities;
using Microsoft.EntityFrameworkCore;

namespace App.Infrastructures.Data.Repositories
{
    public class BidRepository : IBidRepository
    {
        private readonly AppDbContext _context;

        public BidRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreateBid(AddBidInputDto bid, CancellationToken cancellationToken)
        {
            await _context.Bids.AddAsync(new Bid
            {
                AuctionId = bid.AuctionId,
                BuyerId = bid.BuyerId,
                BidAmount = bid.BidAmount,
                BidTime = DateTime.Now
            });

            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteBid(int id, CancellationToken cancellationToken)
        {
            Bid? bid = await _context.Bids.FindAsync(id);

            bid.IsDeleted = true;

            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<List<BidOutputDto>> GetAllBids(CancellationToken cancellationToken)
        {
            var bids = await _context.Bids.Select(b => new BidOutputDto
            {
                Id = b.Id,
                AuctionId = b.AuctionId,
                BuyerId = b.BuyerId,
                BidAmount = b.BidAmount,
                BidTime = b.BidTime
            }).ToListAsync(cancellationToken);

            return bids;
        }

        public async Task<BidOutputDto>? GetBidBy(int id, CancellationToken cancellationToken)
        {
            var bid = await _context.Bids.Where(b => b.Id == id).Select(b => new BidOutputDto
            {
                Id = b.Id,
                AuctionId = b.AuctionId,
                BuyerId = b.BuyerId,
                BidAmount = b.BidAmount,
                BidTime = b.BidTime
            }).FirstAsync(cancellationToken);

            return bid;
        }

        public async Task<BidOutputDto> GetHighestBidForAuction(int auctionId, CancellationToken cancellationToken)
        {
            var highestBid = await _context.Bids
                .Where(b => b.AuctionId == auctionId)
                .OrderByDescending(b => b.BidAmount)
                .FirstOrDefaultAsync(cancellationToken);

            return new BidOutputDto
            {
                Id = highestBid.Id,
                AuctionId = highestBid.AuctionId,
                BuyerId = highestBid.BuyerId,
                BidAmount = highestBid.BidAmount,
                BidTime = highestBid.BidTime,
                IsAcceptedFinally = highestBid.IsAcceptedFinally
            };
        }

        public async Task UpdateBid(EditBidInputDto bid, CancellationToken cancellationToken)
        {
            var bidToUpdate = await _context.Bids.Where(b => b.Id == bid.Id).FirstOrDefaultAsync(cancellationToken);

            bidToUpdate.AuctionId = bid.AuctionId;
            bidToUpdate.BuyerId = bid.BuyerId;
            bidToUpdate.BidAmount = bid.BidAmount;
            bidToUpdate.BidTime = bid.BidTime;

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
