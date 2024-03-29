﻿namespace MarketPlace.Entities;

public partial class ProductPhoto
{
    public int Id { get; set; }

    public string FileName { get; set; } = null!;

    public string FilePath { get; set; } = null!;

    public int ProductId { get; set; }

    public bool IsDeleted { get; set; }

    public virtual Product Product { get; set; } = null!;
}
