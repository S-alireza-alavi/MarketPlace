using App.Domain.Core.DataAccess;
using App.Domain.Core.DtoModels.Models;
using MarketPlace.Database;
using MarketPlace.Entities;
using Microsoft.EntityFrameworkCore;

namespace App.Infrastructures.Data.Repositories;

public class ModelRepository : IModelRepository
{
    private readonly AppDbContext _context;

    public ModelRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<ModelOutputDto>> GetAllModels(CancellationToken cancellationToken)
    {
        var models = await _context.Models.Select(m => new ModelOutputDto
        {
            Id = m.Id,
            Name = m.Name,
            ParentModelId = m.ParentModelId,
            BrandId = m.BrandId
        }).ToListAsync(cancellationToken);

        return models;
    }

    public async Task<ModelOutputDto>? GetModelBy(int id, CancellationToken cancellationToken)
    {
        var model = await _context.Models.Where(m => m.Id == id).Select(m =>
            new ModelOutputDto
            {
                Id = m.Id,
                Name = m.Name,
                ParentModelId = m.ParentModelId,
                BrandId = m.BrandId
            }).FirstAsync(cancellationToken);

        return model;
    }

    public async Task CreateModel(AddModelInputDto model, CancellationToken cancellationToken)
    {
        await _context.Models.AddAsync(new Model
        {
            Name = model.Name,
            ParentModelId = model.ParentModelId,
            BrandId = model.BrandId
        });

        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateModel(EditModelInputDto model, CancellationToken cancellationToken)
    {
        var modelToUpdate = await _context.Models.Where(m => m.Id == model.Id)
            .FirstOrDefaultAsync(cancellationToken);

        modelToUpdate.Name = model.Name;
        modelToUpdate.ParentModelId = model.ParentModelId;
        modelToUpdate.BrandId = model.BrandId;

        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteModel(int id, CancellationToken cancellationToken)
    {
        Model? model = await _context.Models.FindAsync(id);

        model.IsDeleted = true;

        await _context.SaveChangesAsync(cancellationToken);
    }
}