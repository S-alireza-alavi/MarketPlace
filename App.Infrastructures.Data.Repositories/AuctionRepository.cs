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

        public async Task<int> CreateAuction(AddAuctionInputDto inputDto, CancellationToken cancellationToken)
        {
            var auction = new Auction
            {
                StoreId = inputDto.StoreId,
                SellerId = inputDto.SellerId,
                StartTime = inputDto.StartTime,
                EndTime = inputDto.EndTime,
                MinimumPrice = inputDto.MinimumPrice,
                IsRunning = inputDto.IsRunning,
                ProductId = inputDto.ProductId
            };

            await _context.Auctions.AddAsync(auction);
            await _context.SaveChangesAsync(cancellationToken);

            return auction.Id;
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

        public async Task<List<AuctionOutputDto>> GetAllRunningAuctions(CancellationToken cancellationToken)
        {
            var auctions = await _context.Auctions.Where(a => a.IsRunning == true).Select(a => new AuctionOutputDto
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

        public async Task<List<AuctionOutputDto>> GetStoreAuctions(int storeId, CancellationToken cancellationToken)
        {
            var auctions = await _context.Auctions.Where(a => a.StoreId == storeId).Select(a => new AuctionOutputDto
            {
                Id = a.Id,
                StoreId = storeId,
                SellerId = a.SellerId,
                StartTime = a.StartTime,
                EndTime = a.EndTime,
                MinimumPrice = a.MinimumPrice,
                IsRunning = a.IsRunning,
                ProductId = a.ProductId,
                ProductName = a.Product.Name
            }).ToListAsync(cancellationToken);

            return auctions;
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

        public async Task UpdateAuction(int auctionId, bool isRunning, CancellationToken cancellationToken)
        {
            var auctionToUpdate = await _context.Auctions.FindAsync(auctionId, cancellationToken);

            if (auctionToUpdate != null)
            {
                auctionToUpdate.IsRunning = isRunning;
                await _context.SaveChangesAsync(cancellationToken);
            }
        }
    }
}
