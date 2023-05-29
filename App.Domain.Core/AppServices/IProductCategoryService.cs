using App.Domain.Core.DtoModels.Brands;
using App.Domain.Core.DtoModels.ProductCategories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.AppServices
{
    public interface IProductCategoryService
    {
        Task<List<ProductCategoryOutputDto>> GetAllProductCategories();
        Task<ProductCategoryOutputDto> GetProductCategoryBy(int id);
        Task UpdateProductCategory(EditProductCategoryInputDto productCategory);
        Task DeleteProductCategory(int id);
    }
}
