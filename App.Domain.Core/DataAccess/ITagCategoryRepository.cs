using App.Domain.Core.DtoModels.TagCategories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.DataAccess
{
    public interface ITagCategoryRepository
    {
        Task<List<TagCategoryOutputDto>> GetAllTagCategories(CancellationToken cancellationToken);
        Task<TagCategoryOutputDto>? GetTagCategoryBy(int id, CancellationToken cancellationToken);
        Task CreateTagCategory(AddTagCategoryInputDto tagCategory, CancellationToken cancellationToken);
        Task UpdateTagCategory(EditTagCategoryInputDto tagCategory, CancellationToken cancellationToken);
        Task DeleteTagCategory(int id, CancellationToken cancellationToken);
    }
}
