namespace MarketPlace.Entities;

public partial class Commission
{
    public int Id { get; set; }

    public int CommissionAmount { get; set; }

    public bool IsDeleted { get; set; }

    public virtual Order? Order { get; set; }
}
