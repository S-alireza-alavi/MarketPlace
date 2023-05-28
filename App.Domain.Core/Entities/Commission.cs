namespace App.Domain.Core.Entities;

public partial class Commission
{
    public int Id { get; set; }

    public int CommissionAmount { get; set; }

    public bool IsDeleted { get; set; }

    public virtual Order IdNavigation { get; set; } = null!;
}
