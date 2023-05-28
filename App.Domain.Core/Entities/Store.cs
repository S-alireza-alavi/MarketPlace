using App.Domain.Core.Entities;

namespace MarketPlace.Entities;

public partial class Store
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int SellerId { get; set; }

    public string Description { get; set; } = null!;

    public int AddressId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public bool IsDeleted { get; set; }

    public virtual ICollection<Auction> Auctions { get; set; } = new List<Auction>();

    public virtual StoreAddress IdNavigation { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();

    public virtual ApplicationUser Seller { get; set; } = null!;

    public virtual ICollection<StoreComment> StoreComments { get; set; } = new List<StoreComment>();
}
