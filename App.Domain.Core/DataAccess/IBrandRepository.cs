using App.Domain.Core.DtoModels.Bids;
using App.Domain.Core.DtoModels.Brands;

namespace App.Domain.Core.DataAccess
{
    public interface IBrandRepository
    {
        Task<List<BrandOutputDto>> GetAllBrands(CancellationToken cancellationToken);
        Task<BrandOutputDto>? GetBrandBy(int id, CancellationToken cancellationToken);
        Task CreateBrand(AddBrandInputDto brand, CancellationToken cancellationToken);
        Task UpdateBrand(EditBrandInputDto brand, CancellationToken cancellationToken);
        Task DeleteBrand(int id, CancellationToken cancellationToken);
    }
}
