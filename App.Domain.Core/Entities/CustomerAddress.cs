using App.Domain.Core.Entities;

namespace MarketPlace.Entities;

public partial class CustomerAddress
{
    public int Id { get; set; }

    public int? CustomerId { get; set; }

    public string FullAddress { get; set; } = null!;

    public bool IsDeleted { get; set; }

    public virtual ApplicationUser Customer { get; set; }
}
