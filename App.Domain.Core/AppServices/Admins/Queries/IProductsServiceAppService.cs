using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Domain.Core.DtoModels.Products;

namespace App.Domain.Core.AppServices.Admins.Queries
{
    public interface IProductsServiceAppService
    {
        Task<int> GetProductsCount(CancellationToken cancellationToken);
    }
}
