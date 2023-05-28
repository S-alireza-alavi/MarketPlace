using App.Domain.Core.AppServices;
using Microsoft.AspNetCore.Http;
using System.Net.Http.Headers;

namespace App.Domain.AppService
{
    public class PhotosService : IPhotosService
    {
        public async Task<string> UploadProductCategoryImage(IFormFile file, CancellationToken cancellationToken)
        {
            string filePath;
            string fileName;

            if (file != null)
            {
                fileName = Guid.NewGuid().ToString() +
                           ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');

                filePath = Path.Combine("~/images/ProductCategory", fileName);

                try
                {
                    await using (var stream = File.Create(filePath))
                    {
                        await file.CopyToAsync(stream, cancellationToken);
                    }
                }
                catch
                {
                    throw new Exception("Upload image operation failed");
                }
            }
            else
            {
                fileName = "";
            }

            return fileName;
        }
    }
}
