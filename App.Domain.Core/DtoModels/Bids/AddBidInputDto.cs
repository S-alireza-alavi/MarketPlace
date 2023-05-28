namespace App.Domain.Core.DtoModels.Bids
{
    public class AddBidInputDto
    {
        public int AuctionId { get; set; }

        public int BuyerId { get; set; }

        public int BidAmount { get; set; }

        public DateTime BidTime { get; set; }
    }
}
