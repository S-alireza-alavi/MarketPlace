using App.Domain.Core.DtoModels.ProductCategories;

namespace App.Domain.Core.DataAccess
{
    public interface IProductCategoryRepository
    {
        Task<List<ProductCategoryOutputDto>> GetAllProductCategories();
        Task<ProductCategoryOutputDto> GetProductCategoryBy(int id);
        Task CreateProductCategory(AddProductCategoryInputDto productCategory);
        Task UpdateProductCategory(EditProductCategoryInputDto productCategory);
        Task DeleteProductCategory(int id);
    }
}
