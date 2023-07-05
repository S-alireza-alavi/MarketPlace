using App.Domain.Core.Entities;

namespace MarketPlace.Entities;

public partial class Order
{
    public int Id { get; set; }

    public int SellerId { get; set; }

    public int CustomerId { get; set; }

    public int TotalPrice { get; set; }

    public bool IsPurchased { get; set; }

    public DateTime CreatedAt { get; set; }

    public bool IsDeleted { get; set; }

    public virtual ApplicationUser Customer { get; set; } = null!;

    public virtual Commission Commission { get; set; } = null!;

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public virtual ApplicationUser Seller { get; set; } = null!;

    public virtual OrderComment? OrderComment { get; set; }
}
