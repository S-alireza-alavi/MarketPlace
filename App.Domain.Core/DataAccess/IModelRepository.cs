using App.Domain.Core.DtoModels.Models;

namespace App.Domain.Core.DataAccess;

public interface IModelRepository
{
    Task<List<ModelOutputDto>> GetAllModels();
    Task<ModelOutputDto> GetModelBy(int id);
    Task CreateModel(AddModelInputDto model);
    Task UpdateModel(EditModelInputDto model);
    Task DeleteModel(int id);
}