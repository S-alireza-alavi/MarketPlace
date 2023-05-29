using App.Domain.Core.AppServices;
using App.Domain.Core.DataAccess;
using App.Domain.Core.DtoModels.Brands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.AppService
{
    public class BrandsService : IBrandsService
    {
        private readonly IBrandRepository _brandRepository;

        public BrandsService(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }

        public async Task DeleteBrand(int id)
        {
            await _brandRepository.DeleteBrand(id);
        }

        public async Task<List<BrandOutputDto>> GetAllBrands()
        {
            var brands = await _brandRepository.GetAllBrands();
            return brands;
        }

        public async Task<BrandOutputDto> GetBrandBy(int id)
        {
            var brand = await _brandRepository.GetBrandBy(id);
            return brand;
        }

        public async Task UpdateBrand(EditBrandInputDto brand)
        {
            await _brandRepository.UpdateBrand(brand);
        }
    }
}
