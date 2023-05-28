using App.Domain.Core.DtoModels.ProductCategories;

namespace App.Domain.Core.AppServices.Customers.Queries
{
    public interface IHomeCategoryAppService
    {
        Task<List<ProductCategoryOutputDto>> GetAllCategories(CancellationToken cancellationToken);
    }
}
