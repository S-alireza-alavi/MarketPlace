using App.Domain.Core.DataAccess;
using App.Domain.Core.DtoModels.Tags;
using App.Domain.Core.Entities;
using App.Infrastructures.Database.SqlServer.Data;
using Microsoft.EntityFrameworkCore;

namespace App.Infrastructures.Data.Repositories;

public class TagRepository : ITagRepository
{
    private readonly AppDbContext _context;

    public TagRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<TagOutputDto>> GetAllTags(CancellationToken cancellationToken)
    {
        var tags = await _context.Tags.Select(t => new TagOutputDto()
        {
            Id = t.Id,
            Name = t.Name,
            TagCategoryId = t.TagCategoryId,
            HasValue = t.HasValue
        }).ToListAsync(cancellationToken);

        return tags;
    }

    public async Task<TagOutputDto>? GetTagBy(int id, CancellationToken cancellationToken)
    {
        var tag = await _context.Tags.Where(t => t.Id == id).Select(t =>
            new TagOutputDto
            {
                Id = t.Id,
                Name = t.Name,
                TagCategoryId = t.TagCategoryId,
                HasValue = t.HasValue
            }).FirstAsync(cancellationToken);

        return tag;
    }

    public async Task CreateTag(AddTagInputDto tag, CancellationToken cancellationToken)
    {
        await _context.Tags.AddAsync(new Tag
        {
            Name = tag.Name,
            TagCategoryId = tag.TagCategoryId,
            HasValue = tag.HasValue
        });

        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateTag(EditTagInputDto tag, CancellationToken cancellationToken)
    {
        var tagToUpdate = await _context.Tags.Where(t => t.Id == tag.Id)
            .FirstOrDefaultAsync(cancellationToken);

        tagToUpdate.Name = tag.Name;
        tagToUpdate.TagCategoryId = tag.TagCategoryId;
        tagToUpdate.HasValue = tag.HasValue;

        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteTag(int id, CancellationToken cancellationToken)
    {
        Tag? tag = await _context.Tags.FindAsync(id);

        tag.IsDeleted = true;

        await _context.SaveChangesAsync(cancellationToken);
    }
}