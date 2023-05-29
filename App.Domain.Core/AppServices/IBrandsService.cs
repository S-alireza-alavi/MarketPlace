using App.Domain.Core.DtoModels.Brands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.AppServices
{
    public interface IBrandsService
    {
        Task<List<BrandOutputDto>> GetAllBrands();
        Task<BrandOutputDto> GetBrandBy(int id);
        Task UpdateBrand(EditBrandInputDto brand);
        Task DeleteBrand(int id);
    }
}
