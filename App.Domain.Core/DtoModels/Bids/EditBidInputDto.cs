namespace App.Domain.Core.DtoModels.Bids
{
    public class EditBidInputDto
    {
        public int Id { get; set; }

        public int AuctionId { get; set; }

        public int BuyerId { get; set; }

        public int BidAmount { get; set; }

        public bool IsAcceptedFinally { get; set; }

        public DateTime BidTime { get; set; }
    }
}
