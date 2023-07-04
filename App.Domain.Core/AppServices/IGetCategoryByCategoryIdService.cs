using App.Domain.Core.DtoModels.ProductCategories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.AppServices
{
    public interface IGetCategoryByCategoryIdService
    {
        Task<ProductCategoryOutputDto> GetCategoryByCategoryId(int categoryId, CancellationToken cancellationToken);
    }
}
