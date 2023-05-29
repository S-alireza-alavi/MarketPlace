using App.Domain.Core.DtoModels.Models;
using App.Domain.Core.DtoModels.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.AppServices
{
    public interface IModelService
    {
        Task<List<ModelOutputDto>> GetAllModels();
        Task<ModelOutputDto> GetModelBy(int id);
        Task UpdateModel(EditModelInputDto model);
        Task DeleteModel(int id);
    }
}
