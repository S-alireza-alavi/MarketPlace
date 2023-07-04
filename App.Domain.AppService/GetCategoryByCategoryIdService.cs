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
    public class GetCategoryByCategoryIdService : IGetCategoryByCategoryIdService
    {
        private readonly IProductCategoryRepository _productCategoryRepository;

        public GetCategoryByCategoryIdService(IProductCategoryRepository productCategoryRepository)
        {
            _productCategoryRepository = productCategoryRepository;
        }

        public async Task<ProductCategoryOutputDto> GetCategoryByCategoryId(int categoryId, CancellationToken cancellationToken)
        {
            var category = await _productCategoryRepository.GetProductCategoryBy(categoryId);
            return category;
        }
    }
}
