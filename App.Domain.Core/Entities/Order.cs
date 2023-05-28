namespace App.Domain.Core.Entities;

public partial class Order
{
    public int Id { get; set; }

    public int SellerId { get; set; }

    public int CustomerId { get; set; }

    public int TotalPrice { get; set; }

    public bool IsPurchased { get; set; }

    public DateTime? CreatedAt { get; set; }

    public bool IsDeleted { get; set; }

    public virtual Commission? Commission { get; set; }

    public virtual AspNetUser Customer { get; set; } = null!;

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public virtual AspNetUser Seller { get; set; } = null!;
}
