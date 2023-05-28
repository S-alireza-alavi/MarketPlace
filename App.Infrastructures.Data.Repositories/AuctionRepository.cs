using App.Domain.Core.DataAccess;
using App.Domain.Core.DtoModels.Auctions;
using MarketPlace.Database;
using MarketPlace.Entities;
using Microsoft.EntityFrameworkCore;

namespace App.Infrastructures.Data.Repositories
{
    public class AuctionRepository : IAuctionRepository
    {
        private readonly AppDbContext _context;

        public AuctionRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreateAuction(AddAuctionInputDto auction, CancellationToken cancellationToken)
        {
            await _context.Auctions.AddAsync(new Auction
            {
                StoreId = auction.StoreId,
                SellerId = auction.SellerId,
                StartTime = auction.StartTime,
                EndTime = auction.EndTime,
                MinimumPrice = auction.MinimumPrice,
                IsRunning = auction.IsRunning,
                ProductId = auction.ProductId
            });

            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAuction(int id, CancellationToken cancellationToken)
        {
            Auction? auction = await _context.Auctions.FindAsync(id);

            auction.IsDeleted = true;

            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<List<AuctionOutputDto>> GetAllAuctions(CancellationToken cancellationToken)
        {
            var auctions = await _context.Auctions.Select(a => new AuctionOutputDto
            {
                Id = a.Id,
                StoreId = a.StoreId,
                SellerId = a.SellerId,
                StartTime = a.StartTime,
                EndTime = a.EndTime,
                MinimumPrice = a.MinimumPrice,
                IsRunning = a.IsRunning,
                ProductId = a.ProductId
            }).ToListAsync(cancellationToken);

            return auctions;
        }

        public async Task<AuctionOutputDto>? GetAuctionBy(int id, CancellationToken cancellationToken)
        {
            var auction = await _context.Auctions.Where(a => a.Id == id).Select(a => new AuctionOutputDto
            {
                Id = a.Id,
                StoreId = a.StoreId,
                SellerId = a.SellerId,
                StartTime = a.StartTime,
                EndTime = a.EndTime,
                MinimumPrice = a.MinimumPrice,
                IsRunning = a.IsRunning,
                ProductId = a.ProductId,

            }).FirstAsync(cancellationToken);

            return auction;
        }

        public async Task UpdateAuction(EditAuctionInputDto auction, CancellationToken cancellationToken)
        {
            var auctionToUpdate = await _context.Auctions.Where(a => a.Id == auction.Id).FirstOrDefaultAsync(cancellationToken);

            auctionToUpdate.StoreId = auction.StoreId;
            auctionToUpdate.SellerId = auction.SellerId;
            auctionToUpdate.StartTime = auction.StartTime;
            auctionToUpdate.EndTime = auction.EndTime;
            auctionToUpdate.MinimumPrice = auction.MinimumPrice;
            auctionToUpdate.IsRunning = auction.IsRunning;
            auctionToUpdate.ProductId = auction.ProductId;

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
