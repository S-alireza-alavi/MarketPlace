namespace MarketPlace.Entities;

public partial class StoreAddress
{
    public int Id { get; set; }

    public int StoreId { get; set; }

    public string FullAddress { get; set; } = null!;

    public bool? IsDeleted { get; set; }

    public virtual Store Store { get; set; } = null!;
}
