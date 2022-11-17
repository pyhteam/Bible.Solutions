using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace Bible.Service.Services.FileServices
{
    public class FileService : IFileService
    {
        private IWebHostEnvironment _environment;
        public FileService(IWebHostEnvironment environment)
        {
            _environment = environment;
        }
        public bool DeleteFile(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                return false;
            }
            var path = Path.Combine(_environment.WebRootPath, "uploads", fileName);
            if (File.Exists(path))
            {
                File.Delete(path);
                return true;
            }
            return false;
        }

        public async Task<string> UploadFileAsync(IFormFile file)
        {
            if (file == null)
            {
                return null;
            }
            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            var path = Path.Combine(_environment.WebRootPath, "uploads", fileName);
            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            return fileName;

        }
    }
}
