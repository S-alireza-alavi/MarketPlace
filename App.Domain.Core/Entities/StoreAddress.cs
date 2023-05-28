namespace App.Domain.Core.Entities;

public partial class StoreAddress
{
    public int Id { get; set; }

    public string FullAddress { get; set; } = null!;

    public bool IsDeleted { get; set; }

    public virtual Store IdNavigation { get; set; } = null!;
}
