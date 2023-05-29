using App.Domain.Core.AppServices;
using App.Domain.Core.DataAccess;
using App.Domain.Core.DtoModels.ProductCategories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.AppService
{
    public class ProductCategoryService : IProductCategoryService
    {
        private readonly IProductCategoryRepository _productCategoryRepository;

        public ProductCategoryService(IProductCategoryRepository productCategoryRepository)
        {
            _productCategoryRepository = productCategoryRepository;
        }

        public async Task DeleteProductCategory(int id)
        {
            await _productCategoryRepository.DeleteProductCategory(id);
        }

        public async Task<List<ProductCategoryOutputDto>> GetAllProductCategories()
        {
            var productCategories = await _productCategoryRepository.GetAllProductCategories();
            return productCategories;
        }

        public async Task<ProductCategoryOutputDto> GetProductCategoryBy(int id)
        {
            var productCategory = await _productCategoryRepository.GetProductCategoryBy(id);
            return productCategory;
        }

        public async Task UpdateProductCategory(EditProductCategoryInputDto productCategory)
        {
            await _productCategoryRepository.UpdateProductCategory(productCategory);
        }
    }
}
