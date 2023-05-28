namespace MarketPlace.Entities;

public partial class StoreAddress
{
    public int Id { get; set; }

    public string? FullAddress { get; set; }

    public string? IsDeleted { get; set; }

    public virtual Store? Store { get; set; }
}
