namespace App.Domain.Core.Entities;

public partial class Auction
{
    public int Id { get; set; }

    public int StoreId { get; set; }

    public int SellerId { get; set; }

    public DateTime StartTime { get; set; }

    public DateTime EndTime { get; set; }

    public int MinimumPrice { get; set; }

    public bool IsRunning { get; set; }

    public int ProductId { get; set; }

    public bool IsDeleted { get; set; }

    public virtual ICollection<Bid> Bids { get; set; } = new List<Bid>();

    public virtual Product Product { get; set; } = null!;

    public virtual AspNetUser Seller { get; set; } = null!;

    public virtual Store Store { get; set; } = null!;
}
