using App.Domain.Core.DtoModels.Models;

namespace App.Domain.Core.DataAccess;

public interface IModelRepository
{
    Task<List<ModelOutputDto>> GetAllModels(CancellationToken cancellationToken);
    Task<ModelOutputDto>? GetModelBy(int id, CancellationToken cancellationToken);
    Task CreateModel(AddModelInputDto model, CancellationToken cancellationToken);
    Task UpdateModel(EditModelInputDto model, CancellationToken cancellationToken);
    Task DeleteModel(int id, CancellationToken cancellationToken);
}