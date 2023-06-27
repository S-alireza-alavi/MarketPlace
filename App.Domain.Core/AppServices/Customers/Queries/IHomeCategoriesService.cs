using App.Domain.Core.DtoModels.ProductCategories;

namespace App.Domain.Core.AppServices.Customers.Queries
{
    public interface IHomeCategoriesService
    {
        Task<List<ProductCategoryOutputDto>> GetAllCategories(CancellationToken cancellationToken);
    }
}
