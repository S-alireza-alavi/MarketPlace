using App.Domain.Core.DataAccess;
using App.Domain.Core.DtoModels.Bids;
using App.Domain.Core.Entities;
using App.Infrastructures.Database.SqlServer.Data;
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
