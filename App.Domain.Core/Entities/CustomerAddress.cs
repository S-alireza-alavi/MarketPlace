namespace App.Domain.Core.Entities;

public partial class CustomerAddress
{
    public int Id { get; set; }

    public int CustomerId { get; set; }

    public string FullAddress { get; set; } = null!;

    public bool IsDeleted { get; set; }

    public virtual AspNetUser Customer { get; set; } = null!;
}
