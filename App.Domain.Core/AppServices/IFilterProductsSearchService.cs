using App.Domain.Core.DtoModels.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.AppServices
{
    public interface IFilterProductsSearchService
    {
        Task<List<ProductOutputDto>> FilterProductsSearch(string searchPhrase, CancellationToken cancellationToken);
    }
}
