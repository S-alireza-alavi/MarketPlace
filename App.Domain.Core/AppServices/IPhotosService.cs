using Microsoft.AspNetCore.Http;

namespace App.Domain.Core.AppServices
{
    public interface IPhotosService
    {
        Task<string> UploadProductCategoryImage(IFormFile file, CancellationToken cancellationToken);
    }
}
