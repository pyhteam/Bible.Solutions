using Microsoft.AspNetCore.Http;

namespace Bible.Service.Services.FileServices
{
    public interface IFileService
    {
        Task<string> UploadFileAsync(IFormFile file);
        bool DeleteFile(string fileName);

    }
}
