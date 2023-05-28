namespace MarketPlace.Entities;

public partial class TagCategory
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public bool IsDeleted { get; set; }

    public virtual ICollection<Tag> Tags { get; set; } = new List<Tag>();
}
