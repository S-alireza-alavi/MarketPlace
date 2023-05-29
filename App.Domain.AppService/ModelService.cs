using App.Domain.Core.AppServices;
using App.Domain.Core.DataAccess;
using App.Domain.Core.DtoModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.AppService
{
    public class ModelService : IModelService
    {
        private readonly IModelRepository _modelRepository;

        public ModelService(IModelRepository modelRepository)
        {
            _modelRepository = modelRepository;
        }

        public async Task DeleteModel(int id)
        {
            await _modelRepository.DeleteModel(id);
        }

        public async Task<List<ModelOutputDto>> GetAllModels()
        {
            var models = await _modelRepository.GetAllModels();
            return models;
        }

        public async Task<ModelOutputDto> GetModelBy(int id)
        {
            var model = await _modelRepository.GetModelBy(id);
            return model;
        }

        public async Task UpdateModel(EditModelInputDto model)
        {
            await _modelRepository.UpdateModel(model);
        }
    }
}
