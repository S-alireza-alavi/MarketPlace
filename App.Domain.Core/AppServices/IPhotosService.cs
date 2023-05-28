using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace App.Domain.Core.AppServices
{
    public interface IPhotosService
    {
        Task<string> UploadProductCategoryImage(IFormFile file, CancellationToken cancellationToken);
    }
}
