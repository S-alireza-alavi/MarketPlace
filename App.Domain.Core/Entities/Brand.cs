namespace MarketPlace.Entities;

public partial class Brand
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public bool IsDeleted { get; set; }

    public virtual ICollection<Model> Models { get; set; } = new List<Model>();

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
