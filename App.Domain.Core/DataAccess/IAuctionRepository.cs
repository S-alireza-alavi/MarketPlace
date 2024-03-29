﻿using App.Domain.Core.DtoModels.Auctions;
using App.Domain.Core.DtoModels.Bids;

namespace App.Domain.Core.DataAccess
{
    public interface IAuctionRepository
    {
        Task<List<AuctionOutputDto>> GetAllAuctions(CancellationToken cancellationToken);
        Task<List<AuctionOutputDto>> GetAllRunningAuctions(CancellationToken cancellationToken);
        Task<List<AuctionOutputDto>> GetEndedAuctions(CancellationToken cancellationToken);
        Task<List<AuctionOutputDto>> GetStoreAuctions(int storeId, CancellationToken cancellationToken);
        Task<AuctionOutputDto> GetAuctionWithBids(int auctionId, CancellationToken cancellationToken);
        Task<AuctionOutputDto>? GetAuctionBy(int id, CancellationToken cancellationToken);
        Task<int> CreateAuction(AddAuctionInputDto inputDto, CancellationToken cancellationToken);
        Task UpdateAuction(EditAuctionInputDto auction, CancellationToken cancellationToken);
        Task UpdateAuction(int auctionId, bool isRunning, CancellationToken cancellationToken);
        Task DeleteAuction(int id, CancellationToken cancellationToken);
    }
}
