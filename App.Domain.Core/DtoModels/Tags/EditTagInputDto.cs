﻿namespace App.Domain.Core.DtoModels.Tags;

public class EditTagInputDto
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int TagCategoryId { get; set; }

    public bool HasValue { get; set; }
}