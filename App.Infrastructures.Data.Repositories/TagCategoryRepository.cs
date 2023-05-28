using App.Domain.Core.DataAccess;
using App.Domain.Core.DtoModels.TagCategories;
using App.Domain.Core.Entities;
using App.Infrastructures.Database.SqlServer.Data;
using Microsoft.EntityFrameworkCore;

namespace App.Infrastructures.Data.Repositories
{
    public class TagCategoryRepository : ITagCategoryRepository
    {
        private readonly AppDbContext _context;

        public TagCategoryRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreateTagCategory(AddTagCategoryInputDto tagCategory, CancellationToken cancellationToken)
        {
            await _context.TagCategories.AddAsync(new TagCategory
            {
                Name = tagCategory.Name
            });

            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteTagCategory(int id, CancellationToken cancellationToken)
        {
            TagCategory? tagCategory = await _context.TagCategories.FindAsync(id);

            tagCategory.IsDeleted = true;

            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<List<TagCategoryOutputDto>> GetAllTagCategories(CancellationToken cancellationToken)
        {
            var tagCategories = await _context.TagCategories.Select(tc => new TagCategoryOutputDto
            {
                Id = tc.Id,
                Name = tc.Name
            }).ToListAsync(cancellationToken);

            return tagCategories;
        }

        public async Task<TagCategoryOutputDto>? GetTagCategoryBy(int id, CancellationToken cancellationToken)
        {
            var tagCategory = await _context.TagCategories.Where(tc => tc.Id == id).Select(tc =>
                new TagCategoryOutputDto
                {
                    Id = tc.Id,
                    Name = tc.Name
                }).FirstAsync(cancellationToken);

            return tagCategory;
        }

        public async Task UpdateTagCategory(EditTagCategoryInputDto tagCategory, CancellationToken cancellationToken)
        {
            var tagCategoryToUpdate = await _context.TagCategories.Where(tc => tc.Id == tagCategory.Id)
                .FirstOrDefaultAsync(cancellationToken);

            tagCategoryToUpdate.Name = tagCategory.Name;

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}