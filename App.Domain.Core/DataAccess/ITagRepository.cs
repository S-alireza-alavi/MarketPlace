using App.Domain.Core.DtoModels.Tags;

namespace App.Domain.Core.DataAccess;

public interface ITagRepository
{
    Task<List<TagOutputDto>> GetAllTags(CancellationToken cancellationToken);
    Task<TagOutputDto>? GetTagBy(int id, CancellationToken cancellationToken);
    Task CreateTag(AddTagInputDto tag, CancellationToken cancellationToken);
    Task UpdateTag(EditTagInputDto tag, CancellationToken cancellationToken);
    Task DeleteTag(int id, CancellationToken cancellationToken);
}