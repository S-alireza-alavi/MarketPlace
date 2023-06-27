using App.Domain.Core.AppServices.Customers.Queries;
using App.Domain.Core.DataAccess;
using App.Domain.Core.DtoModels.ProductCategories;

namespace App.Domain.AppService.Customers.Queries
{
    public class HomeCategoriesService : IHomeCategoriesService
    {
        private readonly IProductCategoryRepository _productCategoryRepository;

        public HomeCategoriesService(IProductCategoryRepository productCategoryRepository)
        {
            _productCategoryRepository = productCategoryRepository;
        }

        public async Task<List<ProductCategoryOutputDto>> GetAllCategories(CancellationToken cancellationToken)
        {
            try
            {
                var productCategories = await _productCategoryRepository.GetAllProductCategories();

                return productCategories;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
