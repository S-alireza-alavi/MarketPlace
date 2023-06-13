using MarketPlace.Entities;

namespace App.Domain.Core.DtoModels.Auctions
{
    public class AuctionOutputDto
    {
        public int Id { get; set; }

        public int StoreId { get; set; }

        public int SellerId { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public int MinimumPrice { get; set; }

        public bool IsRunning { get; set; }

        public int ProductId { get; set; }

        public string ProductName { get; set; } = null!;

        public virtual Product Product { get; set; } = null!;
    }
}
