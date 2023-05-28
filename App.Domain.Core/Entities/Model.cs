namespace App.Domain.Core.Entities;

public partial class Model
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int? ParentModelId { get; set; }

    public int BrandId { get; set; }

    public bool IsDeleted { get; set; }

    public virtual Brand Brand { get; set; } = null!;
}
