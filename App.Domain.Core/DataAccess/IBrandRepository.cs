﻿using App.Domain.Core.DtoModels.Brands;

namespace App.Domain.Core.DataAccess
{
    public interface IBrandRepository
    {
        Task<List<BrandOutputDto>> GetAllBrands();
        Task<BrandOutputDto> GetBrandBy(int id);
        Task CreateBrand(AddBrandInputDto brand);
        Task UpdateBrand(EditBrandInputDto brand);
        Task DeleteBrand(int id);
    }
}
