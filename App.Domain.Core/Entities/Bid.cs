namespace App.Domain.Core.Entities;

public partial class Bid
{
    public int Id { get; set; }

    public int AuctionId { get; set; }

    public int BuyerId { get; set; }

    public int BidAmount { get; set; }

    public DateTime BidTime { get; set; }

    public bool IsDeleted { get; set; }

    public virtual Auction Auction { get; set; } = null!;

    public virtual AspNetUser Buyer { get; set; } = null!;
}
